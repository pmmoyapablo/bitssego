using System;
using System.Net;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Api_Clients.Models;
using System.Web.Http;
using System.Runtime.Serialization;
using Microsoft.AspNetCore.Authorization;

namespace Api_Clients.Controllers
{
    [Authorize("Bearer")]
    [Route("api/[controller]")]
    [ApiController]
    public class DevelopersClientsController : ControllerBase
    {
        private readonly ClientsContext _context;

        public DevelopersClientsController(ClientsContext context)
        {
            _context = context;
        }

        #region GET: api/DevelopersClients
        [HttpGet]
        public IEnumerable<DevelopersClients> GetSisg_DevelopersClients()
        {
            try
            {
                return _context.Sisg_DevelopersClients;
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(ex.Message);
            }
        }
        #endregion

        #region GET: api/DevelopersClients/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDevelopersClients([FromRoute] int id)
        {
            try
            {
                if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var developersClients = await _context.Sisg_DevelopersClients.FindAsync(id);

            if (developersClients == null)
            {
                return NotFound();
            }

            return Ok(developersClients);
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(ex.Message);
            }
            {

            }
        }

        #endregion

        # region PUT: api/DevelopersClients/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDevelopersClients([FromRoute] int id, [FromBody] DevelopersClients developersClients)
        {
            try
            {
                if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != developersClients.id)
            {
                return BadRequest();
            }

            developersClients.creation_date = DateTime.Now;
            _context.Entry(developersClients).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DevelopersClientsExists(id))
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
             catch (Exception ex)
            {
                throw new HttpResponseException(ex.Message);
    }
}
#endregion

        #region POST: api/DevelopersClients

        [HttpPost]
                public async Task<IActionResult> PostDevelopersClients([FromBody] DevelopersClients developersClients)
                {
                    try
                    {
                        if (!ModelState.IsValid)
                    {
                        return BadRequest(ModelState);
                    }

                    developersClients.creation_date = DateTime.Now;
                    _context.Sisg_DevelopersClients.Add(developersClients);
                    await _context.SaveChangesAsync();

                    return CreatedAtAction("GetDevelopersClients", new { id = developersClients.id }, developersClients);
                    }
                      catch (Exception ex)
                    {
                        throw new HttpResponseException(ex.Message);
            }
                }
                #endregion

        #region DELETE: api/DevelopersClients/5
        [HttpDelete("{id}")]
                public async Task<IActionResult> DeleteDevelopersClients([FromRoute] int id)
                {   try
                    {

                        if (!ModelState.IsValid)
                        {
                            return BadRequest(ModelState);
                        }

                        var developersClients = await _context.Sisg_DevelopersClients.FindAsync(id);
                        if (developersClients == null)
                        {
                            return NotFound();
                        }

                        _context.Sisg_DevelopersClients.Remove(developersClients);
                        await _context.SaveChangesAsync();

                        return Ok(developersClients);
                     }
                     catch (Exception ex)
                      {
                             throw new HttpResponseException(ex.Message);
                      }
                }
        #endregion

        #region POST: api/DevelopersClients/1/2
        [HttpPost("{id}/{idUser}")]
        public async Task<IActionResult> PostDevelopersClientsusers([FromRoute] int id, [FromRoute] int idUser)
        {
            try
            {
                //Se crea relación con un User
                DevelopersClientsusers du = new DevelopersClientsusers { userId = idUser, developersclientsId = id };
                _context.Sisg_DevelopersClientsusers.Add(du);

                await _context.SaveChangesAsync();

                return Ok(du);
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(ex.Message);
            }
        }
        #endregion

        #region DELETE: api/DevelopersClients/1/Users/2
        [HttpDelete("{id}/Users/{idUser}")]
        public async Task<IActionResult> DeleteDevelopersClientsusersr([FromRoute] int id, [FromRoute] int idUser)
        {
            try
            {
                //Se borra relación con un User
                var du = _context.Sisg_DevelopersClientsusers.Where(e => e.developersclientsId == id && e.userId == idUser).FirstOrDefault();
                _context.Sisg_DevelopersClientsusers.Remove(du);

                await _context.SaveChangesAsync();

                return Ok(du);
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(ex.Message);
            }
        }
        #endregion

        private bool DevelopersClientsExists(int id)
        {
            return _context.Sisg_DevelopersClients.Any(e => e.id == id);
        }
    }
}