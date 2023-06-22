using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Api_Products.Models;
using Microsoft.AspNetCore.Authorization;
using System.Runtime.Serialization;

namespace Api_Products.Controllers
{
    [Authorize("Bearer")]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ProductsContext _context;

        public ProductsController(ProductsContext context)
        {
            _context = context;
        }

        #region GET: api/Products
        [HttpGet]
        public IEnumerable<Product> GetSisg_Products()
        {
            try
            {
                foreach (Product prod in _context.Sisg_Products.ToList())
                {
                    prod.Category = _context.Sisg_Categories.Where(cat => cat.Id == prod.CategoryId).FirstOrDefault();

                    prod.Model = _context.Sisg_Models.Where(mod => mod.Id == prod.ModelId).FirstOrDefault();

                    prod.Prefix = _context.Sisg_Prefixes.Where(pre => pre.id == prod.PrefixId).FirstOrDefault();

                    if (prod.Model != null)
                    {
                        prod.Model.Mark = _context.Sisg_Marks.Where(m => m.Id == prod.Model.MarkId).FirstOrDefault();
                    }
                }

                return _context.Sisg_Products;
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(ex.Message);
            }
        }
        #endregion

        #region GET: api/Products/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProducts([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var products = await _context.Sisg_Products.FindAsync(id);

            if (products == null)
            {
                return NotFound();
            }
            else
            {
                products.Category = _context.Sisg_Categories.Where(cat => cat.Id == products.CategoryId).FirstOrDefault();

                products.Model = _context.Sisg_Models.Where(mod => mod.Id == products.ModelId).FirstOrDefault();

                products.Prefix = _context.Sisg_Prefixes.Where(pre => pre.id == products.PrefixId).FirstOrDefault();

                if (products.Model != null)
                {
                    products.Model.Mark = _context.Sisg_Marks.Where(m => m.Id == products.Model.MarkId).FirstOrDefault();
                }
            }

