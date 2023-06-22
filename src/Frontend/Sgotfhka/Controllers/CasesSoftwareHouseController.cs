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


namespace Sisgtfhka.Controllers
{
    public class CasesSoftwareHouseController : BaseController
    {
        public CasesSoftwareHouseController(UserManager<ApplicationUser> userManager,
           SignInManager<ApplicationUser> signInManager,
           RoleManager<IdentityRole> roleManager,
           Services.ClientHttpREST clientHttpREST,
           ILogger<AccountController> logger,
           IOptions<AppSettings> settings)
           : base(userManager, signInManager, roleManager, clientHttpREST, logger, settings)
        {

        }

        #region Index
        public async Task<IActionResult> Index(string sortOrder,
                                               string currentFilter,
                                               string SearchString, string SearchStatus, string SearchEmployee,
                                               int? pageNumber)
        {
            try
            {
                string tokenValue = await this.GetTokenAccess();

                _clientHttpREST.SetToken(tokenValue);

                string repJson = await _clientHttpREST.GetObjetcsAllAsync("api-utilities/CasesSoftwareHouses");

                List<CasesSoftwareHouse> listCases = TypeModel<CasesSoftwareHouse>.DeserializeInArray(repJson);
				
				if (!(RolId <= 7))
                {
                  listCases = listCases.Where(c => c.developersClients.email == _userManager.GetUserName(User)).ToList();
                }

                //Caso Select List de Status Integracion
                String json1 = await _clientHttpREST.GetObjetcsAllAsync("api-utilities/StatusIntegrations");
                List<StatusIntegration> status = TypeModel<StatusIntegration>.DeserializeInArray(json1);
                List<SelectListItem> lst1 = new List<SelectListItem>();
                foreach (StatusIntegration s in status)
                {
                    lst1.Add(new SelectListItem() { Text = s.name, Value = s.id.ToString() });
                }
                ViewBag.Opciones1 = lst1;

                //Caso Select List de Empleados - Soportistas
                String json2 = await _clientHttpREST.GetObjetcsAllAsync("api-employees/Employees");
                List<EmployeeModel> employees = TypeModel<EmployeeModel>.DeserializeInArray(json2);
                employees = employees.Where(e => e.chargueId == 4 || e.chargueId == 5 || e.chargueId == 6).ToList();
                List<SelectListItem> lst2 = new List<SelectListItem>();
                foreach (EmployeeModel s in employees)
                {
                    lst2.Add(new SelectListItem() { Text = s.description, Value = s.id.ToString() });
                }
                ViewBag.Opciones2 = lst2;

                ViewData["CurrentSort"] = sortOrder;
                ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
                ViewData["DateSortParm"] = sortOrder == "Date" ? "date_desc" : "Date";

                if (SearchString != null){
                    pageNumber = 1;
                }else{
                    SearchString = currentFilter;
                }

                ViewData["CurrentFilter"] = SearchString;
                ViewData["StatusFilter"] = SearchStatus;
                ViewData["EmployeeFilter"] = SearchEmployee;

                /*campos de busqueda*/
                /*todos llenos*/
                if (!String.IsNullOrEmpty(SearchString) && !String.IsNullOrEmpty(SearchStatus) && !String.IsNullOrEmpty(SearchEmployee))
                {
                    listCases = listCases.Where(m => m.developersClients.description.IndexOf(SearchStatus, StringComparison.OrdinalIgnoreCase) >= 0 &&
                                                     m.StatusIntegration.name.IndexOf(SearchString, StringComparison.OrdinalIgnoreCase) >= 0 &&
                                                     m.employee.description.IndexOf(SearchEmployee, StringComparison.OrdinalIgnoreCase) >= 0
                                               ).ToList();
                }
                else {
                    //solo viene DATO
                    if (!String.IsNullOrEmpty(SearchString)
                        //&& String.IsNullOrEmpty(SearchStatus) && String.IsNullOrEmpty(SearchEmployee)
                        )
                    {
                        listCases = listCases.Where(m => m.developersClients.document.IndexOf(SearchString, StringComparison.OrdinalIgnoreCase) >= 0 ||
                                                         m.developersClients.description.IndexOf(SearchString, StringComparison.OrdinalIgnoreCase) >= 0 ||
                                                         m.systemAdmin.IndexOf(SearchString, StringComparison.OrdinalIgnoreCase) >= 0 ||
                                                         m.programLanguage.name.IndexOf(SearchString, StringComparison.OrdinalIgnoreCase) >= 0 ||
                                                         m.StatusIntegration.name.IndexOf(SearchString, StringComparison.OrdinalIgnoreCase) >= 0 ||
                                                         m.employee.description.IndexOf(SearchString, StringComparison.OrdinalIgnoreCase) >= 0
                                                        ).ToList();
                    }
                    
                    //solo viene STATUS
                    if (String.IsNullOrEmpty(SearchString) && !String.IsNullOrEmpty(SearchStatus) && String.IsNullOrEmpty(SearchEmployee))
                    {
                        //listCases = listCases.Where(m =>m.StatusIntegration.id.IndexOf(SearchStatus, StringComparison.OrdinalIgnoreCase) >= 0 ).ToList();
                        //listCases = listCases.Where(m =>m.StatusIntegration.id.ToString(SearchStatus, StringComparison.OrdinalIgnoreCase) >=0).ToList();
                    }

                    //solo viene EMPLOYEE - soportista
                    if (String.IsNullOrEmpty(SearchString) && String.IsNullOrEmpty(SearchStatus) && !String.IsNullOrEmpty(SearchEmployee))
                    {
                        //listCases = listCases.Where(m => m.employee.id.IndexOf(SearchEmployee, StringComparison.OrdinalIgnoreCase) >= 0).ToList();
                        
                    }
                    
                }




                switch (sortOrder)
                {
                    case "name_desc":
                        listCases = listCases.OrderByDescending(m => m.systemAdmin).ToList();
                        break;
                    case "Date":
                        listCases = listCases.OrderBy(m => m.systemAdmin).ToList();
                        break;
                    case "date_desc":
                        listCases = listCases.OrderByDescending(m => m.systemAdmin).ToList();
                        break;
                    default:
                        listCases = listCases.OrderBy(m => m.systemAdmin).ToList();
                        break;
                }


                int pageSize = 8;

                ViewData["RolId"] = RolId.ToString();
                ViewData["LevelAccess"] = LevelAccess.ToString();

                return View(PaginatedList<CasesSoftwareHouse>.CreateAsync(listCases.AsQueryable(), pageNumber ?? 1, pageSize));
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
                //casos de casa de software
                string repJson = await _clientHttpREST.GetObjetcAsync("api-utilities/CasesSoftwareHouses", id.ToString());
                CasesSoftwareHouse cases = TypeModel<CasesSoftwareHouse>.DeserializeInObject(repJson);

                //Cargo los Productos asociados al Caso
                string repJson2 = await _clientHttpREST.GetObjetcAsync("api-utilities/CasesProducts/ByCase", id.ToString());
                var caseProducts = TypeModel<CasesProductModel>.DeserializeInArray(repJson2);

                cases.products = new List<ProductModel>();
                foreach (CasesProductModel c in caseProducts)
                {
                  cases.products.Add(c.product);
                }

                return View(cases);
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

        #region EditView
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
                //casos de casa de software
                String json = await _clientHttpREST.GetObjetcAsync("api-utilities/CasesSoftwareHouses", id.ToString());
                CasesSoftwareHouse ecase = TypeModel<CasesSoftwareHouse>.DeserializeInObject(json);

                //Caso Produto
                string repJson2 = await _clientHttpREST.GetObjetcAsync("api-utilities/CasesProducts/ByCase", id.ToString());
                var caseProducts = TypeModel<CasesProductModel>.DeserializeInArray(repJson2);

                ecase.products = new List<ProductModel>();
                foreach (CasesProductModel c in caseProducts)
                {
                    ecase.products.Add(c.product);
                }

                if (ecase == null)
                {
                    return NotFound();
                }

                // List de Status Integracion
                String json1 = await _clientHttpREST.GetObjetcsAllAsync("api-utilities/StatusIntegrations");
                List<StatusIntegration> status = TypeModel<StatusIntegration>.DeserializeInArray(json1);
                List<SelectListItem> lst = new List<SelectListItem>();        
                foreach (StatusIntegration s in status)
                {
                    lst.Add(new SelectListItem() { Text = s.name, Value = s.id.ToString() });
                }
                ViewBag.Opciones1 = lst;

                // List de Empleados - Soportista
                String json2 = await _clientHttpREST.GetObjetcsAllAsync("api-employees/Employees");
                List<EmployeeModel> employees = TypeModel<EmployeeModel>.DeserializeInArray(json2);
                employees = employees.Where(e => e.chargueId == 4 || e.chargueId == 5 || e.chargueId == 6).ToList();
                List<SelectListItem> lst2 = new List<SelectListItem>();
                foreach (EmployeeModel s in employees)
                {
                    lst2.Add(new SelectListItem() { Text = s.description, Value = s.id.ToString() });
                }
                ViewBag.Opciones2 = lst2;


                return View(ecase);
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;

                return View("~/Views/Shared/Error.cshtml", new ErrorViewModel { RequestId = Request.Path });
            }
        }
        #endregion

