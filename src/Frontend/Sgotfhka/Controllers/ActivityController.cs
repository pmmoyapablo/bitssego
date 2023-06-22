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
    public class ActivityController : BaseController
    {
        public ActivityController(UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            RoleManager<IdentityRole> roleManager,
            Services.ClientHttpREST clientHttpREST,
            ILogger<AccountController> logger,
            IOptions<AppSettings> settings)
            : base(userManager, signInManager, roleManager, clientHttpREST, logger, settings)
        {

        }

        #region  GET: Activity
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

                ////Procesos Existentes
                //List<SelectListItem> lst = new List<SelectListItem>();

                //lst.Add(new SelectListItem() { Text = "SERIALES DE PRODUCTOS", Value = "0" });
                //lst.Add(new SelectListItem() { Text = "SERIALES DE REPUESTOS", Value = "1" });

                //ViewBag.Opciones = lst;

                string repJson = await _clientHttpREST.GetObjetcsAllAsync("api-operations/Activities");

                List<ActivityModel> listActivities = TypeModel<ActivityModel>.DeserializeInArray(repJson);

                if (!String.IsNullOrEmpty(searchString))
                {
                    listActivities = listActivities.Where(a => a.employee.description.IndexOf(searchString, StringComparison.OrdinalIgnoreCase) >= 0 ||
                                                               a.employee.Departament.description.IndexOf(searchString, StringComparison.OrdinalIgnoreCase) >= 0 ||
                                                               a.employee.Chargue.description.IndexOf(searchString, StringComparison.OrdinalIgnoreCase) >= 0 ||
                                                               a.Operation.IndexOf(searchString, StringComparison.OrdinalIgnoreCase) >= 0 ||
                                                               a.Serial.IndexOf(searchString, StringComparison.OrdinalIgnoreCase) >= 0 ||
                                                               a.Operation.IndexOf(searchString, StringComparison.OrdinalIgnoreCase) >= 0).ToList();
                }

                switch (sortOrder)
                {
                    case "name_desc":
                        listActivities = listActivities.OrderByDescending(a => a.employee.description).ToList();
                        break;
                    case "Date":
                        listActivities = listActivities.OrderBy(a => a.Operation).ToList();
                        break;
                    case "date_desc":
                        listActivities = listActivities.OrderByDescending(a => a.Operation).ToList();
                        break;
                    default:
                        listActivities = listActivities.OrderBy(a => a.Operation).ToList();
                        break;
                }

                int pageSize = 8;

                return View(PaginatedList<ActivityModel>.CreateAsync(listActivities.AsQueryable(), pageNumber ?? 1, pageSize));
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

        #region GET: Activity/Details/5
        public async Task<IActionResult> Details(int id)
        {
            try
            {
                string tokenValue = await this.GetTokenAccess();

                _clientHttpREST.SetToken(tokenValue);
                string repJson = await _clientHttpREST.GetObjetcAsync("api-operations/Activities", id.ToString());

                ActivityModel activity = TypeModel<ActivityModel>.DeserializeInObject(repJson);

                return View(activity);
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