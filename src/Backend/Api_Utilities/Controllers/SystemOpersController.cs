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
    public class SystemOpersController : ControllerBase
    {
        private readonly UtilitiesContext _context;

        public SystemOpersController(UtilitiesContext context)
        {
            _context = context;
        }

        // GET: api/SystemOpers
        /// <summary>
        /// Retorna todos los Sistemas Operativos
        /// </summary>
        /// <returns></returns>
        [HttpGet]

        public IEnumerable<SystemOper> GetSisg_SystemOpers()
        {
            return _context.Sisg_SystemOpers;
        }

        // GET: api/SystemOpers/5
        /// <summary>
        /// Retorna un Sistema Operativo en especifico
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]

        public async Task<IActionResult> GetSystemOper([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var systemOper = await _context.Sisg_SystemOpers.FindAsync(id);

            if (systemOper == null)
            {
                return NotFound();
            }

            return Ok(systemOper);
        }

        // PUT: api/SystemOpers/5
        /// <summary>
        /// Crea o Actualiza un Sistema Operativo en especifico
        /// </summary>
        /// <param name="id"></param>
        /// <param name="systemOper"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSystemOper([FromRoute] int id, [FromBody] SystemOper systemOper)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != systemOper.id)
            {
                return BadRequest();
            }

            _context.Entry(systemOper).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SystemOperExists(id))
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

        // POST: api/SystemOpers
        /// <summary>
        /// Envia un Sistema Operativo
        /// </summary>
        /// <param name="systemOper"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> PostSystemOper([FromBody] SystemOper systemOper)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Sisg_SystemOpers.Add(systemOper);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSystemOper", new { id = systemOper.id }, systemOper);
        }

        // DELETE: api/SystemOpers/5
        /// <summary>
        /// Elimina un Sistema Operativo en especifico
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSystemOper([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var systemOper = await _context.Sisg_SystemOpers.FindAsync(id);
            if (systemOper == null)
            {
                return NotFound();
            }

            _context.Sisg_SystemOpers.Remove(systemOper);
            await _context.SaveChangesAsync();

            return Ok(systemOper);
        }

        private bool SystemOperExists(int id)
        {
            return _context.Sisg_SystemOpers.Any(e => e.id == id);
        }
    }
}