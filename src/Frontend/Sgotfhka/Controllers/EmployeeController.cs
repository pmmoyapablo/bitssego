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

namespace Sisgtfhka.Controllers
{
    [Authorize]
    public class EmployeeController : BaseController
    {
        public EmployeeController(UserManager<ApplicationUser> userManager,
           SignInManager<ApplicationUser> signInManager,
           RoleManager<IdentityRole> roleManager,
           Services.ClientHttpREST clientHttpREST,
           ILogger<AccountController> logger,
           IOptions<AppSettings> settings)
           : base(userManager, signInManager, roleManager, clientHttpREST, logger, settings)
        {

        }

        #region GET: Employee
        public async Task<IActionResult> Index(string sortOrder,
                                               string currentFilter,
                                               string searchString,
                                               int? pageNumber)
        {
            try
            {
                string tokenValue = await this.GetTokenAccess();

                _clientHttpREST.SetToken(tokenValue);

                string repJson = await _clientHttpREST.GetObjetcsAllAsync("api-employees/Employees");

                List<EmployeeModel> listEmployees = TypeModel<EmployeeModel>.DeserializeInArray(repJson);

                if (!(RolId == 1))
                {
                    listEmployees = listEmployees.Where(d => d.email == _userManager.GetUserName(User)).ToList();
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
                    listEmployees = listEmployees.Where(m => m.phone.IndexOf(searchString, StringComparison.OrdinalIgnoreCase) >= 0 ||
                                                 m.rif.IndexOf(searchString, StringComparison.OrdinalIgnoreCase) >= 0 ||
                                                 m.code.IndexOf(searchString, StringComparison.OrdinalIgnoreCase) >= 0 ||
                                                 m.description.ToString().IndexOf(searchString, StringComparison.OrdinalIgnoreCase) >= 0 ||
                                                 m.Departament.description.ToString().IndexOf(searchString, StringComparison.OrdinalIgnoreCase) >= 0 ||
                                                 m.Chargue.description.ToString().IndexOf(searchString, StringComparison.OrdinalIgnoreCase) >= 0 ||
                                                 m.email.IndexOf(searchString, StringComparison.OrdinalIgnoreCase) >= 0).ToList();
                }
                switch (sortOrder)
                {
                    case "name_desc":
                        listEmployees = listEmployees.OrderByDescending(m => m.rif).ToList();
                        break;
                    case "Date":
                        listEmployees = listEmployees.OrderBy(m => m.description).ToList();
                        break;
                    case "date_desc":
                        listEmployees = listEmployees.OrderByDescending(m => m.supervitorId).ToList();
                        break;
                    default:
                        listEmployees = listEmployees.OrderBy(m => m.Departament.description).ToList();
                        break;
                }

                int pageSize = 8;

                ViewData["RolId"] = RolId.ToString();
                ViewData["LevelAccess"] = LevelAccess.ToString();

                return View(PaginatedList<EmployeeModel>.CreateAsync(listEmployees.AsQueryable(), pageNumber ?? 1, pageSize));
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

        #region GET: Employee/Details/5
        public async Task<IActionResult> Details(int id)
        {
            try
            {
                string tokenValue = await this.GetTokenAccess();

                _clientHttpREST.SetToken(tokenValue);

                string repJson = await _clientHttpREST.GetObjetcAsync("api-employees/Employees", id.ToString());

                EmployeeModel employee = TypeModel<EmployeeModel>.DeserializeInObject(repJson);

                if (!(RolId == 1))
                {
                    string repJson0 = await _clientHttpREST.GetObjetcsAllAsync("api-employees/Employees");
                    List<EmployeeModel> listEmployees = TypeModel<EmployeeModel>.DeserializeInArray(repJson0);
                    var empl = listEmployees.Where(e => e.email == _userManager.GetUserName(User)).FirstOrDefault();
                    if (empl != null)
                    {
                        //Validar que sea el mismo o su supervisor
                        string myIdDev = empl.id.ToString();

                        if (employee.supervitorId != empl.id)
                        {
                            if (id.ToString() != myIdDev)
                            {
                                return RedirectToAction("AccessDenied", "Account");
                            }
                        }
                    }
                }

                String json3 = await _clientHttpREST.GetObjetcsAllAsync("api-employees/Employees");
                List<EmployeeModel> employees = TypeModel<EmployeeModel>.DeserializeInArray(json3);
                var emplSup = employees.Where(e => e.id == employee.supervitorId).FirstOrDefault();

                if (emplSup != null)
                { employee.nameSupervitor = emplSup.description;  }

                string repJson1 = await _clientHttpREST.GetObjetcAsync("api-employees/Departaments", employee.departamentId.ToString());

                Departament departament = TypeModel<Departament>.DeserializeInObject(repJson1);

                employee.Departament = departament;

                string repJson2 = await _clientHttpREST.GetObjetcAsync("api-employees/Chargues", employee.chargueId.ToString());

                Chargue chargue = TypeModel<Chargue>.DeserializeInObject(repJson2);

                employee.Chargue = chargue;

                return View(employee);
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

        #region GET: Employee/3/Employees
        public async Task<IActionResult> ViewEmployees(int supervitorId,string sortOrder,
                                              string currentFilter,
                                              string searchString,
                                              int? pageNumber)
        {
            try
            {
                string tokenValue = await this.GetTokenAccess();

                _clientHttpREST.SetToken(tokenValue);

                string json1 = await _clientHttpREST.GetObjetcsAllAsync("api-employees/Employees/" + supervitorId.ToString() + "/Employees");
                List<EmployeeModel> listEmployees = TypeModel<EmployeeModel>.DeserializeInArray(json1);

                foreach(EmployeeModel employee in listEmployees)
                {
                    string repJson1 = await _clientHttpREST.GetObjetcAsync("api-employees/Departaments", employee.departamentId.ToString());

                    Departament departament = TypeModel<Departament>.DeserializeInObject(repJson1);

                    employee.Departament = departament;

                    string repJson2 = await _clientHttpREST.GetObjetcAsync("api-employees/Chargues", employee.chargueId.ToString());

                    Chargue chargue = TypeModel<Chargue>.DeserializeInObject(repJson2);

                    employee.Chargue = chargue;
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
                    listEmployees = listEmployees.Where(m => m.phone.IndexOf(searchString, StringComparison.OrdinalIgnoreCase) >= 0 ||
                                                 m.rif.IndexOf(searchString, StringComparison.OrdinalIgnoreCase) >= 0 ||
                                                 m.code.IndexOf(searchString, StringComparison.OrdinalIgnoreCase) >= 0 ||
                                                 m.description.ToString().IndexOf(searchString, StringComparison.OrdinalIgnoreCase) >= 0 ||
                                                 m.Departament.description.ToString().IndexOf(searchString, StringComparison.OrdinalIgnoreCase) >= 0 ||
                                                 m.Chargue.description.ToString().IndexOf(searchString, StringComparison.OrdinalIgnoreCase) >= 0 ||
                                                 m.email.IndexOf(searchString, StringComparison.OrdinalIgnoreCase) >= 0).ToList();
                }
                switch (sortOrder)
                {
                    case "name_desc":
                        listEmployees = listEmployees.OrderByDescending(m => m.rif).ToList();
                        break;
                    case "Date":
                        listEmployees = listEmployees.OrderBy(m => m.description).ToList();
                        break;
                    case "date_desc":
                        listEmployees = listEmployees.OrderByDescending(m => m.supervitorId).ToList();
                        break;
                    default:
                       // listEmployees = listEmployees.OrderBy(m => m.Departament.description).ToList();
                        break;
                }

                int pageSize = 8;

                ViewData["RolId"] = RolId.ToString();
                ViewData["LevelAccess"] = LevelAccess.ToString();
                ViewData["Employees"] = supervitorId.ToString();

                return View(PaginatedList<EmployeeModel>.CreateAsync(listEmployees.AsQueryable(), pageNumber ?? 1, pageSize));
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

        #region GET: Employee/Create
        public async Task<IActionResult> Create()
        {
            try
            {
                string tokenValue = await this.GetTokenAccess();

                _clientHttpREST.SetToken(tokenValue);

                //Cargo Select List de Departamento
                String json = await _clientHttpREST.GetObjetcsAllAsync("api-employees/Departaments");
                List<Departament> departaments = TypeModel<Departament>.DeserializeInArray(json);

                List<SelectListItem> lst = new List<SelectListItem>();

                foreach (Departament dep in departaments)
                {
                    lst.Add(new SelectListItem() { Text = dep.description, Value = dep.id.ToString() });
                }

                ViewBag.Opciones = lst;

                //Cargo SelectList de Cargos
                String json2 = await _clientHttpREST.GetObjetcsAllAsync("api-employees/Chargues");
                List<Chargue> chargues = TypeModel<Chargue>.DeserializeInArray(json2);

                List<SelectListItem> lst2 = new List<SelectListItem>();

                foreach (Chargue charg in chargues)
                {
                    lst2.Add(new SelectListItem() { Text = charg.description, Value = charg.id.ToString() });
                }

                ViewBag.Opciones2 = lst2;

                //Cargo Select List de Empleados Supervisor
                String json3 = await _clientHttpREST.GetObjetcsAllAsync("api-employees/Employees");
                List<EmployeeModel> employees = TypeModel<EmployeeModel>.DeserializeInArray(json3);

                List<SelectListItem> lst3 = new List<SelectListItem>();

                foreach (EmployeeModel emplo in employees)
                {
                    lst3.Add(new SelectListItem() { Text = emplo.description, Value = emplo.id.ToString() });
                }

                ViewBag.Opciones3 = lst3;

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

        #region POST: Employee/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(EmployeeModel colletion)
        {
            try
            {
                string tokenValue = await this.GetTokenAccess();

                _clientHttpREST.SetToken(tokenValue);

                String json = @"{   'id':" + colletion.id + @",
                                    'supervitorId':'" + colletion.supervitorId + @"',
                                    'rif':'" + colletion.rif + @"',
                                    'code':'" + colletion.code + @"',
                                    'description':'" + colletion.description + @"',
                                    'departamentId':'" + colletion.departamentId + @"',
                                    'chargueId':'" + colletion.chargueId + @"',
                                    'email':'" + colletion.email + @"',
                                    'phone':'" + colletion.phone + @"',
                                    'enable':" + (colletion.Enable ? 1 : 0).ToString() + @"
                                }";

                String response = await _clientHttpREST.PostObjetcAsync("api-employees/Employees", json);

                string repJson = await _clientHttpREST.GetObjetcsAllAsync("api-employees/Employees");

                List<EmployeeModel> listEmployees = TypeModel<EmployeeModel>.DeserializeInArray(repJson);

                EmployeeModel newEmployee = listEmployees.Where(t => t.email == colletion.email).FirstOrDefault();

                if (response.Equals("Created"))
                { //Creo su cuenta de Usuario y relaciono
                    int rolID = 0;

                    string repJson2 = await _clientHttpREST.GetObjetcsAllAsync("api-employees/Chargues");

                    List<Chargue> listchargues = TypeModel<Chargue>.DeserializeInArray(repJson2);

                    var chargue = listchargues.Where(c => c.id == colletion.chargueId).FirstOrDefault();

                    if (chargue != null)
                    { rolID = chargue.rolId;  }

                    String json1 = @"{
                                        'id':0,
                                        'rolId':"+ rolID  + @",
                                        'username':'" + colletion.email + @"',
                                        'password':'" + colletion.rif + @"',
                                        'enable':" + (colletion.Enable ? 1 : 0).ToString() + @"
                                     }";

                    String response1 = await _clientHttpREST.PostObjetcAsync("api-access/Users", json1);

                    if (response1.Equals("Created"))
                    { //Se establece su relación con el Usuario
                        string repJson1 = await _clientHttpREST.GetObjetcsAllAsync("api-access/Users");

                        List<UserModel> listUsers = TypeModel<UserModel>.DeserializeInArray(repJson1);

                        UserModel newUser = listUsers.Where(u => u.Username == colletion.email).FirstOrDefault();

                        if (newUser != null)
                        {
                            String response2 = await _clientHttpREST.PostObjetcAsync("api-employees/Employees/" + newEmployee.id + "/" + newUser.Id.ToString(), "");
                        }
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

        #region GET: Employee/Edit/5
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

                String json = await _clientHttpREST.GetObjetcAsync("api-employees/Employees", id.ToString());

                EmployeeModel employee = TypeModel<EmployeeModel>.DeserializeInObject(json);

                if (employee == null)
                {
                    return NotFound();
                }

                if (!(RolId == 1))
                {
                    string repJson1 = await _clientHttpREST.GetObjetcsAllAsync("api-employees/Employees");
                    List<EmployeeModel> listEmployees = TypeModel<EmployeeModel>.DeserializeInArray(repJson1);
                    var empl = listEmployees.Where(e => e.email == _userManager.GetUserName(User)).FirstOrDefault();
                    if (empl != null)
                    {
                         //Validar que sea el mismo o su supervisor
                         string myIdDev = empl.id.ToString();

                        if (employee.supervitorId != empl.id)
                        {
                            if (id.ToString() != myIdDev)
                            {
                                return RedirectToAction("AccessDenied", "Account");
                            }
                        }
                    }
                }

                //Cargo Select List de Departament
                String json1 = await _clientHttpREST.GetObjetcsAllAsync("api-employees/Departaments");
                List<Departament> departaments = TypeModel<Departament>.DeserializeInArray(json1);

                List<SelectListItem> lst = new List<SelectListItem>();

                foreach (Departament dep in departaments)
                {
                    lst.Add(new SelectListItem() { Text = dep.description, Value = dep.id.ToString() });
                }

                ViewBag.Opciones = lst;

                //Cargo SelectList de Chargues
                String json2 = await _clientHttpREST.GetObjetcsAllAsync("api-employees/Chargues");
                List<Chargue> chargues = TypeModel<Chargue>.DeserializeInArray(json2);

                List<SelectListItem> lst2 = new List<SelectListItem>();

                foreach (Chargue chargue in chargues)
                {
                    lst2.Add(new SelectListItem() { Text = chargue.description, Value = chargue.id.ToString() });
                }

                ViewBag.Opciones2 = lst2;

                //Cargo Select List de Empleados Supervisor
                String json3 = await _clientHttpREST.GetObjetcsAllAsync("api-employees/Employees");
                List<EmployeeModel> employees = TypeModel<EmployeeModel>.DeserializeInArray(json3);

                List<SelectListItem> lst3 = new List<SelectListItem>();

                foreach (EmployeeModel emplo in employees)
                {
                    lst3.Add(new SelectListItem() { Text = emplo.description, Value = emplo.id.ToString() });
                }

                ViewBag.Opciones3 = lst3;

                ViewData["RolId"] = RolId.ToString();

                return View(employee);
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;

                return View("~/Views/Shared/Error.cshtml", new ErrorViewModel { RequestId = Request.Path });
            }
        }
        #endregion

        #region POST: Employee/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, EmployeeModel pEmployee)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    string tokenValue = await this.GetTokenAccess();

                    _clientHttpREST.SetToken(tokenValue);

                    String json = @"{
                                    'id':" + pEmployee.id + @",
                                    'supervitorId':'" + pEmployee.supervitorId + @"',
                                    'rif':'" + pEmployee.rif + @"',
                                    'code':'" + pEmployee.code + @"',
                                    'description':'" + pEmployee.description + @"',
                                    'departamentId':'" + pEmployee.departamentId + @"',
                                    'chargueId':'" + pEmployee.chargueId + @"',
                                    'email':'" + pEmployee.email + @"',
                                    'phone':'" + pEmployee.phone + @"',
                                    'enable':" + (pEmployee.Enable ? 1 : 0).ToString() + @"
                                }";

                    String response = await _clientHttpREST.PutObjetcAsync("api-employees/Employees", pEmployee.id.ToString(), json);

                    if (response.Equals("OK") || response.Equals("NoContent"))
                    {
                        //Edito su usuario para desactivarlo
                        string repJson2 = await _clientHttpREST.GetObjetcsAllAsync("api-access/Users");

                        List<UserModel> listUsers = TypeModel<UserModel>.DeserializeInArray(repJson2);

                        UserModel updUser = listUsers.Where(u => u.Username == pEmployee.email).FirstOrDefault();

                        if (updUser != null)
                        {

                            if (pEmployee.Enable ^ updUser.Enable)
                            {
                                updUser.Enable = pEmployee.Enable;

                                String json1 = @"{   'id':" + updUser.Id + @",
                                    'rolId':" + updUser.RolId + @",
                                    'username':'" + updUser.Username + @"',
                                    'password':'" + updUser.Password + @"',
                                    'enable':" + (updUser.Enable ? 1 : 0).ToString() + @"
                                     }";

                                String response2 = await _clientHttpREST.PutObjetcAsync("api-access/Users", updUser.Id.ToString(), json1);
                            }
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
                else
                {
                    return View(pEmployee);
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

        #region GET: Employee/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                string tokenValue = await this.GetTokenAccess();

                _clientHttpREST.SetToken(tokenValue);

                string repJson = await _clientHttpREST.GetObjetcAsync("api-employees/Employees", id.ToString());

                EmployeeModel employee = TypeModel<EmployeeModel>.DeserializeInObject(repJson);

                if (!(RolId == 1))
                {
                    string repJson0 = await _clientHttpREST.GetObjetcsAllAsync("api-employees/Employees");
                    List<EmployeeModel> listEmployees = TypeModel<EmployeeModel>.DeserializeInArray(repJson0);
                    var empl = listEmployees.Where(e => e.email == _userManager.GetUserName(User)).FirstOrDefault();
                    if (empl != null)
                    {
                        //Validar que sea el mismo o su supervisor
                        string myIdDev = empl.id.ToString();

                        if (employee.supervitorId != empl.id)
                        {
                            if (id.ToString() != myIdDev)
                            {
                                return RedirectToAction("AccessDenied", "Account");
                            }
                        }
                    }
                }

                String json3 = await _clientHttpREST.GetObjetcsAllAsync("api-employees/Employees");
                List<EmployeeModel> employees = TypeModel<EmployeeModel>.DeserializeInArray(json3);
                var emplSup = employees.Where(e => e.id == employee.supervitorId).FirstOrDefault();

                if (emplSup != null)
                { employee.nameSupervitor = emplSup.description; }

                string repJson1 = await _clientHttpREST.GetObjetcAsync("api-employees/Departaments", employee.departamentId.ToString());

                Departament departament = TypeModel<Departament>.DeserializeInObject(repJson1);

                employee.Departament = departament;

                string repJson2 = await _clientHttpREST.GetObjetcAsync("api-employees/Chargues", employee.chargueId.ToString());

                Chargue chargue = TypeModel<Chargue>.DeserializeInObject(repJson2);

                employee.Chargue = chargue;

                return View(employee);
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

        #region POST: Employee/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, EmployeeModel employee)
        {
            try
            {
                string tokenValue = await this.GetTokenAccess();

                _clientHttpREST.SetToken(tokenValue);

                //Borro la relacion Empleado-User
                //Obtengo el User respectivo para borrarlo
                string repJson = await _clientHttpREST.GetObjetcsAllAsync("api-access/Users");

                List<UserModel> listUsers = TypeModel<UserModel>.DeserializeInArray(repJson);
                UserModel user = listUsers.Where(u => u.Username == employee.email).FirstOrDefault();
                if (user != null)
                {
                    String response3 = await _clientHttpREST.DeleteObjetcAsync("api-employees/Employees/" + id.ToString() + "/Users", user.Id.ToString());
                    //Borro el User del Empleado
                    String response2 = await _clientHttpREST.DeleteObjetcAsync("api-access/Users", user.Id.ToString());
                }

                String response = await _clientHttpREST.DeleteObjetcAsync("api-employees/Employees", id.ToString());

                if (response.Equals("OK"))
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

                return View("~/Views/Shared/Error.cshtml", new ErrorViewModel { RequestId = Request.Path });
            }
        }
        #endregion
    }
}