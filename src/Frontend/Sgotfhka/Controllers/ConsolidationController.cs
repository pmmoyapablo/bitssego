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
using System.IO;
using static Sisgtfhka.Enums.Enums;
using System.Xml;
using Microsoft.Extensions.FileProviders;

namespace Sisgtfhka.Controllers
{
    [Authorize]
    public class ConsolidationController : BaseController
    {

        private readonly IHttpContextAccessor _httpContextAccessor;
        private ISession _session => _httpContextAccessor.HttpContext.Session;

        public ConsolidationController(UserManager<ApplicationUser> userManager,
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

        #region GET Index Serial Productos

        public async Task<IActionResult> Index(string sortOrder,
                                       string currentFilter,
                                       string searchString,
                                       int? pageNumber, int proveedor)
        {
            try
            {


                if (proveedor != 0)
                {
                    HttpContext.Session.SetString("provider", proveedor.ToString());
                }
                else
                {
                    if (HttpContext.Session.GetString("provider") != null)
                    {
                        proveedor = Int32.Parse(HttpContext.Session.GetString("provider"));
                    }
                    else
                    {//Carga inicial por Default
                        proveedor = 1;
                        HttpContext.Session.SetString("provider", proveedor.ToString());
                    }
                }


                if (searchString != null)
                {
                    HttpContext.Session.SetString("dateSearch", searchString);
                }
                else
                {
                    if (HttpContext.Session.GetString("dateSearch") != null)
                    {
                        searchString = HttpContext.Session.GetString("dateSearch");
                    }else
                    {//Carga inicial por Default
                        searchString = DateTime.Now.Year.ToString() + "-" + DateTime.Now.Month.ToString().PadLeft(2, '0') + "-" + DateTime.Now.Day.ToString().PadLeft(2, '0');
                        HttpContext.Session.SetString("dateSearch", searchString);
                    }
                }



                string tokenValue = await this.GetTokenAccess();

                _clientHttpREST.SetToken(tokenValue);



                String json = await _clientHttpREST.GetObjetcsAllAsync("api-clients/Providers");

                List<ProviderModel> Provider = TypeModel<ProviderModel>.DeserializeInArray(json);

                List<SelectListItem> lst = new List<SelectListItem>();

                foreach (ProviderModel provider in Provider)
                {
                    lst.Add(new SelectListItem() { Text = provider.description, Value = provider.id.ToString() });
                }

                if (proveedor != 0)
                {
                    var item = lst.Find(p => p.Value == proveedor.ToString());
                    item.Selected = true;
                }

                ViewBag.Opciones = lst;


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

                if (!String.IsNullOrEmpty(searchString) && (proveedor != 0))
                {
                    DateTime date = Convert.ToDateTime(searchString);
                    listSerialsProducts = listSerialsProducts.Where(
                        sfp =>  sfp.DateSale.Year == date.Year
                     && sfp.DateSale.Month == date.Month 
                     && sfp.Provider.id == proveedor
                     ).ToList();

                }
                else if ((proveedor != 0))
                {
                    listSerialsProducts = listSerialsProducts.Where(
                        sfp => sfp.Provider.id == proveedor
                     ).ToList();
                }
                else if (!String.IsNullOrEmpty(searchString))
                {

                    DateTime dateSerialsProducts = DateTime.Parse(searchString);

                    listSerialsProducts = listSerialsProducts.Where(
                            sfp => sfp.DateSale.Year == dateSerialsProducts.Year
                            && sfp.DateSale.Month == dateSerialsProducts.Month
                     ).ToList();
                }

                switch (sortOrder)
                {
                    case "name_desc":
                        listSerialsProducts = listSerialsProducts.OrderByDescending(sfp => sfp.Serial).ToList();
                        break;
                    case "Date":
                        listSerialsProducts = listSerialsProducts.OrderBy(sfp => sfp.Serial).ToList();
                        break;
                    case "date_desc":
                        listSerialsProducts = listSerialsProducts.OrderByDescending(sfp => sfp.Serial).ToList();
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

        #region Get Enajenacion

        public async Task<IActionResult> Alienation(string sortOrder,
                                               string currentFilter,
                                               string searchString,
                                               int? pageNumber, int proveedor)
        {
            try
            {


                if (proveedor != 0)
                {
                    HttpContext.Session.SetString("provider", proveedor.ToString());
                }
                else
                {
                    if (HttpContext.Session.GetString("provider") != null)
                    {
                        proveedor = Int32.Parse(HttpContext.Session.GetString("provider"));
                    }
                    else
                    {//Carga inicial por Default
                        proveedor = 1;
                        HttpContext.Session.SetString("provider", proveedor.ToString());
                    }
                }


                if (searchString != null)
                {
                    HttpContext.Session.SetString("dateSearch", searchString);
                }
                else
                {
                    if (HttpContext.Session.GetString("dateSearch") != null)
                    {
                        searchString = HttpContext.Session.GetString("dateSearch");
                    }
                    else
                    {//Carga inicial por Default
                        searchString = DateTime.Now.Year.ToString() + "-" + DateTime.Now.Month.ToString().PadLeft(2, '0') + "-" + DateTime.Now.Day.ToString().PadLeft(2, '0');
                        HttpContext.Session.SetString("dateSearch", searchString);
                    }
                }




                string tokenValue = await this.GetTokenAccess();

                _clientHttpREST.SetToken(tokenValue);





                String json = await _clientHttpREST.GetObjetcsAllAsync("api-clients/Providers");

                List<ProviderModel> Provider = TypeModel<ProviderModel>.DeserializeInArray(json);

                List<SelectListItem> lst = new List<SelectListItem>();

                foreach (ProviderModel provider in Provider)
                {
                    lst.Add(new SelectListItem() { Text = provider.description, Value = provider.id.ToString() });
                }

                if (proveedor != 0)
                {
                    var item = lst.Find(p => p.Value == proveedor.ToString());
                    item.Selected = true;
                }

                ViewBag.Opciones = lst;







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



                if (!String.IsNullOrEmpty(searchString) && (proveedor != 0))
                {
                    DateTime date = Convert.ToDateTime(searchString);
                    listAlienations = listAlienations.Where(
                        sfp => sfp.AlienationDate.Year == date.Year
                     && sfp.AlienationDate.Month == date.Month
                     && sfp.Provider.id == proveedor
                     ).ToList();

                }
                else if ((proveedor != 0))
                {
                    listAlienations = listAlienations.Where(
                        sfp => sfp.Provider.id == proveedor
                     ).ToList();
                }
                else if (!String.IsNullOrEmpty(searchString))
                {

                    DateTime dateSerialsProducts = DateTime.Parse(searchString);

                    listAlienations = listAlienations.Where(
                            sfp => sfp.AlienationDate.Year == dateSerialsProducts.Year
                            && sfp.AlienationDate.Month == dateSerialsProducts.Month
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

        #region Get Operaciones Tecnicas

        public async Task<IActionResult> TechnicalsOperations(string sortOrder,
                                               string currentFilter,
                                               string searchString,
                                               int? pageNumber, int proveedor)
        {
            try
            {

                if (proveedor != 0)
                {
                    HttpContext.Session.SetString("provider", proveedor.ToString());
                }
                else
                {
                    if (HttpContext.Session.GetString("provider") != null)
                    {
                        proveedor = Int32.Parse(HttpContext.Session.GetString("provider"));
                    }
                    else
                    {//Carga inicial por Default
                        proveedor = 1;
                        HttpContext.Session.SetString("provider", proveedor.ToString());
                    }
                }


                if (searchString != null)
                {
                    HttpContext.Session.SetString("dateSearch", searchString);
                }
                else
                {
                    if (HttpContext.Session.GetString("dateSearch") != null)
                    {
                        searchString = HttpContext.Session.GetString("dateSearch");
                    }
                    else
                    {//Carga inicial por Default
                        searchString = DateTime.Now.Year.ToString() + "-" + DateTime.Now.Month.ToString().PadLeft(2, '0') + "-" + DateTime.Now.Day.ToString().PadLeft(2, '0');
                        HttpContext.Session.SetString("dateSearch", searchString);
                    }
                }




                string tokenValue = await this.GetTokenAccess();

                _clientHttpREST.SetToken(tokenValue);




                String json = await _clientHttpREST.GetObjetcsAllAsync("api-clients/Providers");

                List<ProviderModel> Provider = TypeModel<ProviderModel>.DeserializeInArray(json);

                List<SelectListItem> lst = new List<SelectListItem>();

                foreach (ProviderModel provider in Provider)
                {
                    lst.Add(new SelectListItem() { Text = provider.description, Value = provider.id.ToString() });
                }

                if (proveedor != 0)
                {
                    var item = lst.Find(p => p.Value == proveedor.ToString());
                    item.Selected = true;
                }

                ViewBag.Opciones = lst;





                string respJson = await _clientHttpREST.GetObjetcsAllAsync("api-operations/TechnicalsOperations");

                List<TechnicalOperationModel> listTechnicalOperation = TypeModel<TechnicalOperationModel>.DeserializeInArray(respJson);



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



                if (!String.IsNullOrEmpty(searchString) && (proveedor != 0))
                {
                    DateTime date = Convert.ToDateTime(searchString);

                    listTechnicalOperation = listTechnicalOperation.Where(
                        sfp => sfp.Operation_Date.Year == date.Year
                     && sfp.Operation_Date.Month == date.Month
                     && sfp.Provider.id == proveedor
                     ).ToList();

                }
                else if ((proveedor != 0))
                {
                    listTechnicalOperation = listTechnicalOperation.Where(
                        sfp => sfp.Provider.id == proveedor
                     ).ToList();
                }
                else if (!String.IsNullOrEmpty(searchString))
                {

                    DateTime dateSerialsProducts = DateTime.Parse(searchString);

                    listTechnicalOperation = listTechnicalOperation.Where(
                               sfp => sfp.Operation_Date.Year == dateSerialsProducts.Year
                            && sfp.Operation_Date.Month == dateSerialsProducts.Month
                     ).ToList();
                }










                switch (sortOrder)
                {
                    case "name_desc":
                        listTechnicalOperation = listTechnicalOperation.OrderByDescending(a => a.Serial).ToList();
                        break;

                    case "Date":
                        listTechnicalOperation = listTechnicalOperation.OrderBy(a => a.Serial).ToList();
                        break;

                    case "date_desc":
                        listTechnicalOperation = listTechnicalOperation.OrderByDescending(a => a.Serial).ToList();
                        break;

                    default:
                        listTechnicalOperation = listTechnicalOperation.OrderBy(a => a.Serial).ToList();
                        break;

                }

                int pageSize = 8;

                ViewData["RolId"] = RolId.ToString();
                ViewData["LevelAccess"] = LevelAccess.ToString();

                return View(PaginatedList<TechnicalOperationModel>.CreateAsync(listTechnicalOperation.AsQueryable(), pageNumber ?? 1, pageSize));

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

        #region Exportar a Excel
        [HttpGet]
        public async Task<IActionResult> ExportarExcel()
        {

            int proveedor = 0;
            string searchString = null;

            try
            {

                if (HttpContext.Session.GetString("provider") != null)
                {
                    proveedor = Int32.Parse(HttpContext.Session.GetString("provider"));
                }

                if (HttpContext.Session.GetString("dateSearch") != null)
                {
                    searchString = HttpContext.Session.GetString("dateSearch");
                }


                string tokenValue = await this.GetTokenAccess();

                _clientHttpREST.SetToken(tokenValue);

                string repJson0 = await _clientHttpREST.GetObjetcAsync("api-clients/Providers", proveedor.ToString());

                var providerInfo = TypeModel<ProviderModel>.DeserializeInObject(repJson0);

                string[] arryDate = searchString.Split('-');
                string perio_decla = arryDate[0] + "-" + arryDate[1];
                string fileName = providerInfo.description.Replace(" ", "_") + "-" + perio_decla + ".xls";


                MemoryStream fs = new MemoryStream();
                TextWriter sw = new StreamWriter(fs);

                //System.IO.StreamWriter sw = new System.IO.StreamWriter("exportar.xls");
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

                sw.WriteLine("<ss:Column ss:Width='{0}'/>", 150);
                sw.WriteLine("<ss:Column ss:Width='{0}'/>", 200);
                sw.WriteLine("<ss:Column ss:Width='{0}'/>", 100);
                sw.WriteLine("<ss:Column ss:Width='{0}'/>", 60);
                sw.WriteLine("<ss:Column ss:Width='{0}'/>", 80);
                sw.WriteLine("<ss:Column ss:Width='{0}'/>", 90);
                sw.WriteLine("<ss:Column ss:Width='{0}'/>", 200);
                sw.WriteLine("<ss:Column ss:Width='{0}'/>", 400);

                sw.WriteLine("<ss:Row ss:StyleID='1'>");


                // Nombrar las columnas

                sw.WriteLine("<ss:Cell>");
                sw.WriteLine(String.Format("<ss:Data ss:Type='String'>{0}</ss:Data>", "RIF DEL CONTRIBUYENTE"));
                sw.WriteLine("</ss:Cell>");
                sw.WriteLine("<ss:Cell>");
                sw.WriteLine(String.Format("<ss:Data ss:Type='String'>{0}</ss:Data>", "PROVEEDOR, DISTRIBUIDOR o SERVICIO TECNICO (RIF)"));
                sw.WriteLine("</ss:Cell>");
                sw.WriteLine("<ss:Cell>");
                sw.WriteLine(String.Format("<ss:Data ss:Type='String'>{0}</ss:Data>", "FECHA"));
                sw.WriteLine("</ss:Cell>");
                sw.WriteLine("<ss:Cell>");
                sw.WriteLine(String.Format("<ss:Data ss:Type='String'>{0}</ss:Data>", "MARCA"));
                sw.WriteLine("</ss:Cell>");
                sw.WriteLine("<ss:Cell>");
                sw.WriteLine(String.Format("<ss:Data ss:Type='String'>{0}</ss:Data>", "MODELO"));
                sw.WriteLine("</ss:Cell>");
                sw.WriteLine("<ss:Cell>");
                sw.WriteLine(String.Format("<ss:Data ss:Type='String'>{0}</ss:Data>", "NRO. REGISTRO DE LA MF"));
                sw.WriteLine("</ss:Cell>");
                sw.WriteLine("<ss:Cell>");
                sw.WriteLine(String.Format("<ss:Data ss:Type='String'>{0}</ss:Data>", "TIPO DE OPERACIÓN"));
                sw.WriteLine("</ss:Cell>");
                sw.WriteLine("<ss:Cell>");
                sw.WriteLine(String.Format("<ss:Data ss:Type='String'>{0}</ss:Data>", "OBSERVACIONES"));
                sw.WriteLine("</ss:Cell>");



                sw.WriteLine("</ss:Row>");






                string repJson = await _clientHttpREST.GetObjetcsAllAsync("api-operations/SerialsProducts");

                List<SerialProductModel> listSerialsProducts = TypeModel<SerialProductModel>.DeserializeInArray(repJson);


                if (!String.IsNullOrEmpty(searchString) && (proveedor != 0))
                {
                    DateTime date = DateTime.Parse(searchString);
                    listSerialsProducts = listSerialsProducts.Where(
                        sfp => sfp.DateSale.Year == date.Year
                     && sfp.DateSale.Month == date.Month
                     && sfp.Provider.id == proveedor
                     ).ToList();

                }
                else if ((proveedor != 0))
                {
                    listSerialsProducts = listSerialsProducts.Where(
                        sfp => sfp.Provider.id == proveedor
                     ).ToList();
                }
                else if (!String.IsNullOrEmpty(searchString))
                {

                    DateTime dateSerialsProducts = DateTime.Parse(searchString);

                    listSerialsProducts = listSerialsProducts.Where(
                               sfp => sfp.DateSale.Year == dateSerialsProducts.Year
                            && sfp.DateSale.Month == dateSerialsProducts.Month
                     ).ToList();
                }



                foreach (SerialProductModel serialProduct in listSerialsProducts)
                {



                    sw.WriteLine(String.Format("<ss:Row ss:Height ='{0}'>", 12));

                    sw.WriteLine("<ss:Cell>");
                    sw.WriteLine(String.Format("<ss:Data ss:Type='String'>{0}</ss:Data>", ""));
                    sw.WriteLine("</ss:Cell>");

                    sw.WriteLine("<ss:Cell>");
                    sw.WriteLine(String.Format("<ss:Data ss:Type='String'>{0}</ss:Data>", serialProduct.Distributor.rif));
                    sw.WriteLine("</ss:Cell>");

                    sw.WriteLine("<ss:Cell>");
                    sw.WriteLine(String.Format("<ss:Data ss:Type='String'>{0}</ss:Data>", serialProduct.DateSale));
                    sw.WriteLine("</ss:Cell>");

                    sw.WriteLine("<ss:Cell>");
                    sw.WriteLine(String.Format("<ss:Data ss:Type='String'>{0}</ss:Data>", serialProduct.Product.Model.Mark.name));
                    sw.WriteLine("</ss:Cell>");

                    sw.WriteLine("<ss:Cell>");
                    sw.WriteLine(String.Format("<ss:Data ss:Type='String'>{0}</ss:Data>", serialProduct.Product.Model.name));
                    sw.WriteLine("</ss:Cell>");

                    sw.WriteLine("<ss:Cell>");
                    sw.WriteLine(String.Format("<ss:Data ss:Type='String'>{0}</ss:Data>", serialProduct.Serial));
                    sw.WriteLine("</ss:Cell>");

                    sw.WriteLine("<ss:Cell>");
                    sw.WriteLine(String.Format("<ss:Data ss:Type='String'>{0}</ss:Data>", ""));
                    sw.WriteLine("</ss:Cell>");

                    sw.WriteLine("<ss:Cell>");
                    sw.WriteLine(String.Format("<ss:Data ss:Type='String'>{0}</ss:Data>", serialProduct.Observations));
                    sw.WriteLine("</ss:Cell>");

                    sw.WriteLine("</ss:Row>");

                }





                string respJson = await _clientHttpREST.GetObjetcsAllAsync("api-operations/Alienations");

                List<AlienationModel> listAlienations = TypeModel<AlienationModel>.DeserializeInArray(respJson);


                if (!String.IsNullOrEmpty(searchString) && (proveedor != 0))
                {
                    DateTime date = DateTime.Parse(searchString);

                    listAlienations = listAlienations.Where(
                        sfp => sfp.AlienationDate.Year == date.Year
                     && sfp.AlienationDate.Month == date.Month
                     && sfp.Provider.id == proveedor
                     ).ToList();

                }
                else if ((proveedor != 0))
                {
                    listAlienations = listAlienations.Where(
                        sfp => sfp.Provider.id == proveedor
                     ).ToList();
                }
                else if (!String.IsNullOrEmpty(searchString))
                {

                    DateTime dateSerialsProducts = DateTime.Parse(searchString);

                    listAlienations = listAlienations.Where(
                               sfp => sfp.AlienationDate.Year == dateSerialsProducts.Year
                            && sfp.AlienationDate.Month == dateSerialsProducts.Month
                     ).ToList();
                }





                foreach (AlienationModel alienation in listAlienations)
                {

                    var product = GetProduct(alienation.Serial.Substring(0,3)).Result;

                    sw.WriteLine(String.Format("<ss:Row ss:Height ='{0}'>", 12));

                    sw.WriteLine("<ss:Cell>");
                    sw.WriteLine(String.Format("<ss:Data ss:Type='String'>{0}</ss:Data>", alienation.FinalClient.Rif));
                    sw.WriteLine("</ss:Cell>");

                    sw.WriteLine("<ss:Cell>");
                    sw.WriteLine(String.Format("<ss:Data ss:Type='String'>{0}</ss:Data>", alienation.Distributor.rif));
                    sw.WriteLine("</ss:Cell>");

                    sw.WriteLine("<ss:Cell>");
                    sw.WriteLine(String.Format("<ss:Data ss:Type='String'>{0}</ss:Data>", alienation.AlienationDate));
                    sw.WriteLine("</ss:Cell>");

                    sw.WriteLine("<ss:Cell>");
                    sw.WriteLine(String.Format("<ss:Data ss:Type='String'>{0}</ss:Data>", product != null ? product.Model.Mark.name : ""));
                    sw.WriteLine("</ss:Cell>");

                    sw.WriteLine("<ss:Cell>");
                    sw.WriteLine(String.Format("<ss:Data ss:Type='String'>{0}</ss:Data>", product != null ? product.Model.name : ""));
                    sw.WriteLine("</ss:Cell>");

                    sw.WriteLine("<ss:Cell>");
                    sw.WriteLine(String.Format("<ss:Data ss:Type='String'>{0}</ss:Data>", alienation.Serial));
                    sw.WriteLine("</ss:Cell>");

                    sw.WriteLine("<ss:Cell>");
                    sw.WriteLine(String.Format("<ss:Data ss:Type='String'>{0}</ss:Data>", "01"));
                    sw.WriteLine("</ss:Cell>");

                    sw.WriteLine("<ss:Cell>");
                    sw.WriteLine(String.Format("<ss:Data ss:Type='String'>{0}</ss:Data>", alienation.Observations));
                    sw.WriteLine("</ss:Cell>");

                    sw.WriteLine("</ss:Row>");

                }




                string respJson2 = await _clientHttpREST.GetObjetcsAllAsync("api-operations/TechnicalsOperations");

                List<TechnicalOperationModel> listTechnicalOperation = TypeModel<TechnicalOperationModel>.DeserializeInArray(respJson2);


                if (!String.IsNullOrEmpty(searchString) && (proveedor != 0))
                {
                    DateTime date = DateTime.Parse(searchString);
                    listTechnicalOperation = listTechnicalOperation.Where(
                        sfp => sfp.Operation_Date.Year == date.Year
                     && sfp.Operation_Date.Month == date.Month
                     && sfp.Provider.id == proveedor
                     ).ToList();

                }
                else if ((proveedor != 0))
                {
                    listTechnicalOperation = listTechnicalOperation.Where(
                        sfp => sfp.Provider.id == proveedor
                     ).ToList();
                }
                else if (!String.IsNullOrEmpty(searchString))
                {

                    DateTime dateSerialsProducts = DateTime.Parse(searchString);

                    listTechnicalOperation = listTechnicalOperation.Where(
                               sfp => sfp.Operation_Date.Year == dateSerialsProducts.Year
                            && sfp.Operation_Date.Month == dateSerialsProducts.Month
                     ).ToList();
                }




                foreach (TechnicalOperationModel technicalOperation in listTechnicalOperation)
                {

                    var product = GetProduct(technicalOperation.Serial.Substring(0, 3)).Result;

                    sw.WriteLine(String.Format("<ss:Row ss:Height ='{0}'>", 12));

                    sw.WriteLine("<ss:Cell>");
                    sw.WriteLine(String.Format("<ss:Data ss:Type='String'>{0}</ss:Data>", technicalOperation.FinalClient.Rif));
                    sw.WriteLine("</ss:Cell>");

                    sw.WriteLine("<ss:Cell>");
                    sw.WriteLine(String.Format("<ss:Data ss:Type='String'>{0}</ss:Data>", technicalOperation.Technician.rif));
                    sw.WriteLine("</ss:Cell>");

                    sw.WriteLine("<ss:Cell>");
                    sw.WriteLine(String.Format("<ss:Data ss:Type='String'>{0}</ss:Data>", technicalOperation.Operation_Date));
                    sw.WriteLine("</ss:Cell>");

                    sw.WriteLine("<ss:Cell>");
                    sw.WriteLine(String.Format("<ss:Data ss:Type='String'>{0}</ss:Data>", product != null ? product.Model.Mark.name : ""));
                    sw.WriteLine("</ss:Cell>");

                    sw.WriteLine("<ss:Cell>");
                    sw.WriteLine(String.Format("<ss:Data ss:Type='String'>{0}</ss:Data>", product != null ? product.Model.name : ""));
                    sw.WriteLine("</ss:Cell>");

                    sw.WriteLine("<ss:Cell>");
                    sw.WriteLine(String.Format("<ss:Data ss:Type='String'>{0}</ss:Data>", technicalOperation.Serial));
                    sw.WriteLine("</ss:Cell>");

                    sw.WriteLine("<ss:Cell>");
                    sw.WriteLine(String.Format("<ss:Data ss:Type='String'>{0}</ss:Data>",  technicalOperation.TypeOperationTech.Description));
                    sw.WriteLine("</ss:Cell>");

                    sw.WriteLine("<ss:Cell>");
                    sw.WriteLine(String.Format("<ss:Data ss:Type='String'>{0}</ss:Data>", technicalOperation.Observation));
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

        #region Exportar a XML
        [HttpGet]
        public async Task<IActionResult> ExportarXML()
        {

            int proveedor = 0;
            string searchString = null;

            try
            {

                if (HttpContext.Session.GetString("provider") != null)
                {
                    proveedor = Int32.Parse(HttpContext.Session.GetString("provider"));
                }

                if (HttpContext.Session.GetString("dateSearch") != null)
                {
                    searchString = HttpContext.Session.GetString("dateSearch");
                }


                string tokenValue = await this.GetTokenAccess();

                _clientHttpREST.SetToken(tokenValue);

                string repJson0 = await _clientHttpREST.GetObjetcAsync("api-clients/Providers", proveedor.ToString());

                var providerInfo = TypeModel<ProviderModel>.DeserializeInObject(repJson0);

                string[] arryDate = searchString.Split('-');
                string perio_decla = arryDate[0] + "-" + arryDate[1];
                string fileName = providerInfo.description.Replace(" ", "_") + "-" + perio_decla + ".xml";
                string pathTemp = Path.GetTempPath();
                //var fileProvider = new PhysicalFileProvider(Directory.GetCurrentDirectory());
                pathTemp = pathTemp + fileName;
                // MemoryStream stream = new MemoryStream();
                // XmlWriter writer = XmlWriter.Create(stream);
                XmlTextWriter writer = new XmlTextWriter(pathTemp, System.Text.Encoding.ASCII);
                writer.WriteStartDocument();
                writer.WriteComment("DECLARACION DE ENAJENACIONES DEL PERIODO " + perio_decla + " DEL PROVEEDOR " + providerInfo.description);
                writer.WriteStartElement("Proveedor");
                writer.WriteAttributeString("RIF_proveedor", providerInfo.rif);
                writer.WriteAttributeString("Periodo_Declaracion", perio_decla);


                string repJson = await _clientHttpREST.GetObjetcsAllAsync("api-operations/SerialsProducts");

                List<SerialProductModel> listSerialsProducts = TypeModel<SerialProductModel>.DeserializeInArray(repJson);


                if (!String.IsNullOrEmpty(searchString) && (proveedor != 0))
                {
                    DateTime date = DateTime.Parse(searchString);

                    listSerialsProducts = listSerialsProducts.Where(
                        sfp => sfp.DateSale.Year == date.Year
                     && sfp.DateSale.Month == date.Month
                     && sfp.Provider.id == proveedor
                     ).ToList();

                }
                else if ((proveedor != 0))
                {
                    listSerialsProducts = listSerialsProducts.Where(
                        sfp => sfp.Provider.id == proveedor
                     ).ToList();
                }
                else if (!String.IsNullOrEmpty(searchString))
                {

                    DateTime dateSerialsProducts = DateTime.Parse(searchString);

                    listSerialsProducts = listSerialsProducts.Where(
                               sfp => sfp.DateSale.Year == dateSerialsProducts.Year
                            && sfp.DateSale.Month == dateSerialsProducts.Month
                     ).ToList();
                }

                //Agrupamos los Distrubiodores de Seriales Vendidos

                var listGroupSerials = listSerialsProducts.GroupBy(s => s.DistributorId).ToList();


                listSerialsProducts = listSerialsProducts.OrderBy(s => s.DistributorId).ToList();

                string respJson = await _clientHttpREST.GetObjetcsAllAsync("api-operations/Alienations");

                List<AlienationModel> listAlienations = TypeModel<AlienationModel>.DeserializeInArray(respJson);


                if (!String.IsNullOrEmpty(searchString) && (proveedor != 0))
                {
                    DateTime date = DateTime.Parse(searchString);

                    listAlienations = listAlienations.Where(
                        sfp => sfp.AlienationDate.Year == date.Year
                     && sfp.AlienationDate.Month == date.Month
                     && sfp.Provider.id == proveedor
                     ).ToList();

                }
                else if ((proveedor != 0))
                {
                    listAlienations = listAlienations.Where(
                        sfp => sfp.Provider.id == proveedor
                     ).ToList();
                }
                else if (!String.IsNullOrEmpty(searchString))
                {

                    DateTime dateSerialsProducts = DateTime.Parse(searchString);

                    listAlienations = listAlienations.Where(
                               sfp => sfp.AlienationDate.Year == dateSerialsProducts.Year
                            && sfp.AlienationDate.Month == dateSerialsProducts.Month
                     ).ToList();
                }

                //Agrupamos los Distrubiodores de Enajenaciones

                var listGroupEnajen = listAlienations.GroupBy(a => a.DistributorId);

                listAlienations = listAlienations.OrderBy(a => a.DistributorId).ToList();

                //Etiquetas agrupadas por Distribuidor para Enajenaciones y Seriales Vendidos
                if (listSerialsProducts.Count > 0) //Verifica si hay Maquinas Vendidas y Enajenaciones
                {
                    List<int> keys = new List<int>();
                    foreach (var v in listGroupSerials)
                    {
                        var ditributor = listGroupSerials.Single(g => g.Key == v.Key).FirstOrDefault().Distributor;
                        writer.WriteStartElement("Distribuidor");
                        writer.WriteAttributeString("Rif_distribuidor", ditributor.rif);

                        var group = listGroupEnajen.Where(g => g.Key == v.Key);
                        var groupUsr = new List<AlienationModel>();
                        if (group.Count() > 0)
                        { groupUsr = listGroupEnajen.Single(g => g.Key == v.Key).ToList(); }

                        if (groupUsr.Count > 0)
                        {
                            keys.Add(v.Key);

                            foreach (AlienationModel alienation in groupUsr)
                            {
                                writer.WriteStartElement("Usuario");
                                writer.WriteElementString("RIF_usuario", alienation.FinalClient.Rif);  //RIF Cliente Final
                                writer.WriteElementString("Numero_registro_maquina", alienation.Serial); //Serial de Maquina
                                writer.WriteElementString("Fecha_operacion", alienation.AlienationDate.ToString("yyyy-MM-dd"));   //Feha de Enajenacion
                                writer.WriteElementString("Tipo_operacion", "01");  //Tipo de Operación siempre 01
                                writer.WriteElementString("Observaciones", alienation.Observations); //Observaciones de Enajenacion
                                writer.WriteEndElement();
                            }
                        }

                        var groupMaq = listGroupSerials.Single(g => g.Key == v.Key).ToList();

                        foreach (SerialProductModel serialProduct in groupMaq)
                        {

                            writer.WriteStartElement("Maquinas");  //Seriales Vendidos
                            writer.WriteElementString("Numero_registro_maquina", serialProduct.Serial);  //Serial
                            writer.WriteElementString("Fecha_operacion", serialProduct.DateSale.ToString("yyyy-MM-dd")); //Fecha de Venta
                            writer.WriteElementString("Tipo_operacion", "01"); //Siempre 01
                            writer.WriteElementString("Observaciones", serialProduct.Observations); //Observaciones
                            writer.WriteEndElement();

                        }

                        writer.WriteEndElement();  //Cierre de Nodo </Distribuidor>
                    }

                    //Solo Enajenaciones con Maquinas pero con Distribucion aparte
                    foreach (var v in listGroupEnajen)
                    {
                        int key = keys.Where(k => k == v.Key).FirstOrDefault();
                        if (key == 0)
                        {
                            var ditributor = listGroupEnajen.Single(g => g.Key == v.Key).FirstOrDefault().Distributor;
                            writer.WriteStartElement("Distribuidor");
                            writer.WriteAttributeString("Rif_distribuidor", ditributor.rif);

                            var groupUsr = listGroupEnajen.Single(g => g.Key == v.Key).ToList();

                            foreach (AlienationModel alienation in groupUsr)
                            {
                                writer.WriteStartElement("Usuario");
                                writer.WriteElementString("RIF_usuario", alienation.FinalClient.Rif);  //RIF Cliente Final
                                writer.WriteElementString("Numero_registro_maquina", alienation.Serial); //Serial de Maquina
                                writer.WriteElementString("Fecha_operacion", alienation.AlienationDate.ToString("yyyy-MM-dd"));   //Feha de Enajenacion
                                writer.WriteElementString("Tipo_operacion", "01");  //Tipo de Operación siempre 01
                                writer.WriteElementString("Observaciones", alienation.Observations); //Observaciones de Enajenacion
                                writer.WriteEndElement();
                            }

                            writer.WriteEndElement();  //Cierre de Nodo </Distribuidor>
                        }
                    }
                }
                else  //Verifica si solo hay Enajenaciones
                {
                    foreach (var v in listGroupEnajen)
                    {
                        var ditributor = listGroupEnajen.Single(g => g.Key == v.Key).FirstOrDefault().Distributor;
                        writer.WriteStartElement("Distribuidor");
                        writer.WriteAttributeString("Rif_distribuidor", ditributor.rif);

                        var groupUsr = listGroupEnajen.Single(g => g.Key == v.Key).ToList();

                        foreach (AlienationModel alienation in groupUsr)
                        {
                            writer.WriteStartElement("Usuario");
                            writer.WriteElementString("RIF_usuario", alienation.FinalClient.Rif);  //RIF Cliente Final
                            writer.WriteElementString("Numero_registro_maquina", alienation.Serial); //Serial de Maquina
                            writer.WriteElementString("Fecha_operacion", alienation.AlienationDate.ToString("yyyy-MM-dd"));   //Feha de Enajenacion
                            writer.WriteElementString("Tipo_operacion", "01");  //Tipo de Operación siempre 01
                            writer.WriteElementString("Observaciones", alienation.Observations); //Observaciones de Enajenacion
                            writer.WriteEndElement();
                        }

                        writer.WriteEndElement();  //Cierre de Nodo </Distribuidor>
                    }
                }


                string respJson2 = await _clientHttpREST.GetObjetcsAllAsync("api-operations/TechnicalsOperations");

                List<TechnicalOperationModel> listTechnicalOperation = TypeModel<TechnicalOperationModel>.DeserializeInArray(respJson2);


                if (!String.IsNullOrEmpty(searchString) && (proveedor != 0))
                {
                    DateTime date = DateTime.Parse(searchString);

                    listTechnicalOperation = listTechnicalOperation.Where(
                        sfp => sfp.Operation_Date.Year == date.Year
                     && sfp.Operation_Date.Month == date.Month
                     && sfp.Provider.id == proveedor
                     ).ToList();

                }
                else if ((proveedor != 0))
                {
                    listTechnicalOperation = listTechnicalOperation.Where(
                        sfp => sfp.Provider.id == proveedor
                     ).ToList();
                }
                else if (!String.IsNullOrEmpty(searchString))
                {

                    DateTime dateSerialsProducts = DateTime.Parse(searchString);

                    listTechnicalOperation = listTechnicalOperation.Where(
                            sfp => sfp.Operation_Date.Year == dateSerialsProducts.Year
                            && sfp.Operation_Date.Month == dateSerialsProducts.Month
                     ).ToList();
                }




                foreach (TechnicalOperationModel technicalOperation in listTechnicalOperation)
                {

                    writer.WriteStartElement("PersonalTecnico");   //Operacion Tecnica
                    writer.WriteElementString("RIF_personal_tecnico", technicalOperation.Technician.rif); //RIF del Tecnico
                    writer.WriteElementString("RIF_usuario", technicalOperation.FinalClient.Rif); //RIF de Cliente Final
                    writer.WriteElementString("Numero_registro_maquina", technicalOperation.Serial); // Serial de Maquina
                    writer.WriteElementString("Fecha_operacion", technicalOperation.Operation_Date.ToString("yyyy-MM-dd"));  //Fecha de la Operacion
                    writer.WriteElementString("Tipo_operacion", technicalOperation.TypeOperationTech.Id.ToString().PadLeft(2, '0'));  //Tipo de Operacion Tecnica typeOperationTechId ("00") Format
                    writer.WriteElementString("Observaciones", technicalOperation.Observation); //Observaciones de la operacion
                    writer.WriteEndElement();
                }



                writer.WriteEndElement();
                writer.WriteEndDocument();
                writer.Flush();
                writer.Close();


                // byte[] bytes = stream.ToArray();

                //Formatear los Nodos del XML
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(pathTemp);
                XmlNode root = xmlDoc.DocumentElement;
                xmlDoc.Save(pathTemp);

                byte[] bytes = System.IO.File.ReadAllBytes(pathTemp);

                DateTime dateNow = DateTime.Now;
                DateTime searchDate = DateTime.Parse(searchString);
                if (searchDate < dateNow)
                {
                    if (searchDate.Month != dateNow.Month)
                    {
                        String response = await _clientHttpREST.PutObjetcContentAndCodeAsync("api-operations/Alienations", proveedor + "/" + searchString, "");
                        String response2 = await _clientHttpREST.PutObjetcContentAndCodeAsync("api-operations/TechnicalsOperations", proveedor + "/" + searchString, "");
                    }
                }

                return File(bytes, "application/xml", fileName);

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

        [HttpGet]
        public IActionResult Refrescar()
        {

                HttpContext.Session.Remove("provider");
                HttpContext.Session.Remove("dateSearch");

            return RedirectToAction("Index");
        }

        private async Task<ProductModel> GetProduct(string prefix)
        {
            string repJson = await _clientHttpREST.GetObjetcsAllAsync("api-products/Products");

            List<ProductModel> listProducts = TypeModel<ProductModel>.DeserializeInArray(repJson);

            var product = listProducts.Where(p => p.Prefix.InitAlphaNum == prefix).FirstOrDefault();

            return product;

        }

    }
}