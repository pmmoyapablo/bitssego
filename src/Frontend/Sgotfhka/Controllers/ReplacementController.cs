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
using Microsoft.AspNetCore.Hosting;





using iTextSharp.text.pdf;
using iTextSharp.text;

namespace Sisgtfhka.Controllers
{   
    
    [Authorize]
    public class ReplacementController : BaseController
    {
        public ReplacementController(UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            RoleManager<IdentityRole> roleManager,
            Services.ClientHttpREST clientHttpREST,
            ILogger<AccountController> logger,
            IOptions<AppSettings> settings)
            : base(userManager, signInManager, clientHttpREST, settings)

        {

        }
              
        #region // GET: Replacement
        public async Task<IActionResult> Index(string sortOrder,
                                                string currentFilter,
                                                string searchString,
                                                string modelFilter,
                                                int? pageNumber)
        {
            try
            {
                string tokenValue = await this.GetTokenAccess();

                _clientHttpREST.SetToken(tokenValue);

                string repJson = await _clientHttpREST.GetObjetcsAllAsync("api-products/Replacements");

                List<ReplacementModel> listReplacements = TypeModel<ReplacementModel>.DeserializeInArray(repJson);

                ViewData["CurrentSort"] = sortOrder;
                ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
                ViewData["DateSortParm"] = sortOrder == "Date" ? "date_desc" : "Date";
                ViewData["jsontest"] = repJson;

                if (searchString != null)
                {
                    pageNumber = 1;
                }
                else
                {
                    searchString = currentFilter;
                }

                ViewData["CurrentFilter"] = searchString;
                ViewData["ModelFilter"] = modelFilter;

            //Select List de Modelos

            String json1 = await _clientHttpREST.GetObjetcsAllAsync("api-products/Models");

            List<ModelModel> Model = TypeModel<ModelModel>.DeserializeInArray(json1);

            List<SelectListItem> lst = new List<SelectListItem>();

            foreach (ModelModel model in Model)
            {
                lst.Add(new SelectListItem() { Text = model.name });
            }

            ViewBag.Opciones = lst;

            if (!String.IsNullOrEmpty(modelFilter) && !String.IsNullOrEmpty(searchString))
            {
                    
                listReplacements = listReplacements.Where(m => m.Model.name.IndexOf(modelFilter, StringComparison.OrdinalIgnoreCase) >= 0 &&
                                                                m.name.IndexOf(searchString, StringComparison.OrdinalIgnoreCase) >= 0).ToList(); 
                   

            }
            if ( String.IsNullOrEmpty(modelFilter) && !String.IsNullOrEmpty(searchString))
            {
                listReplacements = listReplacements.Where(m => m.code.IndexOf(searchString, StringComparison.OrdinalIgnoreCase) >= 0 ||
                                                                m.name.IndexOf(searchString, StringComparison.OrdinalIgnoreCase) >= 0 ||
                                                                m.Model.name.IndexOf(searchString, StringComparison.OrdinalIgnoreCase) >= 0 ||
                                                                m.Model.Mark.name.IndexOf(searchString, StringComparison.OrdinalIgnoreCase) >= 0).ToList();
            }
            if (!String.IsNullOrEmpty(modelFilter) && String.IsNullOrEmpty(searchString))
            {
                searchString = modelFilter;
                listReplacements = listReplacements.Where(m => m.code.IndexOf(searchString, StringComparison.OrdinalIgnoreCase) >= 0 ||
                                                                m.name.IndexOf(searchString, StringComparison.OrdinalIgnoreCase) >= 0 ||
                                                                m.Model.name.IndexOf(searchString, StringComparison.OrdinalIgnoreCase) >= 0 ||
                                                                m.Model.Mark.name.IndexOf(searchString, StringComparison.OrdinalIgnoreCase) >= 0).ToList();
            }

            switch (sortOrder)
                {
                    case "name_desc":
                        listReplacements = listReplacements.OrderByDescending(m => m.name).ToList();
                        break;
                    case "Date":
                        listReplacements = listReplacements.OrderBy(m => m.name).ToList();
                        break;
                    case "date_desc":
                        listReplacements = listReplacements.OrderByDescending(m => m.name).ToList();
                        break;
                    default:
                        listReplacements = listReplacements.OrderBy(m => m.name).ToList();
                        break;
                }

                int pageSize = 8;

                ViewData["RolId"] = RolId.ToString();
                ViewData["LevelAccess"] = LevelAccess.ToString();

                return View(PaginatedList<ReplacementModel>.CreateAsync(listReplacements.AsQueryable(), pageNumber ?? 1, pageSize));
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

        #region// GET: Replacement/Details/5
        public async Task<IActionResult> Details(int id)
        {
            try
            {
                string tokenValue = await this.GetTokenAccess();

                _clientHttpREST.SetToken(tokenValue);

                string repJson = await _clientHttpREST.GetObjetcAsync("api-products/Replacements", id.ToString());

                ReplacementModel Replacement = TypeModel<ReplacementModel>.DeserializeInObject(repJson);

                return View(Replacement);
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

        #region// GET: Replacement/Create
            
        public async Task<IActionResult> Create()
        {
                
            try
            {                    
                //Select List de Modelos
                string tokenValue = await this.GetTokenAccess();

                _clientHttpREST.SetToken(tokenValue);

                String json = await _clientHttpREST.GetObjetcsAllAsync("api-products/Models");
                List<ModelModel> Model = TypeModel<ModelModel>.DeserializeInArray(json);

                List<SelectListItem> lst = new List<SelectListItem>();

                foreach (ModelModel model in Model)
                {
                    lst.Add(new SelectListItem() { Text = model.name, Value = model.id.ToString() });
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

        #region // POST: Replacement/Create
                
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ReplacementModel colletion)
        {
            try
            {
                string tokenValue = await this.GetTokenAccess();

                _clientHttpREST.SetToken(tokenValue);

            String repJson = await _clientHttpREST.GetObjetcsAllAsync("api-products/Replacements");

            List<ReplacementModel> reList = TypeModel<ReplacementModel>.DeserializeInArray(repJson);
                
            //verificar si el codigo de repuesto indicado ya existe                
            var rc = reList.Where(y => y.code.ToUpper().Trim() == colletion.code.ToUpper().Trim()).FirstOrDefault();

            if (rc != null)
            {
                Alert( $"Ya existe un repuesto con el Código: {colletion.code}", NotificationType.info);                    
                return RedirectToAction("Create");
            }
                
            String json = JsonConvert.SerializeObject(colletion);

            String response = await _clientHttpREST.PostObjetcAsync("api-products/Replacements/", json);            
                                

                if (response.Equals("Created"))
                {
                    if (colletion.image != null)
                    {
                        //colocar nombre
                        string imageName = Path.GetFileName(colletion.image.FileName);                

                        //capturar ruta de guardado
                        string savePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/repuestos", imageName);

                        //guardar
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

        #region // GET: Replacement/Edit/5
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

                String json = await _clientHttpREST.GetObjetcAsync("api-products/Replacements", id.ToString());
                ReplacementModel replacement = TypeModel<ReplacementModel>.DeserializeInObject(json);

                if (replacement == null)
                {
                    return NotFound();
                }

                //Select List de Modelos              
                String json2 = await _clientHttpREST.GetObjetcsAllAsync("api-products/Models");
                List<ModelModel> models = TypeModel<ModelModel>.DeserializeInArray(json2);

                List<SelectListItem> lst = new List<SelectListItem>();

                foreach (ModelModel model in models)
                {
                    lst.Add(new SelectListItem() { Text = model.name, Value = model.id.ToString() });
                }

                ViewBag.Opciones = lst;

            //Select List de Prefijos
            String json3 = await _clientHttpREST.GetObjetcsAllAsync("api-products/Prefixes");
            List<PrefixModel> Prefixes = TypeModel<PrefixModel>.DeserializeInArray(json3);
            List<SelectListItem> lst2 = new List<SelectListItem>();

            foreach (PrefixModel prefix in Prefixes)
            {
                lst2.Add(new SelectListItem() { Text = prefix.InitAlphaNum + " (" + prefix.InitCorrelative + ")", Value = prefix.Id.ToString() });
            }
            ViewBag.Opciones2 = lst2;

            return View(replacement);
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;

                return View("~/Views/Shared/Error.cshtml", new ErrorViewModel { RequestId = Request.Path });
            }
        }
        #endregion

        #region // POST: Replacement/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ReplacementModel pModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    string tokenValue = await this.GetTokenAccess();

                    _clientHttpREST.SetToken(tokenValue);

                    String repJson = await _clientHttpREST.GetObjetcsAllAsync("api-products/Replacements");

                    List<ReplacementModel> reList = TypeModel<ReplacementModel>.DeserializeInArray(repJson);

                    //verificar si el codigo de repuesto en edicion existe en otro registo               
                    var rc = reList.Where(y => y.code.ToUpper().Trim() == pModel.code.ToUpper().Trim() && y.id != pModel.id).FirstOrDefault();

                    if (rc != null)
                    {
                        Alert($"Ya existe un repuesto con el Código: {pModel.code}", NotificationType.info);
                        return RedirectToAction("Edit");
                    }

                    String json = JsonConvert.SerializeObject(pModel);

                String response = await _clientHttpREST.PutObjetcAsync("api-products/Replacements", pModel.id.ToString(), json);


                if (response.Equals("OK") || response.Equals("NoContent"))
                    {
                    if (pModel.image != null)
                    {
                        //colocar nombre
                        string imageName = Path.GetFileName(pModel.image.FileName);

                        //capturar ruta de guardado
                        string savePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/repuestos", imageName);

                        //guardar
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

        #region // GET: Replacement/Delete/5
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

                String json = await _clientHttpREST.GetObjetcAsync("api-products/Replacements", id.ToString());

                ReplacementModel replacement = TypeModel<ReplacementModel>.DeserializeInObject(json);

                if (replacement == null)
                {
                    return NotFound();
                }

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

        #region // POST: Replacement/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, ReplacementModel collection)
        {
            try
            {
                string tokenValue = await this.GetTokenAccess();

                _clientHttpREST.SetToken(tokenValue);

                String response = await _clientHttpREST.DeleteObjetcAsync("api-products/Replacements", id.ToString());

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

        #region //AJAX Validations
        public async Task<IActionResult> AjaxValidation(ReplacementModel Obj)
        {
            try
            {
                string tokenValue = await this.GetTokenAccess();

                _clientHttpREST.SetToken(tokenValue);

                String repJson = await _clientHttpREST.GetObjetcsAllAsync("api-products/Replacements");

                List<ReplacementModel> reList = TypeModel<ReplacementModel>.DeserializeInArray(repJson);

                //verificar si el codigo de repuesto indicado ya existe                
                var rc = reList.Where(y => y.code.ToUpper().Trim() == Obj.code.ToUpper().Trim()).FirstOrDefault();
                
                if (rc == null)
                {
                    
                    return Json(true);

                }else{
                    
                    return Json(false);
                }
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;

                return ViewBag;
            }

        }
        #endregion

        #region Create PDF

        public async Task<IActionResult> GetPdf(string searchString,
                                                string modelFilter)
        {
            string tokenValue = await this.GetTokenAccess();
            _clientHttpREST.SetToken(tokenValue);
            string repJson = await _clientHttpREST.GetObjetcsAllAsync("api-products/Replacements");
            List<ReplacementModel> listReplacements = TypeModel<ReplacementModel>.DeserializeInArray(repJson);

        if (!String.IsNullOrEmpty(modelFilter) && !String.IsNullOrEmpty(searchString))
        {

          listReplacements = listReplacements.Where(m => m.Model.name.IndexOf(modelFilter, StringComparison.OrdinalIgnoreCase) >= 0 &&
                                                          m.name.IndexOf(searchString, StringComparison.OrdinalIgnoreCase) >= 0).ToList();


        }
        if (String.IsNullOrEmpty(modelFilter) && !String.IsNullOrEmpty(searchString))
        {
          listReplacements = listReplacements.Where(m => m.code.IndexOf(searchString, StringComparison.OrdinalIgnoreCase) >= 0 ||
                                                          m.name.IndexOf(searchString, StringComparison.OrdinalIgnoreCase) >= 0 ||
                                                          m.Model.name.IndexOf(searchString, StringComparison.OrdinalIgnoreCase) >= 0 ||
                                                          m.Model.Mark.name.IndexOf(searchString, StringComparison.OrdinalIgnoreCase) >= 0).ToList();
        }
        if (!String.IsNullOrEmpty(modelFilter) && String.IsNullOrEmpty(searchString))
        {
          searchString = modelFilter;
          listReplacements = listReplacements.Where(m => m.code.IndexOf(searchString, StringComparison.OrdinalIgnoreCase) >= 0 ||
                                                          m.name.IndexOf(searchString, StringComparison.OrdinalIgnoreCase) >= 0 ||
                                                          m.Model.name.IndexOf(searchString, StringComparison.OrdinalIgnoreCase) >= 0 ||
                                                          m.Model.Mark.name.IndexOf(searchString, StringComparison.OrdinalIgnoreCase) >= 0).ToList();
        }

      MemoryStream memoryStream = new MemoryStream();
            Document  document = new Document();
            PdfWriter replacementPDF = PdfWriter.GetInstance(document, memoryStream);

            document.AddTitle("Repuestos");
            document.Open();

            string filePath = @"wwwroot\images\logos\LogoTFHKA.jpg";
            var path = Path.GetDirectoryName(filePath);
            string imagePath = path + "\\LogoTFHKA.jpg";
            iTextSharp.text.Image img = iTextSharp.text.Image.GetInstance(imagePath);
            img.ScaleToFit(100f, 45f);
            Paragraph p = new Paragraph();
            p.Add(new Chunk(img, 0, -20));
            p.Add(new Phrase("                                    Reporte de Repuestos"));
            document.Add(p);
            document.Add(Chunk.NEWLINE);
            document.Add(Chunk.NEWLINE);

            iTextSharp.text.Font _standardFont = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 9, iTextSharp.text.Font.BOLD, BaseColor.BLACK);

            PdfPTable replacementTable = new PdfPTable(4);
            replacementTable.WidthPercentage = 100;
            document.Add(Chunk.NEWLINE);

            PdfPCell cl1 = new PdfPCell(new Phrase("Código", _standardFont));
            cl1.BorderWidth = 0;
            cl1.BorderWidthBottom = 0.75f;

            PdfPCell cl2 = new PdfPCell(new Phrase("Nombre", _standardFont));
            cl2.BorderWidth = 0;
            cl2.BorderWidthBottom = 0.75f;

            PdfPCell cl3 = new PdfPCell(new Phrase("Modelo Principal Relativo", _standardFont));
            cl3.BorderWidth = 0;
            cl3.BorderWidthBottom = 0.75f;

            PdfPCell cl4 = new PdfPCell(new Phrase("Marca Relacionada", _standardFont));
            cl4.BorderWidth = 0;
            cl4.BorderWidthBottom = 0.75f;

            replacementTable.AddCell(cl1);
            replacementTable.AddCell(cl2);
            replacementTable.AddCell(cl3);
            replacementTable.AddCell(cl4);

            iTextSharp.text.Font _standardFont2 = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 8, iTextSharp.text.Font.NORMAL, BaseColor.BLACK);

            foreach (ReplacementModel replacement in listReplacements)
            {
                cl1 = new PdfPCell(new Phrase(replacement.code, _standardFont2));
                cl1.BorderWidth = 1;

                cl2 = new PdfPCell(new Phrase(replacement.name, _standardFont2));
                cl2.BorderWidth = 1;

                cl3 = new PdfPCell(new Phrase(replacement.Model.name, _standardFont2));
                cl3.BorderWidth = 1;

                cl4 = new PdfPCell(new Phrase(replacement.Model.Mark.name, _standardFont2));
                cl4.BorderWidth = 1;

                replacementTable.AddCell(cl1);
                replacementTable.AddCell(cl2);
                replacementTable.AddCell(cl3);
                replacementTable.AddCell(cl4);
            }

            document.Add(replacementTable);
            document.Close();

            byte[] content = memoryStream.ToArray();

            return File(content, "application/pdf", "Repuestos.pdf");
        }

        #endregion

    }
        
}
