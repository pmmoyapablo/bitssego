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
    public class TechnicianController : BaseController
    {
        public TechnicianController(UserManager<ApplicationUser> userManager,
           SignInManager<ApplicationUser> signInManager,
           RoleManager<IdentityRole> roleManager,
           Services.ClientHttpREST clientHttpREST,
           ILogger<AccountController> logger,
           IOptions<AppSettings> settings)
           : base(userManager, signInManager, roleManager, clientHttpREST, logger, settings)
        {

        }

        #region GET: Technician
        public async Task<IActionResult> Index(string sortOrder,
                                               string currentFilter,
                                               string searchString,
                                               int? pageNumber)
        {
            try
            {
                string tokenValue = await this.GetTokenAccess();

                _clientHttpREST.SetToken(tokenValue);

                string repJson = await _clientHttpREST.GetObjetcsAllAsync("api-clients/Technicians");

                List<TechnicianModel> listTechnicians = TypeModel<TechnicianModel>.DeserializeInArray(repJson);

                if (!(RolId <= 7))
                {
                    if (RolId == 9)
                    {
                        string repJson2 = await _clientHttpREST.GetObjetcsAllAsync("api-clients/Distributors");
                        string username = _userManager.GetUserName(User);

                        List<DistributorModel> listDistributors = TypeModel<DistributorModel>.DeserializeInArray(repJson2);
                        DistributorModel distributor = listDistributors.Where(d => d.email == username).FirstOrDefault();

                        if (distributor != null)
                        {
                            string json1 = await _clientHttpREST.GetObjetcsAllAsync("api-clients/Distributors/" + distributor.id + "/Technicians");
                            listTechnicians = TypeModel<TechnicianModel>.DeserializeInArray(json1);
                        }
                        else
                        {
                            listTechnicians = new List<TechnicianModel>();
                        }
                    }
                    else
                    {
                        listTechnicians = listTechnicians.Where(t => t.email == _userManager.GetUserName(User)).ToList();
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
                    listTechnicians = listTechnicians.Where(m => m.description.IndexOf(searchString, StringComparison.OrdinalIgnoreCase) >= 0 ||
                                                 m.phone.ToString().IndexOf(searchString, StringComparison.OrdinalIgnoreCase) >= 0 ||
                                                 m.rif.IndexOf(searchString, StringComparison.OrdinalIgnoreCase) >= 0 ||
                                                 m.email.IndexOf(searchString, StringComparison.OrdinalIgnoreCase) >= 0).ToList();
                }
                switch (sortOrder)
                {
                    case "name_desc":
                        listTechnicians = listTechnicians.OrderByDescending(m => m.rif).ToList();
                        break;
                    case "Date":
                        listTechnicians = listTechnicians.OrderBy(m => m.description).ToList();
                        break;
                    case "date_desc":
                        listTechnicians = listTechnicians.OrderByDescending(m => m.address).ToList();
                        break;
                    default:
                        listTechnicians = listTechnicians.OrderBy(m => m.email).ToList();
                        break;
                }

                int pageSize = 8;

                ViewData["RolId"] = RolId.ToString();
                ViewData["LevelAccess"] = LevelAccess.ToString();

                return View(PaginatedList<TechnicianModel>.CreateAsync(listTechnicians.AsQueryable(), pageNumber ?? 1, pageSize));
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

        public async Task<IActionResult> Import(string sortOrder,
                                               string currentFilter,
                                               string searchString,
                                               int? pageNumber)
        {
            try
            {
                string tokenValue = await this.GetTokenAccess();

                _clientHttpREST.SetToken(tokenValue);

                string repJson = await _clientHttpREST.GetObjetcsAllAsync("api-clients/Technicians");

                List<TechnicianModel> listTechnicians = new List<TechnicianModel>();
                List<TechnicianModel> listTechniciansStore = TypeModel<TechnicianModel>.DeserializeInArray(repJson);

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
                    listTechnicians = listTechniciansStore.Where(m => m.rif.IndexOf(searchString, StringComparison.OrdinalIgnoreCase) >= 0).ToList();
                }

                switch (sortOrder)
                {
                    case "name_desc":
                        listTechnicians = listTechnicians.OrderByDescending(m => m.rif).ToList();
                        break;
                    case "Date":
                        listTechnicians = listTechnicians.OrderBy(m => m.description).ToList();
                        break;
                    case "date_desc":
                        listTechnicians = listTechnicians.OrderByDescending(m => m.address).ToList();
                        break;
                    default:
                        listTechnicians = listTechnicians.OrderBy(m => m.email).ToList();
                        break;
                }

                int pageSize = 8;

                return View(PaginatedList<TechnicianModel>.CreateAsync(listTechnicians.AsQueryable(), pageNumber ?? 1, pageSize));
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

        #region GET: Technician/Details/5
        public async Task<IActionResult> Details(int id)
        {
            try
            {
                string tokenValue = await this.GetTokenAccess();

                _clientHttpREST.SetToken(tokenValue);

                if (RolId == 10)
                {
                    string repJson0 = await _clientHttpREST.GetObjetcsAllAsync("api-clients/Technicians");

                    List<TechnicianModel> listTechnicians = TypeModel<TechnicianModel>.DeserializeInArray(repJson0);

                    var technical = listTechnicians.Where(t => t.email == _userManager.GetUserName(User)).FirstOrDefault();

                    if (technical != null)
                    {
                        string myIdTech = technical.id.ToString();

                        if (id.ToString() != myIdTech)
                        {
                            return RedirectToAction("AccessDenied", "Account");
                        }
                    }
                }

                string repJson = await _clientHttpREST.GetObjetcAsync("api-clients/Technicians", id.ToString());

                TechnicianModel technician = TypeModel<TechnicianModel>.DeserializeInObject(repJson);

                ViewData["RolId"] = RolId.ToString();
                ViewData["LevelAccess"] = LevelAccess.ToString();

                return View(technician);
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

        #region GET: Technician/Create
        public async Task<IActionResult> Create()
        {
            try
            {
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

        #region POST: Technician/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TechnicianModel colletion)
        {
            try
            {
                string tokenValue = await this.GetTokenAccess();

                _clientHttpREST.SetToken(tokenValue);

                String json = @"{   'id':" + colletion.id + @",
                                    'rif':'" + colletion.rif + @"',
                                    'description':'" + colletion.description + @"',
                                    'address':'" + colletion.address + @"',
                                    'phone':'" + colletion.phone + @"',
                                    'email':'" + colletion.email + @"',
                                    'enable':" + (colletion.enable ? 1 : 0).ToString() + @"
                                }";

                String response = await _clientHttpREST.PostObjetcAsync("api-clients/Technicians", json);              

                if (response.Equals("Created"))
                { //Relaciono con Distribuidor o Proveedor en curso
                    string repJson = await _clientHttpREST.GetObjetcsAllAsync("api-clients/Technicians");

                    List<TechnicianModel> listTechnicians = TypeModel<TechnicianModel>.DeserializeInArray(repJson);

                    TechnicianModel newTechn = listTechnicians.Where(t => t.email == colletion.email).FirstOrDefault();

                    if (newTechn != null)
                    {
                        string repJson2 = await _clientHttpREST.GetObjetcsAllAsync("api-clients/Distributors");
                        string username = _userManager.GetUserName(User);
                        string idDistributor = "0";

                        List<DistributorModel> listDistributors = TypeModel<DistributorModel>.DeserializeInArray(repJson2);
                        DistributorModel distributor = listDistributors.Where(d => d.email == username).FirstOrDefault();

                        if (distributor != null)
                        { idDistributor = distributor.id.ToString(); }

                        String json1 = @"{
                                          'id': " + idDistributor + @"
                                          }";

                        String response1 = await _clientHttpREST.PostObjetcAsync("api-clients/Technicians/"+ newTechn.id + "/Distributors", json1);
                     
                    }

                    //Creo su cuenta de Usuario y relaciono
                    String json2 = @"{
                                        'id':0,
                                        'rolId':10,
                                        'username':'" + colletion.email + @"',
                                        'password':'" + colletion.rif + @"',
                                        'enable':" + (colletion.enable ? 1 : 0).ToString() + @"
                                     }";

                    String response2 = await _clientHttpREST.PostObjetcAsync("api-access/Users", json2);

                    if (response2.Equals("Created"))
                    { //Estableco su relación con el Usuario
                        string repJson2 = await _clientHttpREST.GetObjetcsAllAsync("api-access/Users");

                        List<UserModel> listUsers = TypeModel<UserModel>.DeserializeInArray(repJson2);

                        UserModel newUser = listUsers.Where(u => u.Username == colletion.email).FirstOrDefault();

                        if (newUser != null)
                        {
                            String response3 = await _clientHttpREST.PostObjetcAsync("api-clients/Technicians/" + newTechn.id + "/" + newUser.Id.ToString() , "");
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

        #region GET: Technician/Edit/5
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

                if (!(RolId <= 7))
                {
                    string repJson = await _clientHttpREST.GetObjetcsAllAsync("api-clients/Technicians");

                    List<TechnicianModel> listTechnicians = TypeModel<TechnicianModel>.DeserializeInArray(repJson);

                    var technical = listTechnicians.Where(t => t.email == _userManager.GetUserName(User)).FirstOrDefault();

                    if (technical != null)
                    {
                        string myIdTech = technical.id.ToString();

                        if (id.ToString() != myIdTech)
                        {
                            return RedirectToAction("AccessDenied", "Account");
                        }
                    }
                }

                String json = await _clientHttpREST.GetObjetcAsync("api-clients/Technicians", id.ToString());

                TechnicianModel technician = TypeModel<TechnicianModel>.DeserializeInObject(json);

                if (technician == null)
                {
                    return NotFound();
                }

                return View(technician);
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

        #region POST: Technician/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, TechnicianModel pTechnician)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    string tokenValue = await this.GetTokenAccess();

                    _clientHttpREST.SetToken(tokenValue);

                    String json = @"{   'id':" + pTechnician.id + @",
                                    'rif':'" + pTechnician.rif + @"',
                                    'description':'" + pTechnician.description + @"',
                                    'address':'" + pTechnician.address + @"',
                                    'phone':'" + pTechnician.phone + @"',
                                    'email':'" + pTechnician.email + @"',
                                    'enable':" + (pTechnician.enable ? 1 : 0).ToString() + @"
                                }";

                    String response = await _clientHttpREST.PutObjetcAsync("api-clients/Technicians", pTechnician.id.ToString(), json);

                    if (response.Equals("OK") || response.Equals("NoContent"))
                    {
                        //Edito su usuario para desactivarlo
                            string repJson2 = await _clientHttpREST.GetObjetcsAllAsync("api-access/Users");

                            List<UserModel> listUsers = TypeModel<UserModel>.DeserializeInArray(repJson2);

                            UserModel updUser = listUsers.Where(u => u.Username == pTechnician.email).FirstOrDefault();

                            if (updUser != null)
                            {

                                if (pTechnician.enable ^ updUser.Enable)
                                {
                                    updUser.Enable = pTechnician.enable;

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
                    return View(pTechnician);
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

        #region GET: Technician/UnSubscribe/5
        public async Task<IActionResult> UnSubscribe(int id)
        {
            try
            {
                if (id == 0)
                {
                    return new StatusCodeResult((int)HttpStatusCode.BadRequest);
                }

                string tokenValue = await this.GetTokenAccess();

                _clientHttpREST.SetToken(tokenValue);

                String json = await _clientHttpREST.GetObjetcAsync("api-clients/Technicians", id.ToString());

                TechnicianModel technician = TypeModel<TechnicianModel>.DeserializeInObject(json);

                if (technician == null)
                {
                    return NotFound();
                }

                return View(technician);
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

        #region POST: Technician/UnSubscribe/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UnSubscribe(int id, TechnicianModel technical)
        {
            try
            {
                string tokenValue = await this.GetTokenAccess();

                _clientHttpREST.SetToken(tokenValue);

                string repJson2 = await _clientHttpREST.GetObjetcsAllAsync("api-clients/Distributors");
                string username = _userManager.GetUserName(User);

                List<DistributorModel> listDistributors = TypeModel<DistributorModel>.DeserializeInArray(repJson2);
                DistributorModel distributor = listDistributors.Where(d => d.email == username).FirstOrDefault();

                string idDistributor = "0";

                if (distributor != null)
                { idDistributor = distributor.id.ToString(); }

                String response = await _clientHttpREST.DeleteObjetcAsync("api-clients/Technicians/"+id.ToString()+"/Distributors", idDistributor);

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

        #region GET: Technician/Delete/5
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

                String json = await _clientHttpREST.GetObjetcAsync("api-clients/Technicians", id.ToString());

                TechnicianModel technician = TypeModel<TechnicianModel>.DeserializeInObject(json);

                if (technician == null)
                {
                    return NotFound();
                }

                return View(technician);
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

        #region POST: Technician/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, TechnicianModel technical)
        {
            try
            {
                string tokenValue = await this.GetTokenAccess();

                _clientHttpREST.SetToken(tokenValue);

                //Borro la relacion Tecnico-User
                //Obtengo el User respectivo para borrarlo
                string repJson = await _clientHttpREST.GetObjetcsAllAsync("api-access/Users");

                List<UserModel> listUsers = TypeModel<UserModel>.DeserializeInArray(repJson);
                UserModel user = listUsers.Where(u => u.Username == technical.email).FirstOrDefault();
                if (user != null)
                {
                    String response3 = await _clientHttpREST.DeleteObjetcAsync("api-clients/Technicians/" + id.ToString() + "/Users", user.Id.ToString());
                    //Borro el User del Técnico
                    String response2 = await _clientHttpREST.DeleteObjetcAsync("api-access/Users", user.Id.ToString());
                }

                String response = await _clientHttpREST.DeleteObjetcAsync("api-clients/Technicians", id.ToString());

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

        #region GET Technician/AddTechnical/2

        public async Task<IActionResult> AddTechnical(int id)
        {
            try
            {
                if (id == 0)
                {
                    return new StatusCodeResult((int)HttpStatusCode.BadRequest);
                }

                string tokenValue = await this.GetTokenAccess();

                _clientHttpREST.SetToken(tokenValue);

                String json = await _clientHttpREST.GetObjetcAsync("api-clients/Technicians", id.ToString());

                TechnicianModel technician = TypeModel<TechnicianModel>.DeserializeInObject(json);

                if (technician == null)
                {
                    return NotFound();
                }

                return View(technician);
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

        #region POST Technician/AddTechnical/2
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddTechnical(int id, TechnicianModel technician)
        {
            try
            {
                string tokenValue = await this.GetTokenAccess();

                _clientHttpREST.SetToken(tokenValue);

                string repJson2 = await _clientHttpREST.GetObjetcsAllAsync("api-clients/Distributors");
                string username = _userManager.GetUserName(User);

                List<DistributorModel> listDistributors = TypeModel<DistributorModel>.DeserializeInArray(repJson2);
                DistributorModel distributor = listDistributors.Where(d => d.email == username).FirstOrDefault();

                string idDistributor = "0";

                if (distributor != null)
                { idDistributor = distributor.id.ToString(); }

                    String json = @"{
                                      'id': "+ idDistributor +@"
                                    }";

                String response = await _clientHttpREST.PostObjetcAsync("api-clients/Technicians/" + id.ToString() + "/Distributors", json);

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
