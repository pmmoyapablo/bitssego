using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Api_Products.Models;
using Microsoft.AspNetCore.Authorization;

namespace Api_Products.Controllers
{
    [Authorize("Bearer")]
    [Route("api/[controller]")]
    [ApiController]
    public class PrefixesController : ControllerBase
    {
        private readonly ProductsContext _context;

        public PrefixesController(ProductsContext context)
        {
            _context = context;
        }

        // GET: api/Prefixes
        [HttpGet]
        public IEnumerable<Object> GetSisg_Prefixes()
        {         
            return _context.Sisg_Prefixes;         
        }

        // GET: api/Prefixes/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPrefix([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var prefix = await _context.Sisg_Prefixes.FindAsync(id);

            if (prefix == null)
            {
                return NotFound();
            }

            return Ok(prefix);
        }

        // PUT: api/Prefixes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPrefix([FromRoute] int id, [FromBody] Prefix prefix)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != prefix.id)
            {
                return BadRequest();
            }

            _context.Entry(prefix).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PrefixExists(id))
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

        // POST: api/Prefixes
        [HttpPost]
        public async Task<IActionResult> PostPrefix([FromBody] Prefix prefix)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            prefix.creation_date = DateTime.Now;
            _context.Sisg_Prefixes.Add(prefix);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPrefix", new { id = prefix.id }, prefix);
        }

        // DELETE: api/Prefixes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePrefix([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var prefix = await _context.Sisg_Prefixes.FindAsync(id);
            if (prefix == null)
            {
                return NotFound();
            }

            _context.Sisg_Prefixes.Remove(prefix);
            await _context.SaveChangesAsync();

            return Ok(prefix);
        }

        private bool PrefixExists(int id)
        {
            return _context.Sisg_Prefixes.Any(e => e.id == id);
        }
    }
}