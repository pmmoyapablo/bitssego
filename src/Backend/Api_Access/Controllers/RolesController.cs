using System;
using System.Net;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Api_Access.Models;
using System.Runtime.Serialization;
using Microsoft.AspNetCore.Authorization;
using System.Web.Http;

namespace Api_Access.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly AccessContext _context;

        public RolesController(AccessContext context)
        {
            _context = context;
        }

        #region // GET: api/Roles
        /// <summary>
        /// Retorna todos los Roles
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<Rol> GetRoles()
        {
            try
            {
                foreach (Rol ro in _context.Sisg_Roles.ToList())
                {
                    ro.profile = _context.Sisg_Profiles.Where(p => p.id == ro.profileId).FirstOrDefault();

                    ro.access = _context.Sisg_Accessroles.Where(a => a.id == ro.accessId).FirstOrDefault();
                }

                return _context.Sisg_Roles;
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(ex.Message);
            }
        }

        // GET: api/Roles/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetRol([FromRoute] int id)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var rol = await _context.Sisg_Roles.FindAsync(id);

                if (rol == null)
                {
                    return NotFound();
                }
                else
                {
                    rol.profile = _context.Sisg_Profiles.Where(p => p.id == rol.profileId).FirstOrDefault();
                    rol.access = _context.Sisg_Accessroles.Where(a => a.id == rol.accessId).FirstOrDefault();
                }

                return Ok(rol);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
        #endregion

        #region // POST: api/Roles
        /// <summary>
        /// Crea un Nuevo Rol
        /// </summary>
        /// <param name="rol">Rol a Crear</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> PostRol([FromBody] Rol rol)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                _context.Sisg_Roles.Add(rol);

                rol.creation_date = DateTime.Now;

                await _context.SaveChangesAsync();

                rol.access = _context.Sisg_Accessroles.Where(s => s.id == rol.accessId).FirstOrDefault();
                rol.profile = _context.Sisg_Profiles.Where(p => p.id == rol.profileId).FirstOrDefault();

                return CreatedAtAction("GetRol", new { id = rol.id }, rol);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
        #endregion

        #region // PUT: api/Roles/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRol([FromRoute] int id, [FromBody] Rol rol)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                if (id != rol.id)
                {
                    return BadRequest();
                }

                _context.Entry(rol).State = EntityState.Modified;

                rol.creation_date = DateTime.Now;

                await _context.SaveChangesAsync();

                return NoContent();
            }
            catch (Exception ex)
            {
                if (!RolExists(id))
                {
                    return NotFound();
                }
                else
                {
                    return NotFound(ex.Message);
                }
            }

        }
        #endregion

        #region // DELETE: api/Roles/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRol([FromRoute] int id)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var Rol = await _context.Sisg_Roles.FindAsync(id);

                if (Rol == null)
                {
                    return NotFound();
                }

                _context.Sisg_Roles.Remove(Rol);
                await _context.SaveChangesAsync();

                return Ok(Rol);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        private bool RolExists(int id)
        {
            var rol = _context.Sisg_Roles.Where(e => e.id == id).FirstOrDefault();

            if (rol != null)
            { return true; }
            else
            { return false; }
        }

        #endregion

        #region // POST: api/Roles/1/Menus
        [Authorize("Bearer")]
        [HttpPost("{id}/Menus")]
        public async Task<IActionResult> PostRolMenu([FromRoute] int id, [FromBody] Menu menu)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                if (menu.id != 0)
                {
                    RolesMenu rm = new RolesMenu { RolId = id, MenuId = menu.id };

                    _context.Sisg_Rolesmenus.Add(rm);

                    await _context.SaveChangesAsync();

                    return Ok();
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(ex.Message);
            }
        }
        #endregion

        #region // PUT: api/Roles/2/Menus/2
        [Authorize("Bearer")]
        [HttpPut("{id}/Menus/{id2}")]
        public async Task<IActionResult> PutRolMenu([FromRoute] int id, [FromRoute] int id2, [FromBody] Menu menu)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                if (!(id != 1 && menu.id != 0))
                {
                    return BadRequest();
                }

                var rm = _context.Sisg_Rolesmenus.Where(e => e.MenuId == menu.id && e.RolId == id).FirstOrDefault();

                rm.RolId = id2;
                _context.Entry(rm).State = EntityState.Modified;
                await _context.SaveChangesAsync();

                return NoContent();
   
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
            catch (Exception ex)
            {
                throw new HttpResponseException(ex.Message);
            }
        }

        private bool MenuExists(int id)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region // GET: api/Roles/1/Menus
        [Authorize("Bearer")]
        [HttpGet("{id}/Menus")]
        public IEnumerable<Menu> GetRolMenu([FromRoute] int id)
        {
            
           var rms = _context.Sisg_Rolesmenus.Where(rm => rm.RolId == id).ToList();

           List<Menu> menus = new List<Menu>();

            foreach (RolesMenu rm in rms)
            {
                var menu = _context.Sisg_Menus.Find(rm.MenuId);

                if (menu != null)
                {
                    menus.Add(menu);
                }
            }

            return menus;
        
        }
        #endregion
    }

    [Serializable]
    internal class HttpResponseException : Exception
    {
        private HttpStatusCode notFound;

        public HttpResponseException()
        {
        }

        public HttpResponseException(HttpStatusCode notFound)
        {
            this.notFound = notFound;
        }

        public HttpResponseException(string message) : base(message)
        {
        }

        public HttpResponseException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected HttpResponseException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