            return Ok(products);
        }
        #endregion

        #region GET: api/ProductsByCategory/{CategoryId}/Products
        [HttpGet("ProductsByCategory/{CategoryId}/Products")]
        public IEnumerable<Product> GetProductsCategory([FromRoute] int CategoryId)
        {
            try
            {
                var listProductsCategory = _context.Sisg_Products.Where(a => a.CategoryId == CategoryId).ToList();
                foreach (Product prod in listProductsCategory)
                {
                    prod.Category = _context.Sisg_Categories.Where(cat => cat.Id == prod.CategoryId).FirstOrDefault();

                    prod.Model = _context.Sisg_Models.Where(mod => mod.Id == prod.ModelId).FirstOrDefault();

                    if (prod.Model != null)
                    {
                        prod.Model.Mark = _context.Sisg_Marks.Where(m => m.Id == prod.Model.MarkId).FirstOrDefault();
                    }

                    prod.Prefix = _context.Sisg_Prefixes.Where(pre => pre.id == prod.PrefixId).FirstOrDefault();
                }
                return listProductsCategory;
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(ex.Message);
            }
        }
        #endregion

        #region GET: api/ProductsByModel/{ModelId}/Products
        [HttpGet("ProductsByModel/{ModelId}/Products")]
        public IEnumerable<Product> GetProductsModel([FromRoute] int ModelId)
        {
            try
            {
                var listProductsModel = _context.Sisg_Products.Where(a => a.ModelId == ModelId).ToList();
                foreach (Product prod in listProductsModel)
                {
					prod.Category = _context.Sisg_Categories.Where(cat => cat.Id == prod.CategoryId).FirstOrDefault();
                    prod.Model = _context.Sisg_Models.Where(mod => mod.Id == prod.ModelId).FirstOrDefault();

                    if (prod.Model != null)
                    {
                        prod.Model.Mark = _context.Sisg_Marks.Where(m => m.Id == prod.Model.MarkId).FirstOrDefault();
                    }

                    prod.Prefix = _context.Sisg_Prefixes.Where(pre => pre.id == prod.PrefixId).FirstOrDefault();
                }
                return listProductsModel;
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(ex.Message);
            }
        }
        #endregion

        #region GET: api/ProductsByMark/{MarkId}/Products
        [HttpGet("ProductsByMark/{MarkId}/Products")]
        public IEnumerable<Product> GetProductsMark([FromRoute] int MarkId)
        {
            try
            {
                var listProductsMark = _context.Sisg_Products.Where(a => a.Model.MarkId == MarkId).ToList();
                foreach (Product prod in listProductsMark)
                {
					prod.Category = _context.Sisg_Categories.Where(cat => cat.Id == prod.CategoryId).FirstOrDefault();
                    prod.Model = _context.Sisg_Models.Where(m => m.Id == prod.ModelId).FirstOrDefault();

                    if (prod.Model != null)
                    {
                        prod.Model.Mark = _context.Sisg_Marks.Where(m => m.Id == prod.Model.MarkId).FirstOrDefault();
                    }

                    prod.Prefix = _context.Sisg_Prefixes.Where(pre => pre.id == prod.PrefixId).FirstOrDefault();
                }
                return listProductsMark;
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(ex.Message);
            }
        }
        #endregion

        #region GET: api/ProductsByPrefix/Products/{PrefixId}
        [HttpGet("ProductsByPrefix/Products/{PrefixId}")]
        public  IActionResult GetProductsByPrefix([FromRoute] int PrefixId)
        {
            try
            {
                var prod = _context.Sisg_Products.Where(p => p.PrefixId == PrefixId).FirstOrDefault();

                if (prod != null)
                {
                    prod.Category = _context.Sisg_Categories.Where(cat => cat.Id == prod.CategoryId).FirstOrDefault();

                    prod.Model = _context.Sisg_Models.Where(mod => mod.Id == prod.ModelId).FirstOrDefault();

                    if (prod.Model != null)
                    {
                        prod.Model.Mark = _context.Sisg_Marks.Where(m => m.Id == prod.Model.MarkId).FirstOrDefault();
                    }

                    prod.Prefix = _context.Sisg_Prefixes.Where(pre => pre.id == prod.PrefixId).FirstOrDefault();
                }

                return Ok(prod);
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(ex.Message);
            }
        }
        #endregion

        #region GET: api/Products/{id}/Accesories
        [HttpGet("{ProductId}/Accesories")]
        public IEnumerable<Accessory> GetProductsAccessories([FromRoute] int ProductId)
        {
            try
            {
                var listProductsAccessory = _context.Sisg_ProductsAccessories.Where(a => a.ProductId == ProductId).ToList();
                var listAccessory = new List<Accessory>();

                foreach (ProductsAccessories pa in listProductsAccessory)
                {
                    var accesory = _context.Sisg_Accessories.Where(a => a.Id == pa.AccessoryId).FirstOrDefault();
                   
                    if(accesory != null)
                    { listAccessory.Add(accesory); }
                }

                return listAccessory;
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(ex.Message);
            }
        }
        #endregion

        #region GET: api/Products/{id}/Replacements
        [HttpGet("{ProductId}/Replacements")]
        public IEnumerable<Replacement> GetProductsReplacements([FromRoute] int ProductId)
        {
            try
            {
                var listProductsReplacement = _context.Sisg_ProductsReplacements.Where(r => r.ProductId == ProductId).ToList();
                var listReplacement = new List<Replacement>();

                foreach (ProductsReplacement pr in listProductsReplacement)
                {
                    var replacement = _context.Sisg_Replacements.Where(r => r.Id == pr.ReplacementId).FirstOrDefault();

                    if (replacement != null)
                    {
                        replacement.Model = _context.Sisg_Models.Where(md => md.Id == replacement.ModelId).FirstOrDefault();

                        if (replacement.Model != null)
                        {
                            replacement.Model.Mark = _context.Sisg_Marks.Where(m => m.Id == replacement.Model.MarkId).FirstOrDefault();
                        }

                        listReplacement.Add(replacement);
                    }
                }

                return listReplacement;
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(ex.Message);
            }
        }
        #endregion

        #region PUT: api/Products/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProducts([FromRoute] int id, [FromBody] Product products)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != products.Id)
            {
                return BadRequest();
            }

            products.creation_date = DateTime.Now;
            _context.Entry(products).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductsExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }
        #endregion

        #region POST: api/Products
        [HttpPost]
        public async Task<IActionResult> PostProducts([FromBody] Product products)
        {
            try
            { 
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                products.creation_date = DateTime.Now;
                _context.Sisg_Products.Add(products);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetProducts", new { id = products.Id }, products);
            }
                catch (Exception ex)
                {
                    throw new HttpResponseException(ex.Message);
                }
        }
        #endregion

        #region POST: api/Products/{ProductId}/Accesories
        [HttpPost("{ProductId}/Accesories")]
        public async Task<IActionResult> PostProductAccesories([FromRoute] int ProductId, [FromBody] Accessory pAccessory)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                if(pAccessory == null)
                {
                    return NotFound("Argumento nulo");
                }               

                ProductsAccessories pa = new ProductsAccessories();
                pa.AccessoryId = pAccessory.Id;
                pa.ProductId = ProductId;

                _context.Sisg_ProductsAccessories.Add(pa);

                await _context.SaveChangesAsync();

                return Ok(pa);
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(ex.Message);
            }
        }

        #endregion

        #region POST: api/Products/{ProductId}/Replacements
        [HttpPost("{ProductId}/Replacements")]
        public async Task<IActionResult> PostProductReplacements([FromRoute] int ProductId, [FromBody] Replacement pReplacement)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                if (pReplacement == null)
                {
                    return NotFound("Argumento nulo");
                }

                var product = _context.Sisg_Products.Where(p => p.Id == ProductId).FirstOrDefault();

                if (product == null)
                {
                    return NotFound("Producto no existe");
                }
                else
                {
                    if (pReplacement.ModelId == product.ModelId || pReplacement.ModelId == 0)
                    {
                        ProductsReplacement pr = new ProductsReplacement();
                        pr.ProductId = ProductId;
                        pr.ReplacementId = pReplacement.Id;

                        _context.Sisg_ProductsReplacements.Add(pr);

                        await _context.SaveChangesAsync();

                        return Ok(pr);
                    }
                    else
                    {
                        return NotFound("Los Modelos no coiciden");
                    }
                }
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(ex.Message);
            }
        }

        #endregion

        #region DELETE: api/Products/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProducts([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var products = await _context.Sisg_Products.FindAsync(id);
            if (products == null)
            {
                return NotFound();
            }

            _context.Sisg_Products.Remove(products);
            await _context.SaveChangesAsync();

            return Ok(products);
        }
        #endregion

        #region DELETE: api/Products/{ProductId}/Accesories/{AccesoryId} 
        //Elimina un Accesorio asociado a un Producto
        [HttpDelete("{ProductId}/Accesories/{AccesoryId}")]
        public async Task<IActionResult> DeleteProductAccesorie([FromRoute] int AccesoryId, [FromRoute] int ProductId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var productAccesory =  _context.Sisg_ProductsAccessories.Where(pa => pa.AccessoryId == AccesoryId && pa.ProductId == ProductId).FirstOrDefault();

            if (productAccesory == null)
            {
                return NotFound();
            }

            _context.Sisg_ProductsAccessories.Remove(productAccesory);
            await _context.SaveChangesAsync();

            return Ok(productAccesory);
        }
        #endregion

        #region DELETE: api/Products/{ProductId}/Replacements/{ReplacementId}
        //Elimina un Repuesto asociado a un Producto
        [HttpDelete("{ProductId}/Replacements/{ReplacementId}")]
        public async Task<IActionResult> DeleteProductReplacement([FromRoute] int ReplacementId, [FromRoute] int ProductId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var productReplacement = _context.Sisg_ProductsReplacements.Where(pr => pr.ReplacementId == ReplacementId && pr.ProductId == ProductId).FirstOrDefault();

            if (productReplacement == null)
            {
                return NotFound();
            }

            _context.Sisg_ProductsReplacements.Remove(productReplacement);
            await _context.SaveChangesAsync();

            return Ok(productReplacement);
        }
        #endregion

        private bool ProductsExists(int id)
        {
            return _context.Sisg_Products.Any(e => e.Id == id);
        }
    }
} 