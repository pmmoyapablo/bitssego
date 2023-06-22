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
    public class TechniciansController : ControllerBase
    {
        private readonly ClientsContext _context;

        public TechniciansController(ClientsContext context)
        {
            _context = context;
        }

        #region GET: api/Technicians
        [HttpGet]
        public IEnumerable<Technician> GetSisg_Technicians()
        {
            try
            {
                return _context.Sisg_Technicians;
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(ex.Message);
            }
        }
        #endregion

        #region GET: api/Technicians/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTechnician([FromRoute] int id)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var technician = await _context.Sisg_Technicians.FindAsync(id);

                if (technician == null)
                {
                    return NotFound();
                }

                return Ok(technician);
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(ex.Message);
            }
        }
        #endregion

        #region GET: api/Technicians/5/Distributors
        [HttpGet("{id}/Distributors")]
        public IEnumerable<Distributor> GetDistributors([FromRoute] int id)
        {
            try
            {
               
                var relatiosDistr = _context.Sisg_TechniciansDistributors.Where(td => td.techniciansId == id).ToList();

                List<Distributor> distributors = new List<Distributor>();

                foreach (TechniciansDistributor td in relatiosDistr)
                {
                    var distributor = _context.Sisg_Distributors.Where(d => d.id == td.distributorsId).FirstOrDefault();
                    distributors.Add(distributor);
                }

                return distributors;
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(ex.Message);
            }
        }
        #endregion

        #region PUT: api/Technicians/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTechnician([FromRoute] int id, [FromBody] Technician technician)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                if (id != technician.id)
                {
                    return BadRequest();
                }

                technician.creation_date = DateTime.Now;
                _context.Entry(technician).State = EntityState.Modified;

                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TechnicianExists(id))
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

        #region POST: api/Technicians
        [HttpPost]
        public async Task<IActionResult> PostTechnician([FromBody] Technician technician)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                technician.creation_date = DateTime.Now;
                _context.Sisg_Technicians.Add(technician);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetTechnician", new { id = technician.id }, technician);
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(ex.Message);
            }
        }
        #endregion

        #region DELETE: api/Technicians/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTechnician([FromRoute] int id)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var technician = await _context.Sisg_Technicians.FindAsync(id);
                if (technician == null)
                {
                    return NotFound();
                }

                _context.Sisg_Technicians.Remove(technician);
                await _context.SaveChangesAsync();

                return Ok(technician);
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(ex.Message);
            }
        }
        #endregion

        #region POST: api/Technicians/1/Distributors
        [HttpPost("{id}/Distributors")]
        public async Task<IActionResult> PostTechnicianDistributor([FromRoute] int id, [FromBody] Distributor dist)
        {
            try
            {
                if (dist == null)
                {
                    return NotFound();
                }
                //Se crea relación con Distribuidor
                TechniciansDistributor td = new TechniciansDistributor { distributorsId = dist.id, techniciansId = id };
                _context.Sisg_TechniciansDistributors.Add(td);

                await _context.SaveChangesAsync();

                return Ok(td);
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(ex.Message);
            }
        }
        #endregion

        #region DELETE: api/Technicians/1/Distributors/2
        [HttpDelete("{id}/Distributors/{idDistributor}")]
        public async Task<IActionResult> DeleteTechnicianDistributor([FromRoute] int id, [FromRoute] int idDistributor)
        {
            try
            {
                //Se borra relación con Distribuidor
                var td = _context.Sisg_TechniciansDistributors.Where(e => e.techniciansId == id && e.distributorsId == idDistributor).ToList();

                if (td == null)
                {
                    return NotFound();
                }

                _context.Sisg_TechniciansDistributors.RemoveRange(td);
                await _context.SaveChangesAsync();

                return Ok(td);
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(ex.Message);
            }
        }
        #endregion

        #region POST: api/Technicians/1/2
        [HttpPost("{id}/{idUser}")]
        public async Task<IActionResult> PostTechnicianUser([FromRoute] int id, [FromRoute] int idUser)
        {
            try
            {
                //Se crea relación con un User
                TechniciansUser tu = new TechniciansUser { userId = idUser, techniciansId = id };
                _context.Sisg_TechniciansUsers.Add(tu);

                await _context.SaveChangesAsync();

                return Ok(tu);
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(ex.Message);
            }
        }
        #endregion

        #region DELETE: api/Technicians/1/Users/2
        [HttpDelete("{id}/Users/{idUser}")]
        public async Task<IActionResult> DeleteTechnicianUser([FromRoute] int id, [FromRoute] int idUser)
        {
            try
            {
                //Se borra relación con un User
                var tu = _context.Sisg_TechniciansUsers.Where(e => e.techniciansId == id && e.userId == idUser).FirstOrDefault();
                _context.Sisg_TechniciansUsers.Remove(tu);

                await _context.SaveChangesAsync();

                return Ok(tu);
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(ex.Message);
            }
        }
        #endregion

        private bool TechnicianExists(int id)
        {
            return _context.Sisg_Technicians.Any(e => e.id == id);
        }
    }
}