using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Api_Utilities.Models;
using Microsoft.AspNetCore.Authorization;

namespace Api_Utilities.Controllers
{
    [Authorize("Bearer")]
    [Route("api/[controller]")]
    [ApiController]
  public class CasesProductsController : ControllerBase
  {
        private readonly UtilitiesContext _context;

        public CasesProductsController(UtilitiesContext context)
        {
            _context = context;
        }
        // GET: api/CasesProducts
        /// <summary>
        /// Retorna todos los Casos Productos
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<CasesProducts> GetSisg_CasesProducts()
        {
            return _context.Sisg_CasesProducts.Include(c => c.product.Model).ToList();
        }

        // GET: api/CasesProducts/5
        /// <summary>
        /// Retorna un Casos Productos en especifico
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCasesProduct([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var CasesProduct = await _context.Sisg_CasesProducts.Where(x => x.id == id).Include(c => c.product.Model).FirstOrDefaultAsync();

            if (CasesProduct == null)
            {
                return NotFound();
            }

            return Ok(CasesProduct);
        }
        // GET: api/CasesProducts/ByCase/5
        /// <summary>
        /// Retorna los Casos Productos de un caso especifico
        /// </summary>
        /// <param name="caseId">Caso Id</param>
        /// <returns></returns>
        [HttpGet("ByCase/{caseId}")]
        public IEnumerable<CasesProducts> GetCasesProductByCase([FromRoute] int caseId)
        {
          
           var CasesProducts =  _context.Sisg_CasesProducts.Where(x => x.caseSoftwareHouseId == caseId).Include(c => c.product.Model).ToList();

           return CasesProducts;
        }

        // PUT: api/CasesProducts/5
        /// <summary>
        /// Crea o Actualiza un Casos Productos en especifico
        /// </summary>
        /// <param name="id"></param>
        /// <param name="CasesProduct"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCasesProduct([FromRoute] int id, [FromBody] CasesProducts CasesProduct)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != CasesProduct.id)
            {
                return BadRequest();
            }

            _context.Entry(CasesProduct).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CasesProductExists(id))
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

        // POST: api/CasesProducts
        /// <summary>
        /// Envia un Casos Productos
        /// </summary>
        /// <param name="CasesProduct"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> PostCasesProduct([FromBody] CasesProducts CasesProduct)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Sisg_CasesProducts.Add(CasesProduct);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCasesProduct", new { id = CasesProduct.id }, CasesProduct);
        }

        // DELETE: api/CasesProducts/5
        /// <summary>
        /// Elimina un Casos Productos en especifico
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCasesProduct([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var CasesProduct = await _context.Sisg_CasesProducts.FindAsync(id);
            if (CasesProduct == null)
            {
                return NotFound();
            }

            _context.Sisg_CasesProducts.Remove(CasesProduct);
            await _context.SaveChangesAsync();

            return Ok(CasesProduct);
        }

        private bool CasesProductExists(int id)
        {
            return _context.Sisg_CasesProducts.Any(e => e.id == id);
        }
    }
}