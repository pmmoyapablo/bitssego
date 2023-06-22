using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using Sisgtfhka.Models;
using Newtonsoft.Json;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;
using static Sisgtfhka.Enums.Enums;
using Microsoft.AspNetCore.Identity;


namespace Sisgtfhka.Controllers
{
    [Authorize]
    public class ProviderController : BaseController
    {
        public ProviderController(UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            RoleManager<IdentityRole> roleManager,
            Services.ClientHttpREST clientHttpREST,
            //ILogger<AccountController> logger,
            IOptions<AppSettings> settings)
            : base(userManager, signInManager, clientHttpREST, settings)

        {

        }

        #region // GET: Provider
        public async Task<IActionResult> Index()
        {
            try
            {
                string repJson = await _clientHttpREST.GetObjetcsAllAsync("api-clients/Providers");

                List<ProviderModel> listProviders = TypeModel<ProviderModel>.DeserializeInArray(repJson);

                return View(listProviders);
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;

                return View("~/Views/Shared/Error.cshtml", new ErrorViewModel { RequestId = Request.Path });
            }
        }
        #endregion

        #region // GET: Provider/Details/5
        public async Task<IActionResult> Details(int id)
        {
            try
            {
                string tokenValue = await this.GetTokenAccess();

                _clientHttpREST.SetToken(tokenValue);
                string repJson = await _clientHttpREST.GetObjetcAsync("api-clients/Providers", id.ToString());

                ProviderModel provider = TypeModel<ProviderModel>.DeserializeInObject(repJson);

                return View(provider);
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

        #region // GET: Provider/Create
        public async Task<IActionResult> Create()
        {
            try
            {
                string tokenValue = await this.GetTokenAccess();

                _clientHttpREST.SetToken(tokenValue);
                
                String json = await _clientHttpREST.GetObjetcsAllAsync("api-clients/Providers");
               
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

        #region // POST: Provider/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProviderModel colletion)
        {
            try
            {
                String json = JsonConvert.SerializeObject(colletion);

                String response = await _clientHttpREST.PostObjetcAsync("api-clients/Providers/", json);

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

        #region // GET: Provider/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                if (id == 0)
                {
                    return new StatusCodeResult((int)HttpStatusCode.BadRequest);
                }

                String json = await _clientHttpREST.GetObjetcAsync("api-clients/Providers", id.ToString());

                ProviderModel provider = TypeModel<ProviderModel>.DeserializeInObject(json);

                if (provider == null)
                {
                    return NotFound();
                }

                return View(provider);
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;

                return View("~/Views/Shared/Error.cshtml", new ErrorViewModel { RequestId = Request.Path });
            }
        }
        #endregion

        #region // POST: Provider/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ProviderModel pProvider)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    String json = JsonConvert.SerializeObject(pProvider);

                    String response = await _clientHttpREST.PutObjetcAsync("api-clients/Providers", pProvider.id.ToString(), json);

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
                    return View(pProvider);
                }
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;

                return View("~/Views/Shared/Error.cshtml", new ErrorViewModel { RequestId = Request.Path });
            }
        }
        #endregion

        #region // GET: Provider/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                if (id == 0)
                {
                    return new StatusCodeResult((int)HttpStatusCode.BadRequest);
                }

                String json = await _clientHttpREST.GetObjetcAsync("api-clients/Providers", id.ToString());

                ProviderModel provider = TypeModel<ProviderModel>.DeserializeInObject(json);

                if (provider == null)
                {
                    return NotFound();
                }

                return View(provider);
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;

                return View("~/Views/Shared/Error.cshtml", new ErrorViewModel { RequestId = Request.Path });
            }
        }
        #endregion

        #region // POST: Provider/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, IFormCollection collection)
        {
            try
            {
                String response = await _clientHttpREST.DeleteObjetcAsync("api-clients/Providers", id.ToString());

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
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;

                return View("~/Views/Shared/Error.cshtml", new ErrorViewModel { RequestId = Request.Path });
            }
        }
    }
    #endregion
}