        #region Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, CasesSoftwareHouse pCase)
        {
            try
            {
                string tokenValue = await this.GetTokenAccess();
                _clientHttpREST.SetToken(tokenValue);

                if (ModelState.IsValid)
                {
                    //casos casa de software
                    String json = JsonConvert.SerializeObject(pCase);
                    String response = await _clientHttpREST.PutObjetcAsync("api-utilities/CasesSoftwareHouses", pCase.id.ToString(), json);

                    if (response.Equals("OK") || response.Equals("NoContent"))
                    {
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
                else
                {
                    return View(pCase);
                }
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;

                return View("~/Views/Shared/Error.cshtml", new ErrorViewModel { RequestId = Request.Path });
            }
        }
        #endregion

        #region DeleteView
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
                //caso casa de software
                String json = await _clientHttpREST.GetObjetcAsync("api-utilities/CasesSoftwareHouses", id.ToString());
                CasesSoftwareHouse dcase = TypeModel<CasesSoftwareHouse>.DeserializeInObject(json);

                if (dcase == null)
                {
                    return NotFound();
                }

                return View(dcase);
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

        #region Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, CasesSoftwareHouse collection)
        {
            try
            {
                string tokenValue = await this.GetTokenAccess();

                _clientHttpREST.SetToken(tokenValue);                

                //get del caso
                string repJsonCSH = await _clientHttpREST.GetObjetcAsync("api-utilities/CasesSoftwareHouses", id.ToString());
                CasesSoftwareHouse cases = TypeModel<CasesSoftwareHouse>.DeserializeInObject(repJsonCSH);

                //get del caso producto
                string repJsonCP = await _clientHttpREST.GetObjetcAsync("api-utilities/CasesProducts/ByCase", id.ToString());
                var caseProducts = TypeModel<CasesProductModel>.DeserializeInArray(repJsonCP);
                cases.products = new List<ProductModel>();
                //obtener el id del casoproducto
                foreach (CasesProductModel c in caseProducts)
                {
                    //cases.products.Add(c.product);
                    // se debe borrar primero el casoproducto
                    //POST DELETE CASE PRODCTO
                    String response1 = await _clientHttpREST.DeleteObjetcAsync("api-utilities/CasesProducts", c.id.ToString());

                }


                //delete del caso
                String response = await _clientHttpREST.DeleteObjetcAsync("api-utilities/CasesSoftwareHouses", id.ToString());

                if (response.Equals("OK") 
                    //&& response1.Equals("OK")
                    )
                {
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
                return View("~/Views/Shared/Error.cshtml", new ErrorViewModel { RequestId = Request.Path }); ;
            }
        }
        #endregion

        #region Index2
        public async Task<IActionResult> Index2(string sortOrder,
                                               string currentFilter,
                                               string SearchString, string SearchStatus, string SearchEmployee,
                                               int? pageNumber)
        {
            try
            {
                string tokenValue = await this.GetTokenAccess();

                _clientHttpREST.SetToken(tokenValue);

                string repJson = await _clientHttpREST.GetObjetcsAllAsync("api-utilities/CasesSoftwareHouses");

                List<CasesSoftwareHouse> listCases = TypeModel<CasesSoftwareHouse>.DeserializeInArray(repJson);
                 
				        if (!(RolId <= 7))
                {
                  listCases = listCases.Where(c => c.developersClients.email == _userManager.GetUserName(User)).ToList();
                }
				
                //Caso Select List de Status Integracion
                String json1 = await _clientHttpREST.GetObjetcsAllAsync("api-utilities/StatusIntegrations");
                List<StatusIntegration> status = TypeModel<StatusIntegration>.DeserializeInArray(json1);
                List<SelectListItem> lst1 = new List<SelectListItem>();
                foreach (StatusIntegration s in status)
                {
                    lst1.Add(new SelectListItem() { Text = s.name, Value = s.id.ToString() });
                }
                ViewBag.Opciones1 = lst1;

                //Caso Select List de Empleados 
                String json2 = await _clientHttpREST.GetObjetcsAllAsync("api-employees/Employees");
                List<EmployeeModel> employees = TypeModel<EmployeeModel>.DeserializeInArray(json2);
                employees = employees.Where(e => e.chargueId == 4 || e.chargueId == 5 || e.chargueId == 6).ToList();
                List<SelectListItem> lst2 = new List<SelectListItem>();
                foreach (EmployeeModel s in employees)
                {
                    lst2.Add(new SelectListItem() { Text = s.description, Value = s.id.ToString() });
                }
                ViewBag.Opciones2 = lst2;

                ViewData["CurrentSort"] = sortOrder;
                ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
                ViewData["DateSortParm"] = sortOrder == "Date" ? "date_desc" : "Date";

                DateTime dateCases = DateTime.Now;

                if (SearchString != null)
                {
                    pageNumber = 1;
                    dateCases = DateTime.Parse(SearchString);
                    //Establezco la variable de busqueda de Session para Filtro de Exportacion
                    HttpContext.Session.SetString("dateSearch", SearchString);
                }
                else
                {
                    SearchString = currentFilter;
                }                

                  //Ejecuto el Filtro por periodo YYYY-MM
                  listCases = listCases.Where(
                         sfp => sfp.dateRegister.Year == dateCases.Year &&
                         sfp.dateRegister.Month == dateCases.Month
                  ).ToList();

                ViewData["CurrentFilter"] = SearchString;
                ViewData["StatusFilter"] = SearchStatus;
                ViewData["EmployeeFilter"] = SearchEmployee;


                //solo viene STATUS
                if (String.IsNullOrEmpty(SearchString) && !String.IsNullOrEmpty(SearchStatus) && String.IsNullOrEmpty(SearchEmployee))
                {
                    listCases = listCases.Where(m =>
                                                     //m.developersClients.description.IndexOf(SearchStatus, StringComparison.OrdinalIgnoreCase) >= 0 ||
                                                     //m.systemAdmin.IndexOf(SearchStatus, StringComparison.OrdinalIgnoreCase) >= 0 ||
                                                     //m.programLanguage.name.IndexOf(SearchStatus, StringComparison.OrdinalIgnoreCase) >= 0 ||
                                                     m.StatusIntegration.name.IndexOf(SearchStatus, StringComparison.OrdinalIgnoreCase) >= 0 ||

                                                     //m.statusId.CompareTo(SearchStatus, StringComparison.OrdinalIgnoreCase) >= 0 ||
                                                     //m.statusId.Equals(SearchStatus, StringComparison.OrdinalIgnoreCase) >= 0 ||

                                                     m.employee.description.IndexOf(SearchStatus, StringComparison.OrdinalIgnoreCase) >= 0
                                              ).ToList();
                }

                //solo viene EMPLOYEE - soportista
                if (String.IsNullOrEmpty(SearchString) && String.IsNullOrEmpty(SearchStatus) && !String.IsNullOrEmpty(SearchEmployee))
                {
                    listCases = listCases.Where(m =>
                                                     //m.developersClients.description.IndexOf(SearchEmployee, StringComparison.OrdinalIgnoreCase) >= 0 ||
                                                     //m.systemAdmin.IndexOf(SearchEmployee, StringComparison.OrdinalIgnoreCase) >= 0 ||
                                                     //m.programLanguage.name.IndexOf(SearchEmployee, StringComparison.OrdinalIgnoreCase) >= 0 ||
                                                     m.StatusIntegration.name.IndexOf(SearchEmployee, StringComparison.OrdinalIgnoreCase) >= 0 ||
                                                     m.employee.description.IndexOf(SearchEmployee, StringComparison.OrdinalIgnoreCase) >= 0
                                              ).ToList();
                }



                switch (sortOrder)
                {
                    case "name_desc":
                        listCases = listCases.OrderByDescending(m => m.systemAdmin).ToList();
                        break;
                    case "Date":
                        listCases = listCases.OrderBy(m => m.systemAdmin).ToList();
                        break;
                    case "date_desc":
                        listCases = listCases.OrderByDescending(m => m.systemAdmin).ToList();
                        break;
                    default:
                        listCases = listCases.OrderBy(m => m.systemAdmin).ToList();
                        break;
                }


                int pageSize = 8;

                ViewData["RolId"] = RolId.ToString();
                ViewData["LevelAccess"] = LevelAccess.ToString();

                return View(PaginatedList<CasesSoftwareHouse>.CreateAsync(listCases.AsQueryable(), pageNumber ?? 1, pageSize));
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


        #region ExportarExcel
        [HttpGet]
        public async Task<IActionResult> ExportarExcel()
        {            
            try
            {
                string SearchString = null;

                if (HttpContext.Session.GetString("dateSearch") != null)
                {
                  SearchString = HttpContext.Session.GetString("dateSearch");
                }

                string tokenValue = await this.GetTokenAccess();

                _clientHttpREST.SetToken(tokenValue);

                string repJson0 = await _clientHttpREST.GetObjetcsAllAsync("api-utilities/CasesSoftwareHouses");

                var casesList = TypeModel<CasesSoftwareHouse>.DeserializeInArray(repJson0);

                DateTime dateCases = DateTime.Now;

                if (!String.IsNullOrEmpty(SearchString))
                {
                  dateCases = DateTime.Parse(SearchString);
                }
                else {
                   SearchString = dateCases.ToString();
                }

                casesList = casesList.Where(
                         sfp => sfp.dateRegister.Year == dateCases.Year &&
                         sfp.dateRegister.Month == dateCases.Month
                  ).ToList();

                //Cargo los Productos asociados a los Casos 
                foreach (CasesSoftwareHouse cases in casesList)
                {
                  string repJson2 = await _clientHttpREST.GetObjetcAsync("api-utilities/CasesProducts/ByCase", cases.id.ToString());
                  var caseProducts = TypeModel<CasesProductModel>.DeserializeInArray(repJson2);

                  cases.products = new List<ProductModel>();
                  foreach (CasesProductModel c in caseProducts)
                  {
                    cases.products.Add(c.product);
                  }
                }

                string perio_decla = dateCases.Year.ToString() + "-" + dateCases.Month.ToString().PadLeft(2,'0');
                string fileName =  "Casas_Software_TFHKA-" + perio_decla + ".xls";


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
                sw.WriteLine("<ss:Column ss:Width='{0}'/>", 80);
                sw.WriteLine("<ss:Column ss:Width='{0}'/>", 100);
                sw.WriteLine("<ss:Column ss:Width='{0}'/>", 80);
                sw.WriteLine("<ss:Column ss:Width='{0}'/>", 150);
                sw.WriteLine("<ss:Column ss:Width='{0}'/>", 80);
                sw.WriteLine("<ss:Column ss:Width='{0}'/>", 100);
                sw.WriteLine("<ss:Column ss:Width='{0}'/>", 100);
                sw.WriteLine("<ss:Column ss:Width='{0}'/>", 150);
                sw.WriteLine("<ss:Column ss:Width='{0}'/>", 150);
                sw.WriteLine("<ss:Column ss:Width='{0}'/>", 120);
                sw.WriteLine("<ss:Column ss:Width='{0}'/>", 80);
                sw.WriteLine("<ss:Column ss:Width='{0}'/>", 150);
                sw.WriteLine("<ss:Row ss:StyleID='1'>");


                // Nombrar las columnas
                    sw.WriteLine("<ss:Cell>");
                    sw.WriteLine(String.Format("<ss:Data ss:Type='String'>{0}</ss:Data>", "Casa de Software"));
                    sw.WriteLine("</ss:Cell>");
                    sw.WriteLine("<ss:Cell>");
                    sw.WriteLine(String.Format("<ss:Data ss:Type='String'>{0}</ss:Data>", "RIF"));
                    sw.WriteLine("</ss:Cell>");
                    sw.WriteLine("<ss:Cell>");
                    sw.WriteLine(String.Format("<ss:Data ss:Type='String'>{0}</ss:Data>", "Tipo"));
                    sw.WriteLine("</ss:Cell>");
                    sw.WriteLine("<ss:Cell>");
                    sw.WriteLine(String.Format("<ss:Data ss:Type='String'>{0}</ss:Data>", "Representante"));
                    sw.WriteLine("</ss:Cell>");
                    sw.WriteLine("<ss:Cell>");
                    sw.WriteLine(String.Format("<ss:Data ss:Type='String'>{0}</ss:Data>", "Telefono"));
                    sw.WriteLine("</ss:Cell>");
                    sw.WriteLine("<ss:Cell>");
                    sw.WriteLine(String.Format("<ss:Data ss:Type='String'>{0}</ss:Data>", "Email"));
                    sw.WriteLine("</ss:Cell>");
                    sw.WriteLine("<ss:Cell>");
                    sw.WriteLine(String.Format("<ss:Data ss:Type='String'>{0}</ss:Data>", "Pais"));
                    sw.WriteLine("</ss:Cell>");
                    sw.WriteLine("<ss:Cell>");
                    sw.WriteLine(String.Format("<ss:Data ss:Type='String'>{0}</ss:Data>", "Ciudad"));
                    sw.WriteLine("</ss:Cell>");
                    sw.WriteLine("<ss:Cell>");
                    sw.WriteLine(String.Format("<ss:Data ss:Type='String'>{0}</ss:Data>", "Tecnología"));
                    sw.WriteLine("</ss:Cell>");
                    sw.WriteLine("<ss:Cell>");
                    sw.WriteLine(String.Format("<ss:Data ss:Type='String'>{0}</ss:Data>", "Sistema Operativo"));
                    sw.WriteLine("</ss:Cell>");
                    sw.WriteLine("<ss:Cell>");
                    sw.WriteLine(String.Format("<ss:Data ss:Type='String'>{0}</ss:Data>", "Página"));
                    sw.WriteLine("</ss:Cell>");
                    sw.WriteLine("<ss:Cell>");
                    sw.WriteLine(String.Format("<ss:Data ss:Type='String'>{0}</ss:Data>", "Software Integrado"));
                    sw.WriteLine("</ss:Cell>");
                    sw.WriteLine("<ss:Cell>");
                    sw.WriteLine(String.Format("<ss:Data ss:Type='String'>{0}</ss:Data>", "Version del Software"));
                    sw.WriteLine("</ss:Cell>");
                    sw.WriteLine("<ss:Cell>");
                    sw.WriteLine(String.Format("<ss:Data ss:Type='String'>{0}</ss:Data>", "Fecha y Hora"));
                    sw.WriteLine("</ss:Cell>");


                sw.WriteLine("</ss:Row>");


                foreach (CasesSoftwareHouse caseinfo in casesList)
                {

                        string typeClienteDescp = "";
                        string opcion1 = "Fabricante de Software";
                        string opcion2 = "Aliado Comercial de Ventas";
                        string opcion3 = "Desarrollo Independiente";
                        string salida = "Indefinido";

                        switch (caseinfo.clientType)
                        {
                          case 0: typeClienteDescp = salida; break;
                          case 1: typeClienteDescp = opcion1; break;
                          case 2: typeClienteDescp = opcion2; break;
                          case 3: typeClienteDescp = opcion3; break;
                          default: typeClienteDescp = salida; break;
                        }

                        sw.WriteLine(String.Format("<ss:Row ss:Height ='{0}'>", 12));
                    /*casa de software*/
                        sw.WriteLine("<ss:Cell>");
                        sw.WriteLine(String.Format("<ss:Data ss:Type='String'>{0}</ss:Data>", caseinfo.developersClients.description));
                        sw.WriteLine("</ss:Cell>");
                    /*RIF*/
                        sw.WriteLine("<ss:Cell>");
                        sw.WriteLine(String.Format("<ss:Data ss:Type='String'>{0}</ss:Data>", caseinfo.developersClients.document));
                        sw.WriteLine("</ss:Cell>");
                    /*Tipo*/
                        sw.WriteLine("<ss:Cell>");
                        sw.WriteLine(String.Format("<ss:Data ss:Type='String'>{0}</ss:Data>", typeClienteDescp));
                        sw.WriteLine("</ss:Cell>");
                     /*representante*/
                        sw.WriteLine("<ss:Cell>");
                        sw.WriteLine(String.Format("<ss:Data ss:Type='String'>{0}</ss:Data>", caseinfo.developersClients.description));
                        sw.WriteLine("</ss:Cell>");
                    /*Telefono*/
                        sw.WriteLine("<ss:Cell>");
                        sw.WriteLine(String.Format("<ss:Data ss:Type='String'>{0}</ss:Data>", caseinfo.developersClients.phone));
                        sw.WriteLine("</ss:Cell>");
                    /*email*/
                        sw.WriteLine("<ss:Cell>");
                        sw.WriteLine(String.Format("<ss:Data ss:Type='String'>{0}</ss:Data>", caseinfo.developersClients.email));
                        sw.WriteLine("</ss:Cell>");
                    /*pais*/
                        sw.WriteLine("<ss:Cell>");
                        sw.WriteLine(String.Format("<ss:Data ss:Type='String'>{0}</ss:Data>", caseinfo.developersClients.country));
                        sw.WriteLine("</ss:Cell>");
                    /* ciudad*/
                        sw.WriteLine("<ss:Cell>");
                        sw.WriteLine(String.Format("<ss:Data ss:Type='String'>{0}</ss:Data>", caseinfo.developersClients.city));
                        sw.WriteLine("</ss:Cell>");
                    /*tecnologia*/
                        sw.WriteLine("<ss:Cell>");
                        sw.WriteLine(String.Format("<ss:Data ss:Type='String'>{0}</ss:Data>", caseinfo.programLanguage.name));
                        sw.WriteLine("</ss:Cell>");
                    /*sistema operativo*/
                        sw.WriteLine("<ss:Cell>");
                        sw.WriteLine(String.Format("<ss:Data ss:Type='String'>{0}</ss:Data>", caseinfo.SystemOper.name));
                        sw.WriteLine("</ss:Cell>");
                    /*pagina*/
                        sw.WriteLine("<ss:Cell>");
                        sw.WriteLine(String.Format("<ss:Data ss:Type='String'>{0}</ss:Data>", caseinfo.page));
                        sw.WriteLine("</ss:Cell>");
                    /*Software Integrado*/
                        sw.WriteLine("<ss:Cell>");
                        sw.WriteLine(String.Format("<ss:Data ss:Type='String'>{0}</ss:Data>", caseinfo.systemAdmin));
                        sw.WriteLine("</ss:Cell>");
                    /*Version del Software*/
                        sw.WriteLine("<ss:Cell>");
                        sw.WriteLine(String.Format("<ss:Data ss:Type='String'>{0}</ss:Data>", caseinfo.versionSystemAdmin));
                        sw.WriteLine("</ss:Cell>");
                    /*Fecha y Hora*/
                        sw.WriteLine("<ss:Cell>");
                        sw.WriteLine(String.Format("<ss:Data ss:Type='String'>{0}</ss:Data>", caseinfo.dateRegister));
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

    }
}
