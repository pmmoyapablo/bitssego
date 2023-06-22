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
using System.IO;

namespace Sisgtfhka.Controllers
{
    [Authorize]
    public class ProductController : BaseController
    {
        public ProductController(UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            RoleManager<IdentityRole> roleManager,
            Services.ClientHttpREST clientHttpREST,
            ILogger<AccountController> logger,
            IOptions<AppSettings> settings)
            : base(userManager, signInManager, clientHttpREST, settings)
        {

        }

        #region  GET: Product
        public async Task<IActionResult> Index(string sortOrder,
                                               string currentFilter,
                                               string searchString,
                                               int? pageNumber)
        {
            try
            {
                string tokenValue = await this.GetTokenAccess();

                _clientHttpREST.SetToken(tokenValue);

                string repJson = await _clientHttpREST.GetObjetcsAllAsync("api-products/Products");

                List<ProductModel> listProducts = TypeModel<ProductModel>.DeserializeInArray(repJson);

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
                    listProducts = listProducts.Where(p => p.Name.IndexOf(searchString, StringComparison.OrdinalIgnoreCase) >= 0 || p.Code.IndexOf(searchString, StringComparison.OrdinalIgnoreCase) >= 0
                    || p.Model.name.IndexOf(searchString, StringComparison.OrdinalIgnoreCase) >= 0 || p.Model.Mark.name.IndexOf(searchString, StringComparison.OrdinalIgnoreCase) >= 0
                    || p.Category.name.IndexOf(searchString, StringComparison.OrdinalIgnoreCase) >= 0 || p.Description.IndexOf(searchString, StringComparison.OrdinalIgnoreCase) >= 0).ToList();
                }
                switch (sortOrder)
                {
                    case "name_desc":
                        listProducts = listProducts.OrderByDescending(p => p.Name).ToList();
                        break;
                    case "Date":
                        listProducts = listProducts.OrderBy(p => p.Name).ToList();
                        break;
                    case "date_desc":
                        listProducts = listProducts.OrderByDescending(p => p.Name).ToList();
                        break;
                    default:
                        listProducts = listProducts.OrderBy(p => p.Name).ToList();
                        break;
                }

                int pageSize = 8;

                ViewData["RolId"] = RolId.ToString();
                ViewData["LevelAccess"] = LevelAccess.ToString();

                return View(PaginatedList<ProductModel>.CreateAsync(listProducts.AsQueryable(), pageNumber ?? 1, pageSize));
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

        #region GET: Product/Details/5
        public async Task<IActionResult> Details(int id)
        {
            try
            {
                string tokenValue = await this.GetTokenAccess();

                _clientHttpREST.SetToken(tokenValue);

                string repJson = await _clientHttpREST.GetObjetcAsync("api-products/Products", id.ToString());

                ProductModel Product = TypeModel<ProductModel>.DeserializeInObject(repJson);

                return View(Product);
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

        #region GET: Product/Create
        public async Task<IActionResult> Create()
        {
            try
            {
                string tokenValue = await this.GetTokenAccess();

                _clientHttpREST.SetToken(tokenValue);

                //Select List de Categorias

                String json = await _clientHttpREST.GetObjetcsAllAsync("api-products/Categories");

                List<CategoryModel> Category = TypeModel<CategoryModel>.DeserializeInArray(json);

                List<SelectListItem> lst = new List<SelectListItem>();

                foreach (CategoryModel category in Category)
                {
                    lst.Add(new SelectListItem() { Text = category.name, Value = category.id.ToString() });
                }

                ViewBag.Opciones = lst;

                //Select List de Modelos

                String json1 = await _clientHttpREST.GetObjetcsAllAsync("api-products/Models");

                List<ModelModel> Model = TypeModel<ModelModel>.DeserializeInArray(json1);

                List<SelectListItem> lst1 = new List<SelectListItem>();

                foreach (ModelModel model in Model)
                {
                    lst1.Add(new SelectListItem() { Text = model.name, Value = model.id.ToString() });
                }

                ViewBag.Opciones2 = lst1;

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

        #region  POST: Product/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProductModel colletion)
        {
            try
            {
                string tokenValue = await this.GetTokenAccess();

                _clientHttpREST.SetToken(tokenValue);

                String json = JsonConvert.SerializeObject(colletion);

                String response = await _clientHttpREST.PostObjetcAsync("api-products/Products/", json);

                String json1 = @"{   'id':" + colletion.Id + @",
                                    'categoryId':'" + colletion.CategoryId + @"',
                                    'modelId':'" + colletion.ModelId + @"',
                                    'name':'" + colletion.Name + @"',
                                    'description':'" + colletion.Description + @"',
                                    'code':'" + colletion.Code + @"',
                                    'state':" + colletion.State + @"', 
                                    'imageUrl':'" + colletion.ImageUrl + @"                               
                                }";

                if (response.Equals("Created"))
                {
                    if (colletion.image != null)
                    {
                        //Guardar imagen al servidor
                        string imageName = Path.GetFileName(colletion.image.FileName);
                        
                        string savePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/productos", imageName);
                        
                        using (var stream = new FileStream(savePath, FileMode.Create))
                        {
                            colletion.image.CopyTo(stream);
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
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;

                return View("~/Views/Shared/Error.cshtml", new ErrorViewModel { RequestId = Request.Path });
            }
        }
        #endregion

        #region  GET: Product/Edit/5
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
                String json = await _clientHttpREST.GetObjetcAsync("api-products/Products", id.ToString());
                ProductModel product = TypeModel<ProductModel>.DeserializeInObject(json);

                if (product == null)
                {
                    return NotFound();
                }
                //Select List de Categorias
                String json1 = await _clientHttpREST.GetObjetcsAllAsync("api-products/Categories");
                List<CategoryModel> categories = TypeModel<CategoryModel>.DeserializeInArray(json1);
                List<SelectListItem> lst = new List<SelectListItem>();

                foreach (CategoryModel category in categories)
                {
                    lst.Add(new SelectListItem() { Text = category.name, Value = category.id.ToString() });
                }
                ViewBag.Opciones = lst;

                //Select List de Modelos
                String json2 = await _clientHttpREST.GetObjetcsAllAsync("api-products/Models");
                List<ModelModel> Model = TypeModel<ModelModel>.DeserializeInArray(json2);
                List<SelectListItem> lst2 = new List<SelectListItem>();

                foreach (ModelModel model in Model)
                {
                    lst2.Add(new SelectListItem() { Text = model.name, Value = model.id.ToString() });
                }
                ViewBag.Opciones2 = lst2;

                //Select List de Prefijos
                String json3 = await _clientHttpREST.GetObjetcsAllAsync("api-products/Prefixes");
                List<PrefixModel> Prefixes = TypeModel<PrefixModel>.DeserializeInArray(json3);
                List<SelectListItem> lst3 = new List<SelectListItem>();

                foreach (PrefixModel prefix in Prefixes)
                {
                    lst3.Add(new SelectListItem() { Text = prefix.InitAlphaNum + " (" + prefix.InitCorrelative + ")", Value = prefix.Id.ToString() });
                }
                ViewBag.Opciones3 = lst3;

                return View(product);
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
                return View("~/Views/Shared/Error.cshtml", new ErrorViewModel { RequestId = Request.Path });
            }
        }
        #endregion

        #region  POST: /Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ProductModel pModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    string tokenValue = await this.GetTokenAccess();

                    _clientHttpREST.SetToken(tokenValue);

                    String json = JsonConvert.SerializeObject(pModel);

                    String response = await _clientHttpREST.PutObjetcAsync("api-products/Products", pModel.Id.ToString(), json);


                    if (response.Equals("OK") || response.Equals("NoContent"))
                    {
                        if (pModel.image != null)
                        {
                            //Guardar imagen al servidor
                            string imageName = Path.GetFileName(pModel.image.FileName);

                            string savePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/productos", imageName);

                            using (var stream = new FileStream(savePath, FileMode.Create))
                            {
                                pModel.image.CopyTo(stream);
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
                    return View(pModel);
                }
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;

                return View("~/Views/Shared/Error.cshtml", new ErrorViewModel { RequestId = Request.Path });
            }
        }
        #endregion

        #region  GET: Product/Delete/5
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

                String json = await _clientHttpREST.GetObjetcAsync("api-products/Products", id.ToString());

                ProductModel product = TypeModel<ProductModel>.DeserializeInObject(json);

                if (product == null)
                {
                    return NotFound();
                }

                return View(product);
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

        #region  POST: Product/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, ReplacementModel collection)
        {
            try
            {
                string tokenValue = await this.GetTokenAccess();

                _clientHttpREST.SetToken(tokenValue);

                String response = await _clientHttpREST.DeleteObjetcAsync("api-products/Products", id.ToString());

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

        //ACCESORIO

        #region  GET: api/Products/{ProductId}/Accesories -------------LISTAR
        public async Task<IActionResult> ListAccessories(int id)
        {
            try
            {
                string tokenValue = await this.GetTokenAccess();

                _clientHttpREST.SetToken(tokenValue);

                string json1 = await _clientHttpREST.GetObjetcsAllAsync("api-Products/Products/" + id.ToString() + "/Accesories");

                List<AccessoryModel> listaccessories = TypeModel<AccessoryModel>.DeserializeInArray(json1);

                ViewData["idProduct"] = id;

                return View(listaccessories);
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;

                return View("~/Views/Shared/Error.cshtml", new ErrorViewModel { RequestId = Request.Path });
            }
        }
        #endregion

        #region  GET: api/Products/{ProductId}/Accesories -------------AGREGAR 
        public async Task<IActionResult> AddAccessories(int productId)
        {
            try
            {
                string tokenValue = await this.GetTokenAccess();

                _clientHttpREST.SetToken(tokenValue);

                //Select List de Accesorios

                String json = await _clientHttpREST.GetObjetcsAllAsync("api-products/Accessories");

                List<AccessoryModel> Accessories = TypeModel<AccessoryModel>.DeserializeInArray(json);

                List<SelectListItem> lst = new List<SelectListItem>();

                foreach (AccessoryModel accessory in Accessories)
                {
                    lst.Add(new SelectListItem() { Text = accessory.name, Value = accessory.id.ToString() });
                }

                string repJson = await _clientHttpREST.GetObjetcAsync("api-products/Products", productId.ToString());

                ProductModel Product = TypeModel<ProductModel>.DeserializeInObject(repJson);

                ViewBag.Opciones = lst;
                ViewBag.ProductId = productId;
                ViewBag.DescriptionProduct = Product.Name + " " + Product.Model.name;

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

        #region  POST: api/Products/{ProductId}/Accesories 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddAccessories(int productId, AccessoryModel accesory)
        {
            try
            {
                string tokenValue = await this.GetTokenAccess();

                _clientHttpREST.SetToken(tokenValue);

                String json = JsonConvert.SerializeObject(accesory);

                String response = await _clientHttpREST.PostObjetcAsync("api-products/products/" + productId.ToString() + "/Accesories", json);

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
        #endregion

        #region GET api/Products/{ProductId}/Accesories/{AccesoryId} -------------BORRAR
        public async Task<IActionResult> DeleteAccessories(int id, int productId)
        {
            try
            {
                if (id == 0)
                {
                    return new StatusCodeResult((int)HttpStatusCode.BadRequest);
                }

                string tokenValue = await this.GetTokenAccess();

                _clientHttpREST.SetToken(tokenValue);

                String json = await _clientHttpREST.GetObjetcsAllAsync("api-products/Accessories/" + id.ToString());

                AccessoryModel accessory = TypeModel<AccessoryModel>.DeserializeInObject(json);

                if (accessory == null)
                {
                    return NotFound();
                }

                ViewBag.ProductId = productId;

                return View(accessory);
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

        #region  POST: api/Products/{ProductId}/Accesories/{AccesoryId}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteAccessories(int id, int productId, AccessoryModel collection)
        {
            try
            {
                string tokenValue = await this.GetTokenAccess();

                _clientHttpREST.SetToken(tokenValue);

                String response = await _clientHttpREST.DeleteObjetcAsync("api-products/products/" + productId.ToString() + "/Accesories", id.ToString());

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

        //REPUESTO

        #region  GET: api/Products/{id}/Replacements -------------LISTAR
        public async Task<IActionResult> ListReplacements(int id)
        {
            try
            {
                string tokenValue = await this.GetTokenAccess();

                _clientHttpREST.SetToken(tokenValue);

                string json1 = await _clientHttpREST.GetObjetcsAllAsync("api-Products/Products/" + id.ToString() + "/Replacements");

                List<ReplacementModel> listreplacements = TypeModel<ReplacementModel>.DeserializeInArray(json1);

                ViewData["idProduct"] = id;

                return View(listreplacements);
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;

                return View("~/Views/Shared/Error.cshtml", new ErrorViewModel { RequestId = Request.Path });
            }
        }
        #endregion

        #region  GET: api/Products/{ProductId}/Replacements -------------AGREGAR 
        public async Task<IActionResult> AddReplacements(int productId)
        {
            try
            {
                string tokenValue = await this.GetTokenAccess();
                _clientHttpREST.SetToken(tokenValue);
                //Product
                string repJson = await _clientHttpREST.GetObjetcAsync("api-products/Products", productId.ToString());
                ProductModel Product = TypeModel<ProductModel>.DeserializeInObject(repJson);
                //Select List de Repuestos con Modelo Principal del Producto
                String json = await _clientHttpREST.GetObjetcsAllAsync("api-products/Replacements/" + Product.ModelId + "/Replacements");
                List<ReplacementModel> Replacementes = TypeModel<ReplacementModel>.DeserializeInArray(json);
                List<SelectListItem> lst = new List<SelectListItem>();
                foreach (ReplacementModel replacement in Replacementes)
                {
                    lst.Add(new SelectListItem() { Text = replacement.name + " - " + replacement.Model.name, Value = replacement.id.ToString() });
                }
                //Select List de Repuestos con Modelo Varios
                String json2 = await _clientHttpREST.GetObjetcsAllAsync("api-products/Replacements/0/Replacements");
                List<ReplacementModel> ReplacementesVar = TypeModel<ReplacementModel>.DeserializeInArray(json2);
                foreach (ReplacementModel replacement in ReplacementesVar)
                {
                    lst.Add(new SelectListItem() { Text = replacement.name + " - " + replacement.Model.name, Value = replacement.id.ToString() });
                }
                ViewBag.Opciones = lst;
                ViewBag.ProductId = productId;
                ViewBag.DescriptionProduct = Product.Name + " " + Product.Model.name;
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

        #region  POST: api/Products/{ProductId}/Replacements 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddReplacements(int productId, ReplacementModel replacement)
        {
            try
            {
                string tokenValue = await this.GetTokenAccess();

                _clientHttpREST.SetToken(tokenValue);

                string repJson = await _clientHttpREST.GetObjetcAsync("api-products/Replacements", replacement.id.ToString());

                replacement = TypeModel<ReplacementModel>.DeserializeInObject(repJson);

                String json = JsonConvert.SerializeObject(replacement);

                String response = await _clientHttpREST.PostObjetcAsync("api-products/products/" + productId.ToString() + "/Replacements", json);

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

        #endregion

        #region  GET: Product/Delete/Replacements -------------BORRAR
        public async Task<IActionResult> DeleteReplacements(int id, int productId)
        {
            try
            {
                if (id == 0)
                {
                    return new StatusCodeResult((int)HttpStatusCode.BadRequest);
                }

                string tokenValue = await this.GetTokenAccess();

                _clientHttpREST.SetToken(tokenValue);

                String json = await _clientHttpREST.GetObjetcsAllAsync("api-products/Replacements/" + id.ToString());

                ReplacementModel replacement = TypeModel<ReplacementModel>.DeserializeInObject(json);

                if (replacement == null)
                {
                    return NotFound();
                }

                ViewBag.ProductId = productId;

                return View(replacement);
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

        #region  POST: Product/Delete/Replacements
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteReplacements(int id, int productId, ReplacementModel replacement)
        {
            try
            {
                string tokenValue = await this.GetTokenAccess();

                _clientHttpREST.SetToken(tokenValue);

                String response = await _clientHttpREST.DeleteObjetcAsync("api-products/products/" + productId.ToString() + "/Replacements", id.ToString());

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