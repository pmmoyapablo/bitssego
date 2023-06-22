using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using Sisgtfhka.Models;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Sisgtfhka.Services;
using Microsoft.Extensions.Logging;
using static Sisgtfhka.Enums.Enums;
using Sisgtfhka.Extensions;
using Newtonsoft.Json;
using System.Globalization;

namespace Sisgtfhka.Controllers
{
    [Authorize]
    public class FiscalOperationController : BaseController
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private ISession _session => _httpContextAccessor.HttpContext.Session;

        public FiscalOperationController(UserManager<ApplicationUser> userManager,
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

        #region // GET: FiscalOperation
        public async Task<IActionResult> Index(string sortOrder,
                                               string currentFilter,
                                               string searchString,
                                               int? pageNumber)
        {
            try
            {
                string tokenValue = await this.GetTokenAccess();

                _clientHttpREST.SetToken(tokenValue);

                string repJson = await _clientHttpREST.GetObjetcsAllAsync("api-operations/FiscalsOperations");

                List<FiscalOperationModel> listFiscalsOperations = TypeModel<FiscalOperationModel>.DeserializeInArray(repJson);

                if (!(RolId <= 7))
                {//Compruebo si es Distribuidor en Session
                    string repJson2 = await _clientHttpREST.GetObjetcsAllAsync("api-clients/Distributors");

                    List<DistributorModel> listDistributors = TypeModel<DistributorModel>.DeserializeInArray(repJson2);

                    var distributor = listDistributors.Where(d => d.email == _userManager.GetUserName(User)).FirstOrDefault();

                    if (distributor != null)
                    {
                        //Almaceno el Id de Distribuidor en una Variable de Sesión
                        SessionExtensions.SetInt32(_session, SessionDistributorId, distributor.id);

                        listFiscalsOperations = listFiscalsOperations.Where(o => o.distributorId == distributor.id).ToList();
                    }
                    else
                    {//Determino si es un Tecnico de Centro de Servicio
                        string repJson3 = await _clientHttpREST.GetObjetcsAllAsync("api-clients/Technicians");

                        List<TechnicianModel> listTechnicians = TypeModel<TechnicianModel>.DeserializeInArray(repJson3);
                        var technical = listTechnicians.Where(t => t.email == _userManager.GetUserName(User)).FirstOrDefault();

                        if (technical != null)
                        { //Almaceno el Id de Tecnico de Centro d Servicio en una Variable de Sesión
                            SessionExtensions.SetInt32(_session, SessionTechnicalId, technical.id);
                            List<FiscalOperationModel> listFiscalsOperationsTemp = new List<FiscalOperationModel>();
                            listFiscalsOperationsTemp.Clear();
                            //Escatimamos su Operaciones con sus Distribuidores Padres
                            string repJson4 = await _clientHttpREST.GetObjetcsAllAsync("api-clients/Technicians/"+ technical .id.ToString() + "/Distributors");

                            List<DistributorModel> listDistributorsRelat = TypeModel<DistributorModel>.DeserializeInArray(repJson4);

                            foreach (DistributorModel dist in listDistributorsRelat)
                            {
                                var operations = listFiscalsOperations.Where(o => o.technicianId == technical.id && o.distributorId == dist.id).ToList();

                                foreach(FiscalOperationModel oper in operations)
                                {
                                    listFiscalsOperationsTemp.Add(oper);
                                }
                            }

                            listFiscalsOperations = listFiscalsOperationsTemp;
                        }
                        else
                        {
                            listFiscalsOperations = listFiscalsOperations.Where(o => o.distributorId == 0 && o.technicianId == 0).ToList();
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
                    listFiscalsOperations = listFiscalsOperations.Where(sp => sp.serial.IndexOf(searchString, StringComparison.OrdinalIgnoreCase) >= 0 ||
                                            sp.fiscalMode.IndexOf(searchString, StringComparison.OrdinalIgnoreCase) >= 0 ||
                                            sp.serialRetative.IndexOf(searchString, StringComparison.OrdinalIgnoreCase) >= 0 ||
                                            sp.fiscalOperation.IndexOf(searchString, StringComparison.OrdinalIgnoreCase) >= 0 ||
                                            sp.Creation_Date.ToString().IndexOf(searchString, StringComparison.OrdinalIgnoreCase) >= 0 ||
                                            sp.codeOperation.IndexOf(searchString, StringComparison.OrdinalIgnoreCase) >= 0 ||
                                            sp.fiscalAddress.IndexOf(searchString, StringComparison.OrdinalIgnoreCase) >= 0 ||
                                            sp.Distributor.rif.IndexOf(searchString, StringComparison.OrdinalIgnoreCase) >= 0 ||
                                            sp.Distributor.description.IndexOf(searchString, StringComparison.OrdinalIgnoreCase) >= 0 ||
                                            sp.FinalClient.Rif.IndexOf(searchString, StringComparison.OrdinalIgnoreCase) >= 0 ||
                                            sp.FinalClient.Description.IndexOf(searchString, StringComparison.OrdinalIgnoreCase) >= 0 ||
                                            sp.Technician.rif.IndexOf(searchString, StringComparison.OrdinalIgnoreCase) >= 0 ||
                                            sp.Technician.description.IndexOf(searchString, StringComparison.OrdinalIgnoreCase) >= 0).ToList();
                }
                switch (sortOrder)
                {
                    case "name_desc":
                        listFiscalsOperations = listFiscalsOperations.OrderByDescending(sp => sp.serial).ToList();
                        break;
                    case "Date":
                        listFiscalsOperations = listFiscalsOperations.OrderBy(sp => sp.serial).ToList();
                        break;
                    case "date_desc":
                        listFiscalsOperations = listFiscalsOperations.OrderByDescending(sp => sp.serial).ToList();
                        break;
                    default:
                        listFiscalsOperations = listFiscalsOperations.OrderBy(sp => sp.serial).ToList();
                        break;
                }

                int pageSize = 8;

                ViewData["RolId"] = RolId.ToString();
                ViewData["LevelAccess"] = LevelAccess.ToString();

                return View(PaginatedList<FiscalOperationModel>.CreateAsync(listFiscalsOperations.AsQueryable(), pageNumber ?? 1, pageSize));
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

        #region// GET: FiscalOperation/Details/5
        public async Task<IActionResult> Details(int id)
        {
            try
            {
                string tokenValue = await this.GetTokenAccess();

                _clientHttpREST.SetToken(tokenValue);

                string repJson = await _clientHttpREST.GetObjetcAsync("api-operations/FiscalsOperations", id.ToString());

                FiscalOperationModel FiscalOperation = TypeModel<FiscalOperationModel>.DeserializeInObject(repJson);

                return View(FiscalOperation);
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

        #region //GET: CodeGenerator
        public async Task<ActionResult> CodeGenerator(string[] dataOperation)
        {
            try
            {
                CodeGeneratorModel codeGeneratorFiscal = new CodeGeneratorModel();
                
                if (dataOperation.Length > 0)
                {
                    ViewBag.StateRif = false;
                    ViewBag.StateSerial = false;
                    ViewBag.StateMefi = false;

                    if (dataOperation[0] != null)
                    {                    
                        codeGeneratorFiscal.technician = dataOperation[0];
                    }

                    if (dataOperation.Length > 1)
                    {
                        codeGeneratorFiscal.operation = dataOperation[1];                                     
                    }

                    if (dataOperation.Length > 2)
                    {
                        ViewData["Rif_New"] = dataOperation[2];
                        codeGeneratorFiscal.rif = dataOperation[2];                        
                    }

                    if (dataOperation.Length > 3)
                    {
                        codeGeneratorFiscal.description = dataOperation[3];
                        ViewBag.StateRif = true;                               
                    }

                    if (dataOperation.Length > 4)
                    {
                        codeGeneratorFiscal.fiscalAddress = dataOperation[4];            
                    }

                    if (dataOperation.Length > 5)
                    {
                        codeGeneratorFiscal.serial = dataOperation[5];                     
                    }

                    if (dataOperation.Length > 6)
                    {
                        if (dataOperation[6] == "True")
                        {
                            ViewBag.StateSerial = true;
                            codeGeneratorFiscal.validator = true;
                        }
                    }

                    if (dataOperation.Length > 7)
                    {
                        if (dataOperation[7] == "False")
                        {
                            ViewBag.StateMefi = true;                           
                        }else
                        {
                            codeGeneratorFiscal.validatorMefi = true;
                        }
                    }

                    if (dataOperation.Length > 8)
                    {
                        if (dataOperation[8] == "True")
                        {
                            ViewBag.StateMefi = false;
                            codeGeneratorFiscal.validatorMefi = true;
                        }
                    }

                    if (dataOperation.Length > 9)
                    {
                        codeGeneratorFiscal.initSeal = dataOperation[9];
                    }

                    if (dataOperation.Length > 10)
                    {
                        codeGeneratorFiscal.finalSeal = dataOperation[10];
                    }

                    if (dataOperation.Length > 11)
                    {
                        codeGeneratorFiscal.codePrinter = dataOperation[11];
                    }

                    if (dataOperation.Length > 12)
                    {
                        codeGeneratorFiscal.codeOperation = dataOperation[12];
                    }

                }
                else
                {
                    //Determino el RIF de Tecnico
                    string tokenValue = await this.GetTokenAccess();

                    _clientHttpREST.SetToken(tokenValue);

                    string repJson = await _clientHttpREST.GetObjetcsAllAsync("api-clients/Technicians");

                    var listTechnicians = TypeModel<TechnicianModel>.DeserializeInArray(repJson);

                    if (RolId == 10)
                    {
                        var technician = listTechnicians.Where(t => t.email == _userManager.GetUserName(User)).FirstOrDefault();

                        if (technician != null)
                        { codeGeneratorFiscal.technician = technician.rif; }
                    }
                    else
                    {
                        codeGeneratorFiscal.technician = "V000000000";
                    }

                    ViewBag.StateRif = false;
                    ViewBag.StateSerial = false;
                    ViewBag.StateMefi = false;
                }

                return View(codeGeneratorFiscal);
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

        #region //POST CodeGenerator
        [HttpPost]
        public async Task<IActionResult> CodeGenerator(CodeGeneratorModel codeGenerator)
        {
            try
            {
                string tokenValue = await this.GetTokenAccess();

                _clientHttpREST.SetToken(tokenValue);
             
                return View();

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

        #region //POST SerachRif

        [HttpPost]
        public async Task<IActionResult> SerachRif(CodeGeneratorModel codeGenerator)
        {
            try
            {

                string tokenValue = await this.GetTokenAccess();

                _clientHttpREST.SetToken(tokenValue);

                string repJson = await _clientHttpREST.GetObjetcsAllAsync("api-clients/FinalsClients");

                List<FinalsClientsModel> rifClient = TypeModel<FinalsClientsModel>.DeserializeInArray(repJson);

                var finalCLient = rifClient.Where(rc => rc.Rif == codeGenerator.rif).FirstOrDefault();

                string[] dataOperationFiscal = new string[10];

                dataOperationFiscal[0] = codeGenerator.technician;
                dataOperationFiscal[1] = codeGenerator.operation;
                dataOperationFiscal[2] = codeGenerator.rif;
                dataOperationFiscal[5] = codeGenerator.serial;

                if (finalCLient == null)
                {
                    Alert("Cliente Final No Encontrado. Por favor Crear Cliente Final", NotificationType.warning);
                }
                else
                {
                    dataOperationFiscal[3] = finalCLient.Description;
                    if (finalCLient.fiscalAddress == null || finalCLient.fiscalAddress == "")
                        dataOperationFiscal[4] = "Domicilio fiscal actual";
                    else
                        dataOperationFiscal[4] = finalCLient.fiscalAddress;
                }
           
                return RedirectToAction("CodeGenerator", "FiscalOperation", new { dataOperation = dataOperationFiscal});

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

        #region //POST SearchSerial

        [HttpPost]
        public async Task<IActionResult> SearchSerial(CodeGeneratorModel codeGenerator)
        {
            try
            {

                string tokenValue = await this.GetTokenAccess();

                _clientHttpREST.SetToken(tokenValue);

                String repJson2 = await _clientHttpREST.GetObjetcsAllAsync("api-operations/SerialsProducts");
                List<SerialProductModel> spList = TypeModel<SerialProductModel>.DeserializeInArray(repJson2);
                var serialProd = spList.Where(fc => fc.Serial == codeGenerator.serial).FirstOrDefault();
                bool isValid = false;

                if (serialProd != null)
                {
                    if (RolId == 10)
                    {//Caso Tecnico Centro de Servicio en Session
                    //    //Escatimamos su Relacion con sus Distribuidores Padres
                    //    string repJson4 = await _clientHttpREST.GetObjetcsAllAsync("api-clients/Technicians/" + TechnicalId.ToString() + "/Distributors");

                    //    List<DistributorModel> listDistributorsRelat = TypeModel<DistributorModel>.DeserializeInArray(repJson4);

                    //    foreach (DistributorModel dist in listDistributorsRelat)
                    //    {
                    //        if (dist.id == serialProd.DistributorId)
                    //        {
                                isValid = true;
                        //        break;
                        //    }
                        //}
                    } 
                    else if (RolId <= 7)
                    {//Caso Gerencia de Servicio o Soporte de Proveedor
                        string repJson = await _clientHttpREST.GetObjetcAsync("api-clients/Providers", serialProd.ProviderId.ToString());

                        var provider = TypeModel<ProviderModel>.DeserializeInObject(repJson);

                        string repJson3 = await _clientHttpREST.GetObjetcsAllAsync("api-clients/Distributors");

                        List<DistributorModel> listDistributors = TypeModel<DistributorModel>.DeserializeInArray(repJson3);

                        if (provider != null)
                        {
                            var distributorHome = listDistributors.Where(d => d.rif == provider.rif).FirstOrDefault();

                            if(distributorHome != null)
                            {
                                //if(serialProd.DistributorId == distributorHome.id)
                                { isValid = true; }
                            }
                        }
                    }
                }

                string[] dataOperationFiscal = new string[10];

                dataOperationFiscal[0] = codeGenerator.technician;
                dataOperationFiscal[1] = codeGenerator.operation;
                dataOperationFiscal[2] = codeGenerator.rif;
                dataOperationFiscal[3] = codeGenerator.description;
                dataOperationFiscal[4] = codeGenerator.fiscalAddress;
                dataOperationFiscal[5] = codeGenerator.serial;

                if (!isValid)
                {
                    Alert("El Serial suministrado no se encuentra en su registro de Distribuidor en alguna relacion o es invalido. Verifique su correcta denominacion", NotificationType.warning);
                }
                else
                {
                    dataOperationFiscal[6] = isValid.ToString();
                    //Determino si Aplica Cambio de Memoriaa Fiscal en caso de intento de FISCALIZACION
                    if (codeGenerator.operation == "FISCALIZACION")
                    {
                        string repJson5 = await _clientHttpREST.GetObjetcAsync("api-operations/FiscalsOperations/IsNewMachine", codeGenerator.serial);

                        if (repJson5 == "true")
                        { dataOperationFiscal[7] = "True"; }
                        else
                        {
                            dataOperationFiscal[7] = "False";

                            Alert("Aplica cambio de Memoria Fiscal", NotificationType.info);
                        }
                    }
                    else
                    {
                        dataOperationFiscal[7] = "True";
                    }
                }

                return RedirectToAction("CodeGenerator", "FiscalOperation", new { dataOperation = dataOperationFiscal });

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

        #region //POST ValidateMefi

        [HttpPost]
        public async Task<IActionResult> ValidateMefi(CodeGeneratorModel codeGenerator)
        {
            try
            {

                string tokenValue = await this.GetTokenAccess();

                _clientHttpREST.SetToken(tokenValue);

                string jsonBody = @"{
                    'serialMefi':'" + codeGenerator.serialMefi + @"',
                    'serialMachine':'" + codeGenerator.serial + @"',
                    'rifFinal':'" + codeGenerator.rif + @"',
                    'rifTechnical':'" + codeGenerator.technician + @"',
                    'rifDistributor':'" + codeGenerator.rifDistributor + @"',
                    'mode':'AUXILIAR'
                }";

                String repJson = await _clientHttpREST.PostObjetcContentAndCodeAsync("api-operations/FiscalsOperations/ValidateMemfisc", jsonBody);
                string[] responses = repJson.Split('|');

                var responseMefi = TypeModel<ResponceMefi>.DeserializeInObject(responses[1]);
                
                string[] dataOperationFiscal = new string[10];

                dataOperationFiscal[0] = codeGenerator.technician;
                dataOperationFiscal[1] = codeGenerator.operation;
                dataOperationFiscal[2] = codeGenerator.rif;
                dataOperationFiscal[3] = codeGenerator.description;
                dataOperationFiscal[4] = codeGenerator.fiscalAddress;
                dataOperationFiscal[5] = codeGenerator.serial;
                dataOperationFiscal[6] = codeGenerator.validator.ToString();
                dataOperationFiscal[7] = codeGenerator.validatorMefi.ToString();
                dataOperationFiscal[8] = responseMefi.isValid.ToString();

                if (!responseMefi.isValid)
                {
                    Alert(responseMefi.message, NotificationType.warning);                   
                }else
                {
                    //Establezco el Resultado de la Operacion
                    String json = await _clientHttpREST.GetObjetcAsync("api-operations/FiscalsOperations/BySerial", codeGenerator.serialMefi);

                    var operations = TypeModel<FiscalOperationModel>.DeserializeInArray(json);
                    var fiscalOperation = operations.OrderByDescending(o => o.Creation_Date).FirstOrDefault();

                    if (fiscalOperation != null)
                    {
                        fiscalOperation.fiscalResult = 1;
                        fiscalOperation.Distributor = null;
                        fiscalOperation.FinalClient = null;
                        fiscalOperation.Provider = null;
                        fiscalOperation.Technician = null;

                        String json2 = JsonConvert.SerializeObject(fiscalOperation);

                        String response = await _clientHttpREST.PutObjetcAsync("api-operations/FiscalsOperations", fiscalOperation.id.ToString(), json2);
                    }

                    Alert(responseMefi.message, NotificationType.success);
                }

                return RedirectToAction("CodeGenerator", "FiscalOperation", new { dataOperation = dataOperationFiscal });

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

        #region //POST GenerateCodeEnd

        [HttpPost]
        public async Task<IActionResult> GenerateCodeEnd(CodeGeneratorModel codeGenerator)
        {
            try
            {

                string tokenValue = await this.GetTokenAccess();

                _clientHttpREST.SetToken(tokenValue);

 string jsonBody = @"{
                    'precode':'" + codeGenerator.codePrinter + @"',
                    'serial':'" + codeGenerator.serial + @"',
                    'type':'" + codeGenerator.operation + @"',
                    'rifFinal':'" + codeGenerator.rif + @"',
                    'contributorFinal':'" + codeGenerator.description + @"',
                    'rifTechnical':'" + codeGenerator.technician + @"',
                    'addressFiscal':'" + codeGenerator.fiscalAddress + @"',
                    'iniSeal':'" + codeGenerator.initSeal + @"',
                    'endSeal':'" + codeGenerator.finalSeal + @"',                  
                    'login':'',
                    'password':'',
                    'mode':'AUXILIAR'                          
                }";

                String repJson = await _clientHttpREST.PostObjetcContentAndCodeAsync("api-operations/FiscalsOperations", jsonBody);
                string[] responses = repJson.Split('|');

                if (responses[0] == "OK")
                {
                    var responseCode = TypeModel<ResponceCode>.DeserializeInObject(responses[1]);

                    string[] dataOperationFiscal = new string[13];

                    dataOperationFiscal[0] = codeGenerator.technician;
                    dataOperationFiscal[1] = codeGenerator.operation;
                    dataOperationFiscal[2] = codeGenerator.rif;
                    dataOperationFiscal[3] = codeGenerator.description;
                    dataOperationFiscal[4] = codeGenerator.fiscalAddress;
                    dataOperationFiscal[5] = codeGenerator.serial;
                    dataOperationFiscal[6] = codeGenerator.validator.ToString();
                    dataOperationFiscal[7] = codeGenerator.validatorMefi.ToString();
                    dataOperationFiscal[8] = codeGenerator.validatorMefi.ToString();
                    dataOperationFiscal[9] = codeGenerator.initSeal;
                    dataOperationFiscal[10] = codeGenerator.finalSeal;
                    dataOperationFiscal[11] = codeGenerator.codePrinter;

                    if (!responseCode.isValid)
                    {
                        dataOperationFiscal[12] = codeGenerator.codeOperation;

                        Alert(responseCode.message, NotificationType.warning);
                    }
                    else
                    {
                        dataOperationFiscal[12] = responseCode.codeGenerate;
                        //Establezco el Resultado de la Operacion
                        String json = await _clientHttpREST.GetObjetcAsync("api-operations/FiscalsOperations", responseCode.idOperation.ToString());

                        var fiscalOperation = TypeModel<FiscalOperationModel>.DeserializeInObject(json);

                        if(fiscalOperation != null)
                        {
                            fiscalOperation.fiscalResult = 1;
                            fiscalOperation.Distributor = null;
                            fiscalOperation.FinalClient = null;
                            fiscalOperation.Provider = null;
                            fiscalOperation.Technician = null;

                            String json2 = JsonConvert.SerializeObject(fiscalOperation);

                            String response = await _clientHttpREST.PutObjetcAsync("api-operations/FiscalsOperations", fiscalOperation.id.ToString(), json2);
                        }

                        Alert(responseCode.message, NotificationType.success);
                    }

                    return RedirectToAction("CodeGenerator", "FiscalOperation", new { dataOperation = dataOperationFiscal });
                }else
                {
                    ViewBag.Message = "Ocurrio un Error Inesperado.";

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

        #region // GET: FiscalOperation/Delete/5

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

                String json = await _clientHttpREST.GetObjetcAsync("api-operations/FiscalsOperations", id.ToString());

                FiscalOperationModel FiscalOperation = TypeModel<FiscalOperationModel>.DeserializeInObject(json);

                if (FiscalOperation == null)
                {
                    return NotFound();
                }

                return View(FiscalOperation);
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

        #region  // POST: FiscalOperation/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, FiscalOperationModel collection)
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
                    string repJson = await _clientHttpREST.GetObjetcsAllAsync("api-operations/FiscalsOperations");

                    List<FiscalOperationModel> listFiscalsOperations = TypeModel<FiscalOperationModel>.DeserializeInArray(repJson);
                    var fiscalOperation = listFiscalsOperations.Where(f => f.id == id).FirstOrDefault();

                    String response2 = await _clientHttpREST.DeleteObjetcAsync("api-operations/FiscalsOperations", id.ToString());
                  
                    if (response2.Equals("OK"))
                    {
                        string repJsonEmployee = await _clientHttpREST.GetObjetcsAllAsync("api-employees/Employees");
                        List<EmployeeModel> listEmployee = TypeModel<EmployeeModel>.DeserializeInArray(repJsonEmployee);
                        var employee = listEmployee.Where(f => f.email == _userManager.GetUserName(User)).FirstOrDefault();

                        ActivityModel activity = new ActivityModel();
                        activity.Id = 0;
                        activity.EmployeeId = employee.id;
                        activity.Process = "Operaciones Fiscales";
                        activity.Operation = "Borrado (" + fiscalOperation.fiscalOperation + ")";
                        activity.Serial = fiscalOperation.serial;
                        activity.Detail = collection.observation != null ? collection.observation : "Borrado de Operacion Fiscal por Tramite Interno";

                        if (fiscalOperation.fiscalOperation == "FISCALIZACION" && fiscalOperation.fiscalResult == 1)
                        {
                            //Refresco la Lista despues del Borrado
                            listFiscalsOperations.Clear();
                            repJson = await _clientHttpREST.GetObjetcsAllAsync("api-operations/FiscalsOperations");
                            listFiscalsOperations = TypeModel<FiscalOperationModel>.DeserializeInArray(repJson);

                            //Verifico si era unica Operacion Fiscal de FISCALIZACION aprobada con el Serial en curso
                            var operation = listFiscalsOperations.Where(o => o.serial == fiscalOperation.serial && o.fiscalOperation == "FISCALIZACION" && o.fiscalResult == 1).FirstOrDefault();

                            if (operation == null)
                            {
                                string repJsonAlienation = await _clientHttpREST.GetObjetcsAllAsync("api-operations/Alienations");
                                List<AlienationModel> listAlienation = TypeModel<AlienationModel>.DeserializeInArray(repJsonAlienation);
                                var alienation = listAlienation.Where(f => f.Serial == fiscalOperation.serial).FirstOrDefault();

                              if (alienation != null)
                              {
                                String responseAlienation = await _clientHttpREST.DeleteObjetcAsync("api-operations/Alienations", alienation.Id.ToString());

                                activity.Detail = "Borrado de Operacion Fiscal de Tipo Fiscalizacion y Borrado de enajenación asociada";
                              }
                            }
                        }

                        String jsonActivity = JsonConvert.SerializeObject(activity);
                        String response = await _clientHttpREST.PostObjetcContentAndCodeAsync("api-operations/Activities", jsonActivity);

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
                    String json2 = await _clientHttpREST.GetObjetcAsync("api-operations/FiscalsOperations", id.ToString());

                    collection = TypeModel<FiscalOperationModel>.DeserializeInObject(json2);

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

                return View("~/Views/Shared/Error.cshtml", new ErrorViewModel { RequestId = Request.Path }); ;
            }
        }
        #endregion

    }



}