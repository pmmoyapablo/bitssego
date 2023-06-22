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
    public class ModelController : BaseController
    {
        public ModelController(UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            RoleManager<IdentityRole> roleManager,
            Services.ClientHttpREST clientHttpREST,
            ILogger<AccountController> logger,
            IOptions<AppSettings> settings)
            : base(userManager, signInManager, clientHttpREST, settings)

        {

        }

        #region // GET: Model
        public async Task<IActionResult> Index(string sortOrder,
                                               string currentFilter,
                                               string searchString,
                                               int? pageNumber)
        {
            try
            {
                string tokenValue = await this.GetTokenAccess();

                _clientHttpREST.SetToken(tokenValue);

                string repJson = await _clientHttpREST.GetObjetcsAllAsync("api-products/Models");

                List<ModelModel> listModels = TypeModel<ModelModel>.DeserializeInArray(repJson);

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
                    listModels = listModels.Where(m => m.name.IndexOf(searchString, StringComparison.OrdinalIgnoreCase) >= 0 ||  m.Mark.name.IndexOf(searchString, StringComparison.OrdinalIgnoreCase) >= 0).ToList();
                }
                switch (sortOrder)
                {
                    case "name_desc":
                        listModels = listModels.OrderByDescending(m => m.name).ToList();
                        break;
                    case "Date":
                        listModels = listModels.OrderBy(m => m.name).ToList();
                        break;
                    case "date_desc":
                        listModels = listModels.OrderByDescending(m => m.name).ToList();
                        break;
                    default:
                        listModels = listModels.OrderBy(m => m.name).ToList();
                        break;
                }

                int pageSize = 8;

                ViewData["RolId"] = RolId.ToString();
                ViewData["LevelAccess"] = LevelAccess.ToString();

                return View(PaginatedList<ModelModel>.CreateAsync(listModels.AsQueryable(), pageNumber ?? 1, pageSize));
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

        #region// GET: Model/Details/5
        public async Task<IActionResult> Details(int id)
        {
            try
            {
                string tokenValue = await this.GetTokenAccess();

                _clientHttpREST.SetToken(tokenValue);

                string repJson = await _clientHttpREST.GetObjetcAsync("api-products/Models", id.ToString());

                ModelModel model = TypeModel<ModelModel>.DeserializeInObject(repJson);

                return View(model);
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

        #region// GET: Model/Create
        public async Task<IActionResult> Create()
        {
            try
            {
                //Select List de Marcas
                string tokenValue = await this.GetTokenAccess();

                _clientHttpREST.SetToken(tokenValue);

                String json = await _clientHttpREST.GetObjetcsAllAsync("api-products/Marks");
                List<MarkModel> marks = TypeModel<MarkModel>.DeserializeInArray(json);

                List<SelectListItem> lst = new List<SelectListItem>();

                foreach (MarkModel mark in marks)
                {
                    lst.Add(new SelectListItem() { Text = mark.name, Value = mark.id.ToString() });
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

        #region // POST: Model/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ModelModel colletion)
        {
            try
            {
                string tokenValue = await this.GetTokenAccess();

                _clientHttpREST.SetToken(tokenValue);
                String json = JsonConvert.SerializeObject(colletion);

                String response = await _clientHttpREST.PostObjetcAsync("api-products/Models/", json);

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
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;

                return View("~/Views/Shared/Error.cshtml", new ErrorViewModel { RequestId = Request.Path });
            }
        }
        #endregion

        #region // GET: Model/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                string tokenValue = await this.GetTokenAccess();

                _clientHttpREST.SetToken(tokenValue);

                if (id == 0)
                {
                    return new StatusCodeResult((int)HttpStatusCode.BadRequest);
                }

                String json = await _clientHttpREST.GetObjetcAsync("api-products/Models", id.ToString());
                ModelModel model = TypeModel<ModelModel>.DeserializeInObject(json);

                if (model == null)
                {
                    return NotFound();
                }

                //Select List de Marcas              
                String json2 = await _clientHttpREST.GetObjetcsAllAsync("api-products/Marks");
                List<MarkModel> marks = TypeModel<MarkModel>.DeserializeInArray(json2);

                List<SelectListItem> lst = new List<SelectListItem>();

                foreach (MarkModel mark in marks)
                {
                    lst.Add(new SelectListItem() { Text = mark.name, Value = mark.id.ToString() });
                }

                ViewBag.Opciones = lst;

                return View(model);
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;

                return View("~/Views/Shared/Error.cshtml", new ErrorViewModel { RequestId = Request.Path });
            }
        }
        #endregion

        #region // POST: Model/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ModelModel pModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    string tokenValue = await this.GetTokenAccess();

                    _clientHttpREST.SetToken(tokenValue);

                    String json = JsonConvert.SerializeObject(pModel);

                    String response = await _clientHttpREST.PutObjetcAsync("api-products/Models", pModel.id.ToString(), json);

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
                    return View(pModel );
                }
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;

                return View("~/Views/Shared/Error.cshtml", new ErrorViewModel { RequestId = Request.Path });
            }
        }
        #endregion

        #region // GET: Model/Delete/5
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

                String json = await _clientHttpREST.GetObjetcAsync("api-products/Models", id.ToString());

                ModelModel model = TypeModel<ModelModel>.DeserializeInObject(json);

                if (model == null)
                {
                    return NotFound();
                }

                return View(model);
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

        #region // POST: Model/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, ModelModel collection)
        {
            try
            {
                string tokenValue = await this.GetTokenAccess();

                _clientHttpREST.SetToken(tokenValue);

                String response = await _clientHttpREST.DeleteObjetcAsync("api-products/Models", id.ToString());

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