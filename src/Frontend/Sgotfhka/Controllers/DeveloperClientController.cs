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
    public class DeveloperClientController : BaseController
    {
        public DeveloperClientController(UserManager<ApplicationUser> userManager,
           SignInManager<ApplicationUser> signInManager,
           RoleManager<IdentityRole> roleManager,
           Services.ClientHttpREST clientHttpREST,
           ILogger<AccountController> logger,
           IOptions<AppSettings> settings)
           : base(userManager, signInManager, roleManager, clientHttpREST, logger, settings)
        {

        }

        #region GET: DeveloperClient
        public async Task<IActionResult> Index(string sortOrder,
             string currentFilter,
             string searchString,
             int? pageNumber)
        {
            try
            {
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

                string tokenValue = await this.GetTokenAccess();

                _clientHttpREST.SetToken(tokenValue);

                string repJson = await _clientHttpREST.GetObjetcsAllAsync("api-clients/DevelopersClients");

                List<DevelopersClientsModel> listDevelopersClients = TypeModel<DevelopersClientsModel>.DeserializeInArray(repJson);

                if (!(RolId <= 7))
                {
                    listDevelopersClients = listDevelopersClients.Where(d => d.email == _userManager.GetUserName(User)).ToList();
                }

                if (!String.IsNullOrEmpty(searchString))
                {
                    listDevelopersClients = listDevelopersClients.Where(m => m.document.IndexOf(searchString, StringComparison.OrdinalIgnoreCase) >= 0 ||
                    m.description.IndexOf(searchString, StringComparison.OrdinalIgnoreCase) >= 0 || m.email.IndexOf(searchString, StringComparison.OrdinalIgnoreCase) >= 0 ||
                    m.city.IndexOf(searchString, StringComparison.OrdinalIgnoreCase) >= 0 || m.country.IndexOf(searchString, StringComparison.OrdinalIgnoreCase) >= 0).ToList();
                }

                switch (sortOrder)
                {
                    case "name_desc":
                        listDevelopersClients = listDevelopersClients.OrderByDescending(m => m.document).ToList();
                        break;
                    case "Date":
                        listDevelopersClients = listDevelopersClients.OrderBy(m => m.description).ToList();
                        break;
                    case "date_desc":
                        listDevelopersClients = listDevelopersClients.OrderByDescending(m => m.country).ToList();
                        break;
                    default:
                        listDevelopersClients = listDevelopersClients.OrderBy(m => m.state).ToList();
                        break;
                }

                int pageSize = 8;
                ViewData["RolId"] = RolId.ToString();
                ViewData["LevelAccess"] = LevelAccess.ToString();

                return View(PaginatedList<DevelopersClientsModel>.CreateAsync(listDevelopersClients.AsQueryable(), pageNumber ?? 1, pageSize));
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

        #region  GET: DeveloperClient/Details/5
        public async Task<IActionResult> Details(int id)
        {
            try
            {
                string tokenValue = await this.GetTokenAccess();

                _clientHttpREST.SetToken(tokenValue);

                if (!(RolId <= 7))
                {
                    string repJson1 = await _clientHttpREST.GetObjetcsAllAsync("api-clients/DevelopersClients");

                    List<DevelopersClientsModel> listDevelopers = TypeModel<DevelopersClientsModel>.DeserializeInArray(repJson1);

                    var developer = listDevelopers.Where(d => d.email == _userManager.GetUserName(User)).FirstOrDefault();

                    if (developer != null)
                    {
                        string myIdDev = developer.id.ToString();

                        if (id.ToString() != myIdDev)
                        {
                            return RedirectToAction("AccessDenied", "Account");
                        }
                    }
                }

                string repJson = await _clientHttpREST.GetObjetcAsync("api-clients/DevelopersClients", id.ToString());

                DevelopersClientsModel DeveloperClient = TypeModel<DevelopersClientsModel>.DeserializeInObject(repJson);

                return View(DeveloperClient);
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

        #region GET: DeveloperClient/Create
        public async Task<IActionResult> Create()
        {
            try
            {
                string tokenValue = await this.GetTokenAccess();

                _clientHttpREST.SetToken(tokenValue);

                String json = await _clientHttpREST.GetObjetcsAllAsync("api-clients/DevelopersClients");

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

        #region POST: DeveloperClient/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(DevelopersClientsModel colletion)
        {
            try
            {
                string tokenValue = await this.GetTokenAccess();

                _clientHttpREST.SetToken(tokenValue);

                String json = @"{   'id':" + colletion.id + @",
                                    'document':'" + colletion.document + @"',
                                    'description':'" + colletion.description + @"',
                                    'address':'" + colletion.address + @"',
                                    'country':'" + colletion.country + @"',
                                    'state':'" + colletion.state + @"',
                                    'city':'" + colletion.city + @"',
                                    'phone':'" + colletion.phone + @"',
                                    'email':'" + colletion.email + @"',
                                    'enable':" + (colletion.enable ? 1 : 0).ToString() + @"
                                }";

                String response = await _clientHttpREST.PostObjetcAsync("api-clients/DevelopersClients", json);

                string repJson = await _clientHttpREST.GetObjetcsAllAsync("api-clients/DevelopersClients");

                List<DevelopersClientsModel> listDevelopersClients = TypeModel<DevelopersClientsModel>.DeserializeInArray(repJson);

                DevelopersClientsModel newDevelopclient = listDevelopersClients.Where(t => t.email == colletion.email).FirstOrDefault();

                if (response.Equals("Created"))
                { //Creo su cuenta de Usuario y relaciono
                    String json1 = @"{
                                        'id':0,
                                        'rolId':11,
                                        'username':'" + colletion.email + @"',
                                        'password':'" + colletion.document + @"',
                                        'enable':" + (colletion.enable ? 1 : 0).ToString() + @"
                                     }";

                    String response1 = await _clientHttpREST.PostObjetcAsync("api-access/Users", json1);
          
                    if (response1.Equals("Created"))
                    { //Se establece su relación con el Usuario
                        string repJson1 = await _clientHttpREST.GetObjetcsAllAsync("api-access/Users");

                        List<UserModel> listUsers = TypeModel<UserModel>.DeserializeInArray(repJson1);

                        UserModel newUser = listUsers.Where(u => u.Username == colletion.email).FirstOrDefault();

                        if (newUser != null)
                        {
                            String response2 = await _clientHttpREST.PostObjetcAsync("api-clients/DevelopersClients/" + newDevelopclient.id + "/" + newUser.Id.ToString(), "");
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

        #region  GET: DeveloperClient/Edit/5
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
                    string repJson1 = await _clientHttpREST.GetObjetcsAllAsync("api-clients/DevelopersClients");

                    List<DevelopersClientsModel> listDevelopers = TypeModel<DevelopersClientsModel>.DeserializeInArray(repJson1);

                    var developer = listDevelopers.Where(d => d.email == _userManager.GetUserName(User)).FirstOrDefault();

                    if (developer != null)
                    {
                        string myIdDev = developer.id.ToString();

                        if (id.ToString() != myIdDev)
                        {
                            return RedirectToAction("AccessDenied", "Account");
                        }
                    }
                }

                String json = await _clientHttpREST.GetObjetcAsync("api-clients/DevelopersClients", id.ToString());

                DevelopersClientsModel DeveloperClient = TypeModel<DevelopersClientsModel>.DeserializeInObject(json);

                if (DeveloperClient == null)
                {
                    return NotFound();
                }

                return View(DeveloperClient);
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;

                return View("~/Views/Shared/Error.cshtml", new ErrorViewModel { RequestId = Request.Path });
            }
        }
        #endregion

        #region POST: DeveloperClient/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, DevelopersClientsModel pDeveloperClient)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    string tokenValue = await this.GetTokenAccess();

                    _clientHttpREST.SetToken(tokenValue);

                    String json = @"{   'id':" + pDeveloperClient.id + @",
                                        'document':'" + pDeveloperClient.document + @"',
                                        'description':'" + pDeveloperClient.description + @"',
                                        'address':'" + pDeveloperClient.address + @"',
                                        'country':'" + pDeveloperClient.country + @"',
                                        'state':'" + pDeveloperClient.state + @"',
                                        'city':'" + pDeveloperClient.city + @"',
                                        'phone':'" + pDeveloperClient.phone + @"',
                                        'email':'" + pDeveloperClient.email + @"',
                                        'enable':" + (pDeveloperClient.enable ? 1 : 0).ToString() + @"
                                   }";

                    String response = await _clientHttpREST.PutObjetcAsync("api-clients/DevelopersClients", pDeveloperClient.id.ToString(), json);

                    if (response.Equals("OK") || response.Equals("NoContent"))
                    {
                        //Edito su usuario para desactivarlo
                        string repJson2 = await _clientHttpREST.GetObjetcsAllAsync("api-access/Users");

                        List<UserModel> listUsers = TypeModel<UserModel>.DeserializeInArray(repJson2);

                        UserModel updUser = listUsers.Where(u => u.Username == pDeveloperClient.email).FirstOrDefault();

                        if (updUser != null)
                        {

                            if (pDeveloperClient.enable ^ updUser.Enable)
                            {
                                updUser.Enable = pDeveloperClient.enable;

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
                    return View(pDeveloperClient);
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

        #region GET: DeveloperClient/Delete/5
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
                String json = await _clientHttpREST.GetObjetcAsync("api-clients/DevelopersClients", id.ToString());

                DevelopersClientsModel DeveloperClient = TypeModel<DevelopersClientsModel>.DeserializeInObject(json);

                if (DeveloperClient == null)
                {
                    return NotFound();
                }

                return View(DeveloperClient);
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;

                return View("~/Views/Shared/Error.cshtml", new ErrorViewModel { RequestId = Request.Path });
            }
        }
        #endregion

        #region POST: DeveloperClient/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, DevelopersClientsModel developerclient)
        {
            try
            {
                string tokenValue = await this.GetTokenAccess();

                _clientHttpREST.SetToken(tokenValue);

                //Borro la relacion Programador Cliente - User
                //Obtengo el User respectivo para borrarlo
                string repJson = await _clientHttpREST.GetObjetcsAllAsync("api-access/Users");

                List<UserModel> listUsers = TypeModel<UserModel>.DeserializeInArray(repJson);
                UserModel user = listUsers.Where(u => u.Username == developerclient.email).FirstOrDefault();
                if (user != null)
                {
                    String response3 = await _clientHttpREST.DeleteObjetcAsync("api-clients/DevelopersClients/" + id.ToString() + "/Users", user.Id.ToString());
                    //Borro el User del Programador Cliente
                    String response2 = await _clientHttpREST.DeleteObjetcAsync("api-access/Users", user.Id.ToString());
                }

                //Borro al Programador Cliente
                String response = await _clientHttpREST.DeleteObjetcAsync("api-clients/DevelopersClients", id.ToString());

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

