using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Sisgtfhka.Extensions;
using Sisgtfhka.Models;
using static Sisgtfhka.Enums.Enums;

namespace Sisgtfhka.Controllers
{
    [Authorize]
    public class SerialReplacementController : BaseController
    {

        public SerialReplacementController(UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            RoleManager<IdentityRole> roleManager,
            Services.ClientHttpREST clientHttpREST,
            ILogger<AccountController> logger,
            IOptions<AppSettings> settings)
            : base(userManager, signInManager, clientHttpREST, settings)
        {

        }

        #region GET Serial Replecement
        public async Task<IActionResult> Index(string sortOrder,
                                               string currentFilter,
                                               string searchString,
                                               int? pageNumber)
        {

            try
            {
                string tokenValue = await this.GetTokenAccess();

                _clientHttpREST.SetToken(tokenValue);

                string repJson = await _clientHttpREST.GetObjetcsAllAsync("api-operations/SerialsReplacements");

                List<SerialReplacementModel> listSerialsReplacements = TypeModel<SerialReplacementModel>.DeserializeInArray(repJson);

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



                    listSerialsReplacements = listSerialsReplacements.Where(
                    sr => sr.Serial.IndexOf(searchString, StringComparison.OrdinalIgnoreCase) >= 0
                    || sr.Replacement.name.IndexOf(searchString, StringComparison.OrdinalIgnoreCase) >= 0 
                    || sr.Provider.description.IndexOf(searchString, StringComparison.OrdinalIgnoreCase) >= 0
                    || sr.Distributor.rif.IndexOf(searchString, StringComparison.OrdinalIgnoreCase) >= 0
                    || sr.DateSale.ToString().IndexOf(searchString, StringComparison.OrdinalIgnoreCase) >= 0
                    || sr.Observations.IndexOf(searchString, StringComparison.OrdinalIgnoreCase) >= 0
                    ).ToList();
                }
                switch (sortOrder)
                {
                    case "name_desc":
                        listSerialsReplacements = listSerialsReplacements.OrderByDescending(sr => sr.Serial).ToList();
                        break;
                    case "Date":
                        listSerialsReplacements = listSerialsReplacements.OrderBy(sr => sr.DateSale).ToList();
                        break;
                    case "date_desc":
                        listSerialsReplacements = listSerialsReplacements.OrderByDescending(sr => sr.DateSale).ToList();
                        break;
                    default:
                        listSerialsReplacements = listSerialsReplacements.OrderBy(sr => sr.Serial).ToList();
                        break;
                }

                int pageSize = 8;

                ViewData["RolId"] = RolId.ToString();
                ViewData["LevelAccess"] = LevelAccess.ToString();

                return View(PaginatedList<SerialReplacementModel>.CreateAsync(listSerialsReplacements.AsQueryable(), pageNumber ?? 1, pageSize));
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

        #region GET Detail Replacement

        public async Task<IActionResult> Details(int id)
        {
            try
            {
                string tokenValue = await this.GetTokenAccess();

                _clientHttpREST.SetToken(tokenValue);

                string repJson = await _clientHttpREST.GetObjetcAsync("api-operations/SerialsReplacements", id.ToString());

                SerialReplacementModel replacement = TypeModel<SerialReplacementModel>.DeserializeInObject(repJson);

                return View(replacement);
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

                SerialProductModel serial = new SerialProductModel();

                if (distributor == null)
                {
                    return Json(serial);
                }
                else
                {
                    string valor = distributor.description;
                    serial.Distributor = new DistributorModel();
                    serial.Distributor.description = distributor.description;
                    serial.DistributorId = distributor.id;
                    return Json(serial);
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

        #region  GET: SerialProduct/LoadSerialTest

        public IActionResult LoadSerialTest()
        {
            return View(new SerialReplacementModel());
        }

        #endregion

        #region  POST: SerialProduct/LoadSerialTest
        [HttpPost]
        public async Task<IActionResult> LoadSerialTest(SerialReplacementModel pSerial)
        {
            try
            {

                string tokenValue = await this.GetTokenAccess();

                _clientHttpREST.SetToken(tokenValue);

                String repJson1 = await _clientHttpREST.GetObjetcsAllAsync("api-operations/SerialsReplacements");

                List<SerialReplacementModel> srList = TypeModel<SerialReplacementModel>.DeserializeInArray(repJson1);

                //verificar si el serial indicado ya existe
                var sr = srList.Where(s => s.Serial == pSerial.Serial).FirstOrDefault();

                    if (sr != null)
                    {
                        Alert("El Serial del Repuesto ya existe.", NotificationType.info);

                        return View("~/Views/SerialReplacement/LoadSerialTest.cshtml");
                    }
                

                string repJson = await _clientHttpREST.GetObjetcsAllAsync("api-clients/Distributors");

                List<DistributorModel> listDistributors = TypeModel<DistributorModel>.DeserializeInArray(repJson);

                DistributorModel distributor = new DistributorModel();

                if (pSerial.Serial.Substring(0, 3).Equals("F02"))
                {  //Impresoras Fiscales 421
                    distributor = listDistributors.Where(d => d.rif == "J293987130").FirstOrDefault();
                    pSerial.ProviderId = 2;
                }
                else 
                {   
                    //The Facttory HKA
                    distributor = listDistributors.Where(d => d.rif == "J312171197").FirstOrDefault();
                    pSerial.ProviderId = 1;
                }
                

                pSerial.DistributorId = distributor.id;
                pSerial.Observations = "Serial de Pruebas Internas";

                string prefAlf = pSerial.Serial.Substring(0, 3);

                string repJson2 = await _clientHttpREST.GetObjetcsAllAsync("api-products/Prefixes");

                List<PrefixModel> listPrefixes = TypeModel<PrefixModel>.DeserializeInArray(repJson2);

                var prefixModel = listPrefixes.Where(p => p.InitAlphaNum == prefAlf).FirstOrDefault();

                if (prefixModel != null)
                {
                    string repJson3 = await _clientHttpREST.GetObjetcAsync("api-products/Replacements/ReplacementsByPrefix/Replacements", prefixModel.Id.ToString());

                    var replacement = TypeModel<ReplacementModel>.DeserializeInObject(repJson3);

                    if (replacement != null)
                    {
                        pSerial.ReplacementId = replacement.id;
                    }
                }

                pSerial.DateSale = DateTime.Now;

                String json = JsonConvert.SerializeObject(pSerial);

                String response = await _clientHttpREST.PostObjetcAsync("api-operations/SerialsReplacements", json);

                if (response.Equals("Created"))
                {
                    //Determino el Empleado para Registrar el Evento
                    var nameUser = _userManager.GetUserName(User);
                    string repJson3 = await _clientHttpREST.GetObjetcsAllAsync("api-employees/Employees");
                    List<EmployeeModel> listEmployees = TypeModel<EmployeeModel>.DeserializeInArray(repJson3);
                    var employee = listEmployees.Where(e => e.email == nameUser).FirstOrDefault();

                    if (employee != null)
                    { //Alimento el Registro de Actividades
                        var activity = new ActivityModel();
                        activity.EmployeeId = employee.id;
                        activity.ChargueId = employee.chargueId;
                        activity.DepartamentId = employee.departamentId;
                        activity.Process = "Seriales de Repuestos";
                        activity.Operation = "Carga Manual";
                        activity.Serial = pSerial.Serial;
                        activity.Detail = "Para uso interno";

                        String json1 = JsonConvert.SerializeObject(activity);

                        String response2 = await _clientHttpREST.PostObjetcAsync("api-operations/Activities", json1);
                    }

                    Alert("Operación Exitosa", NotificationType.success);

                    return RedirectToAction("Index");
                }
                else
                {
                    Alert("Error en la Operación", NotificationType.error);

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

        #region POST: LoadSerialTest2
        [HttpPost]
        public async Task<IActionResult> LoadSerialTest2(SerialReplacementModel pSerial)
        {
            try
            {
                string tokenValue = await this.GetTokenAccess();
                _clientHttpREST.SetToken(tokenValue);

                String repJson1 = await _clientHttpREST.GetObjetcsAllAsync("api-operations/SerialsReplacements");
                List<SerialReplacementModel> srList = TypeModel<SerialReplacementModel>.DeserializeInArray(repJson1);

                //verificar si el serial indicado ya existe
                var sr = srList.Where(s => s.Serial == pSerial.Serial).FirstOrDefault();

                if (sr != null)
                {
                    Alert("El Serial del Repuesto ya existe.", NotificationType.info);
                    return View("~/Views/SerialReplacement/LoadSerialTest.cshtml");
                }

                string repJson = await _clientHttpREST.GetObjetcsAllAsync("api-clients/Distributors");
             
                if (pSerial.Serial.Substring(0, 3).Equals("F02"))
                {  //Impresoras Fiscales 421                   
                    pSerial.ProviderId = 2;
                }
                else
                {
                    //The Facttory HKA                   
                    pSerial.ProviderId = 1;
                }

                string prefAlf = pSerial.Serial.Substring(0, 3);
                string repJson2 = await _clientHttpREST.GetObjetcsAllAsync("api-products/Prefixes");

                List<PrefixModel> listPrefixes = TypeModel<PrefixModel>.DeserializeInArray(repJson2);

                var prefixModel = listPrefixes.Where(p => p.InitAlphaNum == prefAlf).FirstOrDefault();

                if (prefixModel != null)
                {
                    string repJson3 = await _clientHttpREST.GetObjetcAsync("api-products/Replacements/ReplacementsByPrefix/Replacements", prefixModel.Id.ToString());
                    var replacement = TypeModel<ReplacementModel>.DeserializeInObject(repJson3);
                    if (replacement != null)
                    {
                        pSerial.ReplacementId = replacement.id;
                    }
                    else
                    {//Es un Producto
                        Alert("El Prefijo del Serial No es de Repuesto, pertenece a un Producto.", NotificationType.info);

                        return View("~/Views/SerialReplacement/LoadSerialTest.cshtml");
                    }
                }
                else
                {//No existe el Prefijo
                    Alert("Prefijo de Serial No Registrado", NotificationType.info);

                    return View("~/Views/SerialReplacement/LoadSerialTest.cshtml");
                }

                pSerial.DateSale = DateTime.Now;

                String json = JsonConvert.SerializeObject(pSerial);
                String response = await _clientHttpREST.PostObjetcAsync("api-operations/SerialsReplacements", json);

                if (response.Equals("Created"))
                {
                    //Determino el Empleado para Registrar el Evento
                    var nameUser = _userManager.GetUserName(User);
                    string repJson3 = await _clientHttpREST.GetObjetcsAllAsync("api-employees/Employees");
                    List<EmployeeModel> listEmployees = TypeModel<EmployeeModel>.DeserializeInArray(repJson3);
                    var employee = listEmployees.Where(e => e.email == nameUser).FirstOrDefault();

                    if (employee != null)
                    { //Alimento el Registro de Actividades
                        var activity = new ActivityModel();
                        activity.EmployeeId = employee.id;
                        activity.ChargueId = employee.chargueId;
                        activity.DepartamentId = employee.departamentId;
                        activity.Process = "Seriales de Repuestos";
                        activity.Operation = "Carga Manual";
                        activity.Serial = pSerial.Serial;
                        activity.Detail = "Para Distribudor partcular por Nota de Entrega";

                        String json1 = JsonConvert.SerializeObject(activity);

                        String response2 = await _clientHttpREST.PostObjetcAsync("api-operations/Activities", json1);
                    }

                    Alert("Operación Exitosa", NotificationType.success);

                    return RedirectToAction("Index");
                }
                else
                {
                    Alert("Error en la Operación", NotificationType.error);
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

        #region Upload

        [HttpPost]
        public async Task<IActionResult> UploadFile(IFormFile FormSerialFile, SerialReplacementModel serial)
        {

            serial.DistributorId = serial.DistributorId2;

            List<string> listProcess = new List<string>();
            List<string> listNoProcess = new List<string>();

            if (FormSerialFile == null || FormSerialFile.Length == 0)
            {
                Alert("Hubo un error, debe cargar un archivo válido", NotificationType.error);
                return View("~/Views/SerialProduct/LoadSerialTest.cshtml");
            }

            string extension;
            SerialReplacementModel pSerial = new SerialReplacementModel();

            var supportedTypes2 = new[] { ".txt" };
            extension = Path.GetExtension(FormSerialFile.FileName);
            if (!supportedTypes2.Contains(extension))
            {
                Alert("Hubo un error, debe cargar un archivo válido", NotificationType.error);
                return View("~/Views/SerialProduct/LoadSerialTest.cshtml");
            }
            string tokenValue = await this.GetTokenAccess();
            _clientHttpREST.SetToken(tokenValue);
            using (var reader = new StreamReader(FormSerialFile.OpenReadStream()))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    pSerial.Serial = line;

                    bool serialIsLetterOrDigit = line.All(char.IsLetterOrDigit);
                    if (!serialIsLetterOrDigit)
                    {
                        listNoProcess.Add(line + " (Debe ser solo Letras y Numeros)");
                        continue;
                    }
                    if ((line.Length < 6) || (line.Length > 13))
                    {
                        listNoProcess.Add(line + " (Longitud Invalida)");
                        continue;
                    }
                    try
                    {

                        String repJson1 = await _clientHttpREST.GetObjetcsAllAsync("api-operations/SerialsReplacements");
                        List<SerialReplacementModel> srList = TypeModel<SerialReplacementModel>.DeserializeInArray(repJson1);
                        //verificar si el serial indicado ya existe
                        var sr = srList.Where(s => s.Serial == line).FirstOrDefault();
                        if (sr != null)
                        {
                            listNoProcess.Add(line + " (Serial ya existente)");
                            continue;
                        }

                        string prefAlf = line.Substring(0, 3);
                        string repJson2 = await _clientHttpREST.GetObjetcsAllAsync("api-products/Prefixes");
                        List<PrefixModel> listPrefixes = TypeModel<PrefixModel>.DeserializeInArray(repJson2);
                        var prefixModel = listPrefixes.Where(p => p.InitAlphaNum == prefAlf).FirstOrDefault();
                        if (prefixModel == null)
                        {
                            listNoProcess.Add(line + " (Prefijo no registrado)");
                            continue;
                        }

                        string repJson = await _clientHttpREST.GetObjetcsAllAsync("api-clients/Distributors");
                        List<DistributorModel> listDistributors = TypeModel<DistributorModel>.DeserializeInArray(repJson);
                        DistributorModel distributor = new DistributorModel();

                        if (pSerial.Serial.Substring(0, 3).Equals("F02"))
                        {  //Impresoras Fiscales 421
                            pSerial.ProviderId = 2;
                        }
                        else
                        {
                            //The Facttory HKA
                            pSerial.ProviderId = 1;
                        }

                        if (prefixModel != null)
                        {
                            string repJson3 = await _clientHttpREST.GetObjetcAsync("api-products/Replacements/ReplacementsByPrefix/Replacements", prefixModel.Id.ToString());
                            var replacement = TypeModel<ReplacementModel>.DeserializeInObject(repJson3);
                            if (replacement != null)
                            {
                                pSerial.ReplacementId = replacement.id;
                            }
                        }

                        pSerial.DistributorId = serial.DistributorId;
                        pSerial.DateSale = DateTime.Now;
                        pSerial.Observations = serial.Observations;
                        String json = JsonConvert.SerializeObject(pSerial);
                        String response = await _clientHttpREST.PostObjetcAsync("api-operations/SerialsReplacements", json);
                        if (response.Equals("Created"))
                        {
                            //Determino el Empleado para Registrar el Evento
                            var nameUser = _userManager.GetUserName(User);
                            string repJson3 = await _clientHttpREST.GetObjetcsAllAsync("api-employees/Employees");
                            List<EmployeeModel> listEmployees = TypeModel<EmployeeModel>.DeserializeInArray(repJson3);
                            var employee = listEmployees.Where(e => e.email == nameUser).FirstOrDefault();

                            if (employee != null)
                            { //Alimento el Registro de Actividades
                                var activity = new ActivityModel();
                                activity.EmployeeId = employee.id;
                                activity.ChargueId = employee.chargueId;
                                activity.DepartamentId = employee.departamentId;
                                activity.Process = "Seriales de Repuestos";
                                activity.Operation = "Carga Manual por Lote";
                                activity.Serial = pSerial.Serial;
                                activity.Detail = "Para Distribudor partcular por Nota de Entrega";

                                String json1 = JsonConvert.SerializeObject(activity);

                                String response2 = await _clientHttpREST.PostObjetcAsync("api-operations/Activities", json1);
                            }

                            listProcess.Add(line);
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
            }
            string msnProcess = string.Join("<br>", listProcess);
            string msnNoProcess = string.Join("<br>", listNoProcess);

            pSerial.FileProcessMessage = "<b>Seriales Procesados:</b><br>" + msnProcess + " <br><b>Seriales No Procesados:</b><br>" + msnNoProcess;
            Alert("Archivo Leido", NotificationType.info);

            return RedirectToAction("FileProcess", "SerialReplacement", pSerial);

        }

        #endregion

        #region Post/Mensaje Procesados por Upload
        [HttpGet]
        public IActionResult FileProcess(SerialReplacementModel pSerial)
        {
            return View(pSerial);
        }
        #endregion

        #region GET: SerialReplacement/Import

        public async Task<IActionResult> Import()
        {
            try
            {
                
                ViewBag.Username = _userManager.GetUserName(User);

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

        #region DELETE GET Serial Replacement

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

                String json = await _clientHttpREST.GetObjetcAsync("api-operations/SerialsReplacements", id.ToString());

                SerialReplacementModel replacement = TypeModel<SerialReplacementModel>.DeserializeInObject(json);

                if (replacement == null)
                {
                    return NotFound();
                }

                return View(replacement);
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

        #region DELETE POST Serial Replacement

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, SerialReplacementModel collection)
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

                        String response2 = await _clientHttpREST.DeleteObjetcAsync("api-operations/SerialsReplacements", id.ToString());

                        if (response2.Equals("OK"))
                        {
                            //Determino el Empleado para Registrar el Evento
                            string repJson = await _clientHttpREST.GetObjetcsAllAsync("api-employees/Employees");
                            List<EmployeeModel> listEmployees = TypeModel<EmployeeModel>.DeserializeInArray(repJson);
                            var employee = listEmployees.Where(e => e.email == nameUser).FirstOrDefault();

                            if (employee != null)
                            { //Alimento el Registro de Actividades
                                var activity = new ActivityModel();
                                activity.EmployeeId = employee.id;
                                activity.ChargueId = employee.chargueId;
                                activity.DepartamentId = employee.departamentId;
                                activity.Process = "Seriales de Repuestos";
                                activity.Operation = "Borrado";
                                activity.Serial = collection.Serial;
                                activity.Detail = "Tramitado interno";

                                String json1 = JsonConvert.SerializeObject(activity);

                                String response3 = await _clientHttpREST.PostObjetcAsync("api-operations/Activities", json1);
                            }

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
                      ViewBag.Message = "Clave Errada";

                      String json2 = await _clientHttpREST.GetObjetcAsync("api-operations/SerialsReplacements", id.ToString());

                      collection = TypeModel<SerialReplacementModel>.DeserializeInObject(json2);

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