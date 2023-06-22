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
    public class CasesSoftwareHousesController : ControllerBase
    {
        private readonly UtilitiesContext _context;

        public CasesSoftwareHousesController(UtilitiesContext context)
        {
            _context = context;
        }

        // GET: api/CasesSoftwareHouses
        /// <summary>
        /// Retorna todos los Casos de Casa de Software
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<CasesSoftwareHouse> GetSisg_CasesSoftwareHouses()
        {

            var listorCSH = _context.Sisg_CasesSoftwareHouses
            .Include(e => e.employee)
            .Include(d => d.developersClients)
            .Include(s => s.SystemOper)
            .Include(i => i.StatusIntegration)
            .Include(p => p.programLanguage)
            .ToList();


            return listorCSH;
            //return _context.Sisg_CasesSoftwareHouses;
        }

        // GET: api/CasesSoftwareHouses/5
        /// <summary>
        /// Retorna un Caso de Casa de Software
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]

        public async Task<IActionResult> GetCasesSoftwareHouse([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var casesSoftwareHouse = await _context.Sisg_CasesSoftwareHouses.Where(c => c.id == id).Include(e => e.employee)
            .Include(d => d.developersClients)
            .Include(s => s.SystemOper)
            .Include(i => i.StatusIntegration)
            .Include(p => p.programLanguage).FirstOrDefaultAsync();

            if (casesSoftwareHouse == null)
            {
                return NotFound();
            }

            return Ok(casesSoftwareHouse);
        }

        // PUT: api/CasesSoftwareHouses/5
        /// <summary>
        /// Crea o Actualiza un Caso de Casa de Software
        /// </summary>
        /// <param name="id"></param>
        /// <param name="casesSoftwareHouse"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCasesSoftwareHouse([FromRoute] int id, [FromBody] CasesSoftwareHouse casesSoftwareHouse)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != casesSoftwareHouse.id)
            {
                return BadRequest();
            }

            _context.Entry(casesSoftwareHouse).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CasesSoftwareHouseExists(id))
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

        // POST: api/CasesSoftwareHouses
        /// <summary>
        /// Envia un Caso de Casa de Software
        /// </summary>
        /// <param name="casesSoftwareHouse"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> PostCasesSoftwareHouse([FromBody] CasesSoftwareHouse casesSoftwareHouse)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Sisg_CasesSoftwareHouses.Add(casesSoftwareHouse);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCasesSoftwareHouse", new { id = casesSoftwareHouse.id }, casesSoftwareHouse);
        }

        // DELETE: api/CasesSoftwareHouses/5
        /// <summary>
        /// elimina un Caso de Casa de Software
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCasesSoftwareHouse([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var casesSoftwareHouse = await _context.Sisg_CasesSoftwareHouses.FindAsync(id);
            if (casesSoftwareHouse == null)
            {
                return NotFound();
            }

            _context.Sisg_CasesSoftwareHouses.Remove(casesSoftwareHouse);
            await _context.SaveChangesAsync();

            return Ok(casesSoftwareHouse);
        }

        private bool CasesSoftwareHouseExists(int id)
        {
            return _context.Sisg_CasesSoftwareHouses.Any(e => e.id == id);
        }
    }
}