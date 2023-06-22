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
using System.Text;
using System.IO;
using System.Xml.Linq;

namespace Sisgtfhka.Controllers

{
    [Authorize]
    public class FinalClientController : BaseController
    {

        public FinalClientController(UserManager<ApplicationUser> userManager,
           SignInManager<ApplicationUser> signInManager,
           RoleManager<IdentityRole> roleManager,
           Services.ClientHttpREST clientHttpREST,
           ILogger<AccountController> logger,
           IOptions<AppSettings> settings)
           : base(userManager, signInManager, roleManager, clientHttpREST, logger, settings)
        {

        }
        
        #region GET: FinalClient
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

                string repJson = await _clientHttpREST.GetObjetcsAllAsync("api-clients/FinalsClients");

                List<FinalsClientsModel> listFinalsClients = TypeModel<FinalsClientsModel>.DeserializeInArray(repJson);

                if (!(RolId <= 7))
                {
                    listFinalsClients = listFinalsClients.Where(d => d.email == _userManager.GetUserName(User)).ToList();
                }

                if (!String.IsNullOrEmpty(searchString))
                {
                    listFinalsClients = listFinalsClients.Where(m => m.Rif.IndexOf(searchString, StringComparison.OrdinalIgnoreCase) >= 0 || m.Description.IndexOf(searchString, StringComparison.OrdinalIgnoreCase) >= 0).ToList();
                }

                switch (sortOrder)
                {
                    case "name_desc":
                        listFinalsClients = listFinalsClients.OrderByDescending(m => m.Rif).ToList();
                        break;
                    case "Date":
                        listFinalsClients = listFinalsClients.OrderBy(m => m.Description).ToList();
                        break;
                    case "date_desc":
                        listFinalsClients = listFinalsClients.OrderByDescending(m => m.Name).ToList();
                        break;
                    default:
                        listFinalsClients = listFinalsClients.OrderBy(m => m.LastName).ToList();
                        break;
                }

                int pageSize = 8;

                ViewData["RolId"] = RolId.ToString();

                ViewData["LevelAccess"] = LevelAccess.ToString();

                return View(PaginatedList<FinalsClientsModel>.CreateAsync(listFinalsClients.AsQueryable(), pageNumber ?? 1, pageSize));
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
     
        #region GET: FinalClient/Details/5

