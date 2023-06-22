using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Api_Access.Models;

namespace Api_Access.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccessesController : ControllerBase
    {
        private readonly AccessContext _context;

        public AccessesController(AccessContext context)
        {
            _context = context;
        }

        #region // GET: api/Accesses
        /// <summary>
        /// Retorna todos los Accesos
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<Access> GetSisg_Accessroles()
        {
            return _context.Sisg_Accessroles;
        }
        #endregion

        #region // GET: api/Accesses/5
        /// <summary>
        /// Retorna un Acceso especifico
        /// </summary>
        /// <param name="id">Identificador</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAccess([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var access = await _context.Sisg_Accessroles.FindAsync(id);

            if (access == null)
            {
                return NotFound();
            }

            return Ok(access);
        }
        #endregion

        #region // PUT: api/Accesses/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAccess([FromRoute] int id, [FromBody] Access access)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != access.id)
            {
                return BadRequest();
            }

            _context.Entry(access).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AccessExists(id))
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

        #region // POST: api/Accesses
        [HttpPost]
        public async Task<IActionResult> PostAccess([FromBody] Access access)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Sisg_Accessroles.Add(access);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAccess", new { id = access.id }, access);
        }
        #endregion

        #region // DELETE: api/Accesses/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAccess([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var access = await _context.Sisg_Accessroles.FindAsync(id);
            if (access == null)
            {
                return NotFound();
            }

            _context.Sisg_Accessroles.Remove(access);
            await _context.SaveChangesAsync();

            return Ok(access);
        }
        #endregion

        private bool AccessExists(int id)
        {
            return _context.Sisg_Accessroles.Any(e => e.id == id);
        }
    }
}