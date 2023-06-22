using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api_WorksOrders.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api_WorksOrders.Controllers
{
    [Authorize("Bearer")]
    [Route("api/[controller]")]
    [ApiController]
    public class DeliveryOrderController : ControllerBase
    {
        private readonly WorksOrdersContext _context;

        public DeliveryOrderController(WorksOrdersContext context)
        {
            _context = context;
        }

        #region // GET: api/DeliveryOrder
        /// <summary>
        /// Retorna todos los datos de entrega registrados
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<DeliveryOrder> GetSisg_DeliveryOrders()
        {
            return _context.Sisg_DeliveryOrder.ToList();
        }
        #endregion

        #region // GET: api/DeliveryOrder/5
        /// <summary>
        /// Retorna los datos de entrega de una orden por ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSisg_DeliveryOrder([FromRoute]int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var deliveryorder = await _context.Sisg_DeliveryOrder.FindAsync(id);
            if (deliveryorder == null)
            {
                return NotFound();
            }
            return Ok(deliveryorder);
        }
        #endregion

        #region // POST: api/DeliveryOrder
        /// <summary>
        /// Crea los datos de entrega de una orden
        /// </summary>
        /// <param name="deliveryorder">JSON</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult>PostSisg_DeliveryOrder([FromBody] DeliveryOrder deliveryorder)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                _context.Sisg_DeliveryOrder.Add(deliveryorder);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetSisg_DeliveryOrder", new { id = deliveryorder.Id }, deliveryorder);
            }
            catch (Exception ex)
            {

                throw new HttpResponseException(ex.Message);
            }

        }
        #endregion

        #region // PUT: api/DeliveryOrder/5
        /// <summary>
        /// Actuliza los datos de entrega de una orden por ID
        /// </summary>
        /// <param name="id"></param>
        /// <param name="deliveryorder">JSON</param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult>PutSisg_DeliveryOrder([FromRoute]int id, [FromBody] DeliveryOrder deliveryorder)
        {
            if (ModelState.IsValid)
            {
                BadRequest(ModelState);
            }
            if (id != deliveryorder.Id)
            {
                BadRequest();
            }
            _context.Entry(deliveryorder).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException) when (!DeliveryOrderExist(id))
            {
                return NotFound();
            }
            return NoContent();
        }

        private bool DeliveryOrderExist(long id) =>
            _context.Sisg_DeliveryOrder.Any(e => e.Id == id);
        #endregion

        #region // DELETE: api/DeliveryOrder/5
        /// <summary>
        /// Elimina los datos de entrega de una orden
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult>DeleteSisg_DeliveryOrder([FromRoute]int id)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    BadRequest(ModelState);
                }
                var deliveryorder = await _context.Sisg_DeliveryOrder.FindAsync(id);
                if(deliveryorder==null)
                {
                    return NotFound();
                }
                _context.Sisg_DeliveryOrder.Remove(deliveryorder);
                await _context.SaveChangesAsync();

                return Ok(deliveryorder);
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(ex.Message);
            }
        }
        #endregion
    }
}