        public async Task<IActionResult> Details(int id)
        {
            try
            {
                string tokenValue = await this.GetTokenAccess();

                _clientHttpREST.SetToken(tokenValue);

                if (!(RolId <= 7))
                {
                    string repJson1 = await _clientHttpREST.GetObjetcsAllAsync("api-clients/FinalsClients");
                    List<FinalsClientsModel> listClients = TypeModel<FinalsClientsModel>.DeserializeInArray(repJson1);
                    var clients = listClients.Where(d => d.email == _userManager.GetUserName(User)).FirstOrDefault();
                    if (clients != null)
                    {
                        string myIdDev = clients.Id.ToString();
                        if (id.ToString() != myIdDev)
                        {
                            return RedirectToAction("AccessDenied", "Account");
                        }
                    }
                }

                string repJson = await _clientHttpREST.GetObjetcAsync("api-clients/FinalsClients", id.ToString());

                FinalsClientsModel FinalClient = TypeModel<FinalsClientsModel>.DeserializeInObject(repJson);

                return View(FinalClient);
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
      
        #region GET: FinalClient/Create

        public async Task<IActionResult> Create()
        {
            try
            {
                string tokenValue = await this.GetTokenAccess();

                _clientHttpREST.SetToken(tokenValue);

                String json = await _clientHttpREST.GetObjetcsAllAsync("api-clients/FinalsClients");

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

        #region GET: FinalClient/ViewCreateFinalClient
        public IActionResult ViewCreateFinalClient()
        {
                return View();
        }
        #endregion

        #region POST: FinalClient/ViewCreateFinalClient
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ViewCreateFinalClient(FinalsClientsModel colletion)
        {
            try
            {
                string tokenValue = await this.GetTokenAccess();

                _clientHttpREST.SetToken(tokenValue);

                String json = @"{   'id':" + colletion.Id + @",
                                    'rif':'" + colletion.Rif + @"',
                                    'description':'" + colletion.Description + @"',
                                    'fiscalAddress':'" + colletion.fiscalAddress + @"',
                                }";

                String response = await _clientHttpREST.PostObjetcAsync("api-clients/FinalsClients", json);

                if (response.Equals("Created"))
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

        #region GET: FinalClient/Edit/5
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
                    string repJson1 = await _clientHttpREST.GetObjetcsAllAsync("api-clients/FinalsClients");
                    List<FinalsClientsModel> listClients = TypeModel<FinalsClientsModel>.DeserializeInArray(repJson1);
                    var clients = listClients.Where(d => d.email == _userManager.GetUserName(User)).FirstOrDefault();
                    if (clients != null)
                    {
                        string myIdDev = clients.Id.ToString();
                        if (id.ToString() != myIdDev)
                        {
                            return RedirectToAction("AccessDenied", "Account");
                        }
                    }
                }

                String json = await _clientHttpREST.GetObjetcAsync("api-clients/FinalsClients", id.ToString());

                FinalsClientsModel FinalClient = TypeModel<FinalsClientsModel>.DeserializeInObject(json);

                if (FinalClient == null)
                {
                    return NotFound();
                }

                return View(FinalClient);
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;

                return View("~/Views/Shared/Error.cshtml", new ErrorViewModel { RequestId = Request.Path });
            }
        }
        #endregion

        #region POST: FinalClient/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, FinalsClientsModel pFinalClient)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    string tokenValue = await this.GetTokenAccess();

                    _clientHttpREST.SetToken(tokenValue);

                    String json = @"{   'id':" + pFinalClient.Id + @",
                                        'rif':'" + pFinalClient.Rif + @"',
                                        'description':'" + pFinalClient.Description + @"',
                                        'name':'" + pFinalClient.Name + @"',
                                        'lastName':'" + pFinalClient.LastName + @"',
                                        'phone':'" + pFinalClient.phone + @"',
                                        'email':'" + pFinalClient.email + @"',
                                        'fiscalAddress':'" + pFinalClient.fiscalAddress + @"',
                                        'enable':" + (pFinalClient.enable ? 1 : 0).ToString() + @"
                                   }";

                    String response = await _clientHttpREST.PutObjetcAsync("api-clients/FinalsClients", pFinalClient.Id.ToString(), json);

                    if (response.Equals("OK") || response.Equals("NoContent"))
                    {
                        //Edito su usuario para desactivarlo
                        string repJson2 = await _clientHttpREST.GetObjetcsAllAsync("api-access/Users");

                        List<UserModel> listUsers = TypeModel<UserModel>.DeserializeInArray(repJson2);

                        UserModel updUser = listUsers.Where(u => u.Username == pFinalClient.email).FirstOrDefault();

                        if (updUser != null)
                        {

                            if (pFinalClient.enable ^ updUser.Enable)
                            {
                                updUser.Enable = pFinalClient.enable;

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
                    return View(pFinalClient);
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

        #region GET: FinalClient/Delete/5
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
                String json = await _clientHttpREST.GetObjetcAsync("api-clients/FinalsClients", id.ToString());

                FinalsClientsModel FinalClient = TypeModel<FinalsClientsModel>.DeserializeInObject(json);

                if (FinalClient == null)
                {
                    return NotFound();
                }

                return View(FinalClient);
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;

                return View("~/Views/Shared/Error.cshtml", new ErrorViewModel { RequestId = Request.Path });
            }
        }
        #endregion

        #region // POST: FinalClient/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, FinalsClientsModel collection)
        {
            try
            {
                string tokenValue = await this.GetTokenAccess();

                _clientHttpREST.SetToken(tokenValue);

                String response = await _clientHttpREST.DeleteObjetcAsync("api-clients/FinalsClients", id.ToString());

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

                return View("~/Views/Shared/Error.cshtml", new ErrorViewModel { RequestId = Request.Path }); ;
            }
        }
        #endregion
    }
}