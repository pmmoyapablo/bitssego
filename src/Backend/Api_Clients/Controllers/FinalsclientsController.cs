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
    public class FinalsclientsController : ControllerBase
    {
        private readonly ClientsContext _context;

        public FinalsclientsController(ClientsContext context)
        {
            _context = context;
        }

        #region GET: api/Finalsclients
        [HttpGet]
        public IEnumerable<Finalsclients> GetFinalsclients()
        {
            try
            {
                return _context.Sisg_FinalsClients;
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(ex.Message);
            }
        }
        #endregion

        # region GET: api/Finalsclients/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetFinalsclients([FromRoute] int id)
        {
            try
            {
                if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var finalsclients = await _context.Sisg_FinalsClients.FindAsync(id);

            if (finalsclients == null)
            {
                return NotFound();
            }

            return Ok(finalsclients);
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(ex.Message);
            }
            {

            }
        }

        #endregion

        # region PUT: api/Finalsclients/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFinalsclients([FromRoute] int id, [FromBody] Finalsclients finalsclients)
        {
            try
            {
                if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != finalsclients.id)
            {
                return BadRequest();
            }

            finalsclients.creation_date = DateTime.Now;
            _context.Entry(finalsclients).State = EntityState.Modified;

                try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FinalsclientsExists(id))
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

        #region POST: api/Finalsclients

        [HttpPost]
                public async Task<IActionResult> PostFinalsclients([FromBody] Finalsclients FinalsClients)
                {
                    try
                    {
                    if (!ModelState.IsValid)
                    {
                        return BadRequest(ModelState);
                    }

                    FinalsClients.creation_date = DateTime.Now;
                    _context.Sisg_FinalsClients.Add(FinalsClients);
                    await _context.SaveChangesAsync();

                    return CreatedAtAction("GetFinalsclients", new { id = FinalsClients.id }, FinalsClients);
                    }
                      catch (Exception ex)
                    {
                        throw new HttpResponseException(ex.Message);
                    }
                }
        #endregion

        # region DELETE: api/Finalsclients/5
        [HttpDelete("{id}")]
                public async Task<IActionResult> DeleteFinalsclients([FromRoute] int id)
                {
                    try
                    {
                    if (!ModelState.IsValid)
                    {
                        return BadRequest(ModelState);
                    }

                    var finalsclients = await _context.Sisg_FinalsClients.FindAsync(id);
                    if (finalsclients == null)
                    {
                        return NotFound();
                    }

                    _context.Sisg_FinalsClients.Remove(finalsclients);
                    await _context.SaveChangesAsync();

                    return Ok(finalsclients);
                }
                catch (Exception ex)
                {
                throw new HttpResponseException(ex.Message);

                }
        }
        #endregion

        #region GET: api/Finalsclients/rif
        [HttpGet("rif/{rif}")]
        public IActionResult GetFinalsclientsrif([FromRoute] string rif)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var finalsclients = _context.Sisg_FinalsClients.Where(fc => fc.rif == rif).FirstOrDefault();

                if (finalsclients == null)
                {
                    return NotFound();
                }

                return Ok(finalsclients);
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(ex.Message);
            }
            {

            }
        }

        #endregion

        //se comenta la relacion con users, de momento no se utilizara
        //#region POST: api/Finalsclients/1/2
        //[HttpPost("{id}/{idUser}")]
        //public async Task<IActionResult> PostFinalsclientsusers([FromRoute] int id, [FromRoute] int idUser)
        //{
        //    try
        //    {
        //        //Se crea relación con un User
        //        Finalsclientsusers fu = new Finalsclientsusers { userId = idUser, finalsclientsId = id };
        //        _context.Sisg_FinalsClientsusers.Add(fu);

        //        await _context.SaveChangesAsync();

        //        return Ok(fu);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new HttpResponseException(ex.Message);
        //    }
        //}
        //#endregion

        //#region DELETE: api/Finalsclients/1/Users/2
        //[HttpDelete("{id}/Users/{idUser}")]
        //public async Task<IActionResult> DeleteFinalsclientsusers([FromRoute] int id, [FromRoute] int idUser)
        //{
        //    try
        //    {
        //        //Se borra relación con un User
        //        var fu = _context.Sisg_FinalsClientsusers.Where(e => e.finalsclientsId == id && e.userId == idUser).FirstOrDefault();
        //        _context.Sisg_FinalsClientsusers.Remove(fu);

        //        await _context.SaveChangesAsync();

        //        return Ok(fu);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new HttpResponseException(ex.Message);
        //    }
        //}
        //#endregion

        private bool FinalsclientsExists(int id)
                {
                    return _context.Sisg_FinalsClients.Any(e => e.id == id);
                }
            }
        }