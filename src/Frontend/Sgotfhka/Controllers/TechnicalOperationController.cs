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
    public class TechnicalOperationController : BaseController
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private ISession _session => _httpContextAccessor.HttpContext.Session;

        public TechnicalOperationController(UserManager<ApplicationUser> userManager,
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

        #region GET: TechnicalsOperations INDEX
        public async Task<IActionResult> Index(string sortOrder,
                                               string currentFilter,
                                               string searchString,
                                               int? pageNumber)
        {
            try
            {
                string tokenValue = await this.GetTokenAccess();

                _clientHttpREST.SetToken(tokenValue);

                string respJson = await _clientHttpREST.GetObjetcsAllAsync("api-operations/TechnicalsOperations");

                List<TechnicalOperationModel> listTechnicalsOperations = TypeModel<TechnicalOperationModel>.DeserializeInArray(respJson);

                if (!(RolId <= 7))
                {//Compruebo si es Distribuidor en Session
                    string repJson2 = await _clientHttpREST.GetObjetcsAllAsync("api-clients/Distributors");

                    List<DistributorModel> listDistributors = TypeModel<DistributorModel>.DeserializeInArray(repJson2);

                    var distributor = listDistributors.Where(d => d.email == _userManager.GetUserName(User)).FirstOrDefault();

                    if (distributor != null)
                    {
                        SessionExtensions.SetInt32(_session, SessionDistributorId, distributor.id);

                        listTechnicalsOperations = listTechnicalsOperations.Where(a => a.DistributorId == distributor.id).ToList();
                    }
                    else
                    {//Determino si es un Tecnico de Centro de Servicio
                        string repJson3 = await _clientHttpREST.GetObjetcsAllAsync("api-clients/Technicians");

                        List<TechnicianModel> listTechnicians = TypeModel<TechnicianModel>.DeserializeInArray(repJson3);
                        var technical = listTechnicians.Where(t => t.email == _userManager.GetUserName(User)).FirstOrDefault();
                        if (technical != null)
                        { //Almaceno el Id de Tecnico de Centro d Servicio en una Variable de Sesión
                            SessionExtensions.SetInt32(_session, SessionTechnicalId, technical.id);
                            List<TechnicalOperationModel> listTechnicalsOperationsTemp = new List<TechnicalOperationModel>();
                            listTechnicalsOperationsTemp.Clear();
                            //Escatimamos su Operaciones con sus Distribuidores Padres
                            string repJson4 = await _clientHttpREST.GetObjetcsAllAsync("api-clients/Technicians/" + technical.id.ToString() + "/Distributors");

                            List<DistributorModel> listDistributorsRelat = TypeModel<DistributorModel>.DeserializeInArray(repJson4);

                            foreach (DistributorModel dist in listDistributorsRelat)
                            {
                                var operations = listTechnicalsOperations.Where(o => o.TechnicianId == technical.id && o.DistributorId == dist.id).ToList();

                                foreach (TechnicalOperationModel oper in operations)
                                {
                                    listTechnicalsOperationsTemp.Add(oper);
                                }
                            }

                            listTechnicalsOperations = listTechnicalsOperationsTemp;
                        }
                        else
                        {
                            listTechnicalsOperations = listTechnicalsOperations.Where(a => a.DistributorId == 0).ToList();
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
                    listTechnicalsOperations = listTechnicalsOperations.Where(
                           a => a.Serial.IndexOf(searchString, StringComparison.OrdinalIgnoreCase) >= 0
                        || a.Status.IndexOf(searchString, StringComparison.OrdinalIgnoreCase) >= 0
                        || a.Operation_Date.ToString().IndexOf(searchString, StringComparison.OrdinalIgnoreCase) >= 0
                        || a.Provider.rif.IndexOf(searchString, StringComparison.OrdinalIgnoreCase) >= 0
                        || a.Distributor.description.IndexOf(searchString, StringComparison.OrdinalIgnoreCase) >= 0
                        || a.FinalClient.Description.IndexOf(searchString, StringComparison.OrdinalIgnoreCase) >= 0
                        || a.Technician.description.IndexOf(searchString, StringComparison.OrdinalIgnoreCase) >= 0
                        || a.Technician.rif.IndexOf(searchString, StringComparison.OrdinalIgnoreCase) >= 0
                        || a.Distributor.rif.IndexOf(searchString, StringComparison.OrdinalIgnoreCase) >= 0
                        || a.FinalClient.Rif.IndexOf(searchString, StringComparison.OrdinalIgnoreCase) >= 0
                        || a.TypeOperationTech.Description.IndexOf(searchString, StringComparison.OrdinalIgnoreCase) >= 0
                        ).ToList();
                }

                switch (sortOrder)
                {
                    case "name_desc":
                        listTechnicalsOperations = listTechnicalsOperations.OrderByDescending(a => a.Serial).ToList();
                        break;

                    case "Date":
                        listTechnicalsOperations = listTechnicalsOperations.OrderBy(a => a.Serial).ToList();
                        break;

                    case "date_desc":
                        listTechnicalsOperations = listTechnicalsOperations.OrderByDescending(a => a.Serial).ToList();
                        break;

                    default:
                        listTechnicalsOperations = listTechnicalsOperations.OrderBy(a => a.Serial).ToList();
                        break;
                }

                int pageSize = 8;

                ViewData["RolId"] = RolId.ToString();
                ViewData["LevelAccess"] = LevelAccess.ToString();

                return View(PaginatedList<TechnicalOperationModel>.CreateAsync(listTechnicalsOperations.AsQueryable(), pageNumber ?? 1, pageSize));
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

        #region GET: TechnicalsOperations CREATE
        [HttpGet]
        public async Task<IActionResult> Create(string descClientFinal, string rif)
        {
            try
            {
                string tokenValue = await this.GetTokenAccess();

                _clientHttpREST.SetToken(tokenValue);

                TechnicalOperationModel to = new TechnicalOperationModel();
                to.FinalClient = new FinalsClientsModel();
                to.Operation_Date = DateTime.Now;
                to.DistributorId = DistributorId != null ? (int)DistributorId : 0;
                to.TechnicianId = TechnicalId != null ? (int)TechnicalId : 0;

                if(to.TechnicianId != 0)
                {
                    string repJson = await _clientHttpREST.GetObjetcAsync("api-clients/Technicians", to.TechnicianId.ToString());
                    var technician = TypeModel<TechnicianModel>.DeserializeInObject(repJson);
                    to.rifTechnician = technician.rif;
                }

                if (descClientFinal == null)
                {
                    ViewData["Rif_New"] = rif;
                }
                else
                {
                    String repJson2 = await _clientHttpREST.GetObjetcsAllAsync("api-clients/FinalsClients");
                    List<FinalsClientsModel> fcList = TypeModel<FinalsClientsModel>.DeserializeInArray(repJson2);
                    var finalClient = fcList.Where(fc => fc.Rif == rif).FirstOrDefault();
                    to.Operation_Date = DateTime.Now;

                    if (finalClient == null)
                    {
                        to.FinalClient.Rif = rif;
                        to.FinalClient.Description = descClientFinal;
                    }
                    else
                    {
                        to.FinalClient.Rif = finalClient.Rif;
                        to.FinalClient.Description = finalClient.Description;
                        to.FinalClientId = finalClient.Id;
                    }
                }

                //Cargo las 9 Operaciones Permitidas
                List<SelectListItem> lst = new List<SelectListItem>();
            
                lst.Add(new SelectListItem() { Text = "INSPECCIÓN ANUAL", Value = "2" });
                lst.Add(new SelectListItem() { Text = "REPARACIÓN", Value = "3" });
                lst.Add(new SelectListItem() { Text = "ADAPTACIÓN", Value = "4" });
                lst.Add(new SelectListItem() { Text = "SUSTITUCIÓN DE MEMORIA FISCAL", Value = "5" });
                lst.Add(new SelectListItem() { Text = "SUSTITUCIÓN DE MEMORIA DE AUDITORÍA", Value = "6" });
                lst.Add(new SelectListItem() { Text = "ALTERACIÓN Ó REMOCIÓN DE DISPOSITIVOS DE SEGURIDAD", Value = "7" });
                lst.Add(new SelectListItem() { Text = "REPORTE DE PÉRDIDA Ó ROBO POR PARTE DEL DISTRIBUIDOR", Value = "8" });
                lst.Add(new SelectListItem() { Text = "REPORTE PÉDIDA Ó ROBO POR PARTE DEL USUARIO", Value = "9" });
                lst.Add(new SelectListItem() { Text = "DESINCORPORACIÓN", Value = "10" });

                ViewBag.Opciones = lst;
                ViewData["RolId"] = RolId;

                return View(to);
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

        #region TechnicalsOperations FindFinalClientRif
        [HttpPost]
        public async Task<IActionResult> FindFinalClientRif(TechnicalOperationModel techn)
        {
            try
            {
                string tokenValue = await this.GetTokenAccess();

                _clientHttpREST.SetToken(tokenValue);

                String repJson = await _clientHttpREST.GetObjetcsAllAsync("api-clients/FinalsClients");
                List<FinalsClientsModel> listFinals = TypeModel<FinalsClientsModel>.DeserializeInArray(repJson);
                var clienFinal = listFinals.Where(f => f.Rif == techn.FinalClient.Rif).FirstOrDefault();
                
                if (clienFinal == null)
                {
                    return RedirectToAction("Create", "TechnicalOperation", new { descClientFinal = "", rif = techn.FinalClient.Rif });
                }
                else
                {
                    return RedirectToAction("Create", "TechnicalOperation", new { descClientFinal = clienFinal.Description, rif = clienFinal.Rif });
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

        #region TechnicalsOperations FindFinalClientRif2
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

                TechnicalOperationModel techn = new TechnicalOperationModel();
                if (clienFinal == null)
                {
                    return Json(techn);
                }
                else
                {
                    techn.FinalClient = clienFinal;
                    techn.FinalClientId = clienFinal.Id;

                    return Json(techn);
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

        #region POST: TechnicalsOperations CREATE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TechnicalOperationModel collection)
        {
            try
            {
                string tokenValue = await this.GetTokenAccess();

                _clientHttpREST.SetToken(tokenValue);

                string msjErrorSerialRep = string.Empty;
                bool isSerialRepValid = true;
                SerialReplacementModel replacement = null;

                if (collection.Aplica == false && collection.SerialRepuesto == null)
                {
                    isSerialRepValid = false;
                    msjErrorSerialRep = "Debe asignar un valor a Serial de Repuesto";                  
                }
                else if(collection.SerialRepuesto != null)
                {
                    //Valido en Seriales Vendidos de Repuestos
                    string repJson1 = await _clientHttpREST.GetObjetcAsync("api-operations/SerialsReplacements/BySerial", collection.SerialRepuesto);

                    replacement = TypeModel<SerialReplacementModel>.DeserializeInObject(repJson1);

                    if(replacement == null)
                    {
                        isSerialRepValid = false;
                        msjErrorSerialRep = "No se encontra el Serial de Repuesto en el inventario de venta";
                    }else
                    { //Verifico si se ha utilizado en una intervencion tecnica
                        string repJson3 = await _clientHttpREST.GetObjetcAsync("api-operations/ReplacementsOpeTechs/BySerial", collection.SerialRepuesto);

                        if(repJson3 != "")
                        {
                            isSerialRepValid = false;
                            msjErrorSerialRep = "El Serial de Repuesto ya esta ultilizado en una Intervencion Tecnica";
                        }

                    }

                }

                if(!isSerialRepValid)
                {
                    String repJson = await _clientHttpREST.GetObjetcAsync("api-clients/FinalsClients", collection.FinalClientId.ToString());
                    collection.FinalClient = TypeModel<FinalsClientsModel>.DeserializeInObject(repJson);

                    //Cargo las 9 Operaciones Permitidas
                    List<SelectListItem> lst = new List<SelectListItem>();

                    lst.Add(new SelectListItem() { Text = "INSPECCIÓN ANUAL", Value = "2" });
                    lst.Add(new SelectListItem() { Text = "REPARACIÓN", Value = "3" });
                    lst.Add(new SelectListItem() { Text = "ADAPTACIÓN", Value = "4" });
                    lst.Add(new SelectListItem() { Text = "SUSTITUCIÓN DE MEMORIA FISCAL", Value = "5" });
                    lst.Add(new SelectListItem() { Text = "SUSTITUCIÓN DE MEMORIA DE AUDITORÍA", Value = "6" });
                    lst.Add(new SelectListItem() { Text = "ALTERACIÓN Ó REMOCIÓN DE DISPOSITIVOS DE SEGURIDAD", Value = "7" });
                    lst.Add(new SelectListItem() { Text = "REPORTE DE PÉRDIDA Ó ROBO POR PARTE DEL DISTRIBUIDOR", Value = "8" });
                    lst.Add(new SelectListItem() { Text = "REPORTE PÉDIDA Ó ROBO POR PARTE DEL USUARIO", Value = "9" });
                    lst.Add(new SelectListItem() { Text = "DESINCORPORACIÓN", Value = "10" });

                    ViewBag.Opciones = lst;
                    ViewData["RolId"] = RolId;

                    ModelState.AddModelError("", msjErrorSerialRep);

                    return View(collection);
                }

                //collection.Serial = collection.SerialRepuesto;
                String repJson2 = await _clientHttpREST.GetObjetcsAllAsync("api-operations/SerialsProducts");
                List<SerialProductModel> spList = TypeModel<SerialProductModel>.DeserializeInArray(repJson2);
                var serialProd = spList.Where(fc => fc.Serial == collection.Serial).FirstOrDefault();

                string repJson0 = await _clientHttpREST.GetObjetcsAllAsync("api-clients/Technicians");

                List<TechnicianModel> listTechnicians = TypeModel<TechnicianModel>.DeserializeInArray(repJson0);

                var technical = listTechnicians.Where(t => t.rif == collection.rifTechnician).FirstOrDefault();

                if(technical != null)
                { collection.TechnicianId = technical.id;  }

                if (serialProd == null)
                {
                    collection.ProviderId = 1;
                    collection.DistributorId = 1;
                }
                else
                {
                    collection.ProviderId = serialProd.ProviderId;
                    if (collection.DistributorId == 0)
                    {
                        collection.DistributorId = serialProd.DistributorId;
                    }
                    //else
                    //{
                    //    if (collection.DistributorId != serialProd.DistributorId)
                    //    { collection.Serial = ""; }
                    //}
                }

              
                collection.Status = "PROCESADO";
                String json = JsonConvert.SerializeObject(collection);

                String response = await _clientHttpREST.PostObjetcContentAndCodeAsync("api-operations/TechnicalsOperations", json);

                var strarry = response.Split('|');

                string codeHttp = strarry[0];
                string content = strarry[1];


                if (codeHttp.Equals("Created"))
                {
                    //API nueva solo si el serial del repuesto es diferente de null
                    if(collection.SerialRepuesto != null)
                    {
                        var technicalOperationSave = TypeModel<TechnicalOperationModel>.DeserializeInObject(content);

                        String json2 = @"{ 'Id':0,
                                           'OperationTechId':" + technicalOperationSave.Id + @",
                                           'ReplacementId':" + replacement.ReplacementId + @",
                                           'Serial':'" + collection.SerialRepuesto + @"'
                                         }";

                        String response2 = await _clientHttpREST.PostObjetcAsync("api-operations/ReplacementsOpeTechs", json2);

                    }

                    Alert("Operación Exitosa", NotificationType.success);

                    return RedirectToAction("Index");
                }
                else
                {
                    String repJson = await _clientHttpREST.GetObjetcAsync("api-clients/FinalsClients", collection.FinalClientId.ToString());
                    collection.FinalClient = TypeModel<FinalsClientsModel>.DeserializeInObject(repJson);

                    //Cargo las 9 Operaciones Permitidas
                    List<SelectListItem> lst = new List<SelectListItem>();

                    lst.Add(new SelectListItem() { Text = "INSPECCIÓN ANUAL", Value = "2" });
                    lst.Add(new SelectListItem() { Text = "REPARACIÓN", Value = "3" });
                    lst.Add(new SelectListItem() { Text = "ADAPTACIÓN", Value = "4" });
                    lst.Add(new SelectListItem() { Text = "SUSTITUCIÓN DE MEMORIA FISCAL", Value = "5" });
                    lst.Add(new SelectListItem() { Text = "SUSTITUCIÓN DE MEMORIA DE AUDITORÍA", Value = "6" });
                    lst.Add(new SelectListItem() { Text = "ALTERACIÓN Ó REMOCIÓN DE DISPOSITIVOS DE SEGURIDAD", Value = "7" });
                    lst.Add(new SelectListItem() { Text = "REPORTE DE PÉRDIDA Ó ROBO POR PARTE DEL DISTRIBUIDOR", Value = "8" });
                    lst.Add(new SelectListItem() { Text = "REPORTE PÉDIDA Ó ROBO POR PARTE DEL USUARIO", Value = "9" });
                    lst.Add(new SelectListItem() { Text = "DESINCORPORACIÓN", Value = "10" });

                    ViewBag.Opciones = lst;
                    ViewData["RolId"] = RolId;

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

        #region GET: TechnicalsOperations DETAILS
        public async Task<IActionResult> Details(int id)
        {
            try
            {
                string tokenValue = await this.GetTokenAccess();

                _clientHttpREST.SetToken(tokenValue);

                string repJson = await _clientHttpREST.GetObjetcAsync("api-operations/TechnicalsOperations", id.ToString());

                TechnicalOperationModel technicalsOperation = TypeModel<TechnicalOperationModel>.DeserializeInObject(repJson);

                return View(technicalsOperation);
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

        #region GET: TechnicalsOperations EDIT
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

                String json = await _clientHttpREST.GetObjetcAsync("api-operations/TechnicalsOperations", id.ToString());
                TechnicalOperationModel technicalOperation = TypeModel<TechnicalOperationModel>.DeserializeInObject(json);

                if (technicalOperation == null)
                {
                    return NotFound();
                }

                string repJson = await _clientHttpREST.GetObjetcAsync("api-clients/Technicians", technicalOperation.TechnicianId.ToString());
                var technician = TypeModel<TechnicianModel>.DeserializeInObject(repJson);
                technicalOperation.rifTechnician = technician.rif;

                //Cargo las 9 Operaciones Permitidas
                List<SelectListItem> lst = new List<SelectListItem>();

                lst.Add(new SelectListItem() { Text = "INSPECCIÓN ANUAL", Value = "2" });
                lst.Add(new SelectListItem() { Text = "REPARACIÓN", Value = "3" });
                lst.Add(new SelectListItem() { Text = "ADAPTACIÓN", Value = "4" });
                lst.Add(new SelectListItem() { Text = "SUSTITUCIÓN DE MEMORIA FISCAL", Value = "5" });
                lst.Add(new SelectListItem() { Text = "SUSTITUCIÓN DE MEMORIA DE AUDITORÍA", Value = "6" });
                lst.Add(new SelectListItem() { Text = "ALTERACIÓN Ó REMOCIÓN DE DISPOSITIVOS DE SEGURIDAD", Value = "7" });
                lst.Add(new SelectListItem() { Text = "REPORTE DE PÉRDIDA Ó ROBO POR PARTE DEL DISTRIBUIDOR", Value = "8" });
                lst.Add(new SelectListItem() { Text = "REPORTE PÉDIDA Ó ROBO POR PARTE DEL USUARIO", Value = "9" });
                lst.Add(new SelectListItem() { Text = "DESINCORPORACIÓN", Value = "10" });

                ViewBag.Opciones = lst;
                ViewData["RolId"] = RolId;

                return View(technicalOperation);
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
                return View("~/Views/Shared/Error.cshtml", new ErrorViewModel { RequestId = Request.Path });
            }
        }
        #endregion

        #region POST: TechnicalsOperations EDIT
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, TechnicalOperationModel technicalsOperation)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    string tokenValue = await this.GetTokenAccess();

                    _clientHttpREST.SetToken(tokenValue);

                    string repJson0 = await _clientHttpREST.GetObjetcsAllAsync("api-clients/Technicians");

                    List<TechnicianModel> listTechnicians = TypeModel<TechnicianModel>.DeserializeInArray(repJson0);

                    var technical = listTechnicians.Where(t => t.rif == technicalsOperation.rifTechnician).FirstOrDefault();

                    if (technical != null)
                    { technicalsOperation.TechnicianId = technical.id; }

                    String repJson2 = await _clientHttpREST.GetObjetcsAllAsync("api-operations/SerialsProducts");
                    List<SerialProductModel> spList = TypeModel<SerialProductModel>.DeserializeInArray(repJson2);
                    var serialProd = spList.Where(fc => fc.Serial == technicalsOperation.Serial).FirstOrDefault();

                    if (serialProd == null)
                    {
                        technicalsOperation.ProviderId = 1;
                        technicalsOperation.DistributorId = 1;
                    }
                    else
                    {
                        technicalsOperation.ProviderId = serialProd.ProviderId;
                        if (technicalsOperation.DistributorId == 0)
                        {
                            technicalsOperation.DistributorId = serialProd.DistributorId;
                        }
                        else
                        {
                            if (technicalsOperation.DistributorId != serialProd.DistributorId)
                            { technicalsOperation.Serial = ""; }
                        }
                    }

                    technicalsOperation.Verificador = null;

                    String json = JsonConvert.SerializeObject(technicalsOperation);

                    String response = await _clientHttpREST.PutObjetcContentAndCodeAsync("api-operations/TechnicalsOperations", technicalsOperation.Id.ToString(), json);

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
                        Alert(codeHttp, NotificationType.error);

                        String repJson = await _clientHttpREST.GetObjetcAsync("api-clients/FinalsClients", technicalsOperation.FinalClientId.ToString());
                        technicalsOperation.FinalClient = TypeModel<FinalsClientsModel>.DeserializeInObject(repJson);

                        //Cargo las 9 Operaciones Permitidas
                        List<SelectListItem> lst = new List<SelectListItem>();

                        lst.Add(new SelectListItem() { Text = "INSPECCIÓN ANUAL", Value = "2" });
                        lst.Add(new SelectListItem() { Text = "REPARACIÓN", Value = "3" });
                        lst.Add(new SelectListItem() { Text = "ADAPTACIÓN", Value = "4" });
                        lst.Add(new SelectListItem() { Text = "SUSTITUCIÓN DE MEMORIA FISCAL", Value = "5" });
                        lst.Add(new SelectListItem() { Text = "SUSTITUCIÓN DE MEMORIA DE AUDITORÍA", Value = "6" });
                        lst.Add(new SelectListItem() { Text = "ALTERACIÓN Ó REMOCIÓN DE DISPOSITIVOS DE SEGURIDAD", Value = "7" });
                        lst.Add(new SelectListItem() { Text = "REPORTE DE PÉRDIDA Ó ROBO POR PARTE DEL DISTRIBUIDOR", Value = "8" });
                        lst.Add(new SelectListItem() { Text = "REPORTE PÉDIDA Ó ROBO POR PARTE DEL USUARIO", Value = "9" });
                        lst.Add(new SelectListItem() { Text = "DESINCORPORACIÓN", Value = "10" });

                        ViewBag.Opciones = lst;
                        ViewData["RolId"] = RolId;

                        return View(technicalsOperation);
                    }
                }
                else
                {
                    return View(technicalsOperation);
                }
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;

                return View("~/Views/Shared/Error.cshtml", new ErrorViewModel { RequestId = Request.Path });
            }
        }

        #endregion

        #region GET: TechnicalsOperations DELETE
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

                String json = await _clientHttpREST.GetObjetcAsync("api-operations/TechnicalsOperations", id.ToString());

                TechnicalOperationModel technicalOperation = TypeModel<TechnicalOperationModel>.DeserializeInObject(json);

                if (technicalOperation == null)
                {
                    return NotFound();
                }

                return View(technicalOperation);
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

        #region POST: TechnicalsOperations DELETE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, TechnicalOperationModel collection)
        {
            try
            {
                string tokenValue = await this.GetTokenAccess();

                _clientHttpREST.SetToken(tokenValue);

                String response = await _clientHttpREST.DeleteObjetcAsync("api-operations/TechnicalsOperations", id.ToString());

                if (response.Equals("OK"))
                {
                    //Determino si el Borrado lo hizo un Empleado para Registrar el Evento
                    var nameUser = _userManager.GetUserName(User);
                    string repJson = await _clientHttpREST.GetObjetcsAllAsync("api-employees/Employees");
                    List<EmployeeModel> listEmployees = TypeModel<EmployeeModel>.DeserializeInArray(repJson);
                    var employee = listEmployees.Where(e => e.email == nameUser).FirstOrDefault();

                    if (employee != null)
                    { //Alimento el Registro de Actividades
                        var activity = new ActivityModel();
                        activity.EmployeeId = employee.id;
                        activity.ChargueId = employee.chargueId;
                        activity.DepartamentId = employee.departamentId;
                        activity.Process = "Operaciones Tecnicas";
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