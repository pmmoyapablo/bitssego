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
    public class ProgramLenguagesController : ControllerBase
    {
        private readonly UtilitiesContext _context;

        public ProgramLenguagesController(UtilitiesContext context)
        {
            _context = context;
        }

        // GET: api/ProgramLenguages
        /// <summary>
        /// Retorna todos los Lenguajes de Programación
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<ProgramLenguage> GetSisg_ProgramLenguages()
        {
            return _context.Sisg_ProgramLenguages;
        }

        // GET: api/ProgramLenguages/5
        /// <summary>
        /// Retorna un Lenguaje de Programación en especifico
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProgramLenguage([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var programLenguage = await _context.Sisg_ProgramLenguages.FindAsync(id);

            if (programLenguage == null)
            {
                return NotFound();
            }

            return Ok(programLenguage);
        }

        // PUT: api/ProgramLenguages/5
        /// <summary>
        /// Crea o Actualiza un Lenguaje de Programación en especifico
        /// </summary>
        /// <param name="id"></param>
        /// <param name="programLenguage"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProgramLenguage([FromRoute] int id, [FromBody] ProgramLenguage programLenguage)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != programLenguage.id)
            {
                return BadRequest();
            }

            _context.Entry(programLenguage).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProgramLenguageExists(id))
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

        // POST: api/ProgramLenguages
        /// <summary>
        /// Envia un Lenguaje de Programación
        /// </summary>
        /// <param name="programLenguage"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> PostProgramLenguage([FromBody] ProgramLenguage programLenguage)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Sisg_ProgramLenguages.Add(programLenguage);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProgramLenguage", new { id = programLenguage.id }, programLenguage);
        }

        // DELETE: api/ProgramLenguages/5
        /// <summary>
        /// Elimina un Lenguaje de Programación en especifico
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProgramLenguage([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var programLenguage = await _context.Sisg_ProgramLenguages.FindAsync(id);
            if (programLenguage == null)
            {
                return NotFound();
            }

            _context.Sisg_ProgramLenguages.Remove(programLenguage);
            await _context.SaveChangesAsync();

            return Ok(programLenguage);
        }

        private bool ProgramLenguageExists(int id)
        {
            return _context.Sisg_ProgramLenguages.Any(e => e.id == id);
        }
    }
}