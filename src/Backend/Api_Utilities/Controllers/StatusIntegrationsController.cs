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
    public class StatusIntegrationsController : ControllerBase
    {
        private readonly UtilitiesContext _context;

        public StatusIntegrationsController(UtilitiesContext context)
        {
            _context = context;
        }

        // GET: api/StatusIntegrations
        /// <summary>
        /// Retorna todos los Estatus de Integración
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<StatusIntegration> GetSisg_StatusIntegrations()
        {
            return _context.Sisg_StatusIntegrations;
        }

        // GET: api/StatusIntegrations/5
        /// <summary>
        /// Retorna un Estatus de Integración en especifico
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetStatusIntegration([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var statusIntegration = await _context.Sisg_StatusIntegrations.FindAsync(id);

            if (statusIntegration == null)
            {
                return NotFound();
            }

            return Ok(statusIntegration);
        }

        // PUT: api/StatusIntegrations/5
        /// <summary>
        /// Crea o Actualiza un Estatus de Integración en especifico
        /// </summary>
        /// <param name="id"></param>
        /// <param name="statusIntegration"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStatusIntegration([FromRoute] int id, [FromBody] StatusIntegration statusIntegration)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != statusIntegration.id)
            {
                return BadRequest();
            }

            _context.Entry(statusIntegration).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StatusIntegrationExists(id))
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

        // POST: api/StatusIntegrations
        /// <summary>
        /// Envia un Estatus de Integración
        /// </summary>
        /// <param name="statusIntegration"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> PostStatusIntegration([FromBody] StatusIntegration statusIntegration)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Sisg_StatusIntegrations.Add(statusIntegration);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStatusIntegration", new { id = statusIntegration.id }, statusIntegration);
        }

        // DELETE: api/StatusIntegrations/5
        /// <summary>
        /// Elimina un Estatus de Integración en especifico
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStatusIntegration([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var statusIntegration = await _context.Sisg_StatusIntegrations.FindAsync(id);
            if (statusIntegration == null)
            {
                return NotFound();
            }

            _context.Sisg_StatusIntegrations.Remove(statusIntegration);
            await _context.SaveChangesAsync();

            return Ok(statusIntegration);
        }

        private bool StatusIntegrationExists(int id)
        {
            return _context.Sisg_StatusIntegrations.Any(e => e.id == id);
        }
    }
}