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
using Sisgtfhka.Extensions;
using Sisgtfhka.Models;
using static Sisgtfhka.Enums.Enums;

namespace Sisgtfhka.Controllers
{
    [Authorize]
    public class MenuController : BaseController
    {
        public MenuController(UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            RoleManager<IdentityRole> roleManager,
             Services.ClientHttpREST clientHttpREST,
            ILogger<AccountController> logger,
            IOptions<AppSettings> settings)
            : base(userManager, signInManager, roleManager, clientHttpREST, logger, settings)
        {
            
        }

        // GET: Menu
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

                string repJson = await _clientHttpREST.GetObjetcsAllAsync("api-access/Menus");
               
                List<MenuModel> listMenus = TypeModel<MenuModel>.DeserializeInArray(repJson);
            
                if (!String.IsNullOrEmpty(searchString))
                {
                    listMenus = listMenus.Where(m => m.name.IndexOf(searchString, StringComparison.OrdinalIgnoreCase) >= 0
                                           || m.url.IndexOf(searchString, StringComparison.OrdinalIgnoreCase) >= 0).ToList();
                }

                switch (sortOrder)
                {
                    case "name_desc":
                        listMenus = listMenus.OrderByDescending(m => m.name).ToList();
                        break;
                    case "Date":
                        listMenus = listMenus.OrderBy(m => m.creation_date).ToList();
                        break;
                    case "date_desc":
                        listMenus = listMenus.OrderByDescending(m => m.creation_date).ToList();
                        break;
                    default:
                        listMenus = listMenus.OrderBy(m => m.name).ToList();
                        break;
                }

                int pageSize = 8;
               
                return View(PaginatedList<MenuModel>.CreateAsync(listMenus.AsQueryable(), pageNumber ?? 1, pageSize));
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

