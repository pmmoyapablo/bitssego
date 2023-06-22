using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Api_Employees.Models;
using Microsoft.AspNetCore.Authorization;

namespace Api_Employees.Controllers
{
    [Authorize("Bearer")]
    [Route("api/[controller]")]
    [ApiController]
    public class CharguesController : ControllerBase
    {
        private readonly EmployeesContext _context;

        public CharguesController(EmployeesContext context)
        {
            _context = context;
        }

        #region // GET: api/Chargues
        [HttpGet]
        public IEnumerable<Chargue> GetSisg_Chargues()
        {
            return _context.Sisg_Chargues;
        }
        #endregion

        #region // GET: api/Chargues/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetChargue([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var chargue = await _context.Sisg_Chargues.FindAsync(id);

            if (chargue == null)
            {
                return NotFound();
            }

            return Ok(chargue);
        }
        #endregion

        #region // PUT: api/Chargues/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutChargue([FromRoute] int id, [FromBody] Chargue chargue)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != chargue.Id)
            {
                return BadRequest();
            }

            _context.Entry(chargue).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ChargueExists(id))
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

        #region // POST: api/Chargues
        [HttpPost]
        public async Task<IActionResult> PostChargue([FromBody] Chargue chargue)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Sisg_Chargues.Add(chargue);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetChargue", new { id = chargue.Id }, chargue);
        }
        #endregion

        #region // DELETE: api/Chargues/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteChargue([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var chargue = await _context.Sisg_Chargues.FindAsync(id);
            if (chargue == null)
            {
                return NotFound();
            }

            _context.Sisg_Chargues.Remove(chargue);
            await _context.SaveChangesAsync();

            return Ok(chargue);
        }
        #endregion

        private bool ChargueExists(int id)
        {
            return _context.Sisg_Chargues.Any(e => e.Id == id);
        }
    }
}