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
    public class DepartamentsController : ControllerBase
    {
        private readonly EmployeesContext _context;

        public DepartamentsController(EmployeesContext context)
        {
            _context = context;
        }

        #region // GET: api/Departaments
        [HttpGet]
        public IEnumerable<Departament> GetSisg_Departaments()
        {
            return _context.Sisg_Departaments;
        }
        #endregion

        #region // GET: api/Departaments/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDepartament([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var departament = await _context.Sisg_Departaments.FindAsync(id);

            if (departament == null)
            {
                return NotFound();
            }

            return Ok(departament);
        }
        #endregion

        #region // PUT: api/Departaments/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDepartament([FromRoute] int id, [FromBody] Departament departament)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != departament.Id)
            {
                return BadRequest();
            }

            _context.Entry(departament).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DepartamentExists(id))
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

        #region // POST: api/Departaments
        [HttpPost]
        public async Task<IActionResult> PostProfile([FromBody] Departament departament)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Sisg_Departaments.Add(departament);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDepartament", new { id = departament.Id }, departament);
        }
        #endregion

        #region // DELETE: api/Departaments/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDepartament([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var departament = await _context.Sisg_Departaments.FindAsync(id);
            if (departament == null)
            {
                return NotFound();
            }

            _context.Sisg_Departaments.Remove(departament);
            await _context.SaveChangesAsync();

            return Ok(departament);
        }
        #endregion

        private bool DepartamentExists(int id)
        {
            return _context.Sisg_Departaments.Any(e => e.Id == id);
        }
    }
}