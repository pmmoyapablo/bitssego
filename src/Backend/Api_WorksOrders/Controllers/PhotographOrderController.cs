using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Api_WorksOrders.Models;
using Microsoft.AspNetCore.Authorization;

namespace Api_WorksOrders.Controllers
{
    [Authorize("Bearer")]
    [Route("api/[controller]")]
    [ApiController]
    public class PhotographOrderController : ControllerBase
    {
        private readonly WorksOrdersContext _context;

        public PhotographOrderController(WorksOrdersContext context)
        {
            _context = context;
        }

        #region // GET: api/PhotographOrder
        /// <summary>
        /// Retorna todas las URL de fotografías de las ordenes
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<PhotographOrder> GetSisg_PhotographOrders()
        {
            return _context.Sisg_PhotographsOrder.ToList();
        }
        #endregion

        #region // GET: api/PhotographOrder/5
        /// <summary>
        /// Retorna la URL de una fotografía por ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult>GetSisg_PhotographOrder([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            var photographorderlist = await _context.Sisg_PhotographsOrder.FindAsync(id);
            if(photographorderlist == null)
            {
                return NotFound();
            }
            return Ok(photographorderlist);
        }
        #endregion

        #region // GET: api/PhotographOrder/ByOrderId/5
        /// <summary>
        /// Retorna un listado URL's de fotografías de una orden
        /// </summary>
        /// <param name="orderId">Orden ID</param>
        /// <returns></returns>
        [HttpGet("ByOrderId/{orderId}")]
        public async Task<IActionResult> GetSisg_PhotographOrderList([FromRoute] int orderId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var photograporderlist = await _context.Sisg_PhotographsOrder.Where(x => x.OrderId == orderId).ToListAsync();

            return Ok(photograporderlist);
        }
        #endregion

        #region // POST: api/PhotographOrder
        /// <summary>
        /// Crea la URL de una fotografía de una orden
        /// </summary>
        /// <param name="photographorder">JSON</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult>PostSisg_PhotographOrder([FromBody] PhotographOrder photographorder)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                photographorder.creation_date = DateTime.Now;
                _context.Sisg_PhotographsOrder.Add(photographorder);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetSisg_PhotographOrder", new {id = photographorder.Id },photographorder);
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(ex.Message);
            }
            
        }
        #endregion

        #region // PUT: api/PhotographOrder/5
        /// <summary>
        /// Actualiza la URL de una fotografía de una orden
        /// </summary>
        /// <param name="id"></param>
        /// <param name="photographorder">JSON</param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult>PutSisg_PhotographOrder([FromRoute]int id, [FromBody] PhotographOrder photographorder)
        {
            if (!ModelState.IsValid)
            {
                BadRequest(ModelState);
            }
            if(id != photographorder.Id)
            {
                BadRequest();
            }
            _context.Entry(photographorder).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException) when (!PhotographOrderExist(id))
            {
                NotFound();
            }

            return NoContent();
            
        }

        private bool PhotographOrderExist(long id) =>
            _context.Sisg_PhotographsOrder.Any(e => e.Id == id);
        #endregion

        #region // DELETE: api/PhotographOrder/5
        /// <summary>
        /// Elimina la URL de una fotografía de una orden
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult>DeleteSisg_PhotographOrder([FromRoute]int id)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    BadRequest(ModelState);
                }
                var photographorder = await _context.Sisg_PhotographsOrder.FindAsync(id);
                if(photographorder==null)
                {
                   return NotFound();
                }
                _context.Sisg_PhotographsOrder.Remove(photographorder);
                await _context.SaveChangesAsync();

                return Ok(photographorder);
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(ex.Message);
            }
        }
        #endregion
    }
}
