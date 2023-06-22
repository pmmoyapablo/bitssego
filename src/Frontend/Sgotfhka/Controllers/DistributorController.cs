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
    public class DistributorController : BaseController
    {
        public DistributorController(UserManager<ApplicationUser> userManager,
           SignInManager<ApplicationUser> signInManager,
           RoleManager<IdentityRole> roleManager,
           Services.ClientHttpREST clientHttpREST,
           ILogger<AccountController> logger,
           IOptions<AppSettings> settings)
           : base(userManager, signInManager, roleManager, clientHttpREST, logger, settings)
        {

        }

        #region GET: Distributor
        public async Task<IActionResult> Index(string sortOrder,
                                               string currentFilter,
                                               string searchString,
                                               int? pageNumber)
        {
            try
            {
                string tokenValue = await this.GetTokenAccess();

                _clientHttpREST.SetToken(tokenValue);

                string repJson = await _clientHttpREST.GetObjetcsAllAsync("api-clients/Distributors");

                List<DistributorModel> listDistributors = TypeModel<DistributorModel>.DeserializeInArray(repJson);
      
                if(!(RolId <= 7))
                {
                    listDistributors = listDistributors.Where(d => d.email == _userManager.GetUserName(User)).ToList();
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
                    listDistributors = listDistributors.Where(m => m.description.IndexOf(searchString, StringComparison.OrdinalIgnoreCase) >= 0 ||
                                                 m.state.IndexOf(searchString, StringComparison.OrdinalIgnoreCase) >= 0 ||
                                                 m.city.IndexOf(searchString, StringComparison.OrdinalIgnoreCase) >= 0 ||
                                                 m.idSA.ToString().IndexOf(searchString, StringComparison.OrdinalIgnoreCase) >= 0 ||
                                                 m.rif.IndexOf(searchString, StringComparison.OrdinalIgnoreCase) >= 0 ||
                                                 m.email.IndexOf(searchString, StringComparison.OrdinalIgnoreCase) >= 0 ||
                                                 m.represent.IndexOf(searchString, StringComparison.OrdinalIgnoreCase) >= 0).ToList();
                }
                switch (sortOrder)
                {
                    case "name_desc":
                        listDistributors = listDistributors.OrderByDescending(m => m.rif).ToList();
                        break;
                    case "Date":
                        listDistributors = listDistributors.OrderBy(m => m.description).ToList();
                        break;
                    case "date_desc":
                        listDistributors = listDistributors.OrderByDescending(m => m.state).ToList();
                        break;
                    default:
                        listDistributors = listDistributors.OrderBy(m => m.represent).ToList();
                        break;
                }

                int pageSize = 8;

                ViewData["RolId"] = RolId.ToString();
                ViewData["LevelAccess"] = LevelAccess.ToString();

                return View(PaginatedList<DistributorModel>.CreateAsync(listDistributors.AsQueryable(), pageNumber ?? 1, pageSize));
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

        #region GET: Distributor/Details/5
        public async Task<IActionResult> Details(int id)
        {
            try
            {
                string tokenValue = await this.GetTokenAccess();

                _clientHttpREST.SetToken(tokenValue);

                if (!(RolId <= 7))
                {
                    string repJson1 = await _clientHttpREST.GetObjetcsAllAsync("api-clients/Distributors");
                    List<DistributorModel> listDistributors = TypeModel<DistributorModel>.DeserializeInArray(repJson1);
                    var distr = listDistributors.Where(d => d.email == _userManager.GetUserName(User)).FirstOrDefault();
                    if (distr != null)
                    {
                        string myIdDev = distr.id.ToString();
                        if (id.ToString() != myIdDev)
                        {
                            return RedirectToAction("AccessDenied", "Account");
                        }
                    }
                }

                string repJson = await _clientHttpREST.GetObjetcAsync("api-clients/Distributors", id.ToString());

                DistributorModel distributor = TypeModel<DistributorModel>.DeserializeInObject(repJson);

                return View(distributor);
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

        #region GET Distributors/3/Technicians

        public async Task<IActionResult> ViewTechnicals(int id, string sortOrder,
                                               string currentFilter,
                                               string searchString,
                                               int? pageNumber)
        {
            try
            {
                string tokenValue = await this.GetTokenAccess();

                _clientHttpREST.SetToken(tokenValue);
               
                string json1 = await _clientHttpREST.GetObjetcsAllAsync("api-clients/Distributors/" + id.ToString() + "/Technicians");
                List<TechnicianModel>  listTechnicians = TypeModel<TechnicianModel>.DeserializeInArray(json1);

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
                ViewData["DistributorId"] = id.ToString();

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

        #region GET: Distributor/Create
        public async Task<IActionResult> Create()
        {
            try
            {
                string tokenValue = await this.GetTokenAccess();

                _clientHttpREST.SetToken(tokenValue);

                String json = await _clientHttpREST.GetObjetcsAllAsync("api-clients/Distributors");

                ViewBag.Username = _userManager.GetUserName(User);

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

        #region POST: Distributor/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(DistributorModel colletion)
        {
            try
            {
                String json = JsonConvert.SerializeObject(colletion);

                String response = await _clientHttpREST.PostObjetcAsync("api-clients/Distributors/", json);

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

        #region GET: Distributor/Edit/5
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
                    string repJson1 = await _clientHttpREST.GetObjetcsAllAsync("api-clients/Distributors");
                    List<DistributorModel> listDistributors = TypeModel<DistributorModel>.DeserializeInArray(repJson1);
                    var distr = listDistributors.Where(d => d.email == _userManager.GetUserName(User)).FirstOrDefault();
                    if (distr != null)
                    {
                        string myIdDev = distr.id.ToString();
                        if (id.ToString() != myIdDev)
                        {
                            return RedirectToAction("AccessDenied", "Account");
                        }
                    }
                }

                String json = await _clientHttpREST.GetObjetcAsync("api-clients/Distributors", id.ToString());

                DistributorModel distributor = TypeModel<DistributorModel>.DeserializeInObject(json);

                if (distributor == null)
                {
                    return NotFound();
                }

                return View(distributor);
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;

                return View("~/Views/Shared/Error.cshtml", new ErrorViewModel { RequestId = Request.Path });
            }
        }
        #endregion

        #region POST: Distributor/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, DistributorModel pDistributor)
        {
            try
            {
               // if (ModelState.IsValid)
               // {
                    string tokenValue = await this.GetTokenAccess();

                    _clientHttpREST.SetToken(tokenValue);

                String json = @"{  
                                  'id': "+ pDistributor .id+ @",
                                  'idSA': " + pDistributor.idSA + @",
                                  'rif': '" + pDistributor.rif + @"',
                                  'description': '" + pDistributor.description + @"',
                                  'represent': '" + pDistributor.represent + @"',
                                  'address': '" + pDistributor.address + @"',
                                  'country': '" + pDistributor.country + @"',
                                  'state': '" + pDistributor.state + @"',
                                  'city': '" + pDistributor.city + @"',
                                  'phone': '" + pDistributor.phone + @"',
                                  'email': '" + pDistributor.email + @"',
                                  'nit': '" + pDistributor.nit + @"',
                                  'codeZone': '" + pDistributor.codeZone + @"',
                                  'nameSeller': '" + pDistributor.nameSeller + @"',
                                  'rifSeller': '" + pDistributor.rifSeller + @"',
                                  'phoneSeller': '" + pDistributor.phoneSeller + @"',
                                  'typeAgreement': '" + pDistributor.typeAgreement + @"',
                                  'enable': " + (pDistributor.enable ? 1 : 0).ToString() + @"
                                }";

                String response = await _clientHttpREST.PutObjetcAsync("api-clients/Distributors", pDistributor.id.ToString(), json);

                    if (response.Equals("OK") || response.Equals("NoContent"))
                    {
                         //Edito su usuario para desactivarlo
                         string repJson2 = await _clientHttpREST.GetObjetcsAllAsync("api-access/Users");

                          List<UserModel> listUsers = TypeModel<UserModel>.DeserializeInArray(repJson2);

                          UserModel updUser = listUsers.Where(u => u.Username == pDistributor.email).FirstOrDefault();

                    if (updUser != null)
                    {
                        if (pDistributor.enable ^ updUser.Enable)
                        {
                            updUser.Enable = pDistributor.enable;

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
                //}
                //else
                //{
                //    return View(pDistributor);
                //}
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

        #region GET: Distributor/Delete/5
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

                String json = await _clientHttpREST.GetObjetcAsync("api-clients/Distributors", id.ToString());

                DistributorModel distributor = TypeModel<DistributorModel>.DeserializeInObject(json);

                if (distributor == null)
                {
                    return NotFound();
                }

                return View(distributor);
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

        #region POST: Distributor/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, DistributorModel distributor)
        {
            try
            {             
                string tokenValue = await this.GetTokenAccess();

                _clientHttpREST.SetToken(tokenValue);

                //Borro las relaciones con Distributors-Providers
                String response1 = await _clientHttpREST.DeleteObjetcAsync("api-clients/Distributors/" + id.ToString() + "/Providers", "1");
                response1 = await _clientHttpREST.DeleteObjetcAsync("api-clients/Distributors/" + id.ToString() + "/Providers", "2");
                //Borro la relacion Distribuidor-User
                //Obtengo el User respectivo para borrarlo
                string repJson = await _clientHttpREST.GetObjetcsAllAsync("api-access/Users");

                List<UserModel> listUsers = TypeModel<UserModel>.DeserializeInArray(repJson);
                UserModel user = listUsers.Where(u => u.Username == distributor.email).FirstOrDefault();
                if (user != null)
                {
                    String response3 = await _clientHttpREST.DeleteObjetcAsync("api-clients/Distributors/" + id.ToString() + "/Users", user.Id.ToString());
                    //Borro el User del Distribuidor
                    String response2 = await _clientHttpREST.DeleteObjetcAsync("api-access/Users", user.Id.ToString());
                }

                //Borro al Distribuidor
                String response = await _clientHttpREST.DeleteObjetcAsync("api-clients/Distributors", id.ToString());

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