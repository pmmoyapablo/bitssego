using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api_WorksOrders.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Api_Products.Models;

namespace Api_WorksOrders.Controllers
{
    [Authorize("Bearer")]
    [Route("api/[controller]")]
    [ApiController]
    public class AccessoryOrderController : ControllerBase
    {
        private readonly WorksOrdersContext _context;

        public AccessoryOrderController(WorksOrdersContext context)
        {
            _context = context;
        }


        #region // GET: api/AccessoryOrder
        /// <summary>
        /// Retorna todos los accesorios registrados
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<AccessoryOrder> GetSisg_AccessoryOrders()
        {
            return _context.Sisg_AccessoriesOrders.Include(a =>a.Accessory).ToList();
        }
        #endregion

        #region // GET: api/AccessoryOrder/5
        /// <summary>
        /// Retorna un accesorio de una orden por ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSisg_AccessoryOrder([FromRoute]int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var accessoryorder = await _context.Sisg_AccessoriesOrders.Where(x => x.Id == id)
                .Include(a => a.Accessory).FirstOrDefaultAsync();         

            if (accessoryorder== null)
            {
                return NotFound();
            }
            return Ok(accessoryorder);
        }
    #endregion

    #region // GET: api/AccessoryOrder/ByOrderId/2
    /// <summary>
    /// Retorna todos los accesorios de una orden por el OrdenId
    /// </summary>
    /// <param name="orderId">OrdenId</param>
    /// <returns></returns>
    [HttpGet("ByOrderId/{orderId}")]
    public async Task<IActionResult> GetSisg_AccessoryOrderList([FromRoute]int orderId)
    {
      if (!ModelState.IsValid)
      {
        return BadRequest(ModelState);
      }

      var accessoryorderlist = await _context.Sisg_AccessoriesOrders.Where(x => x.OrderId == orderId)
          .Include(a => a.Accessory).ToListAsync();

            if (accessoryorderlist.Count > 0)
            {
              foreach (AccessoryOrder ao in accessoryorderlist)
              {
                ao.Accessory = await _context.Sisg_Accessories.Where(a => a.Id == ao.AccesoryId).FirstOrDefaultAsync();
              }       
            }

            return Ok(accessoryorderlist);
        }
        #endregion

        #region // POST: api/AccessoryOrder
        /// <summary>
        /// Crea un nuevo accesorio en una orden
        /// </summary>
        /// <param name="accessoryOrder">JSON</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult>PostSisg_AccessoryOrder([FromBody] AccessoryOrder accessoryOrder)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                accessoryOrder.Accessory = await _context.Sisg_Accessories.FindAsync(accessoryOrder.AccesoryId);
                _context.Sisg_AccessoriesOrders.Add(accessoryOrder);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetSisg_AccessoryOrder", new { id = accessoryOrder.Id }, accessoryOrder);
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(ex.Message);
            }
        }
        #endregion

        #region // PUT: api/AccessoryOrder/5
        /// <summary>
        /// Actualiza un accesorio de una orden por ID
        /// </summary>
        /// <param name="id"></param>
        /// <param name="accessoryOrder">JSON</param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult>PutSisg_AccessoryOrder([FromRoute]int id, [FromBody] AccessoryOrder accessoryOrder)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if(id != accessoryOrder.Id)
            {
                return BadRequest();
            }
            _context.Entry(accessoryOrder).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException) when (!AccesoryOrderExist(id))
            {
                return NotFound();
            }
            return NoContent();
        }

        private bool AccesoryOrderExist(long id) =>
            _context.Sisg_AccessoriesOrders.Any(e => e.Id == id);
        #endregion

        #region // DELETE: api/AccessoryOrder/5
        /// <summary>
        /// Elimina un accesorio de una orden por ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult>DeleteSisg_AccessoryOrder( [FromRoute]int id)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var accessoryorder = await _context.Sisg_AccessoriesOrders.Where(x => x.Id == id)
                    .Include(a => a.Accessory).FirstOrDefaultAsync();                    
                
                if (accessoryorder == null)
                {
                    return NotFound();
                }

                _context.Sisg_AccessoriesOrders.Remove(accessoryorder);
                await _context.SaveChangesAsync();

                return Ok(accessoryorder);
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(ex.Message);
            }
        }
        #endregion
    }
}
