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
    public class RolController : BaseController
    {
        public RolController(UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager, 
            Services.ClientHttpREST clientHttpREST,
            IOptions<AppSettings> settings)
            :base(userManager, signInManager, clientHttpREST, settings)
        { 
        }
      
        #region // GET: Rol
        public async Task<IActionResult> Index()
        {
            try
            {                
                string repJson = await _clientHttpREST.GetObjetcsAllAsync("api-access/Roles");

                List<RolModel> listRoles = TypeModel<RolModel>.DeserializeInArray(repJson);

                return View(listRoles);
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;

                return View("~/Views/Shared/Error.cshtml", new ErrorViewModel { RequestId = Request.Path});
            }
        }
        #endregion

        #region // GET: Rol/Details/5
        public async Task<IActionResult> Details(int id)
        {
            try
            {
                string repJson = await _clientHttpREST.GetObjetcAsync("api-access/Roles", id.ToString());

                RolModel rol = TypeModel<RolModel>.DeserializeInObject(repJson);

                return View(rol);
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;

                return View("~/Views/Shared/Error.cshtml", new ErrorViewModel { RequestId = Request.Path });
            }
        }
        #endregion

        #region // GET: Rol/Create
        public async Task<IActionResult> Create()
        {          
            //Cargo Select List de Acceses
            String json = await _clientHttpREST.GetObjetcsAllAsync("api-access/Accesses");
            List<Access> accesces = TypeModel<Access>.DeserializeInArray(json);

            List<SelectListItem> lst = new List<SelectListItem>();

            foreach (Access acs in accesces)
            {
                lst.Add(new SelectListItem() { Text = acs.description, Value = acs.id.ToString() });
            }

            ViewBag.Opciones = lst;
            //Cargo SelectList de Profiles
            String json2 = await _clientHttpREST.GetObjetcsAllAsync("api-access/Profiles");
            List<Profile> profiles = TypeModel<Profile>.DeserializeInArray(json2);

            List<SelectListItem> lst2 = new List<SelectListItem>();

            foreach (Profile profil in profiles)
            {
                lst2.Add(new SelectListItem() { Text = profil.name, Value = profil.id.ToString() });
            }

            ViewBag.Opciones2 = lst2;

            return View();
        }
        #endregion

        #region // POST: Rol/Create
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(RolModel colletion)
        {
            try
            {
                String json = JsonConvert.SerializeObject(colletion);

                String response = await _clientHttpREST.PostObjetcAsync("api-access/Roles/", json);

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

        #region // GET: Rol/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                if (id == 0)
                {  
                    return new StatusCodeResult((int)HttpStatusCode.BadRequest);
                }

                String json = await _clientHttpREST.GetObjetcAsync("api-access/Roles", id.ToString());

                RolModel rol = TypeModel<RolModel>.DeserializeInObject(json);

                if (rol == null)
                {
                    return NotFound();
                }

                //Cargo Select List de Acceses
                String json1 = await _clientHttpREST.GetObjetcsAllAsync("api-access/Accesses");
                List<Access> accesces = TypeModel<Access>.DeserializeInArray(json1);

                List<SelectListItem> lst = new List<SelectListItem>();

                foreach (Access acs in accesces)
                {
                    lst.Add(new SelectListItem() { Text = acs.description, Value = acs.id.ToString() });
                }

                ViewBag.Opciones = lst;
                //Cargo SelectList de Profiles
                String json2 = await _clientHttpREST.GetObjetcsAllAsync("api-access/Profiles");
                List<Profile> profiles = TypeModel<Profile>.DeserializeInArray(json2);

                List<SelectListItem> lst2 = new List<SelectListItem>();

                foreach (Profile profil in profiles)
                {
                    lst2.Add(new SelectListItem() { Text = profil.name, Value = profil.id.ToString() });
                }

                ViewBag.Opciones2 = lst2;

                return View(rol);
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;

                return View("~/Views/Shared/Error.cshtml", new ErrorViewModel { RequestId = Request.Path });
            }
        }
        #endregion

        #region // POST: Rol/Edit/5
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, RolModel pRol)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    String json = JsonConvert.SerializeObject(pRol);

                    String response = await _clientHttpREST.PutObjetcAsync("api-access/Roles", pRol.Id.ToString(), json);

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
                    return View(pRol);
                }
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;

                return View("~/Views/Shared/Error.cshtml", new ErrorViewModel { RequestId = Request.Path });

            }
        }
        #endregion

        #region // GET: Rol/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                if (id == 0)
                {
                    return new StatusCodeResult((int)HttpStatusCode.BadRequest);
                }

                String json = await _clientHttpREST.GetObjetcAsync("api-access/Roles", id.ToString());

                RolModel rol = TypeModel<RolModel>.DeserializeInObject(json);

                if (rol == null)
                {
                    return NotFound();
                }

                return View(rol);
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;

                return View("~/Views/Shared/Error.cshtml", new ErrorViewModel { RequestId = Request.Path });
                //return HttpNotFound(ex.Message);
            }
        }
        #endregion

        #region // POST: Rol/Delete/5
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, IFormCollection collection)
        {
            try
            {
                String response = await _clientHttpREST.DeleteObjetcAsync("api-access/Roles", id.ToString());

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
                //return HttpNotFound(ex.Message);
            }
        }

        #endregion

        #region // GET: Roles/ListMenus
        public async Task<IActionResult> ListMenus(int id)
        {
            try
            {
                string tokenValue = await this.GetTokenAccess();

                _clientHttpREST.SetToken(tokenValue);
                string repJson = await _clientHttpREST.GetObjetcsAllAsync("api-access/Roles/"+ id.ToString() +"/Menus");

                List<MenuModel> listMenus = TypeModel<MenuModel>.DeserializeInArray(repJson);

                ViewBag.RolIdRel = id;

                return View(listMenus);
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