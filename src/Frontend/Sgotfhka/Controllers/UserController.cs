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

namespace Sisgtfhka.Controllers
{
    [Authorize]
    public class UserController : BaseController
    {      
        public UserController(UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            RoleManager<IdentityRole> roleManager,
            Services.ClientHttpREST clientHttpREST,
            ILogger<AccountController> logger,
            IOptions<AppSettings> settings)
            :base(userManager, signInManager, roleManager, clientHttpREST, logger, settings)
        {
             
        }

        #region // GET: User
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

                string repJson = await _clientHttpREST.GetObjetcsAllAsync("api-access/Users");

                List<UserModel> listUsers = TypeModel<UserModel>.DeserializeInArray(repJson);

                if (!String.IsNullOrEmpty(searchString))
                {
                    listUsers = listUsers.Where(m => m.Username.IndexOf(searchString, StringComparison.OrdinalIgnoreCase) >= 0 ||
                                                m.Rol.Description.IndexOf(searchString, StringComparison.OrdinalIgnoreCase) >= 0).ToList();
                }

                switch (sortOrder)
                {
                    case "name_desc":
                        listUsers = listUsers.OrderByDescending(m => m.Username).ToList();
                        break;
                    case "Date":
                        listUsers = listUsers.OrderBy(m => m.Creation_date).ToList();
                        break;
                    case "date_desc":
                        listUsers = listUsers.OrderByDescending(m => m.Creation_date).ToList();
                        break;
                    default:
                        listUsers = listUsers.OrderBy(m => m.Username).ToList();
                        break;
                }

                int pageSize = 8;

                return View(PaginatedList<UserModel>.CreateAsync(listUsers.AsQueryable(), pageNumber ?? 1, pageSize));
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

        #region // GET: User/Details/5
        public async Task<IActionResult> Details(int id)
        {
            try
            {
                string tokenValue = await this.GetTokenAccess();

                _clientHttpREST.SetToken(tokenValue);
                string repJson = await _clientHttpREST.GetObjetcAsync("api-access/Users", id.ToString());

                UserModel user = TypeModel<UserModel>.DeserializeInObject(repJson);

                return View(user);
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

        #region // GET: User/Create
        public async Task<IActionResult> Create()
        {
            try
            {               
                //Select List de Roles
                String json = await _clientHttpREST.GetObjetcsAllAsync("api-access/Roles");
                List<RolModel> roles = TypeModel<RolModel>.DeserializeInArray(json);

                List<SelectListItem> lst = new List<SelectListItem>();

                foreach (RolModel role in roles)
                {
                    lst.Add(new SelectListItem() { Text = role.Description, Value = role.Id.ToString() });
                }

                ViewBag.Opciones = lst;

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

        #region // POST: User/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(UserModel collection)
        {
            try
            {
                var user = new ApplicationUser { UserName = collection.Username, Email = collection.Username };
                //Hago un Insert Check User Identity Model para validar modelo con el formato password de Identity de .NET Core
                var result = await _userManager.CreateAsync(user, collection.Password);
                if (result.Succeeded)
                {
                    //Borro el Insert Check User Identity Model
                    var resultDelUser = await _userManager.DeleteAsync(user);

                    string tokenValue = await this.GetTokenAccess();

                    _clientHttpREST.SetToken(tokenValue);

                    //String json = JsonConvert.SerializeObject(collection); 
                    String json = @"{   'id':" + collection.Id + @",
                                    'rolId':" + collection.RolId + @",
                                    'username':'" + collection.Username + @"',
                                    'password':'" + collection.Password + @"',
                                    'enable':" + (collection.Enable ? 1 : 0).ToString() + @"
                                }";

                    String response = await _clientHttpREST.PostObjetcAsync("api-access/Users", json);

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
                }else
                {
                    Alert("Error en la Operación", NotificationType.error);

                    AddErrors(result);
                    // If we got this far, something failed, redisplay form
                    //Select List de Roles
                    String json = await _clientHttpREST.GetObjetcsAllAsync("api-access/Roles");
                    List<RolModel> roles = TypeModel<RolModel>.DeserializeInArray(json);

                    List<SelectListItem> lst = new List<SelectListItem>();

                    foreach (RolModel role in roles)
                    {
                        lst.Add(new SelectListItem() { Text = role.Description, Value = role.Id.ToString() });
                    }

                    ViewBag.Opciones = lst;

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

        #region // GET: User/Edit/5
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

                String json = await _clientHttpREST.GetObjetcAsync("api-access/Users", id.ToString());

                UserModel user = TypeModel<UserModel>.DeserializeInObject(json);

                if (user == null)
                {
                    return NotFound();
                }

                //Cargo Select List de Roles
                String json1 = await _clientHttpREST.GetObjetcsAllAsync("api-access/Roles");
                List<RolModel> roles = TypeModel<RolModel>.DeserializeInArray(json1);

                List<SelectListItem> lst = new List<SelectListItem>();

                foreach (RolModel rol in roles)
                {
                    lst.Add(new SelectListItem() { Text = rol.Description, Value = rol.Id.ToString() });
                }

                ViewBag.Opciones = lst;

                return View(user);
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

        #region // POST: User/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, UserModel pUser)
        {
            try
            {
                string tokenValue = await this.GetTokenAccess();

                _clientHttpREST.SetToken(tokenValue);
                String json = await _clientHttpREST.GetObjetcAsync("api-access/Users", id.ToString());

                UserModel userPre = TypeModel<UserModel>.DeserializeInObject(json);
                      
                if (userPre != null)
                {
                    pUser.Creation_date = userPre.Creation_date;
                    pUser.Password = userPre.Password;
                    pUser.ConfirmPassword = userPre.Password;

                    //String json1 = JsonConvert.SerializeObject(pUser);
                    String json1 = @"{   'id':" + pUser.Id + @",
                                    'rolId':" + pUser.RolId + @",
                                    'username':'" + pUser.Username + @"',
                                    'password':'" + pUser.Password + @"',
                                    'enable':" + (pUser.Enable ? 1 : 0).ToString() + @"
                                }";

                    String response = await _clientHttpREST.PutObjetcAsync("api-access/Users", pUser.Id.ToString(), json1);

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
                    return View(pUser);
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

        #region // GET: User/Delete/5
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

                String json = await _clientHttpREST.GetObjetcAsync("api-access/Users", id.ToString());

                UserModel user = TypeModel<UserModel>.DeserializeInObject(json);

                if (user == null)
                {
                    return NotFound();
                }

                return View(user);
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

        #region // POST: User/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, IFormCollection collection)
        {
            try
            {
                string tokenValue = await this.GetTokenAccess();

                _clientHttpREST.SetToken(tokenValue);

                String response = await _clientHttpREST.DeleteObjetcAsync("api-access/Users", id.ToString());

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

                return View("~/Views/Shared/Error.cshtml", new ErrorViewModel { RequestId = Request.Path });;
            }
        }
        #endregion      

        #region Helpers

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
        }

        #endregion
    
    }
}