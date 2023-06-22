using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Sisgtfhka.Extensions;
using Sisgtfhka.Models;
using static Sisgtfhka.Enums.Enums;

namespace Sisgtfhka.Controllers
{
    [Authorize]
    public class WorkshopController : BaseController
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private ISession _session => _httpContextAccessor.HttpContext.Session;

        public WorkshopController(UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            RoleManager<IdentityRole> roleManager,
            Services.ClientHttpREST clientHttpREST,
            ILogger<AccountController> logger,
            IOptions<AppSettings> settings,
            IHttpContextAccessor httpContextAccessor)
            : base(userManager, signInManager, clientHttpREST, settings)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        #region GET: Rif Distributor
        [HttpPost]
        public async Task<IActionResult> FindDistributorRif(string rif)
        {
            try
            {
                string tokenValue = await this.GetTokenAccess();

                _clientHttpREST.SetToken(tokenValue);

                String repJson = await _clientHttpREST.GetObjetcsAllAsync("api-clients/Distributors");
                List<DistributorModel> listDistributor = TypeModel<DistributorModel>.DeserializeInArray(repJson);
                DistributorModel distributor = listDistributor.Where(f => f.rif == rif).FirstOrDefault();

                return Json(distributor);
            }
            catch (System.Net.Http.HttpRequestException wex)
            {
                if (wex.Message.Contains("401 (Unauthorized)"))
                {
                    var userIdentity = await _userManager.GetUserAsync(User);

                    return RedirectToAction(nameof(AccountController.LogoutForce), "Account", userIdentity);
                }
                else
                {
                    ViewBag.Message = wex.Message;

                    return View("~/Views/Shared/Error.cshtml", new ErrorViewModel { RequestId = Request.Path });
                }
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;

                return View("~/Views/Shared/Error.cshtml", new ErrorViewModel { RequestId = Request.Path });
            }

        }

        #endregion

        #region Index
        public async Task<IActionResult> Index(string sortOrder,
                                       string currentFilter,
                                       string searchString,
                                       int? pageNumber)
        {
            try
            {

                string tokenValue = await this.GetTokenAccess();

                _clientHttpREST.SetToken(tokenValue);

                string respJson = await _clientHttpREST.GetObjetcsAllAsync("api-worksorders/WorkshopOrder");

                List<WorkshopModel> listWorkshop = TypeModel<WorkshopModel>.DeserializeInArray(respJson);

                ViewData["DistributorActive"] = false;

                if (RolId == 9)
                { //Obtengo el Distribuidor en Session
                    string repJson2 = await _clientHttpREST.GetObjetcsAllAsync("api-clients/Distributors");

                    List<DistributorModel> listDistributors = TypeModel<DistributorModel>.DeserializeInArray(repJson2);

                    var distributor = listDistributors.Where(d => d.email == _userManager.GetUserName(User)).FirstOrDefault();

                    if (distributor != null)
                    {
                        //Almaceno el Id de Distribuidor en una Variable de Sesión
                        SessionExtensions.SetInt32(_session, SessionDistributorId, distributor.id);

                        listWorkshop = listWorkshop.Where(o => o.DistributorId == distributor.id).ToList();

                        if (distributor.enable == true)
                        {
                            ViewData["DistributorActive"] = true;
                        }
                    }
                }
                else if (RolId == 8)
                { //Es un Tecnico de Taller filtro solo sus Asignaciones
                    string repJson = await _clientHttpREST.GetObjetcsAllAsync("api-employees/Employees");
                    var listEmployees = TypeModel<EmployeeModel>.DeserializeInArray(repJson);
                    var employee = listEmployees.Where(e => e.email == _userManager.GetUserName(User)).FirstOrDefault();
                    listWorkshop = listWorkshop.Where(o => o.EmployeeId == employee.id).ToList();
                }

                ViewData["CurrentSort"] = sortOrder;
                ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
                ViewData["DateSortParm"] = sortOrder == "Date" ? "date_desc" : "Date";

                if (searchString != null)
                {
                    pageNumber = 1;
                }
                else
                {
                    searchString = currentFilter;
                }

                ViewData["CurrentFilter"] = searchString;

                if (!String.IsNullOrEmpty(searchString))
                {
                    listWorkshop = listWorkshop.Where(
                           a => a.Serial.IndexOf(searchString, StringComparison.OrdinalIgnoreCase) >= 0
                               || a.NumerOrder.IndexOf(searchString, StringComparison.OrdinalIgnoreCase) >= 0
                                || a.statesOrder.Description.ToString().IndexOf(searchString, StringComparison.OrdinalIgnoreCase) >= 0
                                || a.Distributor.rif.IndexOf(searchString, StringComparison.OrdinalIgnoreCase) >= 0
                                || a.Contact.IndexOf(searchString, StringComparison.OrdinalIgnoreCase) >= 0
                                || a.creation_date.ToString().IndexOf(searchString, StringComparison.OrdinalIgnoreCase) >= 0
                           ).ToList();
                }


                switch (sortOrder)
                {
                    case "name_desc":
                        listWorkshop = listWorkshop.OrderByDescending(a => Int32.Parse(a.NumerOrder)).ToList();
                        break;

                    case "Date":
                        listWorkshop = listWorkshop.OrderBy(a => Int32.Parse(a.NumerOrder)).ToList();
                        break;

                    case "date_desc":
                        listWorkshop = listWorkshop.OrderByDescending(a => Int32.Parse(a.NumerOrder)).ToList();
                        break;

                    default:
                        listWorkshop = listWorkshop.OrderBy(a => Int32.Parse(a.NumerOrder)).ToList();
                        break;

                }

                int pageSize = 8;

                ViewData["RolId"] = RolId.ToString();
                ViewData["LevelAccess"] = LevelAccess.ToString();

                return View(PaginatedList<WorkshopModel>.CreateAsync(listWorkshop.AsQueryable(), pageNumber ?? 1, pageSize));

            }
            catch (System.Net.Http.HttpRequestException wex)
            {
                if (wex.Message.Contains("401 (Unauthorized)"))
                {
                    var userIdentity = await _userManager.GetUserAsync(User);

                    return RedirectToAction(nameof(AccountController.LogoutForce), "Account", userIdentity);
                }
                else
                {
                    ViewBag.Message = wex.Message;

                    return View("~/Views/Shared/Error.cshtml", new ErrorViewModel { RequestId = Request.Path });
                }
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;

                return View("~/Views/Shared/Error.cshtml", new ErrorViewModel { RequestId = Request.Path });
            }

        }
        #endregion

        #region GET RowOrders
        public async Task<IActionResult> RowOrders(string sortOrder,
                                       string currentFilter,
                                       string searchString,
                                       int? pageNumber)
        {
            try
            {

                string tokenValue = await this.GetTokenAccess();

                _clientHttpREST.SetToken(tokenValue);

                string respJson = await _clientHttpREST.GetObjetcsAllAsync("api-worksorders/WorkshopOrder");

                List<WorkshopModel> listWorkshop = TypeModel<WorkshopModel>.DeserializeInArray(respJson);
                //Filtro solo las Ordenes Por Recibir
                listWorkshop = listWorkshop.Where(o => o.StateOrderId == 1).ToList();

                if (RolId == 9)
                { //Obtengo el Distribuidor en Session
                    string repJson2 = await _clientHttpREST.GetObjetcsAllAsync("api-clients/Distributors");

                    List<DistributorModel> listDistributors = TypeModel<DistributorModel>.DeserializeInArray(repJson2);

                    var distributor = listDistributors.Where(d => d.email == _userManager.GetUserName(User)).FirstOrDefault();

                    if (distributor != null)
                    {
                        //Almaceno el Id de Distribuidor en una Variable de Sesión
                        SessionExtensions.SetInt32(_session, SessionDistributorId, distributor.id);

                        listWorkshop = listWorkshop.Where(o => o.DistributorId == distributor.id).ToList();
                    }
                }

                ViewData["CurrentSort"] = sortOrder;
                ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
                ViewData["DateSortParm"] = sortOrder == "Date" ? "date_desc" : "Date";

                if (searchString != null)
                {
                    pageNumber = 1;
                }
                else
                {
                    searchString = currentFilter;
                }

                ViewData["CurrentFilter"] = searchString;

                if (!String.IsNullOrEmpty(searchString))
                {
                    listWorkshop = listWorkshop.Where(
                           a => a.Serial.IndexOf(searchString, StringComparison.OrdinalIgnoreCase) >= 0
                               || a.NumerOrder.IndexOf(searchString, StringComparison.OrdinalIgnoreCase) >= 0
                                || a.statesOrder.Description.ToString().IndexOf(searchString, StringComparison.OrdinalIgnoreCase) >= 0
                                || a.Distributor.rif.IndexOf(searchString, StringComparison.OrdinalIgnoreCase) >= 0
                                || a.Contact.IndexOf(searchString, StringComparison.OrdinalIgnoreCase) >= 0
                                || a.creation_date.ToString().IndexOf(searchString, StringComparison.OrdinalIgnoreCase) >= 0
                           ).ToList();
                }

                switch (sortOrder)
                {
                    case "name_desc":
                        listWorkshop = listWorkshop.OrderByDescending(a => a.Serial).ToList();
                        break;

                    case "Date":
                        listWorkshop = listWorkshop.OrderBy(a => a.Serial).ToList();
                        break;

                    case "date_desc":
                        listWorkshop = listWorkshop.OrderByDescending(a => a.Serial).ToList();
                        break;

                    default:
                        listWorkshop = listWorkshop.OrderBy(a => a.Serial).ToList();
                        break;
                }
                int pageSize = 8;

                ViewData["RolId"] = RolId.ToString();
                ViewData["LevelAccess"] = LevelAccess.ToString();

                return View(PaginatedList<WorkshopModel>.CreateAsync(listWorkshop.AsQueryable(), pageNumber ?? 1, pageSize));
            }
            catch (System.Net.Http.HttpRequestException wex)
            {
                if (wex.Message.Contains("401 (Unauthorized)"))
                {
                    var userIdentity = await _userManager.GetUserAsync(User);

                    return RedirectToAction(nameof(AccountController.LogoutForce), "Account", userIdentity);
                }
                else
                {
                    ViewBag.Message = wex.Message;

                    return View("~/Views/Shared/Error.cshtml", new ErrorViewModel { RequestId = Request.Path });
                }
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;

                return View("~/Views/Shared/Error.cshtml", new ErrorViewModel { RequestId = Request.Path });
            }
        }
        #endregion

