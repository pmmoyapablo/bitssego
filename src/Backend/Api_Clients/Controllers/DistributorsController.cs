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
    public class DistributorsController : ControllerBase
    {
        private readonly ClientsContext _context;

        public DistributorsController(ClientsContext context)
        {
            _context = context;
        }

        #region GET: api/Distributors
        /// <summary>
        /// Retorna Todos Los Distribuidores
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<Distributor> GetSisg_Distributors()
        {
            try
            {
                return _context.Sisg_Distributors;
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(ex.Message);
            }
        }
        #endregion

        #region GET: api/Distributors/5
        /// <summary>
        /// Retorna un Distribuidor por su Identificador
        /// </summary>
        /// <param name="id">Identificador</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDistributor([FromRoute] int id)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var distributor = await _context.Sisg_Distributors.FindAsync(id);

                if (distributor == null)
                {
                    return NotFound();
                }

                return Ok(distributor);
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(ex.Message);
            }
        }
        #endregion

        #region GET: api/Distributors/5/Technicians
        [HttpGet("{id}/Technicians")]
        public IEnumerable<Technician> GetTechnicians([FromRoute] int id)
        {
            try
            {
               
                var relatiosTechs = _context.Sisg_TechniciansDistributors.Where(td => td.distributorsId == id).ToList();

                List<Technician> technicians = new List<Technician>();

                foreach (TechniciansDistributor td in relatiosTechs)
                {
                    var technica = _context.Sisg_Technicians.Where(t => t.id == td.techniciansId).FirstOrDefault();
                    technicians.Add(technica);
                }

                return technicians;
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(ex.Message);
            }
        }
        #endregion

        #region PUT: api/Distributors/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDistributor([FromRoute] int id, [FromBody] Distributor distributor)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                if (id != distributor.id)
                {
                    return BadRequest();
                }

                distributor.creation_date = DateTime.Now;
                _context.Entry(distributor).State = EntityState.Modified;

                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DistributorExists(id))
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

        #region POST: api/Distributors
        [HttpPost]
        public async Task<IActionResult> PostDistributor([FromBody] Distributor distributor)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                distributor.creation_date = DateTime.Now;
                _context.Sisg_Distributors.Add(distributor);
                await _context.SaveChangesAsync();               

                return CreatedAtAction("GetDistributor", new { id = distributor.id }, distributor);
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(ex.Message);
            }
        }
        #endregion

        #region // POST: api/Distributors/1/Providers
        [HttpPost("{id}/Providers")]
        public async Task<IActionResult> PostDistributorProvider([FromRoute] int id, [FromBody] Provider prov)
        {
            try
            {
                if (prov == null)
                {
                    return NotFound();
                }
                //Se crea relación con Proveedor
                DistributorsProvider dp = new DistributorsProvider { ProviderId = prov.id , DistributorsId = id };
                _context.Sisg_DistributorsProviders.Add(dp);

                await _context.SaveChangesAsync();

                return Ok(dp);
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(ex.Message);
            }
        }
        #endregion

        #region // POST: api/Distributors/1/2
        [HttpPost("{id}/{idUser}")]
        public async Task<IActionResult> PostDistributorUser([FromRoute] int id, [FromRoute] int idUser)
        {
            try
            {
                //Se crea relación con un User
                DistributorsUser du = new DistributorsUser { UserId = idUser, DistributorsId = id };
                _context.Sisg_DistributorsUsers.Add(du);

                await _context.SaveChangesAsync();

                return Ok(du);
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(ex.Message);
            }
        }
        #endregion

        #region DELETE: api/Distributors/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDistributor([FromRoute] int id)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var distributor = await _context.Sisg_Distributors.FindAsync(id);
                if (distributor == null)
                {
                    return NotFound();
                }

                _context.Sisg_Distributors.Remove(distributor);
                await _context.SaveChangesAsync();

                return Ok(distributor);
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(ex.Message);
            }
        }
        #endregion

        #region // DELETE: api/Distributors/1/Providers/2
        [HttpDelete("{id}/Providers/{idProvider}")]
        public async Task<IActionResult> DeleteDistributorProvider([FromRoute] int id, [FromRoute] int idProvider)
        {
            try
            {
                //Se borra relación con Proveedor
                var dp = _context.Sisg_DistributorsProviders.Where(e => e.DistributorsId == id && e.ProviderId == idProvider).ToList();

                if (dp == null)
                {
                    return NotFound();
                }

                _context.Sisg_DistributorsProviders.RemoveRange(dp);
                await _context.SaveChangesAsync();

                return Ok(dp);
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(ex.Message);
            }
        }
        #endregion

        #region // DELETE: api/Distributors/1/Users/2
        [HttpDelete("{id}/Users/{idUser}")]
        public async Task<IActionResult> DeleteDistributorUser([FromRoute] int id, [FromRoute] int idUser)
        {
            try
            {
                //Se borra relación con un User
                var du = _context.Sisg_DistributorsUsers.Where(e => e.DistributorsId == id && e.UserId == idUser).FirstOrDefault();
                _context.Sisg_DistributorsUsers.Remove(du);

                await _context.SaveChangesAsync();

                return Ok(du);
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(ex.Message);
            }
        }
        #endregion

        private bool DistributorExists(int id)
        {
            return _context.Sisg_Distributors.Any(e => e.id == id);
        }
    }
}
