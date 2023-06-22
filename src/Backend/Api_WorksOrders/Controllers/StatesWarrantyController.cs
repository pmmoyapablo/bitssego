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
    public class StatesWarrantyController : Controller
    {
        private readonly WorksOrdersContext _context;

        public StatesWarrantyController(WorksOrdersContext context)
        {
            _context = context;
        }

        #region// GET: api/StatesWarranty
        /// <summary>
        /// Retorna todos los Estados de las Garantías
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<StatesWarranty> GetSisg_StatesWarranty()
        {
            return _context.Sisg_StatesWarranty.ToList();
        }
        #endregion

        #region// GET: api/StatesWarranty/1
        /// <summary>
        /// Retorna un Estado de Garantía por Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSisg_StatesWarranty([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var stateswarranty = await _context.Sisg_StatesWarranty.FindAsync(id);
            if (stateswarranty == null)
            {
                return NotFound();
            }

            return Ok(stateswarranty);
        }
        #endregion

        #region// POST: api/StatesWarranty
        /// <summary>
        /// Crea un nuevo Estado de Garantía
        /// </summary>
        /// <param name="stateswarranty">JSON</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> PostStatesWarranty([FromBody] StatesWarranty stateswarranty)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                stateswarranty.creation_date = DateTime.Now;
                _context.Sisg_StatesWarranty.Add(stateswarranty);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetSisg_StatesWarranty", new { id = stateswarranty.Id }, stateswarranty);
               
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(ex.Message);
            }
        }
        #endregion

        #region// PUT: api/StatesWarranty/1
        ///<summary>
        ///Actualiza un Estado de Garantía por Id
        ///</summary>
        ///<param name="id"></param>
        ///<param name="stateswarranty"></param>
        ///<returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStatesWarranty([FromRoute] int id,[FromBody] StatesWarranty stateswarranty)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(stateswarranty);
            }

            if (id != stateswarranty.Id)
            {
                BadRequest();
            }

            stateswarranty.creation_date = DateTime.Now;
            _context.Entry(stateswarranty).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException) when (!StatesWarrantyExist(id))
            {
                return NotFound();
            }
            return NoContent();
        }

        private bool StatesWarrantyExist(long id) =>
            _context.Sisg_StatesWarranty.Any(e => e.Id == id);
        #endregion

        #region //DELETE api/StatesWarranty/1
        /// <summary>
        /// Elimina un Estado de Garantía
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStatesWarranty([FromRoute] int id)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var stateswarranty = await _context.Sisg_StatesWarranty.FindAsync(id);
                if (stateswarranty == null)
                {
                    return NotFound();
                }

                _context.Sisg_StatesWarranty.Remove(stateswarranty);
                await _context.SaveChangesAsync();

                return Ok(stateswarranty);
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(ex.Message);
            }
        }
        #endregion
    }
}