        #region POST ConfmAsigOrder
        [HttpPost]
        public async Task<IActionResult> ConfmAsigOrder(int id, int stateOrder, int employeeId, string observations)
        {
            try
            {

                string tokenValue = await this.GetTokenAccess();

                _clientHttpREST.SetToken(tokenValue);

                string repJson = await _clientHttpREST.GetObjetcAsync("api-worksorders/WorkshopOrder", id.ToString());
                WorkshopModel workshop2 = TypeModel<WorkshopModel>.DeserializeInObject(repJson);

                workshop2.StateOrderId = stateOrder;
                workshop2.EmployeeId = employeeId;


                String json2 = @"{   
                                    'id': " + workshop2.Id + @",
                                    'numerOrder': '" + workshop2.NumerOrder + @"',
                                    'kindEquipment': " + workshop2.KindEquipment + @",
                                    'equipment': " + workshop2.Equipment + @",
                                    'serial': '" + workshop2.Serial + @"',
                                    'warrantyId': " + workshop2.WarrantyId + @",
                                    'firmwareVersion': '" + workshop2.FirmwareVersion + @"',
                                    'deliverDate': '" + workshop2.DeliverDate.ToString("yyyy-MM-dd HH:mm:ss") + @"',
                                    'receptionDate': '" + workshop2.ReceptionDate.ToString("yyyy-MM-dd HH:mm:ss") + @"',
                                    'alienationDate': '" + workshop2.AlienationDate.ToString("yyyy-MM-dd HH:mm:ss") + @"',
                                    'expirationDate': '" + workshop2.ExpirationDate.ToString("yyyy-MM-dd HH:mm:ss") + @"',
                                    'address': '" + workshop2.Address + @"',
                                    'contact': '" + workshop2.Contact + @"',
                                    'insertionOrigin': " + workshop2.InsertionOrigin + @",
                                    'workDone': '" + workshop2.WorkDone + @"',
                                    'customerReview': '" + workshop2.CustomerReview + @"',
                                    'observationTechnical': '" + workshop2.ObservationTechnical + @"',
                                    'extraObservation': '" + workshop2.ExtraObservation + @"',
                                    'creation_date': '" + workshop2.creation_date.ToString("yyyy-MM-dd HH:mm:ss") + @"',
                                    'phone': '" + workshop2.Phone + @"',
                                    'distributorId': " + workshop2.DistributorId + @",                              
                                    'typeFailurId': " + workshop2.TypeFailurId + @",                               
                                    'stateOrderId': " + workshop2.StateOrderId + @",                            
                                    'deliveryOrderId': " + workshop2.DeliveryOrderId + @",                             
                                    'employeeId': " + workshop2.EmployeeId + @"
                                }";

                String response = await _clientHttpREST.PutObjetcAsync("api-worksorders/WorkshopOrder", id.ToString(), json2);

                if (response.Equals("OK") || response.Equals("NoContent"))
                {
                    //Agrego el cambio de estado a la bítacora 

                    var binnacle = new WorkshopBinnacleModel();
                    binnacle.Id = 0;
                    binnacle.OrderId = workshop2.Id;
                    binnacle.StatusId = workshop2.StateOrderId;
                    binnacle.UserId = employeeId;
                    binnacle.Observation = observations;

                    string json1 = JsonConvert.SerializeObject(binnacle);
                    string response1 = await _clientHttpREST.PostObjetcAsync("api-worksorders/WorkshopBinnacle", json1);
                    if (response1.Equals("Created"))
                    {
                        return Ok(true);
                    }
                    else
                    {
                        return Ok(false);
                    }
                }
                else
                {
                    return Ok(false);
                }
                //return Ok(true);
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
                return View("~/Views/Shared/Error.cshtml", new ErrorViewModel { RequestId = Request.Path });
            }
        }
        #endregion

        #region POST ConfmAsigOrder
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> ConfmAsigOrder(int id, WorkshopModel workshop)
        //{
        //  try
        //  {
        //    var errors = ModelState.Values.SelectMany(v => v.Errors);

        //    string tokenValue = await this.GetTokenAccess();

        //    _clientHttpREST.SetToken(tokenValue);

        //    string repJson = await _clientHttpREST.GetObjetcAsync("api-worksorders/WorkshopOrder", id.ToString());
        //    WorkshopModel workshop2 = TypeModel<WorkshopModel>.DeserializeInObject(repJson);

        //    workshop2.ExtraObservation = workshop.ExtraObservation;
        //    workshop2.EmployeeId = workshop.EmployeeId;
        //    workshop2.StateOrderId = 3;

        //    //String json2 = JsonConvert.SerializeObject(workshop2);
        //    String json2 = @"{   
        //                            'id': " + workshop2.Id + @",
        //                            'numerOrder': '" + workshop2.NumerOrder + @"',
        //                            'kindEquipment': " + workshop2.KindEquipment + @",
        //                            'equipment': " + workshop2.Equipment + @",
        //                            'serial': '" + workshop2.Serial + @"',
        //                            'warrantyId': " + 0 + @",
        //                            'firmwareVersion': '" + workshop2.FirmwareVersion + @"',
        //                            'deliverDate': '" + workshop2.DeliverDate.ToString("yyyy-MM-dd HH:mm:ss") + @"',
        //                            'receptionDate': '" + workshop2.ReceptionDate.ToString("yyyy-MM-dd HH:mm:ss") + @"',
        //                            'alienationDate': '" + workshop2.AlienationDate.ToString("yyyy-MM-dd HH:mm:ss") + @"',
        //                            'expirationDate': '" + workshop2.ExpirationDate.ToString("yyyy-MM-dd HH:mm:ss") + @"',
        //                            'address': '" + workshop2.Address + @"',
        //                            'contact': '" + workshop2.Contact + @"',
        //                            'insertionOrigin': " + workshop2.InsertionOrigin + @",
        //                            'workDone': '" + workshop2.WorkDone + @"',
        //                            'customerReview': '" + workshop2.CustomerReview + @"',
        //                            'observationTechnical': '" + workshop2.ObservationTechnical + @"',
        //                            'extraObservation': '" + workshop2.ExtraObservation + @"',
        //                            'creation_date': '" + workshop2.creation_date.ToString("yyyy-MM-dd HH:mm:ss") + @"',
        //                            'phone': '" + workshop2.Phone + @"',
        //                            'distributorId': " + workshop2.DistributorId + @",                              
        //                            'typeFailurId': " + workshop2.TypeFailurId + @",                               
        //                            'stateOrderId': " + workshop2.StateOrderId + @",                            
        //                            'deliveryOrderId': " + workshop2.DeliveryOrderId + @",                             
        //                            'employeeId': " + workshop2.EmployeeId + @"
        //                        }";
        //    String respcomplet = await _clientHttpREST.PutObjetcContentAndCodeAsync("api-worksorders/WorkshopOrder", id.ToString(), json2);
        //    string[] resparray = respcomplet.Split('|');
        //    String response2 = resparray[0];

        //    if (response2.Equals("NoContent"))
        //    {
        //      //Agrego fila la Bitacora de esa Orden Nueva  
        //      string repJson1 = await _clientHttpREST.GetObjetcsAllAsync("api-employees/Employees");
        //      List<EmployeeModel> listEmployees = TypeModel<EmployeeModel>.DeserializeInArray(repJson1);

        //      var employ = listEmployees.Where(d => d.email == _userManager.GetUserName(User)).FirstOrDefault();

        //      string repJson3 = await _clientHttpREST.GetObjetcsAllAsync("api-worksorders/WorkshopBinnacle/ByOrderId/" + id.ToString());
        //      List<WorkshopBinnacleModel> listBinnacle = TypeModel<WorkshopBinnacleModel>.DeserializeInArray(repJson3);

        //      var binnacle = listBinnacle.Where(b => b.OrderId == workshop2.Id && b.StatusId == workshop2.StateOrderId && b.UserId == employ.id).FirstOrDefault();
        //      string observation = workshop2.ExtraObservation;

        //      bool isPut = false;
        //      if (binnacle == null)
        //      {
        //        binnacle = new WorkshopBinnacleModel();
        //        binnacle.Id = 0;
        //        binnacle.OrderId = workshop2.Id;
        //        binnacle.StatusId = workshop2.StateOrderId;
        //        binnacle.UserId = employ.id;
        //      }
        //      else
        //      {
        //        isPut = true;
        //        binnacle.UserId = employ.id;
        //      }

        //      binnacle.Observation = observation;

        //      String json1 = @"{
        //                                                  'Id': " + binnacle.Id + @",
        //                                                  'orderId': " + binnacle.OrderId + @",    
        //                                                  'statusId': " + binnacle.StatusId + @",
        //                                                  'userId': " + binnacle.UserId + @",
        //                                                  'observation':'" + binnacle.Observation + @"'
        //                                               }";

        //      if (!isPut)
        //      {
        //        String response1 = await _clientHttpREST.PostObjetcAsync("api-worksorders/WorkshopBinnacle", json1);
        //      }
        //      else
        //      {
        //        String response1 = await _clientHttpREST.PutObjetcAsync("api-worksorders/WorkshopBinnacle", binnacle.Id.ToString(), json1);
        //      }
        //      Alert("Operación Exitosa", NotificationType.success);

        //      return RedirectToAction("AssignOrders");
        //    }
        //    else
        //    {
        //      string json = resparray[1];
        //      var responseObj = TypeModel<ResponceCode>.DeserializeInObject(json);

        //      Alert(responseObj.message, NotificationType.error);

        //      ViewBag.Message = "Error en la Operación";

        //      return View("~/Views/Shared/Error.cshtml", new ErrorViewModel { RequestId = Request.Path });
        //    }
        //  }
        //  catch (Exception ex)
        //  {
        //    ViewBag.Message = ex.Message;

        //    return View("~/Views/Shared/Error.cshtml", new ErrorViewModel { RequestId = Request.Path });
        //  }
        //}
        #endregion

        #region GET StartOrder
        public async Task<IActionResult> StartOrder(int id)
        {
            try
            {
                string tokenValue = await this.GetTokenAccess();

                _clientHttpREST.SetToken(tokenValue);

                string repJson = await _clientHttpREST.GetObjetcAsync("api-worksorders/WorkshopOrder", id.ToString());
                WorkshopModel workshop = TypeModel<WorkshopModel>.DeserializeInObject(repJson);

                if (workshop.KindEquipment == 1)
                {
                    String repJson2 = await _clientHttpREST.GetObjetcsAllAsync("api-operations/SerialsProducts");

                    List<SerialProductModel> spList = TypeModel<SerialProductModel>.DeserializeInArray(repJson2);
                    var rc = spList.Where(y => y.Serial.ToUpper().Trim() == workshop.Serial.ToUpper().Trim()).FirstOrDefault();

                    String repJson3 = await _clientHttpREST.GetObjetcsAllAsync("api-products/Products");
                    List<ProductModel> pList = TypeModel<ProductModel>.DeserializeInArray(repJson3);
                    var rc3 = pList.Where(y => y.Id == rc.ProductId).FirstOrDefault();

                    workshop.Mark = rc3.Model.Mark.name;
                    workshop.Model = rc3.Model.name;
                    workshop.Product = rc.Product.Name;
                }
                if (workshop.KindEquipment == 2)
                {
                    String repJson2 = await _clientHttpREST.GetObjetcsAllAsync("api-operations/SerialsReplacements");

                    List<SerialReplacementModel> spList = TypeModel<SerialReplacementModel>.DeserializeInArray(repJson2);
                    var rc = spList.Where(y => y.Serial.ToUpper().Trim() == workshop.Serial.ToUpper().Trim()).FirstOrDefault();

                    String repJson3 = await _clientHttpREST.GetObjetcsAllAsync("api-products/Replacements");
                    List<ReplacementModel> rList = TypeModel<ReplacementModel>.DeserializeInArray(repJson3);
                    int replacementId = 0;
                    if (rc != null)
                    {
                        replacementId = rc.ReplacementId;
                    }
                    else
                    {
                        replacementId = workshop.Equipment;
                    }

                    var rc3 = rList.Where(y => y.id == replacementId).FirstOrDefault();

                    if (rc3 != null)
                    {
                        workshop.Mark = rc3.Model.Mark.name;
                        workshop.Model = rc3.Model.name;
                        workshop.Product = rc3.name;
                    }
                }
                if (workshop.KindEquipment == 3)
                {
                    String repJson6 = await _clientHttpREST.GetObjetcsAllAsync("api-products/Products");
                    var pList1 = TypeModel<ProductModel>.DeserializeInArray(repJson6);
                    var product = pList1.Where(p => p.Id == workshop.Equipment).FirstOrDefault();
                    workshop.Mark = product.Model.Mark.name;
                    workshop.Model = product.Model.name;
                    workshop.Product = product.Name;
                }

                workshop.ExtraObservation = "";
                workshop.StateOrderId = 2;

                return View(workshop);
            }
            catch (System.Net.Http.HttpRequestException wex)
            {
                if (wex.Message.Contains("401 (Unauthorized)"))
                {
                    var userIdentity = await _userManager.GetUserAsync(User);

                    return RedirectToAction(nameof(AccountController.LogoutForce), "Account", userIdentity);
                }
                else
                {
                    ViewBag.Message = wex.Message;

                    return View("~/Views/Shared/Error.cshtml", new ErrorViewModel { RequestId = Request.Path });
                }

            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;

                return View("~/Views/Shared/Error.cshtml", new ErrorViewModel { RequestId = Request.Path });
            }
        }
        #endregion

        #region POST StartOrder
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> StartOrder(int id, WorkshopModel workshop)
        {
            try
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors);

                string tokenValue = await this.GetTokenAccess();

                _clientHttpREST.SetToken(tokenValue);

                string repJson = await _clientHttpREST.GetObjetcAsync("api-worksorders/WorkshopOrder", id.ToString());
                WorkshopModel workshop2 = TypeModel<WorkshopModel>.DeserializeInObject(repJson);

                workshop2.ExtraObservation = workshop.ExtraObservation;
                workshop2.StateOrderId = workshop.StateOrderId;

                //String json2 = JsonConvert.SerializeObject(workshop2);
                String json2 = @"{   
                                'id': " + workshop2.Id + @",
                                'numerOrder': '" + workshop2.NumerOrder + @"',
                                'kindEquipment': " + workshop2.KindEquipment + @",
                                'equipment': " + workshop2.Equipment + @",
                                'serial': '" + workshop2.Serial + @"',
                                'warrantyId': " + workshop2.WarrantyId + @",
                                'firmwareVersion': '" + workshop2.FirmwareVersion + @"',
                                'deliverDate': '" + workshop2.DeliverDate.ToString("yyyy-MM-dd HH:mm:ss") + @"',
                                'receptionDate': '" + workshop2.ReceptionDate.ToString("yyyy-MM-dd HH:mm:ss") + @"',
                                'alienationDate': '" + workshop2.AlienationDate.ToString("yyyy-MM-dd HH:mm:ss") + @"',
                                'expirationDate': '" + workshop2.ExpirationDate.ToString("yyyy-MM-dd HH:mm:ss") + @"',
                                'address': '" + workshop2.Address + @"',
                                'contact': '" + workshop2.Contact + @"',
                                'insertionOrigin': " + workshop2.InsertionOrigin + @",
                                'workDone': '" + workshop2.WorkDone + @"',
                                'customerReview': '" + workshop2.CustomerReview + @"',
                                'observationTechnical': '" + workshop2.ObservationTechnical + @"',
                                'extraObservation': '" + workshop2.ExtraObservation + @"',
                                'creation_date': '" + workshop2.creation_date.ToString("yyyy-MM-dd HH:mm:ss") + @"',
                                'phone': '" + workshop2.Phone + @"',
                                'distributorId': " + workshop2.DistributorId + @",                              
                                'typeFailurId': " + workshop2.TypeFailurId + @",                               
                                'stateOrderId': " + workshop2.StateOrderId + @",                            
                                'deliveryOrderId': " + workshop2.DeliveryOrderId + @",                             
                                'employeeId': " + workshop2.EmployeeId + @"
                            }";
                String respcomplet = await _clientHttpREST.PutObjetcContentAndCodeAsync("api-worksorders/WorkshopOrder", id.ToString(), json2);
                string[] resparray = respcomplet.Split('|');
                String response2 = resparray[0];

                if (response2.Equals("NoContent"))
                {
                    //Agrego fila la Bitacora de esa Orden Nueva  
                    string repJson1 = await _clientHttpREST.GetObjetcsAllAsync("api-employees/Employees");
                    List<EmployeeModel> listEmployees = TypeModel<EmployeeModel>.DeserializeInArray(repJson1);

                    var employ = listEmployees.Where(d => d.email == _userManager.GetUserName(User)).FirstOrDefault();

                    string repJson3 = await _clientHttpREST.GetObjetcsAllAsync("api-worksorders/WorkshopBinnacle/ByOrderId/" + id.ToString());
                    List<WorkshopBinnacleModel> listBinnacle = TypeModel<WorkshopBinnacleModel>.DeserializeInArray(repJson3);

                    var binnacle = listBinnacle.Where(b => b.OrderId == workshop2.Id && b.StatusId == workshop2.StateOrderId && b.UserId == employ.id).FirstOrDefault();
                    string observation = workshop2.ExtraObservation;

                    bool isPut = false;
                    if (binnacle == null)
                    {
                        binnacle = new WorkshopBinnacleModel();
                        binnacle.Id = 0;
                        binnacle.OrderId = workshop2.Id;
                        binnacle.StatusId = workshop2.StateOrderId;
                        binnacle.UserId = employ.id;
                    }
                    else
                    {
                        isPut = true;
                        binnacle.UserId = employ.id;
                    }

                    binnacle.Observation = observation;

                    String json1 = @"{
                                                      'Id': " + binnacle.Id + @",
                                                      'orderId': " + binnacle.OrderId + @",    
                                                      'statusId': " + binnacle.StatusId + @",
                                                      'userId': " + binnacle.UserId + @",
                                                      'observation':'" + binnacle.Observation + @"'
                                                   }";

                    if (!isPut)
                    {
                        String response1 = await _clientHttpREST.PostObjetcAsync("api-worksorders/WorkshopBinnacle", json1);
                    }
                    else
                    {
                        String response1 = await _clientHttpREST.PutObjetcAsync("api-worksorders/WorkshopBinnacle", binnacle.Id.ToString(), json1);
                    }
                    Alert("Operación Exitosa", NotificationType.success);

                    return RedirectToAction("RowOrders");
                }
                else
                {
                    string json = resparray[1];
                    var responseObj = TypeModel<ResponceCode>.DeserializeInObject(json);

                    Alert(responseObj.message, NotificationType.error);

                    ViewBag.Message = "Error en la Operación";

                    return View("~/Views/Shared/Error.cshtml", new ErrorViewModel { RequestId = Request.Path });
                }
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;

                return View("~/Views/Shared/Error.cshtml", new ErrorViewModel { RequestId = Request.Path });
            }
        }
        #endregion

        #region Cancel
        public async Task<IActionResult> Cancel(int id)
        {
            try
            {
                string tokenValue = await this.GetTokenAccess();

                _clientHttpREST.SetToken(tokenValue);

                string repJson = await _clientHttpREST.GetObjetcAsync("api-worksorders/WorkshopOrder", id.ToString());
                WorkshopModel workshop = TypeModel<WorkshopModel>.DeserializeInObject(repJson);

                if (workshop.KindEquipment == 1)
                {
                    String repJson2 = await _clientHttpREST.GetObjetcsAllAsync("api-operations/SerialsProducts");

                    List<SerialProductModel> spList = TypeModel<SerialProductModel>.DeserializeInArray(repJson2);
                    var rc = spList.Where(y => y.Serial.ToUpper().Trim() == workshop.Serial.ToUpper().Trim()).FirstOrDefault();

                    String repJson3 = await _clientHttpREST.GetObjetcsAllAsync("api-products/Products");
                    List<ProductModel> pList = TypeModel<ProductModel>.DeserializeInArray(repJson3);
                    var rc3 = pList.Where(y => y.Id == rc.ProductId).FirstOrDefault();

                    workshop.Mark = rc3.Model.Mark.name;
                    workshop.Model = rc3.Model.name;
                    workshop.Product = rc.Product.Name;
                }
                if (workshop.KindEquipment == 2)
                {
                    String repJson2 = await _clientHttpREST.GetObjetcsAllAsync("api-operations/SerialsReplacements");

                    List<SerialReplacementModel> spList = TypeModel<SerialReplacementModel>.DeserializeInArray(repJson2);
                    var rc = spList.Where(y => y.Serial.ToUpper().Trim() == workshop.Serial.ToUpper().Trim()).FirstOrDefault();

                    String repJson3 = await _clientHttpREST.GetObjetcsAllAsync("api-products/Replacements");
                    List<ReplacementModel> rList = TypeModel<ReplacementModel>.DeserializeInArray(repJson3);
                    int replacementId = 0;
                    if (rc != null)
                    {
                        replacementId = rc.ReplacementId;
                    }
                    else
                    {
                        replacementId = workshop.Equipment;
                    }

                    var rc3 = rList.Where(y => y.id == replacementId).FirstOrDefault();

                    if (rc3 != null)
                    {
                        workshop.Mark = rc3.Model.Mark.name;
                        workshop.Model = rc3.Model.name;
                        workshop.Product = rc3.name;
                    }
                }
                if (workshop.KindEquipment == 3)
                {
                    String repJson6 = await _clientHttpREST.GetObjetcsAllAsync("api-products/Products");
                    var pList1 = TypeModel<ProductModel>.DeserializeInArray(repJson6);
                    var product = pList1.Where(p => p.Id == workshop.Equipment).FirstOrDefault();
                    workshop.Mark = product.Model.Mark.name;
                    workshop.Model = product.Model.name;
                    workshop.Product = product.Name;
                }

                string repJson4 = await _clientHttpREST.GetObjetcAsync("api-worksorders/PhotographOrder/ByOrderId", id.ToString());
                workshop.lstPhoto = TypeModel<PhotographOrderModel>.DeserializeInArray(repJson4);

                string repJson5 = await _clientHttpREST.GetObjetcAsync("api-worksorders/AccessoryOrder/ByOrderId", id.ToString());
                workshop.lstAccesories = TypeModel<AccesoryOrderModel>.DeserializeInArray(repJson5);

                workshop.ExtraObservation = "";
                workshop.StateOrderId = 12;

                return View(workshop);
            }
            catch (System.Net.Http.HttpRequestException wex)
            {
                if (wex.Message.Contains("401 (Unauthorized)"))
                {
                    var userIdentity = await _userManager.GetUserAsync(User);

                    return RedirectToAction(nameof(AccountController.LogoutForce), "Account", userIdentity);
                }
                else
                {
                    ViewBag.Message = wex.Message;

                    return View("~/Views/Shared/Error.cshtml", new ErrorViewModel { RequestId = Request.Path });
                }

            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;

                return View("~/Views/Shared/Error.cshtml", new ErrorViewModel { RequestId = Request.Path });
            }
        }
        #endregion

        #region POST: Cancel
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Cancel(int id, WorkshopModel workshop)
        {
            try
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors);

                string tokenValue = await this.GetTokenAccess();

                _clientHttpREST.SetToken(tokenValue);

                var nameUser = _userManager.GetUserName(User);
                String json = @"{   'username':'" + nameUser + @"',
                                                'password':'" + workshop.Verificador + @"'
                                        }";

                String response1 = await _clientHttpREST.PostObjetcContentAsync("api-access/Login", json);
                TokenStruct tokenObj = TypeModel<TokenStruct>.DeserializeInObject(response1);

                if (tokenObj == null)
                {
                    return View(workshop);
                }

                if (tokenObj.authenticated)
                {
                    string repJson = await _clientHttpREST.GetObjetcAsync("api-worksorders/WorkshopOrder", id.ToString());
                    WorkshopModel workshop2 = TypeModel<WorkshopModel>.DeserializeInObject(repJson);

                    workshop2.ExtraObservation = workshop.ExtraObservation;
                    workshop2.StateOrderId = workshop.StateOrderId;

                    WorkshopModel w = new WorkshopModel();
                    w.Id = workshop2.Id;
                    w.NumerOrder = workshop2.NumerOrder;
                    w.KindEquipment = workshop2.KindEquipment;
                    w.Equipment = workshop2.Equipment;
                    w.Serial = workshop2.Serial;
                    w.WarrantyId = workshop2.WarrantyId;
                    w.FirmwareVersion = workshop2.FirmwareVersion;
                    w.DeliverDate = workshop2.DeliverDate;
                    w.ReceptionDate = workshop2.ReceptionDate;
                    w.AlienationDate = workshop2.AlienationDate;
                    w.ExpirationDate = workshop2.ExpirationDate;
                    w.Address = workshop2.Address;
                    w.Contact = workshop2.Contact;
                    w.InsertionOrigin = workshop2.InsertionOrigin;
                    w.WorkDone = workshop2.WorkDone;
                    w.CustomerReview = workshop2.CustomerReview;
                    w.ObservationTechnical = workshop2.ObservationTechnical;
                    w.creation_date = workshop2.creation_date;
                    w.Phone = workshop2.Phone;
                    w.DistributorId = workshop2.DistributorId;
                    w.TypeFailurId = workshop2.TypeFailurId;
                    w.StateOrderId = workshop2.StateOrderId;
                    w.DeliveryOrderId = workshop2.DeliveryOrderId;
                    w.EmployeeId = workshop2.EmployeeId; //Isleye
                    w.ExtraObservation = workshop2.ExtraObservation;

                    String json2 = JsonConvert.SerializeObject(w);
                    String respcontent = await _clientHttpREST.PutObjetcContentAndCodeAsync("api-worksorders/WorkshopOrder", id.ToString(), json2);
                    string[] resparray = respcontent.Split('|');
                    String response2 = resparray[0];

                    if (response2.Equals("NoContent"))
                    {

                        if (RolId != 9)
                        {

                            //Agrego fila la Bitacora de esa Orden Nueva  
                            string repJson1 = await _clientHttpREST.GetObjetcsAllAsync("api-employees/Employees");
                            List<EmployeeModel> listEmployees = TypeModel<EmployeeModel>.DeserializeInArray(repJson1);

                            var employ = listEmployees.Where(d => d.email == _userManager.GetUserName(User)).FirstOrDefault();

                            string repJson3 = await _clientHttpREST.GetObjetcsAllAsync("api-worksorders/WorkshopBinnacle/ByOrderId/" + id.ToString());
                            List<WorkshopBinnacleModel> listBinnacle = TypeModel<WorkshopBinnacleModel>.DeserializeInArray(repJson3);

                            var binnacle = listBinnacle.Where(b => b.OrderId == workshop2.Id && b.StatusId == workshop2.StateOrderId && b.UserId == employ.id).FirstOrDefault();
                            string observation = workshop.ExtraObservation;

                            bool isPut = false;
                            if (binnacle == null)
                            {
                                binnacle = new WorkshopBinnacleModel();
                                binnacle.Id = 0;
                                binnacle.OrderId = workshop2.Id;
                                binnacle.StatusId = workshop2.StateOrderId;
                                binnacle.UserId = employ.id;
                            }
                            else
                            {
                                isPut = true;
                                binnacle.UserId = employ.id;
                            }
                            binnacle.Observation = observation;

                            String json1 = @"{
                                                                      'Id': " + binnacle.Id + @",
                                                                      'orderId': " + binnacle.OrderId + @",    
                                                                      'statusId': " + binnacle.StatusId + @",
                                                                      'userId': " + binnacle.UserId + @",
                                                                      'observation':'" + binnacle.Observation + @"'
                                                                   }";

                            if (!isPut)
                            {
                                String response10 = await _clientHttpREST.PostObjetcAsync("api-worksorders/WorkshopBinnacle", json1);
                            }
                            else
                            {
                                String response10 = await _clientHttpREST.PutObjetcAsync("api-worksorders/WorkshopBinnacle", binnacle.Id.ToString(), json1);
                            }


                        }



                        Alert("Operación Exitosa", NotificationType.success);

                        return RedirectToAction("Index");
                    }
                    else
                    {
                        string json3 = resparray[1];
                        var responseObj = TypeModel<ResponceCode>.DeserializeInObject(json3);

                        Alert(responseObj.message, NotificationType.error);

                        ViewBag.Message = "Error en la Operación";

                        return View("~/Views/Shared/Error.cshtml", new ErrorViewModel { RequestId = Request.Path });
                    }
                }
                else
                {
                    ViewBag.Message = "Clave Errada";

                    string repJson = await _clientHttpREST.GetObjetcAsync("api-worksorders/WorkshopOrder", id.ToString());
                    WorkshopModel workshop2 = TypeModel<WorkshopModel>.DeserializeInObject(repJson);

                    if (workshop2.KindEquipment == 1)
                    {
                        String repJson2 = await _clientHttpREST.GetObjetcsAllAsync("api-operations/SerialsProducts");

                        List<SerialProductModel> spList = TypeModel<SerialProductModel>.DeserializeInArray(repJson2);
                        var rc = spList.Where(y => y.Serial.ToUpper().Trim() == workshop2.Serial.ToUpper().Trim()).FirstOrDefault();

                        String repJson3 = await _clientHttpREST.GetObjetcsAllAsync("api-products/Products");
                        List<ProductModel> pList = TypeModel<ProductModel>.DeserializeInArray(repJson3);
                        var rc3 = pList.Where(y => y.Id == rc.ProductId).FirstOrDefault();

                        workshop2.Mark = rc3.Model.Mark.name;
                        workshop2.Model = rc3.Model.name;
                        workshop2.Product = rc.Product.Name;
                    }
                    if (workshop.KindEquipment == 2)
                    {
                        String repJson2 = await _clientHttpREST.GetObjetcsAllAsync("api-operations/SerialsReplacements");

                        List<SerialReplacementModel> spList = TypeModel<SerialReplacementModel>.DeserializeInArray(repJson2);
                        var rc = spList.Where(y => y.Serial.ToUpper().Trim() == workshop2.Serial.ToUpper().Trim()).FirstOrDefault();

                        String repJson3 = await _clientHttpREST.GetObjetcsAllAsync("api-products/Replacements");
                        List<ReplacementModel> rList = TypeModel<ReplacementModel>.DeserializeInArray(repJson3);
                        var rc3 = rList.Where(y => y.id == rc.ReplacementId).FirstOrDefault();

                        workshop2.Mark = rc3.Model.Mark.name;
                        workshop2.Model = rc3.Model.name;
                        workshop2.Product = rc.Replacement.name;
                    }

                    string repJson4 = await _clientHttpREST.GetObjetcAsync("api-worksorders/PhotographOrder/ByOrderId", id.ToString());
                    workshop2.lstPhoto = TypeModel<PhotographOrderModel>.DeserializeInArray(repJson4);

                    string repJson5 = await _clientHttpREST.GetObjetcAsync("api-worksorders/AccessoryOrder/ByOrderId", id.ToString());
                    workshop2.lstAccesories = TypeModel<AccesoryOrderModel>.DeserializeInArray(repJson5);

                    workshop2.ExtraObservation = workshop.ExtraObservation;
                    workshop2.StateOrderId = 12;

                    return View(workshop2);
                }
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;

                return View("~/Views/Shared/Error.cshtml", new ErrorViewModel { RequestId = Request.Path });
            }
        }
        #endregion

        #region GET: WorkshopBinnacle of one Order
        public async Task<IActionResult> Binnacle(string sortOrder, int id)
        {
            try
            {
                string tokenValue = await this.GetTokenAccess();

                _clientHttpREST.SetToken(tokenValue);

                string repJson = await _clientHttpREST.GetObjetcsAllAsync("api-worksorders/WorkshopBinnacle/ByOrderId/" + id.ToString());

                List<WorkshopBinnacleModel> listBinnacle = TypeModel<WorkshopBinnacleModel>.DeserializeInArray(repJson);

                ViewData["CurrentSort"] = sortOrder;
                ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
                ViewData["DateSortParm"] = sortOrder == "Date" ? "date_desc" : "Date";

                ViewData["CurrentId"] = id;

                switch (sortOrder)
                {
                    case "name_desc":
                        listBinnacle = listBinnacle.OrderByDescending(p => p.Order.NumerOrder).ToList();
                        break;
                    case "Date":
                        listBinnacle = listBinnacle.OrderBy(p => p.Order.NumerOrder).ToList();
                        break;
                    case "date_desc":
                        listBinnacle = listBinnacle.OrderByDescending(p => p.Order.NumerOrder).ToList();
                        break;
                    default:
                        listBinnacle = listBinnacle.OrderBy(p => p.Order.StateOrderId).ToList();
                        break;
                }

                ViewData["RolId"] = RolId.ToString();
                ViewData["LevelAccess"] = LevelAccess.ToString();

                return View(listBinnacle);
            }
            catch (System.Net.Http.HttpRequestException wex)
            {
                if (wex.Message.Contains("401 (Unauthorized)"))
                {
                    var userIdentity = await _userManager.GetUserAsync(User);

                    return RedirectToAction(nameof(AccountController.LogoutForce), "Account", userIdentity);
                }
                else
                {
                    ViewBag.Message = wex.Message;

                    return View("~/Views/Shared/Error.cshtml", new ErrorViewModel { RequestId = Request.Path });
                }
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;

                return View("~/Views/Shared/Error.cshtml", new ErrorViewModel { RequestId = Request.Path });
            }
        }
        #endregion

        #region Details

        public async Task<IActionResult> Details(int id)
        {
            try
            {
                string tokenValue = await this.GetTokenAccess();

                _clientHttpREST.SetToken(tokenValue);

                string repJson = await _clientHttpREST.GetObjetcAsync("api-worksorders/WorkshopOrder", id.ToString());
                WorkshopModel workshop = TypeModel<WorkshopModel>.DeserializeInObject(repJson);

                if (workshop.KindEquipment == 1)
                {
                    String repJson2 = await _clientHttpREST.GetObjetcsAllAsync("api-operations/SerialsProducts");

                    List<SerialProductModel> spList = TypeModel<SerialProductModel>.DeserializeInArray(repJson2);
                    var rc = spList.Where(y => y.Serial.ToUpper().Trim() == workshop.Serial.ToUpper().Trim()).FirstOrDefault();

                    String repJson3 = await _clientHttpREST.GetObjetcsAllAsync("api-products/Products");
                    List<ProductModel> pList = TypeModel<ProductModel>.DeserializeInArray(repJson3);
                    var rc3 = pList.Where(y => y.Id == rc.ProductId).FirstOrDefault();

                    workshop.Mark = rc3.Model.Mark.name;
                    workshop.Model = rc3.Model.name;
                    workshop.Product = rc.Product.Name;
                }
                if (workshop.KindEquipment == 2)
                {
                    String repJson2 = await _clientHttpREST.GetObjetcsAllAsync("api-operations/SerialsReplacements");

                    List<SerialReplacementModel> spList = TypeModel<SerialReplacementModel>.DeserializeInArray(repJson2);
                    var rc = spList.Where(y => y.Serial.ToUpper().Trim() == workshop.Serial.ToUpper().Trim()).FirstOrDefault();

                    String repJson3 = await _clientHttpREST.GetObjetcsAllAsync("api-products/Replacements");
                    List<ReplacementModel> rList = TypeModel<ReplacementModel>.DeserializeInArray(repJson3);
                    int replacementId = 0;
                    if (rc != null)
                    {
                        replacementId = rc.ReplacementId;
                    }
                    else
                    {
                        replacementId = workshop.Equipment;
                    }

                    var rc3 = rList.Where(y => y.id == replacementId).FirstOrDefault();

                    if (rc3 != null)
                    {
                        workshop.Mark = rc3.Model.Mark.name;
                        workshop.Model = rc3.Model.name;
                        workshop.Product = rc3.name;
                    }
                }

                if (workshop.KindEquipment == 3)
                {
                    String repJson6 = await _clientHttpREST.GetObjetcsAllAsync("api-products/Products");
                    var pList1 = TypeModel<ProductModel>.DeserializeInArray(repJson6);
                    var product = pList1.Where(p => p.Id == workshop.Equipment).FirstOrDefault();

                    if (product != null)
                    {
                        workshop.Mark = product.Model.Mark.name;
                        workshop.Model = product.Model.name;
                        workshop.Product = product.Name;
                    }
                    else
                    {
                        workshop.Mark = "";
                        workshop.Model = "";
                        workshop.Product = "";
                    }
                }


                string repJson4 = await _clientHttpREST.GetObjetcAsync("api-worksorders/PhotographOrder/ByOrderId", id.ToString());
                workshop.lstPhoto = TypeModel<PhotographOrderModel>.DeserializeInArray(repJson4);

                string repJson5 = await _clientHttpREST.GetObjetcAsync("api-worksorders/AccessoryOrder/ByOrderId", id.ToString());
                workshop.lstAccesories = TypeModel<AccesoryOrderModel>.DeserializeInArray(repJson5);

                ViewData["RolId"] = RolId.ToString();

                return View(workshop);
            }
            catch (System.Net.Http.HttpRequestException wex)
            {
                if (wex.Message.Contains("401 (Unauthorized)"))
                {
                    var userIdentity = await _userManager.GetUserAsync(User);

                    return RedirectToAction(nameof(AccountController.LogoutForce), "Account", userIdentity);
                }
                else
                {
                    ViewBag.Message = wex.Message;

                    return View("~/Views/Shared/Error.cshtml", new ErrorViewModel { RequestId = Request.Path });
                }

            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;

                return View("~/Views/Shared/Error.cshtml", new ErrorViewModel { RequestId = Request.Path });
            }
        }

        #endregion

        #region CheckIn
        public async Task<IActionResult> CheckIn(int statusWarranty)
        {
            CheckInModel checkin = new CheckInModel();

            if (statusWarranty == 1)
                checkin.Message = "Por favor contacte a The Factory HKA, C.A  para mayor información";
            else
                checkin.Message = "Recuerde que el equipo esta sin garantía y debe cancelar la 1er hora de servicio";

            return View(checkin);
        }
        #endregion

        #region Post GET
        public async Task<IActionResult> Create()
        {
            try
            {
                string tokenValue = await this.GetTokenAccess();

                _clientHttpREST.SetToken(tokenValue);

                ViewData["TipoUsuario"] = 1;


                List<SelectListItem> lst = new List<SelectListItem>();

                lst.Add(new SelectListItem() { Text = "Domesa", Value = "Domesa" });
                lst.Add(new SelectListItem() { Text = "DHL", Value = "DHL" });
                lst.Add(new SelectListItem() { Text = "Fedex", Value = "Fedex" });
                lst.Add(new SelectListItem() { Text = "Tealca", Value = "Tealca" });
                lst.Add(new SelectListItem() { Text = "Zoom", Value = "Zoom" });

                ViewBag.Opciones = lst;

                List<SelectListItem> lst3 = new List<SelectListItem>();

                lst3.Add(new SelectListItem() { Text = "Producto", Value = "1" });
                lst3.Add(new SelectListItem() { Text = "Repuesto", Value = "2" });
                lst3.Add(new SelectListItem() { Text = "Periférico", Value = "3" });

                ViewBag.Opciones3 = lst3;

                List<SelectListItem> lst5 = new List<SelectListItem>();

                lst5.Add(new SelectListItem() { Text = "Persona", Value = "1" });
                lst5.Add(new SelectListItem() { Text = "Encomienda", Value = "0" });

                ViewBag.Opciones5 = lst5;

                List<SelectListItem> lst7 = new List<SelectListItem>();
                String json2 = await _clientHttpREST.GetObjetcsAllAsync("api-products/Models");
                List<ModelModel> model = TypeModel<ModelModel>.DeserializeInArray(json2);
                foreach (ModelModel m in model)
                {
                    lst7.Add(new SelectListItem() { Text = m.name, Value = m.id.ToString() });
                }
                ViewBag.Opciones6 = lst7;


                String json3 = await _clientHttpREST.GetObjetcsAllAsync("api-products/Accessories");
                List<AccesoryOrderModel> accesory = TypeModel<AccesoryOrderModel>.DeserializeInArray(json3);

                WorkshopModel workshop = new WorkshopModel();
                workshop.lstAccesories = accesory;
                workshop.DeliveryMode = true;

                List<SelectListItem> lst6 = new List<SelectListItem>();

                if (DistributorId > 0)
                {
                    workshop.DistributorId = int.Parse(DistributorId.ToString());
                    string repJson = await _clientHttpREST.GetObjetcAsync("api-clients/Distributors", workshop.DistributorId.ToString());

                    var distributor = TypeModel<DistributorModel>.DeserializeInObject(repJson);
                    workshop.rifDistributor = distributor.rif;
                    workshop.Description = distributor.description;

                    workshop.distributorName = distributor.represent;
                    workshop.distributorPhone = distributor.phone;
                    workshop.distributorAddress = distributor.address;
                    workshop.distributorSeller = distributor.nameSeller;
                    workshop.distributorSellerRif = distributor.rifSeller;
                }


                if (RolId == 9)
                {
                    workshop.StateOrderId = 1;
                    workshop.StateOrderName = "Por Recibir";
                }
                else
                {
                    workshop.StateOrderId = 2;
                    workshop.StateOrderName = "Recibido";
                }


                ViewData["RolId"] = RolId.ToString();

                return View(workshop);
            }
            catch (System.Net.Http.HttpRequestException wex)
            {
                if (wex.Message.Contains("401 (Unauthorized)"))
                {
                    var userIdentity = await _userManager.GetUserAsync(User);

                    return RedirectToAction(nameof(AccountController.LogoutForce), "Account", userIdentity);
                }
                else
                {
                    ViewBag.Message = wex.Message;

                    return View("~/Views/Shared/Error.cshtml", new ErrorViewModel { RequestId = Request.Path });
                }
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;

                return View("~/Views/Shared/Error.cshtml", new ErrorViewModel { RequestId = Request.Path });
            }

        }
        #endregion

        #region Post

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(WorkshopModel workshop, IFormFile[] filePicture)//, int[] accesoryList)
        {
            try
            {
                string tokenValue = await this.GetTokenAccess();

                _clientHttpREST.SetToken(tokenValue);

                var errors = ModelState.Values.SelectMany(v => v.Errors);

                if (!ModelState.IsValid)
                {
                    List<SelectListItem> lst = new List<SelectListItem>();

                    lst.Add(new SelectListItem() { Text = "Domesa", Value = "Domesa" });
                    lst.Add(new SelectListItem() { Text = "DHL", Value = "DHL" });
                    lst.Add(new SelectListItem() { Text = "Fedex", Value = "Fedex" });
                    lst.Add(new SelectListItem() { Text = "Tealca", Value = "Tealca" });
                    lst.Add(new SelectListItem() { Text = "Zoom", Value = "Zoom" });

                    ViewBag.Opciones = lst;

                    List<SelectListItem> lst3 = new List<SelectListItem>();

                    lst3.Add(new SelectListItem() { Text = "Producto", Value = "1" });
                    lst3.Add(new SelectListItem() { Text = "Repuesto", Value = "2" });
                    lst3.Add(new SelectListItem() { Text = "Periférico", Value = "3" });

                    ViewBag.Opciones3 = lst3;

                    List<SelectListItem> lst5 = new List<SelectListItem>();

                    lst5.Add(new SelectListItem() { Text = "Persona", Value = "1" });
                    lst5.Add(new SelectListItem() { Text = "Encomienda", Value = "0" });

                    ViewBag.Opciones5 = lst5;

                    List<SelectListItem> lst7 = new List<SelectListItem>();
                    String json2 = await _clientHttpREST.GetObjetcsAllAsync("api-products/Models");
                    List<ModelModel> model = TypeModel<ModelModel>.DeserializeInArray(json2);
                    foreach (ModelModel m in model)
                    {
                        lst7.Add(new SelectListItem() { Text = m.name, Value = m.id.ToString() });
                    }
                    ViewBag.Opciones6 = lst7;

                    ViewData["RolId"] = RolId.ToString();

                    return View(workshop);
                }


                foreach (var file in filePicture)
                {
                    var filepathPhoto =
                                      new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Images", "taller")).Root + $@"\{file.FileName}";
                    if (System.IO.File.Exists(filepathPhoto))
                    {
                        Alert("Nombre de la foto ya existe: " + file.FileName, NotificationType.info);

                        List<SelectListItem> lst = new List<SelectListItem>();

                        lst.Add(new SelectListItem() { Text = "Domesa", Value = "Domesa" });
                        lst.Add(new SelectListItem() { Text = "DHL", Value = "DHL" });
                        lst.Add(new SelectListItem() { Text = "Fedex", Value = "Fedex" });
                        lst.Add(new SelectListItem() { Text = "Tealca", Value = "Tealca" });
                        lst.Add(new SelectListItem() { Text = "Zoom", Value = "Zoom" });

                        ViewBag.Opciones = lst;

                        List<SelectListItem> lst3 = new List<SelectListItem>();

                        lst3.Add(new SelectListItem() { Text = "Producto", Value = "1" });
                        lst3.Add(new SelectListItem() { Text = "Repuesto", Value = "2" });
                        lst3.Add(new SelectListItem() { Text = "Periférico", Value = "3" });

                        ViewBag.Opciones3 = lst3;

                        List<SelectListItem> lst5 = new List<SelectListItem>();

                        lst5.Add(new SelectListItem() { Text = "Persona", Value = "1" });
                        lst5.Add(new SelectListItem() { Text = "Encomienda", Value = "0" });

                        ViewBag.Opciones5 = lst5;

                        List<SelectListItem> lst7 = new List<SelectListItem>();
                        String json2 = await _clientHttpREST.GetObjetcsAllAsync("api-products/Models");
                        List<ModelModel> model = TypeModel<ModelModel>.DeserializeInArray(json2);
                        foreach (ModelModel m in model)
                        {
                            lst7.Add(new SelectListItem() { Text = m.name, Value = m.id.ToString() });
                        }
                        ViewBag.Opciones6 = lst7;

                        ViewData["RolId"] = RolId.ToString();

                        return View(workshop);
                        //return RedirectToAction("Create");
                    }
                }



                DeliveryOrderModel delivery = new DeliveryOrderModel();
                delivery.LiableId = workshop.LiableId;
                delivery.LiableName = workshop.LiableName;
                delivery.LiablePhone = workshop.LiablePhone;
                delivery.GuideNumber = workshop.DeliveryGuideNumber;
                delivery.CompanyName = workshop.DeliveryCompanyName;
                delivery.Address = workshop.DeliveryAddress;
                delivery.Observation = workshop.DeliveryObservations;
                delivery.DispatchDate = DateTime.Now;
                if (workshop.DeliveryMode == true)
                {
                    delivery.DeliveryMode = 1;
                }
                else
                {
                    delivery.DeliveryMode = 0;
                }

                String json4 = JsonConvert.SerializeObject(delivery);
                String response4 = await _clientHttpREST.PostObjetcContentAndCodeAsync("api-worksorders/DeliveryOrder", json4);

                string[] strrespDeli = response4.Split('|');

                string coderesponseDeli = strrespDeli[0];
                string contentDeli = strrespDeli[1];

                DeliveryOrderModel deliveryInfo = new DeliveryOrderModel();

                if (coderesponseDeli == "Created")
                {
                    deliveryInfo = TypeModel<DeliveryOrderModel>.DeserializeInObject(contentDeli);
                }

                WorkshopModel w = new WorkshopModel();
                w.NumerOrder = "0000";//orderNumber.ToString();
                w.KindEquipment = workshop.KindEquipment;
                w.Equipment = workshop.Equipment;

                if (w.KindEquipment == 3)
                {
                    if (workshop.Serial == null)
                    { w.Serial = "0000000000"; }
                    else
                    { w.Serial = workshop.Serial; }

                    if (workshop.Model != null)
                    {
                        //Gestionar EquimentId para Acesorio
                        String repJson3 = await _clientHttpREST.GetObjetcsAllAsync("api-products/Products");
                        var pList = TypeModel<ProductModel>.DeserializeInArray(repJson3);
                        var product = pList.Where(p => p.ModelId == int.Parse(workshop.Model)).FirstOrDefault();
                        w.Equipment = product.Id;
                    }
                }
                else
                {
                    if (w.Equipment == 0 && w.KindEquipment == 2)
                    {
                        //Gestionar EquimentId para Repuesto No en Inventario
                        String repJson3 = await _clientHttpREST.GetObjetcsAllAsync("api-products/Replacements");
                        var rList = TypeModel<ReplacementModel>.DeserializeInArray(repJson3);
                        var replacement = rList.Where(r => r.modelId == int.Parse(workshop.Model)).FirstOrDefault();
                        if (replacement != null)
                        { w.Equipment = replacement.id; }
                        else
                        {
                            //Se Gestionar EquimentId por Producto
                            String repJson4 = await _clientHttpREST.GetObjetcsAllAsync("api-products/Products");
                            var pList = TypeModel<ProductModel>.DeserializeInArray(repJson4);
                            var product = pList.Where(p => p.ModelId == int.Parse(workshop.Model)).FirstOrDefault();
                            w.Equipment = product.Id;
                        }
                    }
                    w.Serial = workshop.Serial;
                }

                w.WarrantyId = workshop.WarrantyId;
                w.FirmwareVersion = null;
                w.DeliverDate = DateTime.Now.AddDays(15);
                w.ReceptionDate = DateTime.Now;
                if (workshop.rifFinalClient == null)
                { w.AlienationDate = DateTime.MinValue; }
                else
                { w.AlienationDate = workshop.AlienationDate; }


                //DateTime dayToday = new DateTime(2021, 2, 1);
                //DateTime dayToday = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);                
                ///w.ExpirationDate = addDaysSkillfulls(dayToday);

                w.ExpirationDate = DateTime.Now.AddDays(15);
                w.Address = workshop.Address;
                w.Contact = workshop.Contact;
                w.InsertionOrigin = 0;
                w.WorkDone = null;
                w.CustomerReview = workshop.CustomerReview;
                w.ObservationTechnical = workshop.ObservationTechnical;
                w.creation_date = DateTime.Now;
                w.Phone = workshop.Phone;
                w.DistributorId = workshop.DistributorId;
                w.TypeFailurId = 0; // Default
                w.StateOrderId = workshop.StateOrderId;
                w.DeliveryOrderId = deliveryInfo.Id;
                //Se Asigna por Defecto a Jefe de Taller Activo
                string repJson = await _clientHttpREST.GetObjetcsAllAsync("api-employees/Employees");
                var listEmployees = TypeModel<EmployeeModel>.DeserializeInArray(repJson);
                var employee = listEmployees.Where(e => e.chargueId == 11 && e.Enable).FirstOrDefault();
                if (employee != null)
                { w.EmployeeId = employee.id; }  //Jefe de Taller
                else
                { //Gerente de Servicio
                    employee = listEmployees.Where(e => e.chargueId == 1 && e.Enable).FirstOrDefault();
                    w.EmployeeId = employee.id;
                }
                w.ExtraObservation = workshop.ExtraObservation;

                String json = JsonConvert.SerializeObject(w);
                String response = await _clientHttpREST.PostObjetcContentAndCodeAsync("api-worksorders/WorkshopOrder", json);

                string[] strresp = response.Split('|');

                string coderesponse = strresp[0];
                string content = strresp[1];

                if (coderesponse == "Created")
                {

                    WorkshopModel workshop2 = TypeModel<WorkshopModel>.DeserializeInObject(content);

                    foreach (var file in filePicture)
                    {
                        if (file.Length > 0)
                        {
                            var filepath = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Images", "taller")).Root + $@"\{file.FileName}";

                            using (FileStream fs = System.IO.File.Create(filepath))
                            {
                                file.CopyTo(fs);
                                fs.Flush();
                            }

                            PhotographOrderModel photo = new PhotographOrderModel();
                            photo.OrderId = workshop2.Id;
                            photo.ImageUrl = file.FileName;
                            String json3 = JsonConvert.SerializeObject(photo);
                            String response3 = await _clientHttpREST.PostObjetcAsync("api-worksorders/PhotographOrder", json3);
                        }
                    }


                    foreach (var accesory in workshop.lstAccesories)
                    {
                        if (accesory.Selected == true)
                        {
                            AccesoryOrderModel a = new AccesoryOrderModel();
                            a.AccesoryId = accesory.id;
                            a.OrderId = workshop2.Id;

                            String json2 = JsonConvert.SerializeObject(a);
                            String response2 = await _clientHttpREST.PostObjetcAsync("api-worksorders/AccessoryOrder", json2);
                        }
                    }


                    if (RolId != 9)
                    {
                        //Inicio la Bitacora de esa Orden Nueva       
                        var employ = listEmployees.Where(d => d.email == _userManager.GetUserName(User)).FirstOrDefault();

                        String json1 = @"{
                                              'Id': 0,
                                              'orderId': " + workshop2.Id + @",    
                                              'statusId': " + workshop2.StateOrderId + @",
                                              'userId': " + employ.id + @",
                                              'observation':'" + workshop2.ExtraObservation + @"'
                                                    }";

                        String response1 = await _clientHttpREST.PostObjetcAsync("api-worksorders/WorkshopBinnacle", json1);
                    }



                    bool warrantyStatus = false;
                    int statusWarranty = 0;


                    if (workshop.WarrantyId == 0)
                    {
                        statusWarranty = 1;
                    }
                    else if (workshop.WarrantyId == 1)
                    {
                        warrantyStatus = true;
                    }
                    else if (workshop.WarrantyId == 2)
                    {
                        warrantyStatus = true;
                    }
                    else
                    {
                        statusWarranty = 2;
                    }


                    Alert("Operación Exitosa. Número de Orden: " + workshop2.NumerOrder, NotificationType.success);


                    if (warrantyStatus == false)
                    {
                        return RedirectToAction("CheckIn", new { statusWarranty = statusWarranty });
                    }
                    else
                    {
                        return RedirectToAction("Index");
                    }

                }
                else
                {
                    //String response6 = await _clientHttpREST.DeleteObjetcAsync("api-worksorders/DeliveryOrder", deliveryInfo.Id.ToString());
                    var responseCode = TypeModel<ResponceCode>.DeserializeInObject(content);
                    Alert("Error en la Operación", NotificationType.error);
                    ViewBag.Message = responseCode.message;
                    //ModelState.AddModelError(string.Empty, responseCode.message);

                    return View("~/Views/Shared/Error.cshtml", new ErrorViewModel { RequestId = Request.Path });
                }
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;

                return View("~/Views/Shared/Error.cshtml", new ErrorViewModel { RequestId = Request.Path });
            }
        }

        #endregion

        #region AJAX Validations
        public async Task<IActionResult> AjaxValidation(string Serial, int KindEquipment)
        {
            try
            {
                string tokenValue = await this.GetTokenAccess();

                _clientHttpREST.SetToken(tokenValue);

                Dato data = new Dato();


                if (Serial == null)
                {
                    data.serialInWorkshop = true;
                    data.serialValid = false;
                    data.isDistributor = true;
                    return Json(data);
                }


                String repJson0 = await _clientHttpREST.GetObjetcsAllAsync("api-worksorders/WorkshopOrder");
                List<WorkshopModel> reList0 = TypeModel<WorkshopModel>.DeserializeInArray(repJson0);
                var order = reList0.Where((y => y.Serial.Trim() == Serial.Trim() && y.StateOrderId != 11 && y.StateOrderId != 12)).FirstOrDefault();

                if (order != null)
                {
                    data.serialInWorkshop = true;
                    data.serialValid = true;
                    data.isDistributor = true;
                    return Json(data);
                }


                //Serial reincidente
                String repJson1 = await _clientHttpREST.GetObjetcsAllAsync("api-worksorders/WorkshopOrder");
                List<WorkshopModel> reList1 = TypeModel<WorkshopModel>.DeserializeInArray(repJson1);
                var order_1 = reList1.Where((y => y.Serial.Trim() == Serial.Trim() && (y.StateOrderId == 11 || y.StateOrderId == 12))).FirstOrDefault();

                if (order_1 != null)
                {
                    data.Recidivist = true;
                }


                if (KindEquipment == 1)
                {

                    String repJson = await _clientHttpREST.GetObjetcsAllAsync("api-operations/SerialsProducts");
                    List<SerialProductModel> reList = TypeModel<SerialProductModel>.DeserializeInArray(repJson);
                    var rc = reList.Where(y => y.Serial.Trim() == Serial.Trim()).FirstOrDefault();


                    if (rc == null)
                    {
                        data.serialValid = false;
                        data.isDistributor = true;
                        return Json(data);
                    }

                    if (rc.Distributor.id != DistributorId && RolId == 9)
                    {
                        return Json(data);
                    }

                    //Informacion del producto
                    String repJson3 = await _clientHttpREST.GetObjetcsAllAsync("api-products/Products");
                    List<ProductModel> pList = TypeModel<ProductModel>.DeserializeInArray(repJson3);
                    var rc3 = pList.Where(y => y.Id == rc.ProductId).FirstOrDefault();
                    bool balance = rc3.Name.ToUpper().Contains("BALANZA");


                    //Confirmar que es una balanza
                    if (balance == true)
                    {

                        /*data.Rif = rc.Distributor.rif;
                        data.AlienationDate = rc.DateSale;
                        data.BusinessName = rc.Distributor.description;*/

                        bool InWarranty = WarrantyValidation(DateTime.Now, rc.DateSale, 365);

                        if (InWarranty == false)
                        {
                            string repJsonW = await _clientHttpREST.GetObjetcAsync("api-worksorders/StatesWarranty", "3");
                            StatesWarrantyModel rw = TypeModel<StatesWarrantyModel>.DeserializeInObject(repJsonW);

                            data.warrantyMessage = rw.Description;
                            data.WarrantyId = rw.Id;

                        }
                        else
                        {
                            string repJsonW = await _clientHttpREST.GetObjetcAsync("api-worksorders/StatesWarranty", "1");
                            StatesWarrantyModel rw = TypeModel<StatesWarrantyModel>.DeserializeInObject(repJsonW);

                            data.warrantyMessage = rw.Description;
                            data.WarrantyId = rw.Id;
                        }


                    }
                    else
                    {


                        String repJson2 = await _clientHttpREST.GetObjetcsAllAsync("api-operations/Alienations");
                        List<AlienationModel> aList = TypeModel<AlienationModel>.DeserializeInArray(repJson2);
                        var rc2 = aList.Where(y => y.Serial.Trim() == Serial.Trim()).FirstOrDefault();
                        if (rc2 == null)
                        {
                            string repJsonW = await _clientHttpREST.GetObjetcAsync("api-worksorders/StatesWarranty", "0");
                            StatesWarrantyModel rw = TypeModel<StatesWarrantyModel>.DeserializeInObject(repJsonW);

                            data.warrantyMessage = rw.Description;
                            data.WarrantyId = rw.Id;
                            data.serialValid = true;
                            data.isDistributor = true;

                        }

                        if (rc2 != null)
                        {
                            data.Rif = rc2.FinalClient.Rif;
                            data.AlienationDate = rc2.AlienationDate;
                            data.BusinessName = rc2.FinalClient.Description;

                            bool InWarranty = WarrantyValidation(DateTime.Now, rc2.AlienationDate, 365);

                            if (InWarranty == false)
                            {
                                string repJsonW = await _clientHttpREST.GetObjetcAsync("api-worksorders/StatesWarranty", "3");
                                StatesWarrantyModel rw = TypeModel<StatesWarrantyModel>.DeserializeInObject(repJsonW);

                                data.warrantyMessage = rw.Description;
                                data.WarrantyId = rw.Id;
                            }
                            else
                            {
                                string repJsonW = await _clientHttpREST.GetObjetcAsync("api-worksorders/StatesWarranty", "1");
                                StatesWarrantyModel rw = TypeModel<StatesWarrantyModel>.DeserializeInObject(repJsonW);

                                data.warrantyMessage = rw.Description;
                                data.WarrantyId = rw.Id;
                            }

                        }


                    }


                    data.enable = true;
                    if (rc3 != null)
                    {
                        data.Mark = rc3.Model.Mark.name;
                        data.Model = rc3.Model.name;
                        data.Product = rc.Product.Name + " - " + rc3.Model.name + " [" + rc3.Model.Mark.name + "]";
                        data.Equipment = rc3.Id;
                    }
                    else
                    {
                        data.Product = rc.Product.Name;
                        data.Equipment = rc.Id;
                    }
                }

                if (KindEquipment == 2)
                {
                    //Confirmar serial
                    String repJson = await _clientHttpREST.GetObjetcsAllAsync("api-operations/SerialsReplacements");
                    List<SerialReplacementModel> reList = TypeModel<SerialReplacementModel>.DeserializeInArray(repJson);
                    var rc = reList.Where(y => y.Serial.Trim() == Serial.Trim()).FirstOrDefault();
                    if (rc == null)
                    {
                        data.serialValid = false;
                        data.isDistributor = true;
                        return Json(data);
                    }


                    if (rc.Distributor.id != DistributorId && RolId == 9)
                    {
                        return Json(data);
                    }

                    //Confirmar informacion del repuesto
                    String repJson3 = await _clientHttpREST.GetObjetcsAllAsync("api-products/Replacements");
                    List<ReplacementModel> pList = TypeModel<ReplacementModel>.DeserializeInArray(repJson3);
                    var rc3 = pList.Where(y => y.id == rc.ReplacementId).FirstOrDefault();

                    bool memoryfiscal = rc3.name.ToUpper().Contains("MEMORIA FISCAL");


                    //Confirmar que es una memoria fiscal
                    if (memoryfiscal == true)
                    {

                        String repJsonFO = await _clientHttpREST.GetObjetcsAllAsync("api-operations/FiscalsOperations");
                        List<FiscalOperationModel> pListfo = TypeModel<FiscalOperationModel>.DeserializeInArray(repJsonFO);
                        var rcfo = pListfo.Where(y => y.serial == Serial.Trim()).FirstOrDefault();

                        bool InWarranty = WarrantyValidation(DateTime.Now, rcfo.Creation_Date, 182);

                        if (InWarranty == false)
                        {
                            string repJsonW = await _clientHttpREST.GetObjetcAsync("api-worksorders/StatesWarranty", "3");
                            StatesWarrantyModel rw = TypeModel<StatesWarrantyModel>.DeserializeInObject(repJsonW);

                            data.warrantyMessage = rw.Description;
                            data.WarrantyId = rw.Id;

                        }
                        else
                        {
                            string repJsonW = await _clientHttpREST.GetObjetcAsync("api-worksorders/StatesWarranty", "2");
                            StatesWarrantyModel rw = TypeModel<StatesWarrantyModel>.DeserializeInObject(repJsonW);

                            data.warrantyMessage = rw.Description;
                            data.WarrantyId = rw.Id;
                        }
                    }
                    else
                    {
                        String repJson4 = await _clientHttpREST.GetObjetcsAllAsync("api-operations/TechnicalsOperations");
                        List<TechnicalOperationModel> oList = TypeModel<TechnicalOperationModel>.DeserializeInArray(repJson4);
                        var rc4 = oList.Where(y => y.Serial.Trim() == Serial.Trim()).FirstOrDefault();

                        if (rc4 != null)
                        {

                            bool InWarranty = WarrantyValidation(DateTime.Now, rc4.Operation_Date, 182);

                            if (InWarranty == false)
                            {
                                string repJsonW = await _clientHttpREST.GetObjetcAsync("api-worksorders/StatesWarranty", "3");
                                StatesWarrantyModel rw = TypeModel<StatesWarrantyModel>.DeserializeInObject(repJsonW);

                                data.warrantyMessage = rw.Description;
                                data.WarrantyId = rw.Id;
                            }
                            else
                            {
                                string repJsonW = await _clientHttpREST.GetObjetcAsync("api-worksorders/StatesWarranty", "2");
                                StatesWarrantyModel rw = TypeModel<StatesWarrantyModel>.DeserializeInObject(repJsonW);

                                data.warrantyMessage = rw.Description;
                                data.WarrantyId = rw.Id;
                            }
                        }
                        else
                        {
                            string repJsonW = await _clientHttpREST.GetObjetcAsync("api-worksorders/StatesWarranty", "0");
                            StatesWarrantyModel rw = TypeModel<StatesWarrantyModel>.DeserializeInObject(repJsonW);

                            data.warrantyMessage = rw.Description;
                            data.WarrantyId = rw.Id;
                        }
                    }


                    data.enable = true;
                    if (rc3 != null)
                    {
                        data.Mark = rc3.Model.Mark.name;
                        data.Model = rc3.Model.name;
                        data.Product = rc.Replacement.name + " - " + rc3.Model.name + " [" + rc3.Model.Mark.name + "]";
                        data.Equipment = rc.Id;
                    }
                    else
                    {
                        data.Product = rc.Replacement.name;
                        data.Equipment = rc.Id;
                    }

                }




                return Json(data);
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;

                return ViewBag;
            }

        }
        #endregion

        #region Create PDF

        public async Task<IActionResult> GetPdf(int id)
        {
            try
            {
                string tokenValue = await this.GetTokenAccess();
                _clientHttpREST.SetToken(tokenValue);

                string repJson = await _clientHttpREST.GetObjetcAsync("api-worksorders/WorkshopOrder", id.ToString());

                WorkshopModel workshop = TypeModel<WorkshopModel>.DeserializeInObject(repJson);
                ProviderModel provider = new ProviderModel();

                String json2 = await _clientHttpREST.GetObjetcAsync("api-clients/Distributors", workshop.DistributorId.ToString());
                var distributor = TypeModel<DistributorModel>.DeserializeInObject(json2);

                workshop.rifDistributor = distributor.rif;
                workshop.Description = distributor.description;
                string tipoEquipment = "Producto Terminado";
                if (workshop.KindEquipment == 1)
                {
                    String repJson2 = await _clientHttpREST.GetObjetcsAllAsync("api-operations/SerialsProducts");

                    List<SerialProductModel> spList = TypeModel<SerialProductModel>.DeserializeInArray(repJson2);
                    var rc = spList.Where(y => y.Serial.ToUpper().Trim() == workshop.Serial.ToUpper().Trim()).FirstOrDefault();
                    provider = rc.Provider;
                    String repJson3 = await _clientHttpREST.GetObjetcsAllAsync("api-products/Products");
                    List<ProductModel> pList = TypeModel<ProductModel>.DeserializeInArray(repJson3);
                    var rc3 = pList.Where(y => y.Id == rc.ProductId).FirstOrDefault();

                    workshop.Mark = rc3.Model.Mark.name;
                    workshop.Model = rc3.Model.name;

                    String repJson5 = await _clientHttpREST.GetObjetcsAllAsync("api-operations/Alienations");
                    List<AlienationModel> alList = TypeModel<AlienationModel>.DeserializeInArray(repJson5);
                    var rc2 = alList.Where(y => y.Serial.ToUpper().Trim() == workshop.Serial.ToUpper().Trim()).FirstOrDefault();

                    if (rc2 != null)
                    {
                        workshop.rifFinalClient = rc2.FinalClient.Rif;
                        workshop.BusinessName = rc2.FinalClient.Description;
                    }
                }

                if (workshop.KindEquipment == 2)
                {
                    tipoEquipment = "Repuesto";
                    String repJson2 = await _clientHttpREST.GetObjetcsAllAsync("api-operations/SerialsReplacements");

                    List<SerialReplacementModel> spList = TypeModel<SerialReplacementModel>.DeserializeInArray(repJson2);
                    var rc = spList.Where(y => y.Serial.ToUpper().Trim() == workshop.Serial.ToUpper().Trim()).FirstOrDefault();

                    String repJson3 = await _clientHttpREST.GetObjetcsAllAsync("api-products/Replacements");
                    List<ReplacementModel> rList = TypeModel<ReplacementModel>.DeserializeInArray(repJson3);

                    int replacementId = 0;
                    if (rc != null)
                    {
                        provider = rc.Provider;
                        replacementId = rc.ReplacementId;
                    }
                    else
                    {
                        replacementId = workshop.Equipment;

                        string repJson6 = await _clientHttpREST.GetObjetcsAllAsync("api-clients/Providers");
                        var providers = TypeModel<ProviderModel>.DeserializeInArray(repJson6);

                        foreach (ProviderModel prov in providers)
                        {
                            string repJson7 = await _clientHttpREST.GetObjetcsAllAsync("api-clients/Providers/" + prov.id.ToString() + "/Distributors");
                            var distributors = TypeModel<DistributorModel>.DeserializeInArray(repJson7);

                            if (distributors.Find(d => d.id == distributor.id) != null)
                            {
                                provider = prov;
                                break;
                            }
                        }
                    }

                    var rc3 = rList.Where(y => y.id == replacementId).FirstOrDefault();

                    if (rc3 != null)
                    {
                        workshop.Mark = rc3.Model.Mark.name;
                        workshop.Model = rc3.Model.name;
                    }

                }

                if (workshop.KindEquipment == 3)
                {
                    tipoEquipment = "Periférico";
                    string repJson6 = await _clientHttpREST.GetObjetcsAllAsync("api-clients/Providers");
                    var providers = TypeModel<ProviderModel>.DeserializeInArray(repJson6);

                    foreach (ProviderModel prov in providers)
                    {
                        string repJson7 = await _clientHttpREST.GetObjetcsAllAsync("api-clients/Providers/" + prov.id.ToString() + "/Distributors");
                        var distributors = TypeModel<DistributorModel>.DeserializeInArray(repJson7);

                        if (distributors.Find(d => d.id == distributor.id) != null)
                        {
                            provider = prov;
                            break;
                        }
                    }

                    String repJson8 = await _clientHttpREST.GetObjetcsAllAsync("api-products/Products");
                    List<ProductModel> pList = TypeModel<ProductModel>.DeserializeInArray(repJson8);
                    var rc3 = pList.Where(y => y.Id == workshop.Equipment).FirstOrDefault();

                    workshop.Mark = rc3.Model.Mark.name;
                    workshop.Model = rc3.Model.name;
                }

                MemoryStream memoryStream = new MemoryStream();
                Document document = new Document();
                PdfWriter replacementPDF = PdfWriter.GetInstance(document, memoryStream);

                document.AddTitle("Orden de Taller");
                document.Open();

                //string filePath = @"wwwroot\images\logos\"; //Windows
                string filePath = @"wwwroot/images/logos/"; //Linux
                var path = Path.GetDirectoryName(filePath);
                //string imagePath = path + "\\" + provider.image; //Windows
                string imagePath = path + "/" + provider.image; //Linux
                iTextSharp.text.Image img = iTextSharp.text.Image.GetInstance(imagePath);
                img.ScaleToFit(150f, 90f);
                Paragraph p = new Paragraph();
                p.Add(new Phrase(Chunk.NEWLINE));
                p.Add(new Phrase(Chunk.NEWLINE));

                p.Add(new Phrase("                                        Nro.Control: " + workshop.NumerOrder, new Font() { Size = 25 }));
                p.Add(new Chunk(img, 0, -20));

                p.Add(new Phrase(Chunk.NEWLINE));
                p.Add(new Phrase(Chunk.NEWLINE));

                //Manejo de Codigo QR
                string srtQr = "Nro.Control: " + workshop.NumerOrder + "\r\n" +
                        "Fecha: " + workshop.ReceptionDate.ToString() + "\r\n" +
                        "Serial: " + workshop.Serial + "\r\n" +
                        "Equipo: " + workshop.Model + " " + workshop.Mark + "\r\n" +
                        "Cliente: " + workshop.rifDistributor;
                iTextSharp.text.pdf.BarcodeQRCode qrcode = new BarcodeQRCode(srtQr, 100, 100, null);
                iTextSharp.text.Image imgQr = qrcode.GetImage();

                p.Add(new Chunk(imgQr, 370, -70));
                p.Add(new Phrase(Chunk.NEWLINE));
                p.Add(new Phrase(Chunk.NEWLINE));
                p.Add(new Phrase(Chunk.NEWLINE));
                //p.Add(new Phrase("   Nro.Control: " + workshop.NumerOrder, new Font() { Size = 25 }));
                p.Add(new Phrase(Chunk.NEWLINE));
                p.Add(new Phrase(Chunk.NEWLINE));
                p.Add(new Phrase("                               Solicitud de Servicio y/o Reparación de Equipos"));
                p.Add(new Phrase(Chunk.NEWLINE));
                p.Add(new Phrase(Chunk.NEWLINE));
                p.Add(new Phrase(Chunk.NEWLINE));
                p.Add(new Phrase("                                                                                               Caracas " + DateTime.Now.ToString("dd/MM/yyyy")));

                if (workshop.statesOrder.Description.ToUpper().Equals("ANULADO"))
                {
                    iTextSharp.text.Font _standardFontRed = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 40, iTextSharp.text.Font.BOLD, BaseColor.RED);
                    p.Add(new Phrase("         ANULADO", _standardFontRed));

                    PdfContentByte under = replacementPDF.DirectContentUnder;
                    BaseFont baseFont = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.WINANSI, BaseFont.EMBEDDED);
                    under.BeginText();
                    under.SetColorFill(iTextSharp.text.pdf.CMYKColor.RED);
                    under.SetFontAndSize(baseFont, 130);
                    under.ShowTextAligned(PdfContentByte.ALIGN_CENTER, "ANULADO", 300, 400, 45);
                    under.EndText();
                }

                document.Add(p);

                iTextSharp.text.Font _standardFont = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 12, iTextSharp.text.Font.BOLD, BaseColor.BLACK);
                iTextSharp.text.Font _standardFont2 = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 11, iTextSharp.text.Font.NORMAL, BaseColor.BLACK);

                PdfPTable workshopTable = new PdfPTable(2);
                workshopTable.WidthPercentage = 100;

                PdfPCell cl1 = new PdfPCell(new Phrase("Compañia Fabricante", _standardFont));
                cl1.BorderWidth = 1;
                cl1.BorderWidthBottom = 0.75f;

                PdfPCell cl2 = new PdfPCell(new Phrase(provider.description, _standardFont2));
                cl2.BorderWidth = 1;
                cl2.BorderWidthBottom = 0.75f;

                workshopTable.AddCell(cl1);
                workshopTable.AddCell(cl2);

                PdfPCell cl30 = new PdfPCell(new Phrase("Distribuidor", _standardFont));
                cl30.BorderWidth = 1;
                cl30.BorderWidthBottom = 0.75f;

                PdfPCell cl20 = new PdfPCell(new Phrase(workshop.Description + " [" + workshop.rifDistributor + "]", _standardFont2));
                cl20.BorderWidth = 1;
                cl20.BorderWidthBottom = 0.75f;

                workshopTable.AddCell(cl30);
                workshopTable.AddCell(cl20);

                cl1 = new PdfPCell(new Phrase("Persona de contacto", _standardFont));
                cl1.BackgroundColor = BaseColor.LIGHT_GRAY;
                cl1.BorderWidth = 1;

                cl2 = new PdfPCell(new Phrase(workshop.Contact, _standardFont2));
                cl2.BackgroundColor = BaseColor.LIGHT_GRAY;
                cl2.BorderWidth = 1;

                workshopTable.AddCell(cl1);
                workshopTable.AddCell(cl2);

                cl1 = new PdfPCell(new Phrase("Teléfono", _standardFont));
                cl1.BorderWidth = 1;

                cl2 = new PdfPCell(new Phrase(workshop.Phone, _standardFont2));
                cl2.BorderWidth = 1;

                workshopTable.AddCell(cl1);
                workshopTable.AddCell(cl2);

                cl1 = new PdfPCell(new Phrase("Fecha de Solicitud", _standardFont));
                cl1.BorderWidth = 1;

                cl2 = new PdfPCell(new Phrase(workshop.ReceptionDate.ToString(), _standardFont2));
                cl2.BorderWidth = 1;

                workshopTable.AddCell(cl1);
                workshopTable.AddCell(cl2);

                /*cl1 = new PdfPCell(new Phrase("Fecha Estimada de Envio", _standardFont));
                cl1.BorderWidth = 1;

                cl2 = new PdfPCell(new Phrase(workshop.DeliverDate.ToString(), _standardFont2));
                cl2.BorderWidth = 1;

                workshopTable.AddCell(cl1);
                workshopTable.AddCell(cl2);*/

                cl1 = new PdfPCell(new Phrase("Fecha / RIF Enajenación", _standardFont));
                cl1.BorderWidth = 1;

                cl2 = new PdfPCell(new Phrase(workshop.rifFinalClient != null ? workshop.AlienationDate.ToString() + " [" + workshop.rifFinalClient + "]" : "", _standardFont2));
                cl2.BorderWidth = 1;

                workshopTable.AddCell(cl1);
                workshopTable.AddCell(cl2);

                cl1 = new PdfPCell(new Phrase("Razón Social Cliente Final", _standardFont));
                cl1.BorderWidth = 1;

                cl2 = new PdfPCell(new Phrase(workshop.BusinessName, _standardFont2));
                cl2.BorderWidth = 1;

                workshopTable.AddCell(cl1);
                workshopTable.AddCell(cl2);

                cl1 = new PdfPCell(new Phrase("Forma de Envío", _standardFont));
                cl1.BorderWidth = 1;

                string deliveryMode;
                if (workshop.deliveryOrder.DeliveryMode == 1)
                {
                    deliveryMode = "Persona";
                }
                else
                {
                    deliveryMode = "Encomienda";
                }

                cl2 = new PdfPCell(new Phrase(deliveryMode, _standardFont2));
                cl2.BorderWidth = 1;

                workshopTable.AddCell(cl1);
                workshopTable.AddCell(cl2);

                if (workshop.deliveryOrder.DeliveryMode == 0)
                {
                    cl1 = new PdfPCell(new Phrase("Dirección de Envio", _standardFont));
                    cl1.BorderWidth = 1;

                    cl2 = new PdfPCell(new Phrase(workshop.deliveryOrder.Address, _standardFont2));
                    cl2.BorderWidth = 1;

                    workshopTable.AddCell(cl1);
                    workshopTable.AddCell(cl2);

                    cl1 = new PdfPCell(new Phrase("Empresa de Encomienda", _standardFont));
                    cl1.BorderWidth = 1;

                    cl2 = new PdfPCell(new Phrase(workshop.deliveryOrder.CompanyName, _standardFont2));
                    cl2.BorderWidth = 1;

                    workshopTable.AddCell(cl1);
                    workshopTable.AddCell(cl2);
                }

                PdfPTable workshopTable2 = new PdfPTable(4);
                workshopTable2.WidthPercentage = 100;

                PdfPCell cl3 = new PdfPCell(new Phrase("Equipo", _standardFont));
                cl3.BorderWidth = 1;
                cl3.BorderWidthBottom = 0.75f;

                PdfPCell cl4 = new PdfPCell(new Phrase(workshop.Model + " / " + workshop.Mark, _standardFont2));
                cl4.BorderWidth = 1;
                cl4.BorderWidthBottom = 0.75f;

                PdfPCell cl5 = new PdfPCell(new Phrase("Tipo", _standardFont2));
                cl5.BorderWidth = 1;
                cl5.BorderWidthBottom = 0.75f;

                PdfPCell cl6 = new PdfPCell(new Phrase(tipoEquipment, _standardFont2));
                cl6.BorderWidth = 1;
                cl6.BorderWidthBottom = 0.75f;

                workshopTable2.AddCell(cl3);
                workshopTable2.AddCell(cl4);
                workshopTable2.AddCell(cl5);
                workshopTable2.AddCell(cl6);

                PdfPTable workshopTable6 = new PdfPTable(2);
                workshopTable6.WidthPercentage = 100;
                cl3 = new PdfPCell(new Phrase("Nro Serial / Nro de Registro", _standardFont));
                cl3.BorderWidth = 1;
                cl3.BorderWidthBottom = 0.75f;

                cl4 = new PdfPCell(new Phrase(workshop.Serial, _standardFont2));
                cl4.BorderWidth = 1;
                cl4.BorderWidthBottom = 0.75f;

                workshopTable6.AddCell(cl3);
                workshopTable6.AddCell(cl4);

                cl5 = new PdfPCell(new Phrase("Gerantía", _standardFont));
                cl5.BorderWidth = 1;
                cl5.BorderWidthBottom = 0.75f;

                cl6 = new PdfPCell(new Phrase(workshop.warranty.Description, _standardFont2));
                cl6.BorderWidth = 1;
                cl6.BorderWidthBottom = 0.75f;

                workshopTable6.AddCell(cl5);
                workshopTable6.AddCell(cl6);


                /*cl5 = new PdfPCell(new Phrase("Ciudad", _standardFont2));
                cl5.BorderWidth = 1;
                cl5.BorderWidthBottom = 0.75f;

                cl6 = new PdfPCell(new Phrase("Distrito Capital", _standardFont2));
                cl6.BorderWidth = 1;
                cl6.BorderWidthBottom = 0.75f;

                workshopTable2.AddCell(cl3);
                workshopTable2.AddCell(cl4);
                workshopTable2.AddCell(cl5);
                workshopTable2.AddCell(cl6);*/

                PdfPTable workshopTable3 = new PdfPTable(1);
                workshopTable3.WidthPercentage = 100;

                PdfPCell cl7 = new PdfPCell(new Phrase("Descripción de la falla", _standardFont));
                cl7.BackgroundColor = BaseColor.LIGHT_GRAY;
                cl7.BorderWidth = 1;
                cl7.BorderWidthBottom = 0.75f;

                PdfPCell cl8 = new PdfPCell(new Phrase(workshop.ObservationTechnical, _standardFont2));
                cl8.BorderWidth = 1;
                cl8.BorderWidthBottom = 0.75f;

                workshopTable3.AddCell(cl7);
                workshopTable3.AddCell(cl8);

                PdfPTable workshopTable4 = new PdfPTable(1);
                workshopTable4.WidthPercentage = 100;

                PdfPCell cl9 = new PdfPCell(new Phrase("Accesorios", _standardFont));
                cl9.BackgroundColor = BaseColor.LIGHT_GRAY;
                cl9.BorderWidth = 1;
                cl9.BorderWidthBottom = 0.75f;
                workshopTable4.AddCell(cl9);

                string repJson4 = await _clientHttpREST.GetObjetcAsync("api-worksorders/AccessoryOrder/ByOrderId", workshop.Id.ToString());

                List<AccesoryOrderModel> aList = TypeModel<AccesoryOrderModel>.DeserializeInArray(repJson4);
                var listAccesory = "" + Chunk.NEWLINE;
                foreach (AccesoryOrderModel accesory in aList)
                {
                    listAccesory = listAccesory + "- " + accesory.accessory.name + Chunk.NEWLINE;
                }

                cl9 = new PdfPCell(new Phrase(listAccesory, _standardFont2));
                cl9.BorderWidth = 1;
                cl9.BorderWidthBottom = 0.75f;

                workshopTable4.AddCell(cl9);

                PdfPTable workshopTable5 = new PdfPTable(1);
                workshopTable5.WidthPercentage = 100;

                PdfPCell cl10 = new PdfPCell(new Phrase("Revisión preliminar realizada por el cliente", _standardFont));
                cl10.BackgroundColor = BaseColor.LIGHT_GRAY;
                cl10.BorderWidth = 1;
                cl10.BorderWidthBottom = 0.75f;

                PdfPCell cl11 = new PdfPCell(new Phrase(workshop.CustomerReview, _standardFont2));
                cl11.BorderWidth = 1;
                cl11.BorderWidthBottom = 0.75f;

                workshopTable5.AddCell(cl10);
                workshopTable5.AddCell(cl11);

                PdfPCell cl12 = new PdfPCell(new Phrase("Observaciones Extras", _standardFont));
                cl12.BackgroundColor = BaseColor.LIGHT_GRAY;
                cl12.BorderWidth = 1;
                cl12.BorderWidthBottom = 0.75f;

                PdfPCell cl13 = new PdfPCell(new Phrase(workshop.ExtraObservation != null ? workshop.ExtraObservation.Replace("<br>", " ") : "", _standardFont2));
                cl13.BorderWidth = 1;
                cl13.BorderWidthBottom = 0.75f;

                workshopTable5.AddCell(cl12);
                workshopTable5.AddCell(cl13);


                document.Add(Chunk.NEWLINE);
                document.Add(workshopTable);
                document.Add(workshopTable2);
                document.Add(workshopTable6);
                document.Add(workshopTable3);
                document.Add(workshopTable4);
                document.Add(workshopTable5);


                Paragraph p2 = new Paragraph();
                p2.Add(new Phrase(Chunk.NEWLINE));
                p2.Add(new Phrase(Chunk.NEWLINE));
                p2.Add(new Phrase(" Firma     __________________________________________                          Fecha: " + DateTime.Now.ToString("dd/MM/yyyy")));

                document.Add(p2);

                Paragraph p3 = new Paragraph();
                p3.Add(new Phrase(Chunk.NEWLINE));
                p3.Add(new Phrase(" Nota: este documento certifica que su solicitud de servicio fue procesada y recibida"));
                document.Add(p3);

                document.Close();

                byte[] content = memoryStream.ToArray();

                return File(content, "application/pdf", "Orden_" + workshop.NumerOrder + ".pdf");
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;

                return View("~/Views/Shared/Error.cshtml", new ErrorViewModel { RequestId = Request.Path });
            }
        }

        #endregion

        #region GET: Delete
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                if (id == 0)
                {
                    return new StatusCodeResult((int)HttpStatusCode.BadRequest);
                }

                string tokenValue = await this.GetTokenAccess();

                _clientHttpREST.SetToken(tokenValue);


                String json = await _clientHttpREST.GetObjetcAsync("api-worksorders/WorkshopOrder", id.ToString());
                WorkshopModel workshop = TypeModel<WorkshopModel>.DeserializeInObject(json);

                if (workshop.KindEquipment == 1)
                {
                    String repJson2 = await _clientHttpREST.GetObjetcsAllAsync("api-operations/SerialsProducts");

                    List<SerialProductModel> spList = TypeModel<SerialProductModel>.DeserializeInArray(repJson2);
                    var rc = spList.Where(y => y.Serial.ToUpper().Trim() == workshop.Serial.ToUpper().Trim()).FirstOrDefault();

                    String repJson3 = await _clientHttpREST.GetObjetcsAllAsync("api-products/Products");
                    List<ProductModel> pList = TypeModel<ProductModel>.DeserializeInArray(repJson3);
                    var rc3 = pList.Where(y => y.Id == rc.ProductId).FirstOrDefault();

                    workshop.Mark = rc3.Model.Mark.name;
                    workshop.Model = rc3.Model.name;
                    workshop.Product = rc.Product.Name;
                }

                if (workshop.KindEquipment == 2)
                {
                    String repJson2 = await _clientHttpREST.GetObjetcsAllAsync("api-operations/SerialsReplacements");

                    List<SerialReplacementModel> spList = TypeModel<SerialReplacementModel>.DeserializeInArray(repJson2);
                    var rc = spList.Where(y => y.Serial.ToUpper().Trim() == workshop.Serial.ToUpper().Trim()).FirstOrDefault();

                    String repJson3 = await _clientHttpREST.GetObjetcsAllAsync("api-products/Replacements");
                    List<ReplacementModel> rList = TypeModel<ReplacementModel>.DeserializeInArray(repJson3);
                    int replacementId = 0;
                    if (rc != null)
                    {
                        replacementId = rc.ReplacementId;
                    }
                    else
                    {
                        replacementId = workshop.Equipment;
                    }

                    var rc3 = rList.Where(y => y.id == replacementId).FirstOrDefault();

                    if (rc3 != null)
                    {
                        workshop.Mark = rc3.Model.Mark.name;
                        workshop.Model = rc3.Model.name;
                        workshop.Product = rc3.name;
                    }
                }
                if (workshop.KindEquipment == 3)
                {
                    String repJson6 = await _clientHttpREST.GetObjetcsAllAsync("api-products/Products");
                    var pList1 = TypeModel<ProductModel>.DeserializeInArray(repJson6);
                    var product = pList1.Where(p => p.Id == workshop.Equipment).FirstOrDefault();
                    workshop.Mark = product.Model.Mark.name;
                    workshop.Model = product.Model.name;
                    workshop.Product = product.Name;
                }

                string repJson4 = await _clientHttpREST.GetObjetcAsync("api-worksorders/PhotographOrder/ByOrderId", id.ToString());
                workshop.lstPhoto = TypeModel<PhotographOrderModel>.DeserializeInArray(repJson4);

                if (workshop == null)
                {
                    return NotFound();
                }

                return View(workshop);

            }
            catch (System.Net.Http.HttpRequestException wex)
            {
                if (wex.Message.Contains("401 (Unauthorized)"))
                {
                    var userIdentity = await _userManager.GetUserAsync(User);

                    return RedirectToAction(nameof(AccountController.LogoutForce), "Account", userIdentity);
                }
                else
                {
                    ViewBag.Message = wex.Message;

                    return View("~/Views/Shared/Error.cshtml", new ErrorViewModel { RequestId = Request.Path });
                }
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;

                return View("~/Views/Shared/Error.cshtml", new ErrorViewModel { RequestId = Request.Path });
            }
        }
        #endregion

        #region POST: Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, WorkshopModel workshop)
        {
            try
            {
                string tokenValue = await this.GetTokenAccess();

                _clientHttpREST.SetToken(tokenValue);

                var nameUser = _userManager.GetUserName(User);
                String json = @"{   'username':'" + nameUser + @"',
                                        'password':'" + workshop.Verificador + @"'
                                }";

                String response1 = await _clientHttpREST.PostObjetcContentAsync("api-access/Login", json);
                TokenStruct tokenObj = TypeModel<TokenStruct>.DeserializeInObject(response1);

                if (tokenObj == null)
                {
                    return View(workshop);
                }

                if (tokenObj.authenticated)
                {
                    String json2 = await _clientHttpREST.GetObjetcAsync("api-worksorders/WorkshopOrder", id.ToString());
                    WorkshopModel workshop2 = TypeModel<WorkshopModel>.DeserializeInObject(json2);

                    if (RolId != 9)
                    {
                        String response0 = await _clientHttpREST.DeleteObjetcAsync("api-worksorders/WorkshopBinnacle/ByOrderId", id.ToString());
                    }

                    String response3 = await _clientHttpREST.DeleteObjetcAsync("api-worksorders/AccessoryOrder", id.ToString());
                    String response4 = await _clientHttpREST.DeleteObjetcAsync("api-worksorders/DeliveryOrder", workshop2.DeliveryOrderId.ToString());
                    String response5 = await _clientHttpREST.DeleteObjetcAsync("api-worksorders/PhotographOrder", id.ToString());
                    String response2 = await _clientHttpREST.DeleteObjetcAsync("api-worksorders/WorkshopOrder", id.ToString());

                    if (response2.Equals("OK"))
                    {
                        Alert("Operación Exitosa", NotificationType.success);
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        Alert("Error en la Operación", NotificationType.error);
                        ViewBag.Message = response2;
                        return View("~/Views/Shared/Error.cshtml", new ErrorViewModel { RequestId = Request.Path });
                    }
                }
                else
                {
                    String json1 = await _clientHttpREST.GetObjetcAsync("api-worksorders/WorkshopOrder", id.ToString());
                    workshop = TypeModel<WorkshopModel>.DeserializeInObject(json1);

                    String repJson2 = await _clientHttpREST.GetObjetcsAllAsync("api-operations/SerialsProducts");
                    List<SerialProductModel> spList = TypeModel<SerialProductModel>.DeserializeInArray(repJson2);
                    var rc = spList.Where(y => y.Serial.ToUpper().Trim() == workshop.Serial.ToUpper().Trim()).FirstOrDefault();

                    String repJson3 = await _clientHttpREST.GetObjetcsAllAsync("api-products/Products");
                    List<ProductModel> pList = TypeModel<ProductModel>.DeserializeInArray(repJson3);
                    var rc3 = pList.Where(y => y.Id == rc.ProductId).FirstOrDefault();

                    workshop.Mark = rc3.Model.Mark.name;
                    workshop.Model = rc3.Model.name;

                    string repJson4 = await _clientHttpREST.GetObjetcAsync("api-worksorders/PhotographOrder/ByOrderId", id.ToString());
                    workshop.lstPhoto = TypeModel<PhotographOrderModel>.DeserializeInArray(repJson4);

                    ViewBag.Message = "Clave Errada";

                    return View(workshop);
                }
            }
            catch (System.Net.Http.HttpRequestException wex)
            {
                if (wex.Message.Contains("401 (Unauthorized)"))
                {
                    var userIdentity = await _userManager.GetUserAsync(User);

                    return RedirectToAction(nameof(AccountController.LogoutForce), "Account", userIdentity);
                }
                else
                {
                    ViewBag.Message = wex.Message;

                    return View("~/Views/Shared/Error.cshtml", new ErrorViewModel { RequestId = Request.Path });
                }
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;

                return View("~/Views/Shared/Error.cshtml", new ErrorViewModel { RequestId = Request.Path });
            }
        }
        #endregion

        #region WarrantyValidation
        private bool WarrantyValidation(DateTime actualDateTime, DateTime alienationDateTime, int daysWarranty)
        {
            TimeSpan timeSinceWarranty = actualDateTime - alienationDateTime;

            int daysSinceWarrantyTranscurrido = Math.Abs(timeSinceWarranty.Days);
            int daysSinceWarranty = daysWarranty;

            if (daysSinceWarrantyTranscurrido > daysSinceWarranty)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        #endregion

        #region GET: Edit
        public async Task<IActionResult> Edit(int id)
        {
            try
            {

                if (id == 0)
                {
                    return new StatusCodeResult((int)HttpStatusCode.BadRequest);
                }

                string tokenValue = await this.GetTokenAccess();

                _clientHttpREST.SetToken(tokenValue);

                String json = await _clientHttpREST.GetObjetcAsync("api-worksorders/WorkshopOrder", id.ToString());
                WorkshopModel workshop = TypeModel<WorkshopModel>.DeserializeInObject(json);

                if (workshop == null)
                {
                    return NotFound();
                }




                if (workshop.KindEquipment == 1)
                {

                    String repJson = await _clientHttpREST.GetObjetcsAllAsync("api-operations/SerialsProducts");
                    List<SerialProductModel> reList = TypeModel<SerialProductModel>.DeserializeInArray(repJson);
                    var rc = reList.Where(y => y.Serial.Trim() == workshop.Serial.Trim()).FirstOrDefault();

                    //Informacion del producto
                    String repJson3 = await _clientHttpREST.GetObjetcsAllAsync("api-products/Products");
                    List<ProductModel> pList = TypeModel<ProductModel>.DeserializeInArray(repJson3);
                    var rc3 = pList.Where(y => y.Id == rc.ProductId).FirstOrDefault();
                    bool balance = rc3.Name.ToUpper().Contains("BALANZA");


                    //Confirmar que es una balanza
                    if (balance == true)
                    {

                        bool InWarranty = WarrantyValidation(DateTime.Now, rc.DateSale, 365);

                        if (InWarranty == false)
                        {
                            string repJsonW = await _clientHttpREST.GetObjetcAsync("api-worksorders/StatesWarranty", "3");
                            StatesWarrantyModel rw = TypeModel<StatesWarrantyModel>.DeserializeInObject(repJsonW);

                            workshop.warrantyMessage = rw.Description;
                            workshop.WarrantyId = rw.Id;

                        }
                        else
                        {
                            string repJsonW = await _clientHttpREST.GetObjetcAsync("api-worksorders/StatesWarranty", "1");
                            StatesWarrantyModel rw = TypeModel<StatesWarrantyModel>.DeserializeInObject(repJsonW);

                            workshop.warrantyMessage = rw.Description;
                            workshop.WarrantyId = rw.Id;
                        }


                    }
                    else
                    {


                        String repJson2 = await _clientHttpREST.GetObjetcsAllAsync("api-operations/Alienations");
                        List<AlienationModel> aList = TypeModel<AlienationModel>.DeserializeInArray(repJson2);
                        var rc2 = aList.Where(y => y.Serial.Trim() == workshop.Serial.Trim()).FirstOrDefault();
                        if (rc2 == null)
                        {
                            string repJsonW = await _clientHttpREST.GetObjetcAsync("api-worksorders/StatesWarranty", "0");
                            StatesWarrantyModel rw = TypeModel<StatesWarrantyModel>.DeserializeInObject(repJsonW);

                            workshop.warrantyMessage = rw.Description;
                            workshop.WarrantyId = rw.Id;

                        }

                        if (rc2 != null)
                        {
                            workshop.rifFinalClient = rc2.FinalClient.Rif;
                            workshop.AlienationDate = rc2.AlienationDate;
                            workshop.BusinessName = rc2.FinalClient.Description;

                            bool InWarranty = WarrantyValidation(DateTime.Now, rc2.AlienationDate, 365);

                            if (InWarranty == false)
                            {
                                string repJsonW = await _clientHttpREST.GetObjetcAsync("api-worksorders/StatesWarranty", "3");
                                StatesWarrantyModel rw = TypeModel<StatesWarrantyModel>.DeserializeInObject(repJsonW);

                                workshop.warrantyMessage = rw.Description;
                                workshop.WarrantyId = rw.Id;
                            }
                            else
                            {
                                string repJsonW = await _clientHttpREST.GetObjetcAsync("api-worksorders/StatesWarranty", "1");
                                StatesWarrantyModel rw = TypeModel<StatesWarrantyModel>.DeserializeInObject(repJsonW);

                                workshop.warrantyMessage = rw.Description;
                                workshop.WarrantyId = rw.Id;
                            }

                        }

                    }


                    if (rc3 != null)
                    {

                        workshop.Product = rc.Product.Name + " - " + rc3.Model.name + " [" + rc3.Model.Mark.name + "]";
                        //workshop.Equipment = rc3.Id;
                    }
                    else
                    {
                        workshop.Product = rc.Product.Name;
                        //workshop.Equipment = rc.Id;
                    }
                }

                if (workshop.KindEquipment == 2)
                {
                    //Confirmar serial
                    String repJson = await _clientHttpREST.GetObjetcsAllAsync("api-operations/SerialsReplacements");
                    List<SerialReplacementModel> reList = TypeModel<SerialReplacementModel>.DeserializeInArray(repJson);
                    var rc = reList.Where(y => y.Serial.Trim() == workshop.Serial.Trim()).FirstOrDefault();


                    //Confirmar informacion del repuesto
                    String repJson3 = await _clientHttpREST.GetObjetcsAllAsync("api-products/Replacements");
                    List<ReplacementModel> pList = TypeModel<ReplacementModel>.DeserializeInArray(repJson3);
                    var rc3 = pList.Where(y => y.id == rc.ReplacementId).FirstOrDefault();

                    bool memoryfiscal = rc3.name.ToUpper().Contains("MEMORIA FISCAL");


                    //Confirmar que es una memoria fiscal
                    if (memoryfiscal == true)
                    {

                        String repJsonFO = await _clientHttpREST.GetObjetcsAllAsync("api-operations/FiscalsOperations");
                        List<FiscalOperationModel> pListfo = TypeModel<FiscalOperationModel>.DeserializeInArray(repJsonFO);
                        var rcfo = pListfo.Where(y => y.serial == workshop.Serial.Trim()).FirstOrDefault();

                        bool InWarranty = WarrantyValidation(DateTime.Now, rcfo.Creation_Date, 182);

                        if (InWarranty == false)
                        {
                            string repJsonW = await _clientHttpREST.GetObjetcAsync("api-worksorders/StatesWarranty", "3");
                            StatesWarrantyModel rw = TypeModel<StatesWarrantyModel>.DeserializeInObject(repJsonW);

                            workshop.warrantyMessage = rw.Description;
                            workshop.WarrantyId = rw.Id;

                        }
                        else
                        {
                            string repJsonW = await _clientHttpREST.GetObjetcAsync("api-worksorders/StatesWarranty", "2");
                            StatesWarrantyModel rw = TypeModel<StatesWarrantyModel>.DeserializeInObject(repJsonW);

                            workshop.warrantyMessage = rw.Description;
                            workshop.WarrantyId = rw.Id;
                        }
                    }
                    else
                    {
                        String repJson6 = await _clientHttpREST.GetObjetcsAllAsync("api-operations/TechnicalsOperations");
                        List<TechnicalOperationModel> oList = TypeModel<TechnicalOperationModel>.DeserializeInArray(repJson6);
                        var rc4 = oList.Where(y => y.Serial.Trim() == workshop.Serial.Trim()).FirstOrDefault();

                        if (rc4 != null)
                        {

                            bool InWarranty = WarrantyValidation(DateTime.Now, rc4.Operation_Date, 182);

                            if (InWarranty == false)
                            {
                                string repJsonW = await _clientHttpREST.GetObjetcAsync("api-worksorders/StatesWarranty", "3");
                                StatesWarrantyModel rw = TypeModel<StatesWarrantyModel>.DeserializeInObject(repJsonW);

                                workshop.warrantyMessage = rw.Description;
                                workshop.WarrantyId = rw.Id;
                            }
                            else
                            {
                                string repJsonW = await _clientHttpREST.GetObjetcAsync("api-worksorders/StatesWarranty", "2");
                                StatesWarrantyModel rw = TypeModel<StatesWarrantyModel>.DeserializeInObject(repJsonW);

                                workshop.warrantyMessage = rw.Description;
                                workshop.WarrantyId = rw.Id;
                            }
                        }
                        else
                        {
                            string repJsonW = await _clientHttpREST.GetObjetcAsync("api-worksorders/StatesWarranty", "0");
                            StatesWarrantyModel rw = TypeModel<StatesWarrantyModel>.DeserializeInObject(repJsonW);

                            workshop.warrantyMessage = rw.Description;
                            workshop.WarrantyId = rw.Id;
                        }
                    }



                    int replacementId = 0;
                    if (rc != null)
                    {
                        replacementId = rc.ReplacementId;
                    }
                    else
                    {
                        replacementId = workshop.Equipment;
                    }

                    var rc5 = pList.Where(y => y.id == replacementId).FirstOrDefault();



                    //data.enable = true;
                    if (rc5 != null)
                    {
                        //data.Mark = rc3.Model.Mark.name;
                        //data.Model = rc3.Model.name;
                        workshop.Product = rc5.name + " - " + rc5.Model.name + " [" + rc5.Model.Mark.name + "]";
                        //workshop.Equipment = rc.Id;
                    }
                    else
                    {
                        workshop.Product = rc.Replacement.name;
                        //workshop.Equipment = rc.Id;
                    }

                }

                if (workshop.KindEquipment == 3)
                {
                    String repJson6 = await _clientHttpREST.GetObjetcsAllAsync("api-products/Products");
                    var pList1 = TypeModel<ProductModel>.DeserializeInArray(repJson6);
                    var product = pList1.Where(p => p.Id == workshop.Equipment).FirstOrDefault();
                    workshop.Model = product.ModelId.ToString();
                }



                List<SelectListItem> lst = new List<SelectListItem>();

                lst.Add(new SelectListItem() { Text = "Domesa", Value = "Domesa" });
                lst.Add(new SelectListItem() { Text = "DHL", Value = "DHL" });
                lst.Add(new SelectListItem() { Text = "Fedex", Value = "Fedex" });
                lst.Add(new SelectListItem() { Text = "Tealca", Value = "Tealca" });
                lst.Add(new SelectListItem() { Text = "Zoom", Value = "Zoom" });

                ViewBag.Opciones = lst;

                List<SelectListItem> lst3 = new List<SelectListItem>();

                lst3.Add(new SelectListItem() { Text = "Producto", Value = "1" });
                lst3.Add(new SelectListItem() { Text = "Repuesto", Value = "2" });
                lst3.Add(new SelectListItem() { Text = "Periférico", Value = "3" });

                ViewBag.Opciones3 = lst3;

                List<SelectListItem> lst5 = new List<SelectListItem>();

                lst5.Add(new SelectListItem() { Text = "Persona", Value = "1" });
                lst5.Add(new SelectListItem() { Text = "Encomienda", Value = "0" });

                ViewBag.Opciones5 = lst5;

                List<SelectListItem> lst7 = new List<SelectListItem>();
                String json1 = await _clientHttpREST.GetObjetcsAllAsync("api-products/Models");
                List<ModelModel> model = TypeModel<ModelModel>.DeserializeInArray(json1);
                foreach (ModelModel m in model)
                {
                    lst7.Add(new SelectListItem() { Text = m.name, Value = m.id.ToString() });
                }
                ViewBag.Opciones6 = lst7;

                String json2 = await _clientHttpREST.GetObjetcAsync("api-clients/Distributors", workshop.DistributorId.ToString());
                DistributorModel distributor = TypeModel<DistributorModel>.DeserializeInObject(json2);

                workshop.rifDistributor = distributor.rif;
                workshop.Description = distributor.description;

                workshop.distributorName = distributor.represent;
                workshop.distributorPhone = distributor.phone;
                workshop.distributorAddress = distributor.address;
                workshop.distributorSeller = distributor.nameSeller;
                workshop.distributorSellerRif = distributor.rifSeller;

                String json3 = await _clientHttpREST.GetObjetcsAllAsync("api-products/Accessories");
                List<AccesoryOrderModel> accesory = TypeModel<AccesoryOrderModel>.DeserializeInArray(json3);

                workshop.lstAccesories = accesory;

                String json4 = await _clientHttpREST.GetObjetcAsync("api-worksorders/DeliveryOrder", workshop.DeliveryOrderId.ToString());

                DeliveryOrderModel delivery = TypeModel<DeliveryOrderModel>.DeserializeInObject(json4);
                workshop.LiableId = delivery.LiableId;
                workshop.LiableName = delivery.LiableName;
                workshop.LiablePhone = delivery.LiablePhone;
                workshop.DeliveryAddress = delivery.Address;
                workshop.DeliveryCompanyName = delivery.CompanyName;
                workshop.DeliveryDispatcherDate = delivery.DispatchDate;
                workshop.DeliveryGuideNumber = delivery.GuideNumber;

                if (delivery.DeliveryMode == 1)
                {
                    workshop.DeliveryMode = true;
                }
                else
                {
                    workshop.DeliveryMode = false;
                }

                workshop.DeliveryObservations = delivery.Observation;

                string repJson4 = await _clientHttpREST.GetObjetcAsync("api-worksorders/AccessoryOrder/ByOrderId", id.ToString());
                List<AccesoryOrderModel> lstAccesories2 = TypeModel<AccesoryOrderModel>.DeserializeInArray(repJson4);

                List<string> listActive = new List<string>();
                foreach (var a in lstAccesories2)
                {
                    listActive.Add(a.AccesoryId.ToString());
                }

                foreach (var a in workshop.lstAccesories)
                {
                    if (listActive.Contains(a.id.ToString()))
                    {
                        a.Selected = true;
                    }

                    /*foreach (var b in lstAccesories2)
                    {
                        if (a.id == b.AccesoryId)
                        {
                            a.Selected = true;
                        }
                    }*/

                }

                string repJson5 = await _clientHttpREST.GetObjetcAsync("api-worksorders/PhotographOrder/ByOrderId", id.ToString());
                workshop.lstPhoto = TypeModel<PhotographOrderModel>.DeserializeInArray(repJson5);



                if (workshop.Serial != "0000000000")
                {
                    workshop.Aplica = false;
                }
                else
                {
                    workshop.Aplica = true;
                    workshop.Serial = "";
                }

                if (RolId == 9)
                {
                    workshop.StateOrderName = "Por Recibir";
                }
                else
                {
                    workshop.StateOrderName = "Recibido";
                }

                String repJson1 = await _clientHttpREST.GetObjetcsAllAsync("api-worksorders/WorkshopOrder");
                List<WorkshopModel> reList1 = TypeModel<WorkshopModel>.DeserializeInArray(repJson1);
                var order_1 = reList1.Where((y => y.Serial.Trim() == workshop.Serial.Trim() && (y.StateOrderId == 11 || y.StateOrderId == 12))).FirstOrDefault();

                if (order_1 != null)
                {
                    workshop.serialRecidivist = true;
                }
                else
                {
                    workshop.serialRecidivist = false;
                }


                ViewData["RolId"] = RolId.ToString();

                return View(workshop);

            }
            catch (System.Net.Http.HttpRequestException wex)
            {
                if (wex.Message.Contains("401 (Unauthorized)"))
                {
                    var userIdentity = await _userManager.GetUserAsync(User);

                    return RedirectToAction(nameof(AccountController.LogoutForce), "Account", userIdentity);
                }
                else
                {
                    ViewBag.Message = wex.Message;

                    return View("~/Views/Shared/Error.cshtml", new ErrorViewModel { RequestId = Request.Path });
                }
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;

                return View("~/Views/Shared/Error.cshtml", new ErrorViewModel { RequestId = Request.Path });
            }
        }
        #endregion

        #region POST: Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, WorkshopModel workshop, IFormFile[] filePicture, string[] photoID)
        {
            try
            {

                var errors = ModelState.Values.SelectMany(v => v.Errors);

                string tokenValue = await this.GetTokenAccess();

                _clientHttpREST.SetToken(tokenValue);

                if (ModelState.IsValid)
                {
                    foreach (var file in filePicture)
                    {
                        var filepathPhoto =
new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Images", "taller")).Root + $@"\{file.FileName}";
                        if (System.IO.File.Exists(filepathPhoto))
                        {
                            Alert("Nombre de la foto ya existe: " + file.FileName, NotificationType.info);

                            List<SelectListItem> lst = new List<SelectListItem>();

                            lst.Add(new SelectListItem() { Text = "Domesa", Value = "Domesa" });
                            lst.Add(new SelectListItem() { Text = "DHL", Value = "DHL" });
                            lst.Add(new SelectListItem() { Text = "Fedex", Value = "Fedex" });
                            lst.Add(new SelectListItem() { Text = "Tealca", Value = "Tealca" });
                            lst.Add(new SelectListItem() { Text = "Zoom", Value = "Zoom" });

                            ViewBag.Opciones = lst;

                            List<SelectListItem> lst3 = new List<SelectListItem>();

                            lst3.Add(new SelectListItem() { Text = "Producto", Value = "1" });
                            lst3.Add(new SelectListItem() { Text = "Repuesto", Value = "2" });
                            lst3.Add(new SelectListItem() { Text = "Periférico", Value = "3" });

                            ViewBag.Opciones3 = lst3;

                            List<SelectListItem> lst5 = new List<SelectListItem>();

                            lst5.Add(new SelectListItem() { Text = "Persona", Value = "1" });
                            lst5.Add(new SelectListItem() { Text = "Encomienda", Value = "0" });

                            ViewBag.Opciones5 = lst5;

                            List<SelectListItem> lst7 = new List<SelectListItem>();
                            String json4 = await _clientHttpREST.GetObjetcsAllAsync("api-products/Models");
                            List<ModelModel> model = TypeModel<ModelModel>.DeserializeInArray(json4);
                            foreach (ModelModel m in model)
                            {
                                lst7.Add(new SelectListItem() { Text = m.name, Value = m.id.ToString() });
                            }
                            ViewBag.Opciones6 = lst7;

                            ViewData["RolId"] = RolId.ToString();

                            List<PhotographOrderModel> lst8 = new List<PhotographOrderModel>();
                            foreach (var file2 in photoID)
                            {
                                PhotographOrderModel photo = new PhotographOrderModel();
                                photo.ImageUrl = file2;
                                lst8.Add(photo);
                            }
                            workshop.lstPhoto = lst8;

                            return View(workshop);

                        }
                    }



                    DeliveryOrderModel delivery = new DeliveryOrderModel();
                    delivery.Id = workshop.DeliveryOrderId;

                    if (workshop.DeliveryMode == true)
                    {
                        delivery.DeliveryMode = 1;
                    }
                    else
                    {
                        delivery.DeliveryMode = 0;
                    }

                    delivery.DispatchDate = workshop.DeliveryDispatcherDate;
                    delivery.LiableId = workshop.LiableId;
                    delivery.LiableName = workshop.LiableName;
                    delivery.LiablePhone = workshop.LiablePhone;
                    delivery.GuideNumber = workshop.DeliveryGuideNumber;
                    delivery.CompanyName = workshop.DeliveryCompanyName;
                    delivery.Address = workshop.DeliveryAddress;
                    delivery.Observation = workshop.DeliveryObservations;
                    delivery.DispatchDate = workshop.DeliveryDispatcherDate;

                    String json = JsonConvert.SerializeObject(delivery);
                    String response = await _clientHttpREST.PutObjetcAsync("api-worksorders/DeliveryOrder", workshop.DeliveryOrderId.ToString(), json);

                    WorkshopModel w = new WorkshopModel();
                    w.Id = id;
                    w.NumerOrder = workshop.NumerOrder;
                    w.KindEquipment = workshop.KindEquipment;
                    w.Equipment = workshop.Equipment;

                    if (w.KindEquipment == 3)
                    {
                        if (workshop.Serial == null)
                        { w.Serial = "0000000000"; }
                        else
                        { w.Serial = workshop.Serial; }

                        if (workshop.Model != null)
                        {
                            //Gestionar EquimentId para Acesorio
                            String repJson3 = await _clientHttpREST.GetObjetcsAllAsync("api-products/Products");
                            var pList = TypeModel<ProductModel>.DeserializeInArray(repJson3);
                            var product = pList.Where(p => p.ModelId == int.Parse(workshop.Model)).FirstOrDefault();
                            w.Equipment = product.Id;
                        }
                    }
                    else
                    {
                        w.Serial = workshop.Serial;
                    }

                    w.WarrantyId = workshop.WarrantyId;
                    w.FirmwareVersion = null;
                    w.DeliverDate = workshop.DeliverDate;
                    w.ReceptionDate = workshop.ReceptionDate;
                    w.AlienationDate = workshop.AlienationDate;
                    w.ExpirationDate = workshop.ExpirationDate;
                    w.Address = workshop.Address;
                    w.Contact = workshop.Contact;
                    w.InsertionOrigin = 0;
                    w.WorkDone = null;
                    w.CustomerReview = workshop.CustomerReview;
                    w.ObservationTechnical = workshop.ObservationTechnical;
                    w.creation_date = workshop.creation_date;
                    w.Phone = workshop.Phone;
                    w.DistributorId = workshop.DistributorId;
                    w.TypeFailurId = workshop.TypeFailurId;
                    w.StateOrderId = workshop.StateOrderId;
                    w.DeliveryOrderId = workshop.DeliveryOrderId;
                    w.EmployeeId = workshop.EmployeeId;
                    w.ExtraObservation = workshop.ExtraObservation;

                    String json2 = JsonConvert.SerializeObject(w);
                    String respcontent = await _clientHttpREST.PutObjetcContentAndCodeAsync("api-worksorders/WorkshopOrder", id.ToString(), json2);
                    string[] resparray = respcontent.Split('|');
                    String response2 = resparray[0];

                    if (response2.Equals("NoContent"))
                    {
                        string response6 = await _clientHttpREST.GetObjetcAsync("api-worksorders/AccessoryOrder/ByOrderId", id.ToString());
                        List<AccesoryOrderModel> lstAccesories2 = TypeModel<AccesoryOrderModel>.DeserializeInArray(response6);

                        foreach (var a in lstAccesories2)
                        {
                            String response7 = await _clientHttpREST.DeleteObjetcAsync("api-worksorders/AccessoryOrder", a.id.ToString());
                        }

                        foreach (var accesory in workshop.lstAccesories)
                        {
                            if (accesory.Selected == true)
                            {
                                AccesoryOrderModel a = new AccesoryOrderModel();
                                a.AccesoryId = accesory.id;
                                a.OrderId = workshop.Id;

                                String json7 = JsonConvert.SerializeObject(a);
                                String response7 = await _clientHttpREST.PostObjetcAsync("api-worksorders/AccessoryOrder", json7);
                            }
                        }

                        string repJson = await _clientHttpREST.GetObjetcAsync("api-worksorders/PhotographOrder/ByOrderId", id.ToString());
                        List<PhotographOrderModel> listPhoto = TypeModel<PhotographOrderModel>.DeserializeInArray(repJson);

                        foreach (var a in listPhoto)
                        {
                            String response3 = await _clientHttpREST.DeleteObjetcAsync("api-worksorders/PhotographOrder", a.Id.ToString());
                        }

                        foreach (var file in photoID)
                        {
                            PhotographOrderModel photo = new PhotographOrderModel();
                            photo.OrderId = workshop.Id;
                            photo.ImageUrl = file;
                            String json4 = JsonConvert.SerializeObject(photo);
                            String response4 = await _clientHttpREST.PostObjetcAsync("api-worksorders/PhotographOrder", json4);
                        }

                        foreach (var file in filePicture)
                        {
                            if (file.Length > 0)
                            {
                                var filepath =
                new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Images", "taller")).Root + $@"\{file.FileName}";

                                using (FileStream fs = System.IO.File.Create(filepath))
                                {
                                    file.CopyTo(fs);
                                    fs.Flush();
                                }

                                PhotographOrderModel photo = new PhotographOrderModel();
                                photo.OrderId = workshop.Id;
                                photo.ImageUrl = file.FileName;
                                String json5 = JsonConvert.SerializeObject(photo);
                                String response5 = await _clientHttpREST.PostObjetcAsync("api-worksorders/PhotographOrder", json5);
                            }
                        }


                        if (RolId != 9)
                        {
                            //Agrego fila la Bitacora de esa Orden Nueva  
                            string repJson1 = await _clientHttpREST.GetObjetcsAllAsync("api-employees/Employees");
                            List<EmployeeModel> listEmployees = TypeModel<EmployeeModel>.DeserializeInArray(repJson1);

                            var employ = listEmployees.Where(d => d.email == _userManager.GetUserName(User)).FirstOrDefault();

                            string observation = "La orden fue actualizada";

                            WorkshopBinnacleModel binnacle = new WorkshopBinnacleModel();
                            binnacle.Id = 0;
                            binnacle.OrderId = id;
                            binnacle.StatusId = workshop.StateOrderId;
                            binnacle.UserId = employ.id;
                            binnacle.Observation = observation;

                            String json1 = @"{
                                    'Id': " + binnacle.Id + @",
                                    'orderId': " + binnacle.OrderId + @",    
                                    'statusId': " + binnacle.StatusId + @",
                                    'userId': " + binnacle.UserId + @",
                                    'observation':'" + binnacle.Observation + @"'
                                    }";

                            String response1 = await _clientHttpREST.PostObjetcAsync("api-worksorders/WorkshopBinnacle", json1);
                        }


                        Alert("Operación Exitosa", NotificationType.success);

                        return RedirectToAction("Index");

                    }
                    else
                    {
                        string json5 = resparray[1];
                        var responseObj = TypeModel<ResponceCode>.DeserializeInObject(json5);

                        Alert(responseObj.message, NotificationType.error);

                        ViewBag.Message = "Error en la Operación";

                        return View("~/Views/Shared/Error.cshtml", new ErrorViewModel { RequestId = Request.Path });
                    }

                }
                else
                {
                    //return RedirectToAction("Edit", new { id = id });


                    List<SelectListItem> lst = new List<SelectListItem>();

                    lst.Add(new SelectListItem() { Text = "Domesa", Value = "Domesa" });
                    lst.Add(new SelectListItem() { Text = "DHL", Value = "DHL" });
                    lst.Add(new SelectListItem() { Text = "Fedex", Value = "Fedex" });
                    lst.Add(new SelectListItem() { Text = "Tealca", Value = "Tealca" });
                    lst.Add(new SelectListItem() { Text = "Zoom", Value = "Zoom" });

                    ViewBag.Opciones = lst;

                    List<SelectListItem> lst3 = new List<SelectListItem>();

                    lst3.Add(new SelectListItem() { Text = "Producto", Value = "1" });
                    lst3.Add(new SelectListItem() { Text = "Repuesto", Value = "2" });
                    lst3.Add(new SelectListItem() { Text = "Periférico", Value = "3" });

                    ViewBag.Opciones3 = lst3;

                    List<SelectListItem> lst5 = new List<SelectListItem>();

                    lst5.Add(new SelectListItem() { Text = "Persona", Value = "1" });
                    lst5.Add(new SelectListItem() { Text = "Encomienda", Value = "0" });

                    ViewBag.Opciones5 = lst5;

                    List<SelectListItem> lst7 = new List<SelectListItem>();
                    String json1 = await _clientHttpREST.GetObjetcsAllAsync("api-products/Models");
                    List<ModelModel> model = TypeModel<ModelModel>.DeserializeInArray(json1);
                    foreach (ModelModel m in model)
                    {
                        lst7.Add(new SelectListItem() { Text = m.name, Value = m.id.ToString() });
                    }
                    ViewBag.Opciones6 = lst7;

                    string repJson5 = await _clientHttpREST.GetObjetcAsync("api-worksorders/PhotographOrder/ByOrderId", id.ToString());
                    workshop.lstPhoto = TypeModel<PhotographOrderModel>.DeserializeInArray(repJson5);

                    return View(workshop);
                }
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;

                return View("~/Views/Shared/Error.cshtml", new ErrorViewModel { RequestId = Request.Path });
            }
        }
        #endregion

        #region GET: AssignOrders
        public async Task<IActionResult> AssignOrders(string sortOrder,
                                       string currentFilter,
                                       string searchString,
                                       int? pageNumber)
        {
            if (RolId <= 3)
            {
                try
                {


                    string tokenValue = await this.GetTokenAccess();

                    _clientHttpREST.SetToken(tokenValue);

                    string respJson = await _clientHttpREST.GetObjetcsAllAsync("api-worksorders/WorkshopOrder");

                    List<WorkshopModel> listWorkshop = TypeModel<WorkshopModel>.DeserializeInArray(respJson);

                    //Filtro: Ordenes Recibidas,Asignadas,en revision y reparando

                    listWorkshop = listWorkshop.Where(o => o.StateOrderId >= 2 || o.StateOrderId <= 11).ToList();
                    
                    //Lista de Producto para casos de Accesorios
                    String repJson6 = await _clientHttpREST.GetObjetcsAllAsync("api-products/Products");
                    var pList1 = TypeModel<ProductModel>.DeserializeInArray(repJson6);

                    foreach (WorkshopModel workshopModel in listWorkshop)
                    {

                        if (workshopModel.KindEquipment == 1)
                        {

                            String repJson = await _clientHttpREST.GetObjetcAsync("api-operations/SerialsProducts/BySerial", workshopModel.Serial.ToUpper().Trim());                         
                            var rc = TypeModel<SerialProductModel>.DeserializeInObject(repJson);

                            if (rc != null)
                            {
                              workshopModel.Mark = rc.Product.Model.Mark.name;
                              workshopModel.Model = rc.Product.Model.name;
                            }
                        }

                        if (workshopModel.KindEquipment == 2)
                        {

                            String repJson = await _clientHttpREST.GetObjetcAsync("api-operations/SerialsReplacements/BySerial", workshopModel.Serial.ToUpper().Trim());                            
                            var rc = TypeModel<SerialReplacementModel>.DeserializeInObject(repJson);

                            if (rc != null)
                            {
                              workshopModel.Mark = rc.Replacement.Model.Mark.name;
                              workshopModel.Model = rc.Replacement.Model.name;
                            }
                            
                        }

                        if (workshopModel.KindEquipment == 3)
                        {
         
                            var product = pList1.Where(p => p.Id == workshopModel.Equipment).FirstOrDefault();

                            if (product != null)
                            {
                                workshopModel.Mark = product.Model.Mark.name;
                                workshopModel.Model = product.Model.name;
                                workshopModel.Product = product.Name;
                            }
                            else
                            {
                                workshopModel.Mark = "";
                                workshopModel.Model = "";
                                workshopModel.Product = "";
                            }

                        }
                    }

                    ViewData["CurrentSort"] = sortOrder;
                    ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
                    ViewData["DateSortParm"] = sortOrder == "Date" ? "date_desc" : "Date";

                    if (searchString != null)
                    {
                        pageNumber = 1;
                    }
                    else
                    {
                        searchString = currentFilter;
                    }

                    ViewData["CurrentFilter"] = searchString;

                    if (!String.IsNullOrEmpty(searchString))
                    {
                        listWorkshop = listWorkshop.Where(
                                a => a.Serial.IndexOf(searchString, StringComparison.OrdinalIgnoreCase) >= 0
                                    || a.NumerOrder.IndexOf(searchString, StringComparison.OrdinalIgnoreCase) >= 0
                                    || a.statesOrder.Description.ToString().IndexOf(searchString, StringComparison.OrdinalIgnoreCase) >= 0
                                    || a.Distributor.description.IndexOf(searchString, StringComparison.OrdinalIgnoreCase) >= 0
                                    || a.creation_date.ToString().IndexOf(searchString, StringComparison.OrdinalIgnoreCase) >= 0
                                    || a.Model.IndexOf(searchString, StringComparison.OrdinalIgnoreCase) >= 0
                                    || a.employee.description.IndexOf(searchString, StringComparison.OrdinalIgnoreCase) >= 0
                                    || a.warranty.Description.IndexOf(searchString, StringComparison.OrdinalIgnoreCase) >= 0
                                ).ToList();
                    }

                    switch (sortOrder)
                    {
                        case "name_desc":
                            listWorkshop = listWorkshop.OrderByDescending(a => a.Serial).ToList();
                            break;

                        case "Date":
                            listWorkshop = listWorkshop.OrderBy(a => a.Serial).ToList();
                            break;

                        case "date_desc":
                            listWorkshop = listWorkshop.OrderByDescending(a => a.Serial).ToList();
                            break;

                        default:
                            listWorkshop = listWorkshop.OrderBy(a => a.creation_date).ToList();
                            break;
                    }
                    int pageSize = 8;

                    ViewData["RolId"] = RolId.ToString();
                    ViewData["LevelAccess"] = LevelAccess.ToString();

                    //Cargo Select List de Empleados Tecnico de Taller
                    String json3 = await _clientHttpREST.GetObjetcsAllAsync("api-employees/Employees");
                    List<EmployeeModel> employees = TypeModel<EmployeeModel>.DeserializeInArray(json3);
                    employees = employees.Where(e => e.Chargue.rolId == 8).ToList();

                    List<SelectListItem> lst3 = new List<SelectListItem>();

                    foreach (EmployeeModel emplo in employees)
                    {
                        lst3.Add(new SelectListItem() { Text = emplo.description, Value = emplo.id.ToString() });
                    }
                    ViewBag.Opciones3 = lst3;

                    // listado de garantías
                    String respJson2 = await _clientHttpREST.GetObjetcsAllAsync("api-worksorders/StatesWarranty");
                    List<StatesWarrantyModel> lstWarranty = TypeModel<StatesWarrantyModel>.DeserializeInArray(respJson2);

                    List<SelectListItem> lst2 = new List<SelectListItem>();

                    foreach (StatesWarrantyModel wrty in lstWarranty)
                    {
                        lst2.Add(new SelectListItem() { Text = wrty.Description, Value = wrty.Id.ToString() });
                    }
                    ViewBag.Opciones2 = lst2;

                    return View(PaginatedList<WorkshopModel>.CreateAsync(listWorkshop.AsQueryable(), pageNumber ?? 1, pageSize));
                }
                catch (System.Net.Http.HttpRequestException wex)
                {
                    if (wex.Message.Contains("401 (Unauthorized)"))
                    {
                        var userIdentity = await _userManager.GetUserAsync(User);

                        return RedirectToAction(nameof(AccountController.LogoutForce), "Account", userIdentity);
                    }
                    else
                    {
                        ViewBag.Message = wex.Message;

                        return View("~/Views/Shared/Error.cshtml", new ErrorViewModel { RequestId = Request.Path });
                    }
                }
                catch (Exception ex)
                {
                    ViewBag.Message = ex.Message;

                    return View("~/Views/Shared/Error.cshtml", new ErrorViewModel { RequestId = Request.Path });
                }


            }

            {
                return RedirectToAction("AccessDenied", "Account");
            }

        }
        #endregion

        #region GET: ReviewOrders
        public async Task<IActionResult> ReviewOrders(string sortOrder,
                                       string currentFilter,
                                       string searchString,
                                       int? pageNumber)
        {
            try
            {

                string tokenValue = await this.GetTokenAccess();

                _clientHttpREST.SetToken(tokenValue);


                string respJson = await _clientHttpREST.GetObjetcsAllAsync("api-worksorders/WorkshopOrder");

                List<WorkshopModel> listWorkshop = TypeModel<WorkshopModel>.DeserializeInArray(respJson);

                //identifico el tecnico en sesion
                string repJson = await _clientHttpREST.GetObjetcsAllAsync("api-employees/Employees");
                var listEmployees = TypeModel<EmployeeModel>.DeserializeInArray(repJson);
                var employee = listEmployees.Where(e => e.email == _userManager.GetUserName(User)).FirstOrDefault();
                ViewData["employee"] = employee.description;


                // listado de garantías
                //String respJson2 = await _clientHttpREST.GetObjetcsAllAsync("api-worksorders/StatesWarranty");
                //List<StatesWarrantyModel> lstWarranty = TypeModel<StatesWarrantyModel>.DeserializeInArray(respJson2);

                //List<SelectListItem> lst = new List<SelectListItem>();

                //foreach (StatesWarrantyModel wrty in lstWarranty)
                //{
                //    lst.Add(new SelectListItem() { Text = wrty.Description, Value = wrty.Id.ToString() });
                //}
                //ViewBag.Opciones = lst;

                // Listado de status de las ordenes disponibles para un tecnico de taller
                String respJson3 = await _clientHttpREST.GetObjetcsAllAsync("api-worksorders/StatesOrder");
                List<StatesWarrantyModel> lstStatesOrder = TypeModel<StatesWarrantyModel>.DeserializeInArray(respJson3);
                List<SelectListItem> lst2 = new List<SelectListItem>();
                //lst2.Add(new SelectListItem { Text = lstStatesOrder[2].Description, Value = lstStatesOrder[2].Id.ToString() });
                lst2.Add(new SelectListItem { Text = lstStatesOrder[3].Description, Value = lstStatesOrder[3].Id.ToString() });
                lst2.Add(new SelectListItem { Text = lstStatesOrder[4].Description, Value = lstStatesOrder[4].Id.ToString() });
                lst2.Add(new SelectListItem { Text = lstStatesOrder[7].Description, Value = lstStatesOrder[7].Id.ToString() });
                lst2.Add(new SelectListItem { Text = lstStatesOrder[8].Description, Value = lstStatesOrder[8].Id.ToString() });
                lst2.Add(new SelectListItem { Text = lstStatesOrder[9].Description, Value = lstStatesOrder[9].Id.ToString() });
                ViewBag.Opciones2 = lst2;

                //Filtro: Ordenes del tecnico                                                             
                listWorkshop = listWorkshop.Where(o => o.EmployeeId == employee.id).ToList();

                //Estadisticas

                int assigned = listWorkshop.Where(a => a.statesOrder.Id == 3).Count();
                ViewData["assigned"] = assigned;

                int review = listWorkshop.Where(r => r.statesOrder.Id == 4).Count();
                ViewData["review"] = review;

                int pendingapp = listWorkshop.Where(p => p.statesOrder.Id == 5).Count();
                ViewData["pendingapp"] = pendingapp;

                int aproved = listWorkshop.Where(x => x.statesOrder.Id == 6).Count();
                ViewData["aproved"] = aproved;

                int rejected = listWorkshop.Where(y => y.statesOrder.Id == 7).Count();
                ViewData["rejected"] = rejected;

                int repairing = listWorkshop.Where(y => y.statesOrder.Id == 8).Count();
                ViewData["repairing"] = repairing;


                //Filtro: Ordenes por status de orden
                listWorkshop = listWorkshop.Where(o => o.StateOrderId == 3 || o.StateOrderId == 4 || o.StateOrderId == 5 || o.StateOrderId == 6 || o.StateOrderId == 7 || o.StateOrderId == 8).ToList();

                ViewData["CurrentSort"] = sortOrder;
                ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
                ViewData["DateSortParm"] = sortOrder == "Date" ? "date_desc" : "Date";

                if (searchString != null)
                {
                    pageNumber = 1;
                }
                else
                {
                    searchString = currentFilter;
                }

                ViewData["CurrentFilter"] = searchString;

                if (!String.IsNullOrEmpty(searchString))
                {
                    listWorkshop = listWorkshop.Where(
                           a => a.Serial.IndexOf(searchString, StringComparison.OrdinalIgnoreCase) >= 0
                               || a.NumerOrder.IndexOf(searchString, StringComparison.OrdinalIgnoreCase) >= 0
                               || a.statesOrder.Description.ToString().IndexOf(searchString, StringComparison.OrdinalIgnoreCase) >= 0
                               || a.Distributor.description.IndexOf(searchString, StringComparison.OrdinalIgnoreCase) >= 0
                               || a.ReceptionDate.ToString().IndexOf(searchString, StringComparison.OrdinalIgnoreCase) >= 0
                               || a.employee.description.ToString().IndexOf(searchString, StringComparison.OrdinalIgnoreCase) >= 0
                               || a.warranty.Description.ToString().IndexOf(searchString, StringComparison.OrdinalIgnoreCase) >= 0
                           //|| a.Model.IndexOf(searchString, StringComparison.OrdinalIgnoreCase) >= 0
                           ).ToList();
                }

                switch (sortOrder)
                {
                    case "name_desc":
                        listWorkshop = listWorkshop.OrderByDescending(a => a.Serial).ToList();
                        break;

                    case "Date":
                        listWorkshop = listWorkshop.OrderBy(a => a.Serial).ToList();
                        break;

                    case "date_desc":
                        listWorkshop = listWorkshop.OrderByDescending(a => a.Serial).ToList();
                        break;

                    default:
                        listWorkshop = listWorkshop.OrderBy(a => a.creation_date).ToList();
                        break;
                }
                int pageSize = 8;

                ViewData["RolId"] = RolId.ToString();
                ViewData["LevelAccess"] = LevelAccess.ToString();

                return View(PaginatedList<WorkshopModel>.CreateAsync(listWorkshop.AsQueryable(), pageNumber ?? 1, pageSize));
            }
            catch (System.Net.Http.HttpRequestException wex)
            {
                if (wex.Message.Contains("401 (Unauthorized)"))
                {
                    var userIdentity = await _userManager.GetUserAsync(User);

                    return RedirectToAction(nameof(AccountController.LogoutForce), "Account", userIdentity);
                }
                else
                {
                    ViewBag.Message = wex.Message;

                    return View("~/Views/Shared/Error.cshtml", new ErrorViewModel { RequestId = Request.Path });
                }
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;

                return View("~/Views/Shared/Error.cshtml", new ErrorViewModel { RequestId = Request.Path });
            }
        }
        #endregion

        #region Billing

        public async Task<IActionResult> Billing(string sortOrder,
                                       string currentFilter,
                                       string searchString,
                                       string dateBegin,
                                       string dateEnd,
                                       int? pageNumber)
        {


            if (RolId == 1 || RolId == 6 || RolId == 7)
            {

                try
                {

                    string tokenValue = await this.GetTokenAccess();

                    _clientHttpREST.SetToken(tokenValue);

                    string respJson = await _clientHttpREST.GetObjetcsAllAsync("api-worksorders/WorkshopOrder");

                    List<WorkshopModel> listWorkshop = TypeModel<WorkshopModel>.DeserializeInArray(respJson);
                    listWorkshop = listWorkshop.Where(o => o.StateOrderId == 5).ToList();

                    if (RolId == 9)
                    { //Obtengo el Distribuidor en Session
                        string repJson2 = await _clientHttpREST.GetObjetcsAllAsync("api-clients/Distributors");

                        List<DistributorModel> listDistributors = TypeModel<DistributorModel>.DeserializeInArray(repJson2);

                        var distributor = listDistributors.Where(d => d.email == _userManager.GetUserName(User)).FirstOrDefault();

                        if (distributor != null)
                        {
                            //Almaceno el Id de Distribuidor en una Variable de Sesión
                            SessionExtensions.SetInt32(_session, SessionDistributorId, distributor.id);

                            listWorkshop = listWorkshop.Where(o => o.DistributorId == distributor.id).ToList();
                        }
                    }
                    else if (RolId == 8)
                    { //Es un Tecnico de Taller filtro solo sus Asignaciones
                        string repJson = await _clientHttpREST.GetObjetcsAllAsync("api-employees/Employees");
                        var listEmployees = TypeModel<EmployeeModel>.DeserializeInArray(repJson);
                        var employee = listEmployees.Where(e => e.email == _userManager.GetUserName(User)).FirstOrDefault();
                        listWorkshop = listWorkshop.Where(o => o.EmployeeId == employee.id).ToList();
                    }

                    foreach (WorkshopModel workshopModel in listWorkshop)
                    {

                        if (workshopModel.KindEquipment == 1)
                        {
                            String repJson = await _clientHttpREST.GetObjetcsAllAsync("api-operations/SerialsProducts");
                            List<SerialProductModel> reList = TypeModel<SerialProductModel>.DeserializeInArray(repJson);
                            var rc = reList.Where(y => y.Serial.ToUpper().Trim() == workshopModel.Serial.ToUpper().Trim()).FirstOrDefault();

                            String repJson3 = await _clientHttpREST.GetObjetcsAllAsync("api-products/Products");
                            List<ProductModel> pList = TypeModel<ProductModel>.DeserializeInArray(repJson3);
                            var rc3 = pList.Where(y => y.Id == rc.ProductId).FirstOrDefault();

                            workshopModel.Mark = rc3.Model.Mark.name;
                            workshopModel.Model = rc3.Model.name;
                        }

                        if (workshopModel.KindEquipment == 2)
                        {


                            String repJson = await _clientHttpREST.GetObjetcsAllAsync("api-operations/SerialsReplacements");
                            List<SerialReplacementModel> reList = TypeModel<SerialReplacementModel>.DeserializeInArray(repJson);
                            var rc = reList.Where(y => y.Serial.ToUpper().Trim() == workshopModel.Serial.ToUpper().Trim()).FirstOrDefault();

                            String repJson3 = await _clientHttpREST.GetObjetcsAllAsync("api-products/Replacements");
                            List<ReplacementModel> pList = TypeModel<ReplacementModel>.DeserializeInArray(repJson3);

                            int replacementId = 0;
                            if (rc != null)
                            {
                                replacementId = rc.ReplacementId;
                            }
                            else
                            {
                                replacementId = workshopModel.Equipment;
                            }

                            var rc2 = pList.Where(y => y.id == replacementId).FirstOrDefault();

                            if (rc2 != null)
                            {
                                workshopModel.Mark = rc2.Model.Mark.name;
                                workshopModel.Model = rc2.Model.name;
                            }
                        }

                        if (workshopModel.KindEquipment == 3)
                        {

                            String repJson6 = await _clientHttpREST.GetObjetcsAllAsync("api-products/Products");
                            var pList1 = TypeModel<ProductModel>.DeserializeInArray(repJson6);
                            var product = pList1.Where(p => p.Id == workshopModel.Equipment).FirstOrDefault();

                            if (product != null)
                            {
                                workshopModel.Mark = product.Model.Mark.name;
                                workshopModel.Model = product.Model.name;
                                workshopModel.Product = product.Name;
                            }
                            else
                            {
                                workshopModel.Mark = "";
                                workshopModel.Model = "";
                                workshopModel.Product = "";
                            }
                        }
                    }

                    ViewData["CurrentSort"] = sortOrder;
                    ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
                    ViewData["DateSortParm"] = sortOrder == "Date" ? "date_desc" : "Date";

                    if (searchString != null)
                    {
                        pageNumber = 1;
                    }
                    else
                    {
                        searchString = currentFilter;
                    }

                    ViewData["CurrentFilter"] = searchString;

                    if (!String.IsNullOrEmpty(searchString))
                    {
                        listWorkshop = listWorkshop.Where(
                               a => a.Serial.IndexOf(searchString, StringComparison.OrdinalIgnoreCase) >= 0
                                    || a.Model.IndexOf(searchString, StringComparison.OrdinalIgnoreCase) >= 0
                                    || a.Mark.IndexOf(searchString, StringComparison.OrdinalIgnoreCase) >= 0
                                    || a.NumerOrder.IndexOf(searchString, StringComparison.OrdinalIgnoreCase) >= 0
                                    || a.statesOrder.Description.ToString().IndexOf(searchString, StringComparison.OrdinalIgnoreCase) >= 0
                                    || a.Distributor.rif.IndexOf(searchString, StringComparison.OrdinalIgnoreCase) >= 0
                                    || a.Distributor.description.IndexOf(searchString, StringComparison.OrdinalIgnoreCase) >= 0
                                    || a.Contact.IndexOf(searchString, StringComparison.OrdinalIgnoreCase) >= 0
                                    || a.Distributor.rifSeller.IndexOf(searchString, StringComparison.OrdinalIgnoreCase) >= 0
                                    || a.ReceptionDate.ToString().IndexOf(searchString, StringComparison.OrdinalIgnoreCase) >= 0
                               ).ToList();
                    }

                    ViewData["dateBegin"] = dateBegin;
                    ViewData["dateEnd"] = dateEnd;

                    if (!String.IsNullOrEmpty(dateEnd) && !String.IsNullOrEmpty(dateBegin))
                    {
                        DateTime endDate = DateTime.Parse(dateEnd);
                        endDate = new DateTime(endDate.Year, endDate.Month, endDate.Day, 23, 59, 59);

                        DateTime startDate = DateTime.Parse(dateBegin);

                        listWorkshop = listWorkshop.Where(
                                              a => a.ReceptionDate >= startDate
                                                  && a.ReceptionDate <= endDate
                                              ).ToList();
                    }

                    switch (sortOrder)
                    {
                        case "name_desc":
                            listWorkshop = listWorkshop.OrderByDescending(a => Int32.Parse(a.NumerOrder)).ToList();
                            break;

                        case "Date":
                            listWorkshop = listWorkshop.OrderBy(a => Int32.Parse(a.NumerOrder)).ToList();
                            break;

                        case "date_desc":
                            listWorkshop = listWorkshop.OrderByDescending(a => Int32.Parse(a.NumerOrder)).ToList();
                            break;

                        default:
                            listWorkshop = listWorkshop.OrderBy(a => Int32.Parse(a.NumerOrder)).ToList();
                            break;

                    }

                    int pageSize = 8;

                    ViewData["RolId"] = RolId.ToString();
                    ViewData["LevelAccess"] = LevelAccess.ToString();

                    List<SelectListItem> lst = new List<SelectListItem>();

                    lst.Add(new SelectListItem() { Text = "Presupuesto Aprobado", Value = "6" });
                    lst.Add(new SelectListItem() { Text = "Presupuesto Rechazado", Value = "7" });

                    ViewBag.Opciones = lst;

                    return View(PaginatedList<WorkshopModel>.CreateAsync(listWorkshop.AsQueryable(), pageNumber ?? 1, pageSize));

                }
                catch (System.Net.Http.HttpRequestException wex)
                {
                    if (wex.Message.Contains("401 (Unauthorized)"))
                    {
                        var userIdentity = await _userManager.GetUserAsync(User);

                        return RedirectToAction(nameof(AccountController.LogoutForce), "Account", userIdentity);
                    }
                    else
                    {
                        ViewBag.Message = wex.Message;

                        return View("~/Views/Shared/Error.cshtml", new ErrorViewModel { RequestId = Request.Path });
                    }
                }
                catch (Exception ex)
                {
                    ViewBag.Message = ex.Message;

                    return View("~/Views/Shared/Error.cshtml", new ErrorViewModel { RequestId = Request.Path });
                }

            }
            else
            {
                return RedirectToAction("AccessDenied", "Account");
            }

        }

        #endregion

        #region AllStates

        public async Task<IActionResult> AllStates(string sortOrder,
                                       string currentFilter,
                                       string searchString,
                                       string dateBegin,
                                       string dateEnd,
                                       int? pageNumber)
        {

            if (RolId == 1 || RolId == 6 || RolId == 7)
            {

                try
                {

                    string tokenValue = await this.GetTokenAccess();

                    _clientHttpREST.SetToken(tokenValue);

                    string respJson = await _clientHttpREST.GetObjetcsAllAsync("api-worksorders/WorkshopOrder");

                    List<WorkshopModel> listWorkshop = TypeModel<WorkshopModel>.DeserializeInArray(respJson);

                    if (RolId == 9)
                    { //Obtengo el Distribuidor en Session
                        string repJson2 = await _clientHttpREST.GetObjetcsAllAsync("api-clients/Distributors");

                        List<DistributorModel> listDistributors = TypeModel<DistributorModel>.DeserializeInArray(repJson2);

                        var distributor = listDistributors.Where(d => d.email == _userManager.GetUserName(User)).FirstOrDefault();

                        if (distributor != null)
                        {
                            //Almaceno el Id de Distribuidor en una Variable de Sesión
                            SessionExtensions.SetInt32(_session, SessionDistributorId, distributor.id);

                            listWorkshop = listWorkshop.Where(o => o.DistributorId == distributor.id).ToList();
                        }
                    }
                    else if (RolId == 8)
                    { //Es un Tecnico de Taller filtro solo sus Asignaciones
                        string repJson = await _clientHttpREST.GetObjetcsAllAsync("api-employees/Employees");
                        var listEmployees = TypeModel<EmployeeModel>.DeserializeInArray(repJson);
                        var employee = listEmployees.Where(e => e.email == _userManager.GetUserName(User)).FirstOrDefault();
                        listWorkshop = listWorkshop.Where(o => o.EmployeeId == employee.id).ToList();
                    }

                    foreach (WorkshopModel workshopModel in listWorkshop)
                    {

                        if (workshopModel.KindEquipment == 1)
                        {

                            String repJson = await _clientHttpREST.GetObjetcsAllAsync("api-operations/SerialsProducts");
                            List<SerialProductModel> reList = TypeModel<SerialProductModel>.DeserializeInArray(repJson);
                            var rc = reList.Where(y => y.Serial.ToUpper().Trim() == workshopModel.Serial.ToUpper().Trim()).FirstOrDefault();

                            String repJson3 = await _clientHttpREST.GetObjetcsAllAsync("api-products/Products");
                            List<ProductModel> pList = TypeModel<ProductModel>.DeserializeInArray(repJson3);
                            var rc3 = pList.Where(y => y.Id == rc.ProductId).FirstOrDefault();

                            workshopModel.Mark = rc3.Model.Mark.name;
                            workshopModel.Model = rc3.Model.name;
                        }

                        if (workshopModel.KindEquipment == 2)
                        {

                            String repJson = await _clientHttpREST.GetObjetcsAllAsync("api-operations/SerialsReplacements");
                            List<SerialReplacementModel> reList = TypeModel<SerialReplacementModel>.DeserializeInArray(repJson);
                            var rc = reList.Where(y => y.Serial.ToUpper().Trim() == workshopModel.Serial.ToUpper().Trim()).FirstOrDefault();

                            String repJson3 = await _clientHttpREST.GetObjetcsAllAsync("api-products/Replacements");
                            List<ReplacementModel> pList = TypeModel<ReplacementModel>.DeserializeInArray(repJson3);

                            int replacementId = 0;
                            if (rc != null)
                            {
                                replacementId = rc.ReplacementId;
                            }
                            else
                            {
                                replacementId = workshopModel.Equipment;
                            }

                            var rc2 = pList.Where(y => y.id == replacementId).FirstOrDefault();

                            if (rc2 != null)
                            {
                                workshopModel.Mark = rc2.Model.Mark.name;
                                workshopModel.Model = rc2.Model.name;
                            }

                        }

                        if (workshopModel.KindEquipment == 3)
                        {

                            String repJson6 = await _clientHttpREST.GetObjetcsAllAsync("api-products/Products");
                            var pList1 = TypeModel<ProductModel>.DeserializeInArray(repJson6);
                            var product = pList1.Where(p => p.Id == workshopModel.Equipment).FirstOrDefault();

                            if (product != null)
                            {
                                workshopModel.Mark = product.Model.Mark.name;
                                workshopModel.Model = product.Model.name;
                                workshopModel.Product = product.Name;
                            }
                            else
                            {
                                workshopModel.Mark = "";
                                workshopModel.Model = "";
                                workshopModel.Product = "";
                            }

                        }

                    }

                    ViewData["CurrentSort"] = sortOrder;
                    ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
                    ViewData["DateSortParm"] = sortOrder == "Date" ? "date_desc" : "Date";

                    if (searchString != null)
                    {
                        pageNumber = 1;
                    }
                    else
                    {
                        searchString = currentFilter;
                    }


                    ViewData["CurrentFilter"] = searchString;

                    if (!String.IsNullOrEmpty(searchString))
                    {
                        listWorkshop = listWorkshop.Where(
                               a => a.Serial.IndexOf(searchString, StringComparison.OrdinalIgnoreCase) >= 0
                               || a.Model.IndexOf(searchString, StringComparison.OrdinalIgnoreCase) >= 0
                               || a.Mark.IndexOf(searchString, StringComparison.OrdinalIgnoreCase) >= 0
                                   || a.NumerOrder.IndexOf(searchString, StringComparison.OrdinalIgnoreCase) >= 0
                                    || a.statesOrder.Description.ToString().IndexOf(searchString, StringComparison.OrdinalIgnoreCase) >= 0
                                    || a.Distributor.rif.IndexOf(searchString, StringComparison.OrdinalIgnoreCase) >= 0
                                    || a.Distributor.description.IndexOf(searchString, StringComparison.OrdinalIgnoreCase) >= 0
                                    || a.Contact.IndexOf(searchString, StringComparison.OrdinalIgnoreCase) >= 0
                                    || a.Distributor.rifSeller.IndexOf(searchString, StringComparison.OrdinalIgnoreCase) >= 0
                                    || a.ReceptionDate.ToString().IndexOf(searchString, StringComparison.OrdinalIgnoreCase) >= 0
                               ).ToList();
                    }


                    ViewData["dateBegin"] = dateBegin;
                    ViewData["dateEnd"] = dateEnd;


                    if (!String.IsNullOrEmpty(dateEnd) && !String.IsNullOrEmpty(dateBegin))
                    {
                        DateTime endDate = DateTime.Parse(dateEnd);
                        endDate = new DateTime(endDate.Year, endDate.Month, endDate.Day, 23, 59, 59);

                        DateTime startDate = DateTime.Parse(dateBegin);

                        listWorkshop = listWorkshop.Where(
                                              a => a.ReceptionDate >= startDate
                                                  && a.ReceptionDate <= endDate
                                              ).ToList();
                    }

                    switch (sortOrder)
                    {
                        case "name_desc":
                            listWorkshop = listWorkshop.OrderByDescending(a => Int32.Parse(a.NumerOrder)).ToList();
                            break;

                        case "Date":
                            listWorkshop = listWorkshop.OrderBy(a => Int32.Parse(a.NumerOrder)).ToList();
                            break;

                        case "date_desc":
                            listWorkshop = listWorkshop.OrderByDescending(a => Int32.Parse(a.NumerOrder)).ToList();
                            break;

                        default:
                            listWorkshop = listWorkshop.OrderBy(a => Int32.Parse(a.NumerOrder)).ToList();
                            break;

                    }

                    int pageSize = 8;

                    ViewData["RolId"] = RolId.ToString();
                    ViewData["LevelAccess"] = LevelAccess.ToString();

                    return View(PaginatedList<WorkshopModel>.CreateAsync(listWorkshop.AsQueryable(), pageNumber ?? 1, pageSize));

                }
                catch (System.Net.Http.HttpRequestException wex)
                {
                    if (wex.Message.Contains("401 (Unauthorized)"))
                    {
                        var userIdentity = await _userManager.GetUserAsync(User);

                        return RedirectToAction(nameof(AccountController.LogoutForce), "Account", userIdentity);
                    }
                    else
                    {
                        ViewBag.Message = wex.Message;

                        return View("~/Views/Shared/Error.cshtml", new ErrorViewModel { RequestId = Request.Path });
                    }
                }
                catch (Exception ex)
                {
                    ViewBag.Message = ex.Message;

                    return View("~/Views/Shared/Error.cshtml", new ErrorViewModel { RequestId = Request.Path });
                }

            }
            else
            {
                return RedirectToAction("AccessDenied", "Account");
            }

        }

        #endregion

        #region EXCEL

        [HttpGet]
        public async Task<IActionResult> ExportExcel(string searchString,
                                       string dateBegin,
                                       string dateEnd, string pageBase)
        {

            try
            {


                string tokenValue = await this.GetTokenAccess();

                _clientHttpREST.SetToken(tokenValue);

                string fileName = "Ordenes de Taller.xls";


                MemoryStream fs = new MemoryStream();
                TextWriter sw = new StreamWriter(fs);

                sw.WriteLine("<?xml version='1.0'?>");
                sw.WriteLine("<?mso-application progid='Excel.Sheet'?>");
                sw.WriteLine("<ss:Workbook xmlns:ss='urn:schemas-microsoft-com:office:spreadsheet'>");
                sw.WriteLine(" <ss:Styles>");
                sw.WriteLine(" <ss:Style ss:ID='1'>");
                sw.WriteLine(" <ss:Font ss:Bold='1'/>");
                sw.WriteLine(" </ss:Style>");
                sw.WriteLine(" </ss:Styles>");
                sw.WriteLine(" <ss:Worksheet ss:Name='REPORTE'>");
                sw.WriteLine(" <ss:Table>");

                // Establecer tamacho de las columnas y estilo

                sw.WriteLine("<ss:Column ss:Width='{0}'/>", 100);
                sw.WriteLine("<ss:Column ss:Width='{0}'/>", 150);
                sw.WriteLine("<ss:Column ss:Width='{0}'/>", 100);
                sw.WriteLine("<ss:Column ss:Width='{0}'/>", 60);
                sw.WriteLine("<ss:Column ss:Width='{0}'/>", 120);
                sw.WriteLine("<ss:Column ss:Width='{0}'/>", 90);
                sw.WriteLine("<ss:Column ss:Width='{0}'/>", 200);
                sw.WriteLine("<ss:Column ss:Width='{0}'/>", 200);
                sw.WriteLine("<ss:Column ss:Width='{0}'/>", 200);
                sw.WriteLine("<ss:Column ss:Width='{0}'/>", 200);
                sw.WriteLine("<ss:Row ss:StyleID='1'>");


                // Nombrar las columnas

                sw.WriteLine("<ss:Cell>");
                sw.WriteLine(String.Format("<ss:Data ss:Type='String'>{0}</ss:Data>", "NUMERO DE ORDEN"));
                sw.WriteLine("</ss:Cell>");
                sw.WriteLine("<ss:Cell>");
                sw.WriteLine(String.Format("<ss:Data ss:Type='String'>{0}</ss:Data>", "NRO SERIAL / NRO DE REGISTRO"));
                sw.WriteLine("</ss:Cell>");
                sw.WriteLine("<ss:Cell>");
                sw.WriteLine(String.Format("<ss:Data ss:Type='String'>{0}</ss:Data>", "MODELO"));
                sw.WriteLine("</ss:Cell>");
                sw.WriteLine("<ss:Cell>");
                sw.WriteLine(String.Format("<ss:Data ss:Type='String'>{0}</ss:Data>", "MARCA"));
                sw.WriteLine("</ss:Cell>");
                sw.WriteLine("<ss:Cell>");
                sw.WriteLine(String.Format("<ss:Data ss:Type='String'>{0}</ss:Data>", "RAZÓN SOCIAL"));
                sw.WriteLine("</ss:Cell>");
                sw.WriteLine("<ss:Cell>");
                sw.WriteLine(String.Format("<ss:Data ss:Type='String'>{0}</ss:Data>", "RIF"));
                sw.WriteLine("</ss:Cell>");
                sw.WriteLine("<ss:Cell>");
                sw.WriteLine(String.Format("<ss:Data ss:Type='String'>{0}</ss:Data>", "ESTATUS"));
                sw.WriteLine("</ss:Cell>");
                sw.WriteLine("<ss:Cell>");
                sw.WriteLine(String.Format("<ss:Data ss:Type='String'>{0}</ss:Data>", "CONTACTO"));
                sw.WriteLine("</ss:Cell>");
                sw.WriteLine("<ss:Cell>");
                sw.WriteLine(String.Format("<ss:Data ss:Type='String'>{0}</ss:Data>", "RIF VENDEDOR"));
                sw.WriteLine("</ss:Cell>");
                sw.WriteLine("<ss:Cell>");
                sw.WriteLine(String.Format("<ss:Data ss:Type='String'>{0}</ss:Data>", "FECHA DE RECEPCION"));
                sw.WriteLine("</ss:Cell>");
                sw.WriteLine("</ss:Row>");



                string respJson = await _clientHttpREST.GetObjetcsAllAsync("api-worksorders/WorkshopOrder");
                var listWorkshop = TypeModel<WorkshopModel>.DeserializeInArray(respJson);

                if (pageBase == "Billing")
                    listWorkshop = listWorkshop.Where(o => o.StateOrderId == 5).ToList();

                foreach (WorkshopModel workshopModel in listWorkshop)
                {

                    if (workshopModel.KindEquipment == 1)
                    {

                        String repJson = await _clientHttpREST.GetObjetcsAllAsync("api-operations/SerialsProducts");
                        List<SerialProductModel> reList = TypeModel<SerialProductModel>.DeserializeInArray(repJson);
                        var rc = reList.Where(y => y.Serial.ToUpper().Trim() == workshopModel.Serial.ToUpper().Trim()).FirstOrDefault();

                        String repJson3 = await _clientHttpREST.GetObjetcsAllAsync("api-products/Products");
                        List<ProductModel> pList = TypeModel<ProductModel>.DeserializeInArray(repJson3);
                        var rc3 = pList.Where(y => y.Id == rc.ProductId).FirstOrDefault();

                        workshopModel.Mark = rc3.Model.Mark.name;
                        workshopModel.Model = rc3.Model.name;
                    }

                    if (workshopModel.KindEquipment == 2)
                    {

                        String repJson = await _clientHttpREST.GetObjetcsAllAsync("api-operations/SerialsReplacements");
                        List<SerialReplacementModel> reList = TypeModel<SerialReplacementModel>.DeserializeInArray(repJson);
                        var rc = reList.Where(y => y.Serial.ToUpper().Trim() == workshopModel.Serial.ToUpper().Trim()).FirstOrDefault();

                        String repJson3 = await _clientHttpREST.GetObjetcsAllAsync("api-products/Replacements");
                        List<ReplacementModel> pList = TypeModel<ReplacementModel>.DeserializeInArray(repJson3);

                        int replacementId = 0;
                        if (rc != null)
                        {
                            replacementId = rc.ReplacementId;
                        }
                        else
                        {
                            replacementId = workshopModel.Equipment;
                        }

                        var rc2 = pList.Where(y => y.id == replacementId).FirstOrDefault();

                        if (rc2 != null)
                        {
                            workshopModel.Mark = rc2.Model.Mark.name;
                            workshopModel.Model = rc2.Model.name;
                        }

                    }

                    if (workshopModel.KindEquipment == 3)
                    {

                        String repJson6 = await _clientHttpREST.GetObjetcsAllAsync("api-products/Products");
                        var pList1 = TypeModel<ProductModel>.DeserializeInArray(repJson6);
                        var product = pList1.Where(p => p.Id == workshopModel.Equipment).FirstOrDefault();

                        if (product != null)
                        {
                            workshopModel.Mark = product.Model.Mark.name;
                            workshopModel.Model = product.Model.name;
                            workshopModel.Product = product.Name;
                        }
                        else
                        {
                            workshopModel.Mark = "";
                            workshopModel.Model = "";
                            workshopModel.Product = "";
                        }

                    }

                }


                ViewData["CurrentFilter"] = searchString;

                if (!String.IsNullOrEmpty(searchString))
                {
                    listWorkshop = listWorkshop.Where(
                           a => a.Serial.IndexOf(searchString, StringComparison.OrdinalIgnoreCase) >= 0
                           || a.Model.IndexOf(searchString, StringComparison.OrdinalIgnoreCase) >= 0
                           || a.Mark.IndexOf(searchString, StringComparison.OrdinalIgnoreCase) >= 0
                               || a.NumerOrder.IndexOf(searchString, StringComparison.OrdinalIgnoreCase) >= 0
                                || a.statesOrder.Description.ToString().IndexOf(searchString, StringComparison.OrdinalIgnoreCase) >= 0
                                || a.Distributor.rif.IndexOf(searchString, StringComparison.OrdinalIgnoreCase) >= 0
                                || a.Distributor.description.IndexOf(searchString, StringComparison.OrdinalIgnoreCase) >= 0
                                || a.Contact.IndexOf(searchString, StringComparison.OrdinalIgnoreCase) >= 0
                                || a.Distributor.rifSeller.IndexOf(searchString, StringComparison.OrdinalIgnoreCase) >= 0
                                || a.ReceptionDate.ToString().IndexOf(searchString, StringComparison.OrdinalIgnoreCase) >= 0
                           ).ToList();
                }


                ViewData["dateBegin"] = dateBegin;
                ViewData["dateEnd"] = dateEnd;


                if (!String.IsNullOrEmpty(dateEnd) && !String.IsNullOrEmpty(dateBegin))
                {
                    DateTime endDate = DateTime.Parse(dateEnd);
                    endDate = new DateTime(endDate.Year, endDate.Month, endDate.Day, 23, 59, 59);

                    DateTime startDate = DateTime.Parse(dateBegin);

                    listWorkshop = listWorkshop.Where(
                                          a => a.ReceptionDate >= startDate
                                              && a.ReceptionDate <= endDate
                                          ).ToList();
                }

                listWorkshop = listWorkshop.OrderBy(a => Int32.Parse(a.NumerOrder)).ToList();

                foreach (WorkshopModel l in listWorkshop)
                {

                    sw.WriteLine(String.Format("<ss:Row ss:Height ='{0}'>", 12));

                    sw.WriteLine("<ss:Cell>");
                    sw.WriteLine(String.Format("<ss:Data ss:Type='String'>{0}</ss:Data>", l.NumerOrder));
                    sw.WriteLine("</ss:Cell>");

                    sw.WriteLine("<ss:Cell>");
                    sw.WriteLine(String.Format("<ss:Data ss:Type='String'>{0}</ss:Data>", l.Serial));
                    sw.WriteLine("</ss:Cell>");

                    sw.WriteLine("<ss:Cell>");
                    sw.WriteLine(String.Format("<ss:Data ss:Type='String'>{0}</ss:Data>", l.Model));
                    sw.WriteLine("</ss:Cell>");

                    sw.WriteLine("<ss:Cell>");
                    sw.WriteLine(String.Format("<ss:Data ss:Type='String'>{0}</ss:Data>", l.Mark));
                    sw.WriteLine("</ss:Cell>");

                    sw.WriteLine("<ss:Cell>");
                    sw.WriteLine(String.Format("<ss:Data ss:Type='String'>{0}</ss:Data>", l.Distributor.description));
                    sw.WriteLine("</ss:Cell>");

                    sw.WriteLine("<ss:Cell>");
                    sw.WriteLine(String.Format("<ss:Data ss:Type='String'>{0}</ss:Data>", l.Distributor.rif));
                    sw.WriteLine("</ss:Cell>");

                    sw.WriteLine("<ss:Cell>");
                    sw.WriteLine(String.Format("<ss:Data ss:Type='String'>{0}</ss:Data>", l.statesOrder.Description));
                    sw.WriteLine("</ss:Cell>");

                    sw.WriteLine("<ss:Cell>");
                    sw.WriteLine(String.Format("<ss:Data ss:Type='String'>{0}</ss:Data>", l.Contact));
                    sw.WriteLine("</ss:Cell>");

                    sw.WriteLine("<ss:Cell>");
                    sw.WriteLine(String.Format("<ss:Data ss:Type='String'>{0}</ss:Data>", l.Distributor.rifSeller));
                    sw.WriteLine("</ss:Cell>");

                    sw.WriteLine("<ss:Cell>");
                    sw.WriteLine(String.Format("<ss:Data ss:Type='String'>{0}</ss:Data>", l.ReceptionDate));
                    sw.WriteLine("</ss:Cell>");

                    sw.WriteLine("</ss:Row>");

                }

                sw.WriteLine("</ss:Table>");

                sw.WriteLine("</ss:Worksheet>");

                sw.WriteLine("</ss:Workbook>");

                sw.Close();


                byte[] bytes = fs.ToArray();


                return File(bytes, "application/vnd.ms-excel", fileName);

            }
            catch (System.Net.Http.HttpRequestException wex)
            {
                if (wex.Message.Contains("401 (Unauthorized)"))
                {
                    var userIdentity = await _userManager.GetUserAsync(User);

                    return RedirectToAction(nameof(AccountController.LogoutForce), "Account", userIdentity);
                }
                else
                {
                    ViewBag.Message = wex.Message;

                    return View("~/Views/Shared/Error.cshtml", new ErrorViewModel { RequestId = Request.Path });
                }
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;

                return View("~/Views/Shared/Error.cshtml", new ErrorViewModel { RequestId = Request.Path });
            }

        }

        #endregion

        #region PDF

        [HttpGet]
        public async Task<IActionResult> ExportPDF(string searchString,
                                       string dateBegin,
                                       string dateEnd, string pageBase)
        {


            string tokenValue = await this.GetTokenAccess();
            _clientHttpREST.SetToken(tokenValue);


            MemoryStream memoryStream = new MemoryStream();
            Document document = new Document();
            PdfWriter replacementPDF = PdfWriter.GetInstance(document, memoryStream);

            document.AddTitle("Orden de Taller");
            document.Open();

            Paragraph p = new Paragraph();
            p.Add(new Phrase("                                                   Reporte de Ordenes de Taller"));
            document.Add(p);
            document.Add(Chunk.NEWLINE);
            document.Add(Chunk.NEWLINE);

            iTextSharp.text.Font _standardFont = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 7, iTextSharp.text.Font.BOLD, BaseColor.BLACK);

            PdfPTable orderTable = new PdfPTable(10);
            orderTable.WidthPercentage = 100;
            document.Add(Chunk.NEWLINE);

            PdfPCell cl1 = new PdfPCell(new Phrase("Nº DE ORDEN", _standardFont));
            cl1.BorderWidth = 0;
            cl1.BorderWidthBottom = 0.75f;

            PdfPCell cl2 = new PdfPCell(new Phrase("NRO SERIAL / NRO DE REGISTRO", _standardFont));
            cl2.BorderWidth = 0;
            cl2.BorderWidthBottom = 0.75f;

            PdfPCell cl3 = new PdfPCell(new Phrase("MODELO", _standardFont));
            cl3.BorderWidth = 0;
            cl3.BorderWidthBottom = 0.75f;

            PdfPCell cl4 = new PdfPCell(new Phrase("MARCA", _standardFont));
            cl4.BorderWidth = 0;
            cl4.BorderWidthBottom = 0.75f;

            PdfPCell cl5 = new PdfPCell(new Phrase("RAZÓN SOCIAL", _standardFont));
            cl5.BorderWidth = 0;
            cl5.BorderWidthBottom = 0.75f;

            PdfPCell cl6 = new PdfPCell(new Phrase("RIF", _standardFont));
            cl6.BorderWidth = 0;
            cl6.BorderWidthBottom = 0.75f;

            PdfPCell cl7 = new PdfPCell(new Phrase("ESTATUS", _standardFont));
            cl7.BorderWidth = 0;
            cl7.BorderWidthBottom = 0.75f;

            PdfPCell cl8 = new PdfPCell(new Phrase("CONTACTO", _standardFont));
            cl8.BorderWidth = 0;
            cl8.BorderWidthBottom = 0.75f;

            PdfPCell cl9 = new PdfPCell(new Phrase("RIF VENDEDOR", _standardFont));
            cl9.BorderWidth = 0;
            cl9.BorderWidthBottom = 0.75f;

            PdfPCell cl10 = new PdfPCell(new Phrase("FECHA DE RECEPCION", _standardFont));
            cl10.BorderWidth = 0;
            cl10.BorderWidthBottom = 0.75f;

            orderTable.AddCell(cl1);
            orderTable.AddCell(cl2);
            orderTable.AddCell(cl3);
            orderTable.AddCell(cl4);
            orderTable.AddCell(cl5);
            orderTable.AddCell(cl6);
            orderTable.AddCell(cl7);
            orderTable.AddCell(cl8);
            orderTable.AddCell(cl9);
            orderTable.AddCell(cl10);

            iTextSharp.text.Font _standardFont2 = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 8, iTextSharp.text.Font.NORMAL, BaseColor.BLACK);

            string respJson = await _clientHttpREST.GetObjetcsAllAsync("api-worksorders/WorkshopOrder");
            var listWorkshop = TypeModel<WorkshopModel>.DeserializeInArray(respJson);

            if (pageBase == "Billing")
                listWorkshop = listWorkshop.Where(o => o.StateOrderId == 5).ToList();

            foreach (WorkshopModel workshopModel in listWorkshop)
            {


                if (workshopModel.KindEquipment == 1)
                {

                    String repJson = await _clientHttpREST.GetObjetcsAllAsync("api-operations/SerialsProducts");
                    List<SerialProductModel> reList = TypeModel<SerialProductModel>.DeserializeInArray(repJson);
                    var rc = reList.Where(y => y.Serial.ToUpper().Trim() == workshopModel.Serial.ToUpper().Trim()).FirstOrDefault();

                    String repJson3 = await _clientHttpREST.GetObjetcsAllAsync("api-products/Products");
                    List<ProductModel> pList = TypeModel<ProductModel>.DeserializeInArray(repJson3);
                    var rc3 = pList.Where(y => y.Id == rc.ProductId).FirstOrDefault();

                    workshopModel.Mark = rc3.Model.Mark.name;
                    workshopModel.Model = rc3.Model.name;
                }

                if (workshopModel.KindEquipment == 2)
                {

                    String repJson = await _clientHttpREST.GetObjetcsAllAsync("api-operations/SerialsReplacements");
                    List<SerialReplacementModel> reList = TypeModel<SerialReplacementModel>.DeserializeInArray(repJson);
                    var rc = reList.Where(y => y.Serial.ToUpper().Trim() == workshopModel.Serial.ToUpper().Trim()).FirstOrDefault();

                    String repJson3 = await _clientHttpREST.GetObjetcsAllAsync("api-products/Replacements");
                    List<ReplacementModel> pList = TypeModel<ReplacementModel>.DeserializeInArray(repJson3);

                    int replacementId = 0;
                    if (rc != null)
                    {
                        replacementId = rc.ReplacementId;
                    }
                    else
                    {
                        replacementId = workshopModel.Equipment;
                    }

                    var rc2 = pList.Where(y => y.id == replacementId).FirstOrDefault();

                    if (rc2 != null)
                    {
                        workshopModel.Mark = rc2.Model.Mark.name;
                        workshopModel.Model = rc2.Model.name;
                    }

                }

                if (workshopModel.KindEquipment == 3)
                {

                    String repJson6 = await _clientHttpREST.GetObjetcsAllAsync("api-products/Products");
                    var pList1 = TypeModel<ProductModel>.DeserializeInArray(repJson6);
                    var product = pList1.Where(pr => pr.Id == workshopModel.Equipment).FirstOrDefault();

                    if (product != null)
                    {
                        workshopModel.Mark = product.Model.Mark.name;
                        workshopModel.Model = product.Model.name;
                        workshopModel.Product = product.Name;
                    }
                    else
                    {
                        workshopModel.Mark = "";
                        workshopModel.Model = "";
                        workshopModel.Product = "";
                    }

                }

            }


            ViewData["CurrentFilter"] = searchString;

            if (!String.IsNullOrEmpty(searchString))
            {
                listWorkshop = listWorkshop.Where(
                       a => a.Serial.IndexOf(searchString, StringComparison.OrdinalIgnoreCase) >= 0
                       || a.Model.IndexOf(searchString, StringComparison.OrdinalIgnoreCase) >= 0
                       || a.Mark.IndexOf(searchString, StringComparison.OrdinalIgnoreCase) >= 0
                           || a.NumerOrder.IndexOf(searchString, StringComparison.OrdinalIgnoreCase) >= 0
                            || a.statesOrder.Description.ToString().IndexOf(searchString, StringComparison.OrdinalIgnoreCase) >= 0
                            || a.Distributor.rif.IndexOf(searchString, StringComparison.OrdinalIgnoreCase) >= 0
                            || a.Distributor.description.IndexOf(searchString, StringComparison.OrdinalIgnoreCase) >= 0
                            || a.Contact.IndexOf(searchString, StringComparison.OrdinalIgnoreCase) >= 0
                            || a.Distributor.rifSeller.IndexOf(searchString, StringComparison.OrdinalIgnoreCase) >= 0
                            || a.ReceptionDate.ToString().IndexOf(searchString, StringComparison.OrdinalIgnoreCase) >= 0
                       ).ToList();
            }


            ViewData["dateBegin"] = dateBegin;
            ViewData["dateEnd"] = dateEnd;


            if (!String.IsNullOrEmpty(dateEnd) && !String.IsNullOrEmpty(dateBegin))
            {
                DateTime endDate = DateTime.Parse(dateEnd);
                endDate = new DateTime(endDate.Year, endDate.Month, endDate.Day, 23, 59, 59);

                DateTime startDate = DateTime.Parse(dateBegin);

                listWorkshop = listWorkshop.Where(
                                      a => a.ReceptionDate >= startDate
                                          && a.ReceptionDate <= endDate
                                      ).ToList();
            }


            listWorkshop = listWorkshop.OrderBy(a => Int32.Parse(a.NumerOrder)).ToList();


            foreach (WorkshopModel l in listWorkshop)
            {
                cl1 = new PdfPCell(new Phrase(l.NumerOrder, _standardFont2));
                cl1.BorderWidth = 1;

                cl2 = new PdfPCell(new Phrase(l.Serial, _standardFont2));
                cl2.BorderWidth = 1;

                cl3 = new PdfPCell(new Phrase(l.Model, _standardFont2));
                cl3.BorderWidth = 1;

                cl4 = new PdfPCell(new Phrase(l.Mark, _standardFont2));
                cl4.BorderWidth = 1;

                cl5 = new PdfPCell(new Phrase(l.Distributor.description, _standardFont2));
                cl5.BorderWidth = 1;

                cl6 = new PdfPCell(new Phrase(l.Distributor.rif, _standardFont2));
                cl6.BorderWidth = 1;

                cl7 = new PdfPCell(new Phrase(l.statesOrder.Description, _standardFont2));
                cl7.BorderWidth = 1;

                cl8 = new PdfPCell(new Phrase(l.Contact, _standardFont2));
                cl8.BorderWidth = 1;

                cl9 = new PdfPCell(new Phrase(l.Distributor.rifSeller, _standardFont2));
                cl9.BorderWidth = 1;

                cl10 = new PdfPCell(new Phrase(l.ReceptionDate.ToString(), _standardFont2));
                cl10.BorderWidth = 1;

                orderTable.AddCell(cl1);
                orderTable.AddCell(cl2);
                orderTable.AddCell(cl3);
                orderTable.AddCell(cl4);
                orderTable.AddCell(cl5);
                orderTable.AddCell(cl6);
                orderTable.AddCell(cl7);
                orderTable.AddCell(cl8);
                orderTable.AddCell(cl9);
                orderTable.AddCell(cl10);
            }

            document.Add(orderTable);
            document.Close();

            byte[] content = memoryStream.ToArray();

            return File(content, "application/pdf", "Ordenes de Taller.pdf");

        }


        #endregion

        #region
        public async Task<IActionResult> Approval(string extraObservation, int ApprovalList, int code)
        {

            try
            {

                string tokenValue = await this.GetTokenAccess();

                _clientHttpREST.SetToken(tokenValue);

                string repJson = await _clientHttpREST.GetObjetcAsync("api-worksorders/WorkshopOrder", code.ToString());
                WorkshopModel workshopModel = TypeModel<WorkshopModel>.DeserializeInObject(repJson);

                WorkshopModel w = new WorkshopModel();
                w.Id = workshopModel.Id;
                w.NumerOrder = workshopModel.NumerOrder;
                w.KindEquipment = workshopModel.KindEquipment;
                w.Equipment = workshopModel.Equipment;
                w.Serial = workshopModel.Serial;
                w.WarrantyId = workshopModel.WarrantyId;
                w.DistributorId = workshopModel.DistributorId;
                w.TypeFailurId = workshopModel.TypeFailurId;
                w.DeliveryOrderId = workshopModel.DeliveryOrderId;
                w.EmployeeId = workshopModel.EmployeeId;
                w.FirmwareVersion = workshopModel.FirmwareVersion;
                w.DeliverDate = workshopModel.DeliverDate;
                w.ReceptionDate = workshopModel.ReceptionDate;
                w.AlienationDate = workshopModel.AlienationDate;
                w.ExpirationDate = workshopModel.ExpirationDate;
                w.Address = workshopModel.Address;
                w.Contact = workshopModel.Contact;
                w.Phone = workshopModel.Phone;
                w.InsertionOrigin = workshopModel.InsertionOrigin;
                w.WorkDone = workshopModel.WorkDone;
                w.CustomerReview = workshopModel.CustomerReview;
                w.ObservationTechnical = workshopModel.ObservationTechnical;
                w.creation_date = workshopModel.creation_date;

                w.StateOrderId = ApprovalList;
                w.ExtraObservation = workshopModel.ExtraObservation;

                String json2 = JsonConvert.SerializeObject(w);
                String respcontent = await _clientHttpREST.PutObjetcContentAndCodeAsync("api-worksorders/WorkshopOrder", code.ToString(), json2);
                string[] resparray = respcontent.Split('|');
                String response2 = resparray[0];

                if (response2.Equals("NoContent"))
                {

                    if (RolId != 9)
                    {
                        //Agrego fila la Bitacora de esa Orden Nueva  
                        string repJson1 = await _clientHttpREST.GetObjetcsAllAsync("api-employees/Employees");
                        List<EmployeeModel> listEmployees = TypeModel<EmployeeModel>.DeserializeInArray(repJson1);

                        var employ = listEmployees.Where(d => d.email == _userManager.GetUserName(User)).FirstOrDefault();

                        string observation = extraObservation;

                        WorkshopBinnacleModel binnacle = new WorkshopBinnacleModel();
                        binnacle.Id = 0;
                        binnacle.OrderId = workshopModel.Id;
                        binnacle.StatusId = workshopModel.StateOrderId;
                        binnacle.UserId = employ.id;
                        binnacle.Observation = observation;

                        String json1 = @"{
                                            'Id': " + binnacle.Id + @",
                                            'orderId': " + binnacle.OrderId + @",    
                                            'statusId': " + binnacle.StatusId + @",
                                            'userId': " + binnacle.UserId + @",
                                            'observation':'" + binnacle.Observation + @"'
                                         }";

                        String response1 = await _clientHttpREST.PostObjetcAsync("api-worksorders/WorkshopBinnacle", json1);

                    }

                    Alert("Operación Exitosa", NotificationType.success);

                    return RedirectToAction("Billing");
                }
                else
                {
                    string json3 = resparray[1];
                    var responseObj = TypeModel<ResponceCode>.DeserializeInObject(json3);

                    Alert(responseObj.message, NotificationType.error);

                    ViewBag.Message = "Error en la Operación";

                    return View("~/Views/Shared/Error.cshtml", new ErrorViewModel { RequestId = Request.Path });
                }

            }
            catch (System.Net.Http.HttpRequestException wex)
            {
                if (wex.Message.Contains("401 (Unauthorized)"))
                {
                    var userIdentity = await _userManager.GetUserAsync(User);

                    return RedirectToAction(nameof(AccountController.LogoutForce), "Account", userIdentity);
                }
                else
                {
                    ViewBag.Message = wex.Message;

                    return View("~/Views/Shared/Error.cshtml", new ErrorViewModel { RequestId = Request.Path });
                }
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;

                return View("~/Views/Shared/Error.cshtml", new ErrorViewModel { RequestId = Request.Path });
            }



        }
        #endregion

        #region Ajax View Information
        public async Task<IActionResult> AjaxViewInformation(int id)
        {
            try
            {
                string tokenValue = await this.GetTokenAccess();

                _clientHttpREST.SetToken(tokenValue);

                string repJson = await _clientHttpREST.GetObjetcAsync("api-worksorders/WorkshopOrder", id.ToString());
                WorkshopModel workshopModel = TypeModel<WorkshopModel>.DeserializeInObject(repJson);

                if (workshopModel.KindEquipment == 1)
                {

                    String repJson0 = await _clientHttpREST.GetObjetcsAllAsync("api-operations/SerialsProducts");
                    List<SerialProductModel> reList = TypeModel<SerialProductModel>.DeserializeInArray(repJson0);
                    var rc = reList.Where(y => y.Serial.Trim() == workshopModel.Serial.Trim()).FirstOrDefault();

                    String repJson3 = await _clientHttpREST.GetObjetcsAllAsync("api-products/Products");
                    List<ProductModel> pList = TypeModel<ProductModel>.DeserializeInArray(repJson3);
                    var rc3 = pList.Where(y => y.Id == rc.ProductId).FirstOrDefault();

                    workshopModel.Mark = rc3.Model.Mark.name;
                    workshopModel.Model = rc3.Model.name;
                }

                if (workshopModel.KindEquipment == 2)
                {

                    String repJson2 = await _clientHttpREST.GetObjetcsAllAsync("api-operations/SerialsReplacements");
                    List<SerialReplacementModel> reList = TypeModel<SerialReplacementModel>.DeserializeInArray(repJson2);
                    var rc = reList.Where(y => y.Serial.Trim() == workshopModel.Serial.Trim()).FirstOrDefault();

                    String repJson4 = await _clientHttpREST.GetObjetcsAllAsync("api-products/Replacements");
                    List<ReplacementModel> pList = TypeModel<ReplacementModel>.DeserializeInArray(repJson4);
                    var rc3 = pList.Where(y => y.id == rc.ReplacementId).FirstOrDefault();

                    workshopModel.Mark = rc3.Model.Mark.name;
                    workshopModel.Model = rc3.Model.name;
                }


                if (workshopModel.KindEquipment == 3)
                {
                    workshopModel.Mark = "---";
                    workshopModel.Model = "---";
                }


                if (workshopModel == null)
                {
                    return Json(workshopModel);
                }

                return Json(workshopModel);
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;

                return ViewBag;
            }

        }
        #endregion

        #region GET: EditBilling
        public async Task<IActionResult> EditBilling(int id)
        {
            if (RolId == 1 || RolId == 6 || RolId == 7)
            {
                try
                {
                    if (id == 0)
                    {
                        return new StatusCodeResult((int)HttpStatusCode.BadRequest);
                    }

                    string tokenValue = await this.GetTokenAccess();

                    _clientHttpREST.SetToken(tokenValue);

                    String json = await _clientHttpREST.GetObjetcAsync("api-worksorders/WorkshopOrder", id.ToString());
                    WorkshopModel workshop = TypeModel<WorkshopModel>.DeserializeInObject(json);

                    if (workshop == null)
                    {
                        return NotFound();
                    }




                    if (workshop.KindEquipment == 1)
                    {

                        String repJson = await _clientHttpREST.GetObjetcsAllAsync("api-operations/SerialsProducts");
                        List<SerialProductModel> reList = TypeModel<SerialProductModel>.DeserializeInArray(repJson);
                        var rc = reList.Where(y => y.Serial.Trim() == workshop.Serial.Trim()).FirstOrDefault();

                        //Informacion del producto
                        String repJson3 = await _clientHttpREST.GetObjetcsAllAsync("api-products/Products");
                        List<ProductModel> pList = TypeModel<ProductModel>.DeserializeInArray(repJson3);
                        var rc3 = pList.Where(y => y.Id == rc.ProductId).FirstOrDefault();
                        bool balance = rc3.Name.ToUpper().Contains("BALANZA");


                        //Confirmar que es una balanza
                        if (balance == true)
                        {

                            bool InWarranty = WarrantyValidation(DateTime.Now, rc.DateSale, 365);

                            if (InWarranty == false)
                            {
                                string repJsonW = await _clientHttpREST.GetObjetcAsync("api-worksorders/StatesWarranty", "3");
                                StatesWarrantyModel rw = TypeModel<StatesWarrantyModel>.DeserializeInObject(repJsonW);

                                workshop.warrantyMessage = rw.Description;
                                workshop.WarrantyId = rw.Id;

                            }
                            else
                            {
                                string repJsonW = await _clientHttpREST.GetObjetcAsync("api-worksorders/StatesWarranty", "1");
                                StatesWarrantyModel rw = TypeModel<StatesWarrantyModel>.DeserializeInObject(repJsonW);

                                workshop.warrantyMessage = rw.Description;
                                workshop.WarrantyId = rw.Id;
                            }


                        }
                        else
                        {


                            String repJson2 = await _clientHttpREST.GetObjetcsAllAsync("api-operations/Alienations");
                            List<AlienationModel> aList = TypeModel<AlienationModel>.DeserializeInArray(repJson2);
                            var rc2 = aList.Where(y => y.Serial.Trim() == workshop.Serial.Trim()).FirstOrDefault();
                            if (rc2 == null)
                            {
                                string repJsonW = await _clientHttpREST.GetObjetcAsync("api-worksorders/StatesWarranty", "0");
                                StatesWarrantyModel rw = TypeModel<StatesWarrantyModel>.DeserializeInObject(repJsonW);

                                workshop.warrantyMessage = rw.Description;
                                workshop.WarrantyId = rw.Id;

                            }

                            if (rc2 != null)
                            {
                                workshop.rifFinalClient = rc2.FinalClient.Rif;
                                workshop.AlienationDate = rc2.AlienationDate;
                                workshop.BusinessName = rc2.FinalClient.Description;

                                bool InWarranty = WarrantyValidation(DateTime.Now, rc2.AlienationDate, 365);

                                if (InWarranty == false)
                                {
                                    string repJsonW = await _clientHttpREST.GetObjetcAsync("api-worksorders/StatesWarranty", "3");
                                    StatesWarrantyModel rw = TypeModel<StatesWarrantyModel>.DeserializeInObject(repJsonW);

                                    workshop.warrantyMessage = rw.Description;
                                    workshop.WarrantyId = rw.Id;
                                }
                                else
                                {
                                    string repJsonW = await _clientHttpREST.GetObjetcAsync("api-worksorders/StatesWarranty", "1");
                                    StatesWarrantyModel rw = TypeModel<StatesWarrantyModel>.DeserializeInObject(repJsonW);

                                    workshop.warrantyMessage = rw.Description;
                                    workshop.WarrantyId = rw.Id;
                                }

                            }

                        }


                        if (rc3 != null)
                        {

                            workshop.Product = rc.Product.Name + " - " + rc3.Model.name + " [" + rc3.Model.Mark.name + "]";
                            //workshop.Equipment = rc3.Id;
                        }
                        else
                        {
                            workshop.Product = rc.Product.Name;
                            //workshop.Equipment = rc.Id;
                        }
                    }

                    if (workshop.KindEquipment == 2)
                    {
                        //Confirmar serial
                        String repJson = await _clientHttpREST.GetObjetcsAllAsync("api-operations/SerialsReplacements");
                        List<SerialReplacementModel> reList = TypeModel<SerialReplacementModel>.DeserializeInArray(repJson);
                        var rc = reList.Where(y => y.Serial.Trim() == workshop.Serial.Trim()).FirstOrDefault();


                        //Confirmar informacion del repuesto
                        String repJson3 = await _clientHttpREST.GetObjetcsAllAsync("api-products/Replacements");
                        List<ReplacementModel> pList = TypeModel<ReplacementModel>.DeserializeInArray(repJson3);
                        var rc3 = pList.Where(y => y.id == rc.ReplacementId).FirstOrDefault();

                        bool memoryfiscal = rc3.name.ToUpper().Contains("MEMORIA FISCAL");


                        //Confirmar que es una memoria fiscal
                        if (memoryfiscal == true)
                        {

                            String repJsonFO = await _clientHttpREST.GetObjetcsAllAsync("api-operations/FiscalsOperations");
                            List<FiscalOperationModel> pListfo = TypeModel<FiscalOperationModel>.DeserializeInArray(repJsonFO);
                            var rcfo = pListfo.Where(y => y.serial == workshop.Serial.Trim()).FirstOrDefault();

                            bool InWarranty = WarrantyValidation(DateTime.Now, rcfo.Creation_Date, 182);

                            if (InWarranty == false)
                            {
                                string repJsonW = await _clientHttpREST.GetObjetcAsync("api-worksorders/StatesWarranty", "3");
                                StatesWarrantyModel rw = TypeModel<StatesWarrantyModel>.DeserializeInObject(repJsonW);

                                workshop.warrantyMessage = rw.Description;
                                workshop.WarrantyId = rw.Id;

                            }
                            else
                            {
                                string repJsonW = await _clientHttpREST.GetObjetcAsync("api-worksorders/StatesWarranty", "2");
                                StatesWarrantyModel rw = TypeModel<StatesWarrantyModel>.DeserializeInObject(repJsonW);

                                workshop.warrantyMessage = rw.Description;
                                workshop.WarrantyId = rw.Id;
                            }
                        }
                        else
                        {
                            String repJson6 = await _clientHttpREST.GetObjetcsAllAsync("api-operations/TechnicalsOperations");
                            List<TechnicalOperationModel> oList = TypeModel<TechnicalOperationModel>.DeserializeInArray(repJson6);
                            var rc4 = oList.Where(y => y.Serial.Trim() == workshop.Serial.Trim()).FirstOrDefault();

                            if (rc4 != null)
                            {

                                bool InWarranty = WarrantyValidation(DateTime.Now, rc4.Operation_Date, 182);

                                if (InWarranty == false)
                                {
                                    string repJsonW = await _clientHttpREST.GetObjetcAsync("api-worksorders/StatesWarranty", "3");
                                    StatesWarrantyModel rw = TypeModel<StatesWarrantyModel>.DeserializeInObject(repJsonW);

                                    workshop.warrantyMessage = rw.Description;
                                    workshop.WarrantyId = rw.Id;
                                }
                                else
                                {
                                    string repJsonW = await _clientHttpREST.GetObjetcAsync("api-worksorders/StatesWarranty", "2");
                                    StatesWarrantyModel rw = TypeModel<StatesWarrantyModel>.DeserializeInObject(repJsonW);

                                    workshop.warrantyMessage = rw.Description;
                                    workshop.WarrantyId = rw.Id;
                                }
                            }
                            else
                            {
                                string repJsonW = await _clientHttpREST.GetObjetcAsync("api-worksorders/StatesWarranty", "0");
                                StatesWarrantyModel rw = TypeModel<StatesWarrantyModel>.DeserializeInObject(repJsonW);

                                workshop.warrantyMessage = rw.Description;
                                workshop.WarrantyId = rw.Id;
                            }
                        }



                        int replacementId = 0;
                        if (rc != null)
                        {
                            replacementId = rc.ReplacementId;
                        }
                        else
                        {
                            replacementId = workshop.Equipment;
                        }

                        var rc5 = pList.Where(y => y.id == replacementId).FirstOrDefault();



                        //data.enable = true;
                        if (rc5 != null)
                        {
                            //data.Mark = rc3.Model.Mark.name;
                            //data.Model = rc3.Model.name;
                            workshop.Product = rc5.name + " - " + rc5.Model.name + " [" + rc5.Model.Mark.name + "]";
                            //workshop.Equipment = rc.Id;
                        }
                        else
                        {
                            workshop.Product = rc.Replacement.name;
                            //workshop.Equipment = rc.Id;
                        }

                    }

                    if (workshop.KindEquipment == 3)
                    {
                        String repJson6 = await _clientHttpREST.GetObjetcsAllAsync("api-products/Products");
                        var pList1 = TypeModel<ProductModel>.DeserializeInArray(repJson6);
                        var product = pList1.Where(p => p.Id == workshop.Equipment).FirstOrDefault();
                        workshop.Model = product.ModelId.ToString();
                    }




                    List<SelectListItem> lst = new List<SelectListItem>();

                    lst.Add(new SelectListItem() { Text = "Domesa", Value = "Domesa" });
                    lst.Add(new SelectListItem() { Text = "DHL", Value = "DHL" });
                    lst.Add(new SelectListItem() { Text = "Fedex", Value = "Fedex" });
                    lst.Add(new SelectListItem() { Text = "Tealca", Value = "Tealca" });
                    lst.Add(new SelectListItem() { Text = "Zoom", Value = "Zoom" });

                    ViewBag.Opciones = lst;

                    List<SelectListItem> lst3 = new List<SelectListItem>();

                    lst3.Add(new SelectListItem() { Text = "Producto", Value = "1" });
                    lst3.Add(new SelectListItem() { Text = "Repuesto", Value = "2" });
                    lst3.Add(new SelectListItem() { Text = "Periférico", Value = "3" });

                    ViewBag.Opciones3 = lst3;

                    List<SelectListItem> lst5 = new List<SelectListItem>();

                    lst5.Add(new SelectListItem() { Text = "Persona", Value = "1" });
                    lst5.Add(new SelectListItem() { Text = "Encomienda", Value = "0" });

                    ViewBag.Opciones5 = lst5;

                    List<SelectListItem> lst7 = new List<SelectListItem>();
                    String json1 = await _clientHttpREST.GetObjetcsAllAsync("api-products/Models");
                    List<ModelModel> model = TypeModel<ModelModel>.DeserializeInArray(json1);
                    foreach (ModelModel m in model)
                    {
                        lst7.Add(new SelectListItem() { Text = m.name, Value = m.id.ToString() });
                    }
                    ViewBag.Opciones6 = lst7;

                    String json2 = await _clientHttpREST.GetObjetcAsync("api-clients/Distributors", workshop.DistributorId.ToString());
                    DistributorModel distributor = TypeModel<DistributorModel>.DeserializeInObject(json2);

                    workshop.rifDistributor = distributor.rif;
                    workshop.Description = distributor.description;

                    workshop.distributorName = distributor.represent;
                    workshop.distributorPhone = distributor.phone;
                    workshop.distributorAddress = distributor.address;
                    workshop.distributorSeller = distributor.nameSeller;
                    workshop.distributorSellerRif = distributor.rifSeller;

                    String json3 = await _clientHttpREST.GetObjetcsAllAsync("api-products/Accessories");
                    List<AccesoryOrderModel> accesory = TypeModel<AccesoryOrderModel>.DeserializeInArray(json3);

                    workshop.lstAccesories = accesory;

                    String json4 = await _clientHttpREST.GetObjetcAsync("api-worksorders/DeliveryOrder", workshop.DeliveryOrderId.ToString());

                    DeliveryOrderModel delivery = TypeModel<DeliveryOrderModel>.DeserializeInObject(json4);
                    workshop.LiableId = delivery.LiableId;
                    workshop.LiableName = delivery.LiableName;
                    workshop.LiablePhone = delivery.LiablePhone;
                    workshop.DeliveryAddress = delivery.Address;
                    workshop.DeliveryCompanyName = delivery.CompanyName;
                    workshop.DeliveryDispatcherDate = delivery.DispatchDate;
                    workshop.DeliveryGuideNumber = delivery.GuideNumber;

                    if (delivery.DeliveryMode == 1)
                    {
                        workshop.DeliveryMode = true;
                    }
                    else
                    {
                        workshop.DeliveryMode = false;
                    }

                    workshop.DeliveryObservations = delivery.Observation;

                    string repJson4 = await _clientHttpREST.GetObjetcAsync("api-worksorders/AccessoryOrder/ByOrderId", id.ToString());
                    List<AccesoryOrderModel> lstAccesories2 = TypeModel<AccesoryOrderModel>.DeserializeInArray(repJson4);

                    List<string> listActive = new List<string>();
                    foreach (var a in lstAccesories2)
                    {
                        listActive.Add(a.AccesoryId.ToString());
                    }

                    foreach (var a in workshop.lstAccesories)
                    {
                        if (listActive.Contains(a.id.ToString()))
                        {
                            a.Selected = true;
                        }
                    }

                    string repJson5 = await _clientHttpREST.GetObjetcAsync("api-worksorders/PhotographOrder/ByOrderId", id.ToString());
                    workshop.lstPhoto = TypeModel<PhotographOrderModel>.DeserializeInArray(repJson5);


                    if (workshop.Serial != "0000000000")
                    {
                        workshop.Aplica = false;
                    }
                    else
                    {
                        workshop.Aplica = true;
                        workshop.Serial = "";
                    }

                    if (RolId == 9)
                    {
                        workshop.StateOrderName = "Por Recibir";
                    }
                    else
                    {
                        workshop.StateOrderName = "Recibido";
                    }


                    String repJson1 = await _clientHttpREST.GetObjetcsAllAsync("api-worksorders/WorkshopOrder");
                    List<WorkshopModel> reList1 = TypeModel<WorkshopModel>.DeserializeInArray(repJson1);
                    var order_1 = reList1.Where((y => y.Serial.Trim() == workshop.Serial.Trim() && (y.StateOrderId == 11 || y.StateOrderId == 12))).FirstOrDefault();

                    if (order_1 != null)
                    {
                        workshop.serialRecidivist = true;
                    }
                    else
                    {
                        workshop.serialRecidivist = false;
                    }


                    ViewData["RolId"] = RolId.ToString();

                    return View(workshop);


                }
                catch (System.Net.Http.HttpRequestException wex)
                {
                    if (wex.Message.Contains("401 (Unauthorized)"))
                    {
                        var userIdentity = await _userManager.GetUserAsync(User);

                        return RedirectToAction(nameof(AccountController.LogoutForce), "Account", userIdentity);
                    }
                    else
                    {
                        ViewBag.Message = wex.Message;

                        return View("~/Views/Shared/Error.cshtml", new ErrorViewModel { RequestId = Request.Path });
                    }
                }
                catch (Exception ex)
                {
                    ViewBag.Message = ex.Message;

                    return View("~/Views/Shared/Error.cshtml", new ErrorViewModel { RequestId = Request.Path });
                }


            }
            else
            {
                return RedirectToAction("AccessDenied", "Account");
            }

        }
        #endregion

        #region POST: Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditBilling(int id, WorkshopModel workshop)
        {
            try
            {

                var errors = ModelState.Values.SelectMany(v => v.Errors);

                string tokenValue = await this.GetTokenAccess();

                _clientHttpREST.SetToken(tokenValue);


                if (ModelState.IsValid)
                {

                    DeliveryOrderModel delivery = new DeliveryOrderModel();
                    delivery.Id = workshop.DeliveryOrderId;

                    if (workshop.DeliveryMode == true)
                    {
                        delivery.DeliveryMode = 1;
                    }
                    else
                    {
                        delivery.DeliveryMode = 0;
                    }

                    delivery.DispatchDate = workshop.DeliveryDispatcherDate;
                    delivery.LiableId = workshop.LiableId;
                    delivery.LiableName = workshop.LiableName;
                    delivery.LiablePhone = workshop.LiablePhone;
                    delivery.GuideNumber = workshop.DeliveryGuideNumber;
                    delivery.CompanyName = workshop.DeliveryCompanyName;
                    delivery.Address = workshop.DeliveryAddress;
                    delivery.Observation = workshop.DeliveryObservations;
                    delivery.DispatchDate = workshop.DeliveryDispatcherDate;

                    String json = JsonConvert.SerializeObject(delivery);
                    String response = await _clientHttpREST.PutObjetcAsync("api-worksorders/DeliveryOrder", workshop.DeliveryOrderId.ToString(), json);

                    if (response.Equals("NoContent"))
                    {

                        if (RolId != 9)
                        {
                            //Agrego fila la Bitacora de esa Orden Nueva  
                            string repJson1 = await _clientHttpREST.GetObjetcsAllAsync("api-employees/Employees");
                            List<EmployeeModel> listEmployees = TypeModel<EmployeeModel>.DeserializeInArray(repJson1);

                            var employ = listEmployees.Where(d => d.email == _userManager.GetUserName(User)).FirstOrDefault();

                            string observation = "El Número de Guía fue actualizado en el editar del Presupuesto";

                            WorkshopBinnacleModel binnacle = new WorkshopBinnacleModel();
                            binnacle.Id = 0;
                            binnacle.OrderId = id;
                            binnacle.StatusId = workshop.StateOrderId;
                            binnacle.UserId = employ.id;
                            binnacle.Observation = observation;

                            String json1 = @"{
                                                'Id': " + binnacle.Id + @",
                                                'orderId': " + binnacle.OrderId + @",    
                                                'statusId': " + binnacle.StatusId + @",
                                                'userId': " + binnacle.UserId + @",
                                                'observation':'" + binnacle.Observation + @"'
                                             }";

                            String response1 = await _clientHttpREST.PostObjetcAsync("api-worksorders/WorkshopBinnacle", json1);

                        }

                        Alert("Operación Exitosa", NotificationType.success);

                        return RedirectToAction("Billing");

                    }
                    else
                    {

                        ViewBag.Message = "Error en la Operación";

                        return View("~/Views/Shared/Error.cshtml", new ErrorViewModel { RequestId = Request.Path });
                    }


                }
                else
                {
                    List<SelectListItem> lst = new List<SelectListItem>();

                    lst.Add(new SelectListItem() { Text = "Domesa", Value = "Domesa" });
                    lst.Add(new SelectListItem() { Text = "DHL", Value = "DHL" });
                    lst.Add(new SelectListItem() { Text = "Fedex", Value = "Fedex" });
                    lst.Add(new SelectListItem() { Text = "Tealca", Value = "Tealca" });
                    lst.Add(new SelectListItem() { Text = "Zoom", Value = "Zoom" });

                    ViewBag.Opciones = lst;

                    List<SelectListItem> lst3 = new List<SelectListItem>();

                    lst3.Add(new SelectListItem() { Text = "Producto", Value = "1" });
                    lst3.Add(new SelectListItem() { Text = "Repuesto", Value = "2" });
                    lst3.Add(new SelectListItem() { Text = "Periférico", Value = "3" });

                    ViewBag.Opciones3 = lst3;

                    List<SelectListItem> lst5 = new List<SelectListItem>();

                    lst5.Add(new SelectListItem() { Text = "Persona", Value = "1" });
                    lst5.Add(new SelectListItem() { Text = "Encomienda", Value = "0" });

                    ViewBag.Opciones5 = lst5;

                    List<SelectListItem> lst7 = new List<SelectListItem>();
                    String json1 = await _clientHttpREST.GetObjetcsAllAsync("api-products/Models");
                    List<ModelModel> model = TypeModel<ModelModel>.DeserializeInArray(json1);
                    foreach (ModelModel m in model)
                    {
                        lst7.Add(new SelectListItem() { Text = m.name, Value = m.id.ToString() });
                    }
                    ViewBag.Opciones6 = lst7;

                    string repJson5 = await _clientHttpREST.GetObjetcAsync("api-worksorders/PhotographOrder/ByOrderId", id.ToString());
                    workshop.lstPhoto = TypeModel<PhotographOrderModel>.DeserializeInArray(repJson5);

                    return View(workshop);
                }



            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;

                return View("~/Views/Shared/Error.cshtml", new ErrorViewModel { RequestId = Request.Path });
            }
        }
        #endregion

        #region POST: WarrantyEdition
        [HttpPost]
        public async Task<IActionResult> WarrantyEdition(int id, WorkshopModel workshop, string observation)
        {
            try
            {

                string tokenValue = await this.GetTokenAccess();

                _clientHttpREST.SetToken(tokenValue);
                // verifico el id del empleado
                string repJson = await _clientHttpREST.GetObjetcsAllAsync("api-employees/Employees");
                List<EmployeeModel> listEmployees = TypeModel<EmployeeModel>.DeserializeInArray(repJson);

                var employ = listEmployees.Where(d => d.email == _userManager.GetUserName(User)).FirstOrDefault();

                string repJson1 = await _clientHttpREST.GetObjetcAsync("api-worksorders/WorkshopOrder", id.ToString());
                WorkshopModel order = TypeModel<WorkshopModel>.DeserializeInObject(repJson1);


                WorkshopModel warrantyEdit = new WorkshopModel();
                warrantyEdit.Id = order.Id;
                warrantyEdit.NumerOrder = order.NumerOrder;
                warrantyEdit.KindEquipment = order.KindEquipment;
                warrantyEdit.Equipment = order.Equipment;
                warrantyEdit.Serial = order.Serial;
                warrantyEdit.WarrantyId = workshop.WarrantyId;
                warrantyEdit.DistributorId = order.DistributorId;
                warrantyEdit.TypeFailurId = order.TypeFailurId;
                warrantyEdit.StateOrderId = order.StateOrderId;
                warrantyEdit.DeliveryOrderId = order.DeliveryOrderId;
                warrantyEdit.EmployeeId = order.EmployeeId;
                warrantyEdit.FirmwareVersion = order.FirmwareVersion;
                warrantyEdit.DeliverDate = order.DeliverDate;
                warrantyEdit.ReceptionDate = order.ReceptionDate;
                warrantyEdit.AlienationDate = order.AlienationDate;
                warrantyEdit.ExpirationDate = order.ExpirationDate;
                warrantyEdit.Address = order.Address;
                warrantyEdit.Contact = order.Contact;
                warrantyEdit.Phone = order.Phone;
                warrantyEdit.InsertionOrigin = order.InsertionOrigin;
                warrantyEdit.WorkDone = order.WorkDone;
                warrantyEdit.CustomerReview = order.CustomerReview;
                warrantyEdit.ObservationTechnical = order.ObservationTechnical;
                warrantyEdit.ExtraObservation = order.ExtraObservation;
                warrantyEdit.creation_date = order.creation_date;



                String json = JsonConvert.SerializeObject(warrantyEdit);
                String response = await _clientHttpREST.PutObjetcAsync("api-worksorders/WorkshopOrder", id.ToString(), json);

                //bandera para la bítacora
                var flag = false;

                if (response.Equals("OK") || response.Equals("NoContent"))
                {
                    //Agrego el cambio de garantía a la bitacora 

                    WorkshopBinnacleModel binnacle = new WorkshopBinnacleModel();
                    binnacle.Id = 0;
                    binnacle.OrderId = id;
                    binnacle.StatusId = order.StateOrderId;
                    binnacle.UserId = employ.id;
                    binnacle.Observation = $"Edición de Garantía: {observation}";

                    string json1 = JsonConvert.SerializeObject(binnacle);
                    string response1 = await _clientHttpREST.PostObjetcAsync("api-worksorders/WorkshopBinnacle", json1);
                    if (response1.Equals("Created"))
                    {
                        flag = true;
                    }

                }
                //validacion que la bítacora fue guardada
                if (flag)
                {
                    Alert("Operación Exitosa", NotificationType.success);
                }
                else
                {
                    Alert($"La Bítacora de la orden: {warrantyEdit.NumerOrder} No pudo ser actualizada, por favor verifique", NotificationType.warning);
                }
                return RedirectToAction("AssignOrders");

            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
                return View("~/Views/Shared/Error.cshtml", new ErrorViewModel { RequestId = Request.Path });
            }
        }

        #endregion

        #region addDaysSkillfulls
        /*
        public DateTime addDaysSkillfulls(DateTime date)
        {
            int days = 0;

            date = date.AddDays(1);

            do
            {
                DayOfWeek dayName = date.DayOfWeek;
                string[] festiveDays = { "2020-12-31", "2021-1-1", "2021-2-15", "2021-2-16", "2021-4-1", "2021-4-2", "2021-4-19" };
                string dateToday = date.Year + "-" + date.Month + "-" + date.Day;
                int index = Array.IndexOf(festiveDays, dateToday);

                if (dayName != DayOfWeek.Saturday && dayName != DayOfWeek.Sunday && Array.IndexOf(festiveDays, dateToday) == -1)
                {
                    days++;
                }

                if (days <= 14)
                {
                    date = date.AddDays(1);
                }

            } while (days <= 14);


            return date;
        }
*/
        #endregion
		
    }
}