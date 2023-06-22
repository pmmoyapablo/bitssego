using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api_WorksOrders.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api_WorksOrders.Controllers
{
    [Authorize("Bearer")]
    [Route("api/[controller]")]
    [ApiController]
    public class WorkshopBinnacleController : Controller
    {
        private readonly WorksOrdersContext _context;

        public WorkshopBinnacleController(WorksOrdersContext context)
        {
            _context = context;
        }

        #region GET: api/WorkshopBinnacle
        /// <summary>
        /// Retorna todos las bitácoras registradas
        /// </summary>
        [HttpGet]
        public IEnumerable<WorkshopBinnacle> GetSisg_WorkshopBinnacless()
        {
            return _context.Sisg_WorkshopBinnacles
                           .Include(o => o.Order)
                           .Include(st => st.StatusOrder)
                           .Include(u => u.User)
                           .ToList();   
        }
    #endregion

        #region GET: api/WorkshopBinnacle/ByOrderId
        /// <summary>
        /// Retorna las bitácoras registradas de una Orden
        /// </summary>
        /// <param name="orderId">Orden ID</param>
        /// <returns></returns>
        [HttpGet("ByOrderId/{orderId}")]
        public IEnumerable<WorkshopBinnacle> GetSisg_WorkshopBinnaclessByOrderId(int orderId)
        {
          var binnacles = _context.Sisg_WorkshopBinnacles.Where(b => b.OrderId == orderId)
                         .Include(o => o.Order)
                         .Include(st => st.StatusOrder)
                         .Include(u => u.User)
                         .ToList();

          return binnacles;
        }
        #endregion

        #region GET: api/WorkshopBinnacle/1
        /// <summary>
        /// Retorna una bitácora por id 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
            public async Task<IActionResult> GetSisg_WorkshopBinnacles([FromRoute]int id)
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var workshopBinnacle = await _context.Sisg_WorkshopBinnacles.Where(x => x.Id == id)
                    .Include(o => o.Order)
                    .Include(st => st.StatusOrder)
                    .Include(u => u.User)
                    .FirstOrDefaultAsync();

                if (workshopBinnacle == null)
                {
                    return NotFound();
                }

                return Ok(workshopBinnacle);

            }

            #endregion

        #region POST: api/WorkshopBinnacle
        /// <summary>
        /// Crea una nueva bitácora 
        /// </summary>
        /// <param name="workshopBinnacle">JSON</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> PostSisg_WorkshopBinnacles([FromBody] WorkshopBinnacle workshopBinnacle)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
               /*
               var binnacle = _context.Sisg_WorkshopBinnacles.Where(b => 
                       b.OrderId == workshopBinnacle.OrderId
                       && b.StatusId == workshopBinnacle.StatusId
                       && b.UserId == workshopBinnacle.UserId)
                       .FirstOrDefault();

                if (binnacle != null)
                   {
                     return BadRequest("Combinacion de Staus, Orden y Usuario duplicada");
                   }  */

                workshopBinnacle.Creation_Date = DateTime.Now;

                _context.Sisg_WorkshopBinnacles.Add(workshopBinnacle);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetSisg_WorkshopBinnacless", new { id = workshopBinnacle.Id }, workshopBinnacle);

            }
            catch (Exception ex)
            {
              return StatusCode(500, ex.Message + ". " + ex.InnerException != null? ex.InnerException.Message : "");
            }
        }
        #endregion

        #region PUT: api/WorkshopBinnacle/1
        /// <summary>
        /// Actualiza una bitácora existente
        /// </summary>
        /// <param name="id"></param>
        /// <param name="workshopBinnacle">JSON</param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSisg_WorkshopBinnacles([FromRoute]int id, [FromBody] WorkshopBinnacle workshopBinnacle)
        {
          try
          {
            if (!ModelState.IsValid)
            {
              return BadRequest(ModelState);
            }

            //var binnacle = _context.Sisg_WorkshopBinnacles.Where(b =>
            //               b.OrderId == workshopBinnacle.OrderId
            //               && b.StatusId == workshopBinnacle.StatusId
            //               && b.UserId == workshopBinnacle.UserId)
            //               .FirstOrDefault();

            //if (binnacle != null)
            //{
            //  return BadRequest("Combinacion de Staus, Orden y Usuario duplicada");
            //}

            workshopBinnacle.Creation_Date = DateTime.Now;
            _context.Entry(workshopBinnacle).State = EntityState.Modified;

            await _context.SaveChangesAsync();

            return NoContent();

          }
          catch (Exception ex)
          {
            return StatusCode(500, ex.Message + ". " + ex.InnerException != null ? ex.InnerException.Message : "");
          }
        }
        #endregion

        #region DELETE: api/WorkshopBinnacle/ByOrderId
        /// <summary>
        /// Elimina las bitácoras registradas de una Orden
        /// </summary>
        /// <param name="orderId">Orden ID</param>
        /// <returns></returns>
        [HttpDelete("ByOrderId/{orderId}")]
        public async Task<IActionResult> DelSisg_WorkshopBinnaclessByOrderId(int orderId)
        {
          try
          {
            var binnacles = _context.Sisg_WorkshopBinnacles.Where(b => b.OrderId == orderId)
                           .Include(o => o.Order)
                           .Include(st => st.StatusOrder)
                           .Include(u => u.User)
                           .ToList();

            _context.Sisg_WorkshopBinnacles.RemoveRange(binnacles.ToArray());
            await _context.SaveChangesAsync();

            return Ok();

          }
          catch (Exception ex)
          {
            return StatusCode(500, ex.Message + ". " + ex.InnerException != null ? ex.InnerException.Message : "");
          }
        }
        #endregion

  }
}