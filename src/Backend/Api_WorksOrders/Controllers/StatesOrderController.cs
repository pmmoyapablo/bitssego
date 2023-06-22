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
    public class StatesOrderController : ControllerBase
    {
        private readonly WorksOrdersContext _context;

        public StatesOrderController(WorksOrdersContext context)
        {
            _context = context;
        }

        #region // GET: api/StatesOrder
        /// <summary>
        /// Retorna todos los Estados de las Ordenes
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<StatesOrder> GetSisg_StatesOrders()
        {
            return _context.Sisg_StatesOrder.ToList();
        }
        #endregion

        #region // GET: api/StatesOrder/5
        /// <summary>
        /// Retorna un Estado de una Orden por Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSisg_StatesOrder([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var statesorder = await _context.Sisg_StatesOrder.FindAsync(id);
            if (statesorder == null)
            {
                return NotFound();
            }

            return Ok(statesorder);
        }
        #endregion

        #region // POST: api/StatesOrder
        /// <summary>
        /// Crea un nuevo Estado de Orden
        /// </summary>
        /// <param name="statesorder">JSON</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> PostStatesOrder([FromBody] StatesOrder statesorder)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                statesorder.creation_date = DateTime.Now;
                _context.Sisg_StatesOrder.Add(statesorder);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetSisg_StatesOrder", new { id = statesorder.Id }, statesorder);
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(ex.Message);
            }                       

        }
        #endregion

        #region // PUT: api/StatesOrder/5
        /// <summary>
        /// Actualiza un Estado de Orden
        /// </summary>
        /// <param name="id"></param>
        /// <param name="statesorder">JSON</param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStatesOrder([FromRoute]int id, [FromBody] StatesOrder statesorder)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if(id != statesorder.Id)
            {
                return BadRequest();
            }

            statesorder.creation_date = DateTime.Now;
            _context.Entry(statesorder).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException) when (!StatesOrderExist(id))
            {
                return NotFound();                
            }
            return NoContent();
        }

        private bool StatesOrderExist(long id) =>
            _context.Sisg_StatesOrder.Any(e => e.Id == id);
        #endregion

        #region // DELETE: api/StatesOrder/5
        /// <summary>
        /// Elimina un Estado de Orden
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStatesOrder([FromRoute]int id)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var statesorder = await _context.Sisg_StatesOrder.FindAsync(id);
                if(statesorder == null)
                {
                    return NotFound();
                }
                _context.Sisg_StatesOrder.Remove(statesorder);
                await _context.SaveChangesAsync();

                return Ok(statesorder);
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(ex.Message);
            }
            
        }
        #endregion
    }
}
