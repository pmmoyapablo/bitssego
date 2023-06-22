using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Api_WorksOrders.Models;
using Microsoft.AspNetCore.Authorization;

namespace Api_WorksOrders.Controllers
{
    [Authorize("Bearer")]
    [Route("api/[controller]")]
    [ApiController]
    public class ReplacementOrderController : ControllerBase
    {
        private readonly WorksOrdersContext _context;

        public ReplacementOrderController(WorksOrdersContext context)
        {
            _context = context;
        }

        #region // GET: api/ReplacementOrder
        /// <summary>
        /// Retorna todos los repuestos de todas las ordenes
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<ReplacementOrder> GetSisg_ReplacementOrders()
        {
            return _context.Sisg_ReplacementsOrders.Include(r => r.Replacement).ToList();
        }
        #endregion

        #region // GET: api/ReplacementOrder/5
        /// <summary>
        /// Retorna un repuesto de una orden por ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSisg_ReplacementOrder([FromRoute]int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var replacementOrder = await _context.Sisg_ReplacementsOrders.Where(x => x.Id == id)
                .Include(r => r.Replacement).FirstOrDefaultAsync();

            if (replacementOrder == null)
            {
                return NotFound();
            }
            return Ok(replacementOrder);
        }
        #endregion

        #region // GET: api/ReplacementOrder/byOrderId/5
        /// <summary>
        /// Retorna todos los repuestos de una orden por el #Orden
        /// </summary>
        /// <param name="orderId">#Orden</param>
        /// <returns></returns>
        [HttpGet("byOrderId/{orderId}")]
        public async Task<IActionResult> GetSisg_ReplacementOrderList([FromRoute]int orderId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }                       

            var replacementorderlist = await _context.Sisg_ReplacementsOrders.Where(x => x.OrderId == orderId)
                .Include(a => a.Replacement).ToListAsync();           

            return Ok(replacementorderlist);
            
        }
        #endregion

        #region // POST: api/ReplacementOrder
        /// <summary>
        /// Crea un repuesto de una orden
        /// </summary>
        /// <param name="replacementOrder">JSON</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> PostSisg_ReplacementOrder([FromBody] ReplacementOrder replacementOrder)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                replacementOrder.Replacement = await _context.Sisg_Replacements.FindAsync(replacementOrder.ReplacementId);
                _context.Sisg_ReplacementsOrders.Add(replacementOrder);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetSisg_ReplacementOrder", new { id = replacementOrder.Id }, replacementOrder);
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(ex.Message);
            }
        }
        #endregion

        #region // PUT: api/ReplacementOrder/5
        /// <summary>
        /// Actualiza un repuesto de una orden por ID
        /// </summary>
        /// <param name="id"></param>
        /// <param name="replacementOrder">JSON</param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutReplacementOrder([FromRoute]int id, [FromBody] ReplacementOrder replacementOrder)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (id != replacementOrder.Id)
            {
                return BadRequest();
            }
            _context.Entry(replacementOrder).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException) when (!ReplacementOrderExist(id))
            {
                return NotFound();
            }
            return NoContent();
        }

        private bool ReplacementOrderExist(long id) =>
            _context.Sisg_StatesOrder.Any(e => e.Id == id);
        #endregion

        #region // DELETE: api/ReplacementOrder/5
        /// <summary>
        /// Elimina un repusto de una orden por ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSisg_ReplacementOrder([FromRoute]int id)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var replacementOrder = await _context.Sisg_ReplacementsOrders.Where(x => x.Id == id)
                    .Include(r => r.Replacement).FirstOrDefaultAsync();

                if (replacementOrder == null)
                {
                    return NotFound();
                }

                _context.Sisg_ReplacementsOrders.Remove(replacementOrder);
                await _context.SaveChangesAsync();

                return Ok(replacementOrder);
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(ex.Message);
            }
        }
        #endregion
    }
}
