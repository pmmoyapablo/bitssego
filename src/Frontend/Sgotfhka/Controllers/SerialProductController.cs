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
using System.IO;
using System.Text;

namespace Sisgtfhka.Controllers
{
    [Authorize]
    public class SerialProductController : BaseController
    {
        public SerialProductController(UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            RoleManager<IdentityRole> roleManager,
            Services.ClientHttpREST clientHttpREST,
            ILogger<AccountController> logger,
            IOptions<AppSettings> settings)
            : base(userManager, signInManager, clientHttpREST, settings)
        {

        }

        #region  GET: SerialProduct
        public async Task<IActionResult> Index(string sortOrder,
                                               string currentFilter,
                                               string searchString,
                                               int? pageNumber)
        {
            try
            {
                string tokenValue = await this.GetTokenAccess();

                _clientHttpREST.SetToken(tokenValue);

                string repJson = await _clientHttpREST.GetObjetcsAllAsync("api-operations/SerialsProducts");

                List<SerialProductModel> listSerialsProducts = TypeModel<SerialProductModel>.DeserializeInArray(repJson);

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
                    listSerialsProducts = listSerialsProducts.Where(sfp => sfp.Serial.IndexOf(searchString, StringComparison.OrdinalIgnoreCase) >= 0
                    || sfp.Product.Name.IndexOf(searchString, StringComparison.OrdinalIgnoreCase) >= 0 
                    || sfp.Provider.description.IndexOf(searchString, StringComparison.OrdinalIgnoreCase) >= 0
                    || sfp.Distributor.rif.IndexOf(searchString, StringComparison.OrdinalIgnoreCase) >= 0
                    || sfp.DateSale.ToString().IndexOf(searchString, StringComparison.OrdinalIgnoreCase) >= 0
                    || sfp.Observations.IndexOf(searchString, StringComparison.OrdinalIgnoreCase) >= 0).ToList();
                }
                switch (sortOrder)
                {
                    case "name_desc":
                        listSerialsProducts = listSerialsProducts.OrderByDescending(sfp => sfp.Serial).ToList();
                        break;
                    case "Date":
                        listSerialsProducts = listSerialsProducts.OrderBy(sfp => sfp.DateSale).ToList();
                        break;
                    case "date_desc":
                        listSerialsProducts = listSerialsProducts.OrderByDescending(sfp => sfp.DateSale).ToList();
                        break;
                    default:
                        listSerialsProducts = listSerialsProducts.OrderBy(sfp => sfp.Serial).ToList();
                        break;
                }

                int pageSize = 8;

                ViewData["RolId"] = RolId.ToString();
                ViewData["LevelAccess"] = LevelAccess.ToString();

                return View(PaginatedList<SerialProductModel>.CreateAsync(listSerialsProducts.AsQueryable(), pageNumber ?? 1, pageSize));
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

        #region GET: SerialProduct/Details/5
        public async Task<IActionResult> Details(int id)
        {
            try
            {
                string tokenValue = await this.GetTokenAccess();

                _clientHttpREST.SetToken(tokenValue);

                string repJson = await _clientHttpREST.GetObjetcAsync("api-operations/SerialsProducts", id.ToString());

                SerialProductModel SerialProduct = TypeModel<SerialProductModel>.DeserializeInObject(repJson);

                return View(SerialProduct);
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

        #region GET: SerialProduct/Import

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
        [HttpGet]
        public IActionResult LoadSerialTest()
        {
            return View(new SerialProductModel());
        }

        #endregion

        #region  POST: SerialProduct/LoadSerialTest
        [HttpPost]
        public async Task<IActionResult> LoadSerialTest(SerialProductModel pSerial)
        {
           try{

                string tokenValue = await this.GetTokenAccess();

                _clientHttpREST.SetToken(tokenValue);

                String repJson1 = await _clientHttpREST.GetObjetcsAllAsync("api-operations/SerialsProducts");

                List<SerialProductModel> spList = TypeModel<SerialProductModel>.DeserializeInArray(repJson1);

                //verificar si el serial indicado ya existe
                var sp = spList.Where(s => s.Serial == pSerial.Serial).FirstOrDefault();
                
                    if (sp != null)
                    {
                        Alert("El Serial del Producto ya existe.", NotificationType.info);

                        return View("~/Views/SerialProduct/LoadSerialTest.cshtml");
                    }
                

                string repJson = await _clientHttpREST.GetObjetcsAllAsync("api-clients/Distributors");

                List<DistributorModel> listDistributors = TypeModel<DistributorModel>.DeserializeInArray(repJson);

                DistributorModel distributor = new DistributorModel();

                if (pSerial.Serial.Substring(0,1).Equals("Z"))
                {  //The Facttory HKA
                    distributor = listDistributors.Where(d => d.rif == "J312171197").FirstOrDefault();
                    pSerial.ProviderId = 1;
                }else if (pSerial.Serial.Substring(0, 1).Equals("D"))
                {   //Impresoras Fiscales 421
                    distributor = listDistributors.Where(d => d.rif == "J293987130").FirstOrDefault();
                    pSerial.ProviderId = 2;
                }
                else
                {   //HKA Venezuela
                    distributor = listDistributors.Where(d => d.rif == "J402385358").FirstOrDefault();
                    pSerial.ProviderId = 3;
                }
                
                pSerial.DistributorId = distributor.id;
                pSerial.Observations = "Serial de Pruebas Internas";

                string prefAlf = pSerial.Serial.Substring(0, 3);

                string repJson2 = await _clientHttpREST.GetObjetcsAllAsync("api-products/Prefixes");

                List<PrefixModel> listPrefixes = TypeModel<PrefixModel>.DeserializeInArray(repJson2);

                var prefixModel = listPrefixes.Where(p => p.InitAlphaNum == prefAlf).FirstOrDefault();

                if(prefixModel != null)
                {
                    string repJson3 = await _clientHttpREST.GetObjetcAsync("api-products/Products/ProductsByPrefix/Products", prefixModel.Id.ToString());

                    var product = TypeModel<ProductModel>.DeserializeInObject(repJson3);

                    if(product != null)
                    {
                        pSerial.ProductId = product.Id;
                    }
                }

                pSerial.DateSale = DateTime.Now;

                String json = JsonConvert.SerializeObject(pSerial);

                String response = await _clientHttpREST.PostObjetcAsync("api-operations/SerialsProducts", json);

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
                        activity.Process = "Seriales de Productos";
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
        public async Task<IActionResult> LoadSerialTest2(SerialProductModel pSerial)
        {
            try
            {

                string tokenValue = await this.GetTokenAccess();

                _clientHttpREST.SetToken(tokenValue);

                String repJson1 = await _clientHttpREST.GetObjetcsAllAsync("api-operations/SerialsProducts");

                List<SerialProductModel> spList = TypeModel<SerialProductModel>.DeserializeInArray(repJson1);

                //verificar si el serial indicado ya existe
                var sp = spList.Where(s => s.Serial == pSerial.Serial).FirstOrDefault();

                if (sp != null)
                {
                    Alert("El Serial del Producto ya existe.", NotificationType.info);

                    return View("~/Views/SerialProduct/LoadSerialTest.cshtml");
                }

                string repJson = await _clientHttpREST.GetObjetcsAllAsync("api-clients/Distributors");

                if (pSerial.Serial.Substring(0, 1).Equals("Z"))
                {  //The Facttory HKA                  
                    pSerial.ProviderId = 1;
                }
                else if (pSerial.Serial.Substring(0, 1).Equals("D"))
                {   //Impresoras Fiscales 421                   
                    pSerial.ProviderId = 2;
                }
                else
                {   //HKA Venezuela                   
                    pSerial.ProviderId = 3;
                }

                string prefAlf = pSerial.Serial.Substring(0, 3);

                string repJson2 = await _clientHttpREST.GetObjetcsAllAsync("api-products/Prefixes");

                List<PrefixModel> listPrefixes = TypeModel<PrefixModel>.DeserializeInArray(repJson2);

                var prefixModel = listPrefixes.Where(p => p.InitAlphaNum == prefAlf).FirstOrDefault();

                if (prefixModel != null)
                {
                    string repJson3 = await _clientHttpREST.GetObjetcAsync("api-products/Products/ProductsByPrefix/Products", prefixModel.Id.ToString());

                    var product = TypeModel<ProductModel>.DeserializeInObject(repJson3);

                    if (product != null)
                    {
                        pSerial.ProductId = product.Id;
                    }else
                    {//Es un Repuesto
                        Alert("El Prefijo del Serial No es de Producto, pertenece a un Repuesto.", NotificationType.info);

                        return View("~/Views/SerialProduct/LoadSerialTest.cshtml");
                    }
                }
                else
                {//No existe el Prefijo
                    Alert("Prefijo de Serial No Registrado", NotificationType.info);

                    return View("~/Views/SerialProduct/LoadSerialTest.cshtml");
                }

                pSerial.DistributorId = pSerial.DistributorId;
                pSerial.DateSale = DateTime.Now;

                String json = JsonConvert.SerializeObject(pSerial);
                String response = await _clientHttpREST.PostObjetcAsync("api-operations/SerialsProducts", json);

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
                        activity.Process = "Seriales de Productos";
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

        #region  GET: SerialProduct/Delete/5
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

                String json = await _clientHttpREST.GetObjetcAsync("api-operations/SerialsProducts", id.ToString());

                SerialProductModel serialProduct = TypeModel<SerialProductModel>.DeserializeInObject(json);

                if (serialProduct == null)
                {
                    return NotFound();
                }

                return View(serialProduct);
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

        #region  POST: SerialProduct/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, SerialProductModel collection)
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

                    String response2 = await _clientHttpREST.DeleteObjetcAsync("api-operations/SerialsProducts", id.ToString());

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
                            activity.Process = "Seriales de Productos";
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
                    String json2 = await _clientHttpREST.GetObjetcAsync("api-operations/SerialsProducts", id.ToString());

                    collection = TypeModel<SerialProductModel>.DeserializeInObject(json2);

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


        #region UPLOAD

        [HttpPost]
        public async Task<IActionResult> UploadFile(IFormFile FormSerialFile, SerialProductModel serial)
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
            SerialProductModel pSerial = new SerialProductModel();
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
                        String repJson1 = await _clientHttpREST.GetObjetcsAllAsync("api-operations/SerialsProducts");
                        List<SerialProductModel> spList = TypeModel<SerialProductModel>.DeserializeInArray(repJson1);
                        //verificar si el serial indicado ya existe
                        var sp = spList.Where(s => s.Serial == line).FirstOrDefault();
                        if (sp != null)
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
                        if (line.Substring(0, 1).Equals("Z"))
                        {  //The Facttory HKA
                            pSerial.ProviderId = 1;
                        }
                        else if (line.Substring(0, 1).Equals("D"))
                        {   //Impresoras Fiscales 421
                            pSerial.ProviderId = 2;
                        }
                        else
                        {   //HKA Venezuela
                            pSerial.ProviderId = 3;
                        }
                        if (prefixModel != null)
                        {
                            string repJson3 = await _clientHttpREST.GetObjetcAsync("api-products/Products/ProductsByPrefix/Products", prefixModel.Id.ToString());
                            var product = TypeModel<ProductModel>.DeserializeInObject(repJson3);
                            if (product != null)
                            {
                                pSerial.ProductId = product.Id;
                            }
                        }

                        pSerial.Serial = line;
                        pSerial.DistributorId = serial.DistributorId;
                        pSerial.DateSale = DateTime.Now;
                        pSerial.Observations = serial.Observations;
                        String json = JsonConvert.SerializeObject(pSerial);
                        String response = await _clientHttpREST.PostObjetcAsync("api-operations/SerialsProducts", json);
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
                                activity.Process = "Seriales de Productos";
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
            string msnProcess   = string.Join("<br>", listProcess);
            string msnNoProcess = string.Join("<br>", listNoProcess);

            pSerial.FileProcessMessage = "<b>Seriales Procesados:</b><br>" + msnProcess + " <br><b>Seriales No Procesados:</b><br>" + msnNoProcess;
            Alert("Archivo Leido", NotificationType.info);
            return RedirectToAction("FileProcess", "SerialProduct", pSerial);
        }

        #endregion

        #region Post/Mensaje Procesados por Upload
        [HttpGet]
        public IActionResult FileProcess(SerialProductModel pSerial)
        {
            return View(pSerial);
        }
        #endregion

    }



}

