using System;
using System.Net;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Web.Http;
using System.Runtime.Serialization;
using Microsoft.AspNetCore.Authorization;
using Api_Operations.Models;
using Api_Clients.Models;
using Api_Products.Models;


namespace Api_Operations.Controllers
{
    [Authorize("Bearer")]
    [Route("api/[controller]")]
    [ApiController]
    public class SerialsProductsController : ControllerBase
    {

        private readonly OperationsContext _context;

        public SerialsProductsController(OperationsContext context)
        {
            _context = context;
        }

        #region GET api/SerialsProducts
        [HttpGet]
        public IEnumerable<SerialProduct> GetSisg_Serials()
        {

            try
            {
                foreach (SerialProduct sp in _context.Sisg_SerialsProducts.ToList())
                {
                    sp.product = _context.Sisg_Products.Where(p => p.Id == sp.ProductId).FirstOrDefault();

                    if (sp.product != null)
                    {
                        sp.product.Category = _context.Sisg_Categories.Where(c => sp.product.CategoryId == c.Id).FirstOrDefault();
                        sp.product.Model = _context.Sisg_Models.Where(m => sp.product.ModelId == m.Id).FirstOrDefault();

                        if (sp.product.Model != null)
                        {
                            sp.product.Model.Mark = _context.Sisg_Marks.Where(mk => sp.product.Model.MarkId == mk.Id).FirstOrDefault();
                        }
                        sp.product.Prefix = _context.Sisg_Prefixes.Where(px => sp.product.PrefixId == px.id).FirstOrDefault();
                    }

                    sp.provider = _context.Sisg_Providers.Where(pro => pro.id == sp.ProviderId).FirstOrDefault();
                    sp.distributor = _context.Sisg_Distributors.Where(d => d.id == sp.DistributorId).FirstOrDefault();
                }

                return _context.Sisg_SerialsProducts;
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(ex.Message);
            }
        }
        #endregion

        #region GET api/SerialsProducts/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSerialsProducts([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var serialfp = await _context.Sisg_SerialsProducts.FindAsync(id);

            if (serialfp == null)
            {
                return NotFound();
            }
            else
            {
                serialfp.product = _context.Sisg_Products.Where(p => p.Id == serialfp.ProductId).FirstOrDefault();

                if (serialfp.product != null)
                {
                    serialfp.product.Category = _context.Sisg_Categories.Where(c => serialfp.product.CategoryId == c.Id).FirstOrDefault();
                    serialfp.product.Model = _context.Sisg_Models.Where(m => serialfp.product.ModelId == m.Id).FirstOrDefault();

                    if (serialfp.product.Model != null)
                    {
                        serialfp.product.Model.Mark = _context.Sisg_Marks.Where(mk => serialfp.product.Model.MarkId == mk.Id).FirstOrDefault();
                    }
                    serialfp.product.Prefix = _context.Sisg_Prefixes.Where(px => serialfp.product.PrefixId == px.id).FirstOrDefault();
                }
                serialfp.provider = _context.Sisg_Providers.Where(pro => pro.id == serialfp.ProviderId).FirstOrDefault();
                serialfp.distributor = _context.Sisg_Distributors.Where(d => d.id == serialfp.DistributorId).FirstOrDefault();

                if (serialfp == null)
                {
                    return NotFound();
                }

                return Ok(serialfp);
            }

        }

        #endregion

        #region GET api/SerialsProducts/BySerial/Z1B1234567
        [HttpGet("BySerial/{serial}")]
        public async Task<IActionResult> GetSerialsProducts([FromRoute] string serial)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var serialfp = await _context.Sisg_SerialsProducts.Where(s => s.Serial == serial).FirstOrDefaultAsync();

                if (serialfp == null)
                {
                    return Ok(null);
                }
                else
                {
                    serialfp.product = _context.Sisg_Products.Where(p => p.Id == serialfp.ProductId).FirstOrDefault();

                    if (serialfp.product != null)
                    {
                        serialfp.product.Category = _context.Sisg_Categories.Where(c => serialfp.product.CategoryId == c.Id).FirstOrDefault();
                        serialfp.product.Model = _context.Sisg_Models.Where(m => serialfp.product.ModelId == m.Id).FirstOrDefault();

                        if (serialfp.product.Model != null)
                        {
                            serialfp.product.Model.Mark = _context.Sisg_Marks.Where(mk => serialfp.product.Model.MarkId == mk.Id).FirstOrDefault();
                        }
                        serialfp.product.Prefix = _context.Sisg_Prefixes.Where(px => serialfp.product.PrefixId == px.id).FirstOrDefault();
                    }
                    serialfp.provider = _context.Sisg_Providers.Where(pro => pro.id == serialfp.ProviderId).FirstOrDefault();
                    serialfp.distributor = _context.Sisg_Distributors.Where(d => d.id == serialfp.DistributorId).FirstOrDefault();

                    return Ok(serialfp);
                }

            }catch(Exception ex)
            {
                //return StatusCode(500,ex.Message);
                throw new HttpResponseException(ex.Message);
            }

        }

        #endregion

        #region PUT api/SerialsProducts
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSisg_Serials([FromRoute] int id, [FromBody] SerialProduct serial)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != serial.Id)
            {
                return BadRequest();
            }

            //serial.Creation_Date = DateTime.Now;
            _context.Entry(serial).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SerialExists(id))
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

        #region POST  api/SerialsProducts

        [HttpPost]
        public async Task<IActionResult> PostSisg_Serials([FromBody] SerialProduct serial)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                //serial.DateSale = DateTime.Now;
                serial.Creation_Date = DateTime.Now;
                _context.Sisg_SerialsProducts.Add(serial);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetSisg_Serials", new { id = serial.Id }, serial);
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(ex.Message);
            }

 
        }

        #endregion

        #region DELETE api/SerialsProducts
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSisg_Serials([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var product = await _context.Sisg_SerialsProducts.FindAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            _context.Sisg_SerialsProducts.Remove(product);
            await _context.SaveChangesAsync();

            return Ok(product);
        }

        #endregion

        #region Serial Exists
        private bool SerialExists(int id)
        {
            return _context.Sisg_SerialsProducts.Any(e => e.Id == id);
        }
        #endregion

        #region Clases Requeridas
        [Serializable]
        internal class HttpResponseException : Exception
        {
            public HttpResponseException()
            {
            }

            public HttpResponseException(string message) : base(message)
            {
            }

            public HttpResponseException(string message, Exception innerException) : base(message, innerException)
            {
            }

            protected HttpResponseException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }
        }

        #endregion
    }
}