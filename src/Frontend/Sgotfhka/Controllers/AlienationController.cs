using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Sisgtfhka.Extensions;
using Sisgtfhka.Models;
using static Sisgtfhka.Enums.Enums;

namespace Sisgtfhka.Controllers
{
    [Authorize]
    public class AlienationController : BaseController
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private ISession _session => _httpContextAccessor.HttpContext.Session;

        public AlienationController(UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            RoleManager<IdentityRole> roleManager,
            Services.ClientHttpREST clientHttpREST,
            ILogger<AccountController> logger,
            IOptions<AppSettings> settings,
            IHttpContextAccessor httpContextAccessor)
            :base(userManager, signInManager, clientHttpREST, settings)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        #region GET Alienations INDEX
        public async Task<IActionResult> Index(string sortOrder,
                                               string currentFilter,
                                               string searchString,
                                               int? pageNumber)
        {


            try
            {

                string tokenValue = await this.GetTokenAccess();

                _clientHttpREST.SetToken(tokenValue);

                string respJson = await _clientHttpREST.GetObjetcsAllAsync("api-operations/Alienations");

                List<AlienationModel> listAlienations = TypeModel<AlienationModel>.DeserializeInArray(respJson);
              
                if (!(RolId <= 7))
                {//Obtengo el Distribuidor en Session
                    string repJson2 = await _clientHttpREST.GetObjetcsAllAsync("api-clients/Distributors");

                    List<DistributorModel> listDistributors = TypeModel<DistributorModel>.DeserializeInArray(repJson2);

                    var distributor = listDistributors.Where(d => d.email == _userManager.GetUserName(User)).FirstOrDefault();

                    if (distributor != null)
                    {
                        //Almaceno el Id de Distribuidor en una Variable de Sesión
                        SessionExtensions.SetInt32(_session, SessionDistributorId, distributor.id);

                        listAlienations = listAlienations.Where(a => a.DistributorId == distributor.id).ToList();
                    }
                    else
                    {
                        listAlienations = listAlienations.Where(a => a.DistributorId == 0).ToList();
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
                    listAlienations = listAlienations.Where(
                           a => a.Serial.IndexOf(searchString, StringComparison.OrdinalIgnoreCase) >= 0
                            || a.Status.IndexOf(searchString, StringComparison.OrdinalIgnoreCase) >= 0
                            || a.AlienationDate.ToString().IndexOf(searchString, StringComparison.OrdinalIgnoreCase) >= 0
                        || a.Provider.rif.IndexOf(searchString, StringComparison.OrdinalIgnoreCase) >= 0
                        || a.Distributor.description.IndexOf(searchString, StringComparison.OrdinalIgnoreCase) >= 0
                        || a.FinalClient.Description.IndexOf(searchString, StringComparison.OrdinalIgnoreCase) >= 0
                         || a.Distributor.rif.IndexOf(searchString, StringComparison.OrdinalIgnoreCase) >= 0
                        || a.FinalClient.Rif.IndexOf(searchString, StringComparison.OrdinalIgnoreCase) >= 0
                        ).ToList();
                }

                switch (sortOrder)
                {
                    case "name_desc":
                        listAlienations = listAlienations.OrderByDescending(a => a.Serial).ToList();
                        break;

                    case "Date":
                        listAlienations = listAlienations.OrderBy(a => a.Serial).ToList();
                        break;

                    case "date_desc":
                        listAlienations = listAlienations.OrderByDescending(a => a.Serial).ToList();
                        break;

                    default:
                        listAlienations = listAlienations.OrderBy(a => a.Serial).ToList();
                        break;

                }

                int pageSize = 8;

                ViewData["RolId"] = RolId.ToString();
                ViewData["LevelAccess"] = LevelAccess.ToString();

                return View(PaginatedList<AlienationModel>.CreateAsync(listAlienations.AsQueryable(), pageNumber ?? 1, pageSize));

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

        #region GET DETAILS
        public async Task<IActionResult> Details(int id)
        {
            try
            {
                string tokenValue = await this.GetTokenAccess();

                _clientHttpREST.SetToken(tokenValue);

                string repJson = await _clientHttpREST.GetObjetcAsync("api-operations/Alienations", id.ToString());

                AlienationModel alienation = TypeModel<AlienationModel>.DeserializeInObject(repJson);

                return View(alienation);
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

        #region Encontrar RIF
        [HttpPost]
        public async Task<IActionResult> FindFinalClientRif(AlienationModel alien)
        {
            try
            {
                string tokenValue = await this.GetTokenAccess();

                _clientHttpREST.SetToken(tokenValue);

                String repJson = await _clientHttpREST.GetObjetcsAllAsync("api-clients/FinalsClients");
                List<FinalsClientsModel> listFinals = TypeModel<FinalsClientsModel>.DeserializeInArray(repJson);
                var clienFinal = listFinals.Where(f => f.Rif == alien.FinalClient.Rif).FirstOrDefault();

                if (clienFinal == null)
                {
                    return RedirectToAction("Create", "Alienation", new { descClientFinal = "", rif = alien.FinalClient.Rif});
                }
                else
                {
                    return RedirectToAction("Create", "Alienation", new { descClientFinal = clienFinal.Description, rif = clienFinal.Rif });
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

        #region Encontrar RIF 2
        [HttpPost]
        public async Task<IActionResult> FindFinalClientRif2(string rif)
        {

            try
            {
                string tokenValue = await this.GetTokenAccess();

                _clientHttpREST.SetToken(tokenValue);

                String repJson = await _clientHttpREST.GetObjetcsAllAsync("api-clients/FinalsClients");
                List<FinalsClientsModel> listFinals = TypeModel<FinalsClientsModel>.DeserializeInArray(repJson);
                var clienFinal = listFinals.Where(f => f.Rif == rif).FirstOrDefault();

                AlienationModel alien = new AlienationModel();


                if (clienFinal == null)
                {
                    return Json(alien);
                }
                else
                {

                    alien.FinalClient = clienFinal;
                    alien.FinalClientId = clienFinal.Id;

                    return Json(alien);
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

        #region GET CREATE
        [HttpGet]
        public async Task<IActionResult> Create(string descClientFinal, string rif)
        {
            try
            {

                string tokenValue = await this.GetTokenAccess();

                _clientHttpREST.SetToken(tokenValue);

                AlienationModel al = new AlienationModel();
                al.FinalClient = new FinalsClientsModel();
                al.AlienationDate = DateTime.Now;
                al.DistributorId = DistributorId != null ? (int)DistributorId : 0;

                if (descClientFinal == null)
                {
                    ViewData["Rif_New"] = rif;
                                 
                }
                else
                {
                    String repJson2 = await _clientHttpREST.GetObjetcsAllAsync("api-clients/FinalsClients");
                    List<FinalsClientsModel> fcList = TypeModel<FinalsClientsModel>.DeserializeInArray(repJson2);
                    var finalClient = fcList.Where(fc =>fc.Rif == rif).FirstOrDefault();
                    al.AlienationDate = DateTime.Now;

                    if (finalClient == null)
                    {
                        al.FinalClient.Rif = rif;
                        al.FinalClient.Description = descClientFinal;
                    }
                    else
                    {
                        al.FinalClient.Rif = finalClient.Rif;
                        al.FinalClient.Description = finalClient.Description;
                        al.FinalClientId = finalClient.Id;
                    }

                }

                return View(al);

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

        #region POST CREATE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AlienationModel collection)
        {

            try
            {
                string tokenValue = await this.GetTokenAccess();

                _clientHttpREST.SetToken(tokenValue);

                String repJson2 = await _clientHttpREST.GetObjetcsAllAsync("api-operations/SerialsProducts");
                List<SerialProductModel> spList = TypeModel<SerialProductModel>.DeserializeInArray(repJson2);
                var serialProd = spList.Where(fc => fc.Serial == collection.Serial).FirstOrDefault();


                if (serialProd == null)
                {
                    collection.ProviderId = 1;
                    collection.DistributorId = 1;               
                }
                else
                {
                    collection.ProviderId = serialProd.ProviderId;
                    if (RolId <= 7)
                    { collection.DistributorId = serialProd.DistributorId; }
                }

                collection.Status = "PROCESADO";
                String json = JsonConvert.SerializeObject(collection);

                String response = await _clientHttpREST.PostObjetcContentAndCodeAsync("api-operations/Alienations", json);

                var strarry = response.Split('|');

                string codeHttp = strarry[0];
                string content = strarry[1];

                if (codeHttp.Equals("Created"))
                {
                    Alert("Operación Exitosa", NotificationType.success);

                    return RedirectToAction("Index");
                }
                else
                {
                    String repJson = await _clientHttpREST.GetObjetcAsync("api-clients/FinalsClients", collection.FinalClientId.ToString());
                    collection.FinalClient = TypeModel<FinalsClientsModel>.DeserializeInObject(repJson);
                   
                    Alert(content, NotificationType.error);

                    return View(collection);
                }


            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;

                return View("~/Views/Shared/Error.cshtml", new ErrorViewModel { RequestId = Request.Path });
            }
        }

        #endregion

        #region GET EDIT
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {

            try
            {
                string tokenValue = await this.GetTokenAccess();

                _clientHttpREST.SetToken(tokenValue);

                if (id == 0)
                {
                    return new StatusCodeResult((int)HttpStatusCode.BadRequest);
                }


                    String json = await _clientHttpREST.GetObjetcAsync("api-operations/Alienations", id.ToString());
                    AlienationModel alienation = TypeModel<AlienationModel>.DeserializeInObject(json);

                    if (alienation == null)
                    {
                        return NotFound();
                    }

                    return View(alienation);
                
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
                return View("~/Views/Shared/Error.cshtml", new ErrorViewModel { RequestId = Request.Path });
            }

        }

        #endregion

        #region POST EDIT
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, AlienationModel alienation)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    string tokenValue = await this.GetTokenAccess();

                    _clientHttpREST.SetToken(tokenValue);

                    String json = JsonConvert.SerializeObject(alienation);

                    String response = await _clientHttpREST.PutObjetcContentAndCodeAsync("api-operations/Alienations", alienation.Id.ToString(), json);

                    var strarry = response.Split('|');

                    string codeHttp = strarry[0];
                    string content = strarry[1];

                    if (codeHttp.Equals("NoContent"))
                    {
                        Alert("Operación Exitosa", NotificationType.success);

                        return RedirectToAction("Index");
                    }
                    else
                    {
                        Alert(content, NotificationType.error);

                        String repJson = await _clientHttpREST.GetObjetcAsync("api-clients/FinalsClients", alienation.FinalClientId.ToString());
                        alienation.FinalClient = TypeModel<FinalsClientsModel>.DeserializeInObject(repJson);

                        return View(alienation);
                    }

                }
                else
                {
                    return View(alienation);
                }
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;

                return View("~/Views/Shared/Error.cshtml", new ErrorViewModel { RequestId = Request.Path });
            }
        }

        #endregion

        #region GET DELETE
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

                String json = await _clientHttpREST.GetObjetcAsync("api-operations/Alienations", id.ToString());

                AlienationModel alienation = TypeModel<AlienationModel>.DeserializeInObject(json);

                if (alienation == null)
                {
                    return NotFound();
                }

                return View(alienation);
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

        #region POST DELETE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, AlienationModel collection)
        {

            try
            {
                string tokenValue = await this.GetTokenAccess();

                _clientHttpREST.SetToken(tokenValue);

                var nameUser = _userManager.GetUserName(User);
                String json = @"{   'username':'" + nameUser + @"',
                                        'password':'" + collection.Verificador + @"'
                                    }";

                String response1 = await _clientHttpREST.PostObjetcContentAsync("api-access/Login", json);

                TokenStruct tokenObj = TypeModel<TokenStruct>.DeserializeInObject(response1);

                if (tokenObj == null)
                {
                    return View(collection);
                }

                if (tokenObj.authenticated)
                {

                    String response = await _clientHttpREST.DeleteObjetcAsync("api-operations/Alienations", id.ToString());

                    if (response.Equals("OK"))
                    {
                        //Determino si el Borrado lo hizo un Empleado para Registrar el Evento

                        string repJson = await _clientHttpREST.GetObjetcsAllAsync("api-employees/Employees");
                        List<EmployeeModel> listEmployees = TypeModel<EmployeeModel>.DeserializeInArray(repJson);
                        var employee = listEmployees.Where(e => e.email == nameUser).FirstOrDefault();

                        if(employee != null)
                        { //Alimento el Registro de Actividades
                            var activity = new ActivityModel();
                            activity.EmployeeId = employee.id;
                            activity.ChargueId = employee.chargueId;
                            activity.DepartamentId = employee.departamentId;
                            activity.Process = "Enajenaciones";
                            activity.Operation = "Borrado";
                            activity.Serial = collection.Serial;
                            activity.Detail = "Tramitado interno";

                            String json1 = JsonConvert.SerializeObject(activity);

                            String response2 = await _clientHttpREST.PostObjetcAsync("api-operations/Activities", json1);
                        }

                        Alert("Operación Exitosa", Enums.Enums.NotificationType.success);

                        return RedirectToAction("Index");
                    }
                    else
                    {
                        Alert("Error en la Operación", Enums.Enums.NotificationType.error);

                        ViewBag.Message = response;

                        return View("~/Views/Shared/Error.cshtml", new ErrorViewModel { RequestId = Request.Path });
                    }
                }
                else
                {
                    String json2 = await _clientHttpREST.GetObjetcAsync("api-operations/Alienations", id.ToString());
                    string key = collection.Verificador;
                    collection = TypeModel<AlienationModel>.DeserializeInObject(json2);
                    collection.Verificador = key;

                    ViewBag.Message = "Clave Errada";

                    return View(collection);
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
    }
}