        // GET: Menu/Details/5
        public async Task<IActionResult> Details(int id)
        {
            try
            {
                string tokenValue = await this.GetTokenAccess();

                _clientHttpREST.SetToken(tokenValue);
                string repJson = await _clientHttpREST.GetObjetcAsync("api-access/Menus", id.ToString());

                MenuModel menu = TypeModel<MenuModel>.DeserializeInObject(repJson);

                return View(menu);
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

        // GET: Menu/Create
        public async Task<IActionResult> Create()
        {
            try
            {
                string tokenValue = await this.GetTokenAccess();

                _clientHttpREST.SetToken(tokenValue);
                //Cargo Select List de Menus Padres
                String json = await _clientHttpREST.GetObjetcsAllAsync("api-access/Menus");
                List<MenuModel> menus = TypeModel<MenuModel>.DeserializeInArray(json);

                menus = menus.Where(m => m.parentId == 0).ToList();

                List<SelectListItem> lst = new List<SelectListItem>();

                lst.Add(new SelectListItem() { Text = "Ninguno", Value = "0" });

                foreach (MenuModel m in menus)
                {
                    lst.Add(new SelectListItem() { Text = m.name, Value = m.id.ToString() });
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

        // POST: Menu/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(MenuModel collection)
        {
            try
            {
                string tokenValue = await this.GetTokenAccess();

                _clientHttpREST.SetToken(tokenValue);

                //String json = JsonConvert.SerializeObject(collection); 
                String json = @"{   'id':0,
                                        'name':'" + collection.name+ @"',
                                        'parentId': " + collection.parentId + @",
                                        'view':'" + collection.view + @"',
                                        'level': " + collection.level + @",
                                        'order': " + collection.order + @",
                                        'url':'" + collection.url + @"',
                                        'visible': " + (collection.visible ? 1 : 0).ToString() + @",
                                        'path_icon':'" + collection.path_icon + @"',
                                     }";

                String response = await _clientHttpREST.PostObjetcAsync("api-access/Menus", json);

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

        // GET: Menu/Edit/5
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
                string repJson = await _clientHttpREST.GetObjetcAsync("api-access/Menus", id.ToString());

                MenuModel menu = TypeModel<MenuModel>.DeserializeInObject(repJson);

                return View(menu);
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

        // POST: Menu/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, MenuModel pMenu)
        {
            try
            {
                string tokenValue = await this.GetTokenAccess();

                _clientHttpREST.SetToken(tokenValue);
              
                    //String json1 = JsonConvert.SerializeObject(pUser);
                    String json1 = @"{   'id': " + pMenu.id + @",
                                        'name':'" + pMenu.name + @"',
                                        'parentId': " + pMenu.parentId + @",
                                        'view':'" + pMenu.view + @"',
                                        'level': " + pMenu.level + @",
                                        'order': " + pMenu.order + @",
                                        'url':'" + pMenu.url + @"',
                                        'visible': " + (pMenu.visible ? 1 : 0).ToString() + @",
                                        'path_icon':'" + pMenu.path_icon + @"',
                                     }";

                    String response = await _clientHttpREST.PutObjetcAsync("api-access/Menus", pMenu.id.ToString(), json1);

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

        // GET: Menu/Delete/5
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

                String json = await _clientHttpREST.GetObjetcAsync("api-access/Menus", id.ToString());

                MenuModel menu = TypeModel<MenuModel>.DeserializeInObject(json);

                if (menu == null)
                {
                    return NotFound();
                }

                return View(menu);
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

        // POST: Menu/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, MenuModel collection)
        {
            try
            {
                string tokenValue = await this.GetTokenAccess();

                _clientHttpREST.SetToken(tokenValue);

                String response = await _clientHttpREST.DeleteObjetcAsync("api-access/Menus", id.ToString());

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

        //GET Menu/AddRol
        public async Task<IActionResult> AddRol(int idMenu)
        {
            try
            {
                string tokenValue = await this.GetTokenAccess();

                _clientHttpREST.SetToken(tokenValue);

                String json = await _clientHttpREST.GetObjetcAsync("api-access/Menus", idMenu.ToString());
                MenuModel menu = TypeModel<MenuModel>.DeserializeInObject(json);

                //Cargo la lista de Roles en un Select
                String json1 = await _clientHttpREST.GetObjetcsAllAsync("api-access/Roles");
                List<RolModel> roles = TypeModel<RolModel>.DeserializeInArray(json1);

                List<SelectListItem> lst = new List<SelectListItem>();

                foreach (RolModel rol in roles)
                {
                    lst.Add(new SelectListItem() { Text = rol.Description, Value = rol.Id.ToString() });
                }

                ViewBag.Opciones = lst;

                return View(menu);
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

        // POST: Menu/AddRol
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> AddRol(MenuModel menu)
        {
            try
            {
                string tokenValue = await this.GetTokenAccess();

                _clientHttpREST.SetToken(tokenValue);

                //String json = JsonConvert.SerializeObject(menu); 
                String json = @"{   'id': " + menu.id+@",
                                        'name':'" + menu.name + @"',
                                        'parentId': " + menu.parentId + @",
                                        'view':'" + menu.view + @"',
                                        'level': " + menu.level + @",
                                        'order': " + menu.order + @",
                                        'url':'" + menu.url + @"',
                                        'visible': " + (menu.visible ? 1 : 0).ToString() + @",
                                        'path_icon':'" + menu.path_icon + @"'
                                     }";

                String response = await _clientHttpREST.PostObjetcAsync("api-access/Roles/"+ menu.RolId.ToString() + "/Menus", json);

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

        // GET: Menus/EditRelation
        public async Task<IActionResult> EditRelation(int idMenu, int idRol)
        {
            try
            {
                string tokenValue = await this.GetTokenAccess();

                _clientHttpREST.SetToken(tokenValue);

                String json = await _clientHttpREST.GetObjetcAsync("api-access/Menus", idMenu.ToString());
                MenuModel menu = TypeModel<MenuModel>.DeserializeInObject(json);
                menu.RolId = idRol;
                //Cargo la lista de Roles en un Select
                String json1 = await _clientHttpREST.GetObjetcsAllAsync("api-access/Roles");
                List<RolModel> roles = TypeModel<RolModel>.DeserializeInArray(json1);

                List<SelectListItem> lst = new List<SelectListItem>();

                foreach (RolModel rol in roles)
                {
                    lst.Add(new SelectListItem() { Text = rol.Description, Value = rol.Id.ToString() });
                }

                ViewBag.Opciones = lst;

                return View(menu);
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

        // POST:  Menus/EditRelation
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> EditRelation(IFormCollection collection)
        {
            try
            {
                string tokenValue = await this.GetTokenAccess();

                _clientHttpREST.SetToken(tokenValue);
                MenuModel menu = new MenuModel();
                menu.id = int.Parse(collection["id"].ToString());
                menu.name = collection["name"];
                menu.RolId = int.Parse(collection["RolId"].ToString());
                int idRol0 = int.Parse(collection["idRol0"].ToString());
                //String json = JsonConvert.SerializeObject(menu); 
                String json = @"{   'id': " + menu.id + @",
                                        'name':'" + menu.name + @"',
                                        'parentId': " + menu.parentId + @",
                                        'view':'" + menu.view + @"',
                                        'level': " + menu.level + @",
                                        'order': " + menu.order + @",
                                        'url':'" + menu.url + @"',
                                        'visible': " + (menu.visible ? 1 : 0).ToString() + @",
                                        'path_icon':'" + menu.path_icon + @"'
                                     }";

                String response = await _clientHttpREST.PutObjetcAsync("api-access/Roles/" + idRol0.ToString() + "/Menus/", menu.RolId.ToString(), json);

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
}