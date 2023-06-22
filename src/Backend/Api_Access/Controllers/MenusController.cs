using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Api_Access.Models;
using Microsoft.AspNetCore.Authorization;

namespace Api_Access.Controllers
{
    [Authorize("Bearer")]
    [Route("api/[controller]")]
    [ApiController]
    public class MenusController : ControllerBase
    {
        private readonly AccessContext _context;

        public MenusController(AccessContext context)
        {
            _context = context;
        }

        #region GET: api/Menus
        [HttpGet]
        public IEnumerable<Menu> GetSisg_Menus()
        {
            return _context.Sisg_Menus;
        }

        // GET: api/Menus/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMenu([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var menu = await _context.Sisg_Menus.FindAsync(id);

            if (menu == null)
            {
                return NotFound();
            }

            return Ok(menu);
        }
        #endregion

        #region POST: api/Menus
        [HttpPost]
        public async Task<IActionResult> PostMenu([FromBody] Menu menu)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            menu.creation_date = DateTime.Now;
            _context.Sisg_Menus.Add(menu);
            await _context.SaveChangesAsync();
            //Creo la relación por Defecto con Rol id = 1
            RolesMenu rm = new RolesMenu { RolId = 1, MenuId = menu.id };

            _context.Sisg_Rolesmenus.Add(rm);

            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMenu", new { id = menu.id }, menu);
        }
        #endregion

        #region PUT: api/Menus/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMenu([FromRoute] int id, [FromBody] Menu menu)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != menu.id)
            {
                return BadRequest();
            }

            menu.creation_date = DateTime.Now;
            _context.Entry(menu).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MenuExists(id))
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

        #region DELETE: api/Menus/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMenu([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var menu = await _context.Sisg_Menus.FindAsync(id);
            if (menu == null)
            {
                return NotFound();
            }

            var rms = _context.Sisg_Rolesmenus.Where(e => e.MenuId == id).ToList();

            _context.Sisg_Rolesmenus.RemoveRange(rms);
            await _context.SaveChangesAsync();

            _context.Sisg_Menus.Remove(menu);
            await _context.SaveChangesAsync();

            return Ok(menu);
        }
        #endregion

        private bool MenuExists(int id)
        {
            return _context.Sisg_Menus.Any(e => e.id == id);
        }
    }
}