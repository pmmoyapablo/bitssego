using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Api_Clients.Models;
using Microsoft.AspNetCore.Authorization;
using System.Runtime.Serialization;

namespace Api_Clients.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProvidersController : ControllerBase
    {
        private readonly ClientsContext _context;

        public ProvidersController(ClientsContext context)
        {
            _context = context;
        }

        #region // GET: api/Providers
        [HttpGet]
        public IEnumerable<Provider> GetSisg_Providers()
        {
            try
            {
                return _context.Sisg_Providers;
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(ex.Message);
            }
        }
        #endregion

        #region // GET: api/Providers/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProvider([FromRoute] int id)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var provider = await _context.Sisg_Providers.FindAsync(id);

                if (provider == null)
                {
                    return NotFound();
                }

                return Ok(provider);
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(ex.Message);
            }
        }
        #endregion

        #region GET: api/Providers/1/Distributors
        [HttpGet("{id}/Distributors")]
        public IEnumerable<Distributor> GetDistributors([FromRoute] int id)
        {
            try
            {
                var relatiosDistr = _context.Sisg_DistributorsProviders.Where(pd => pd.ProviderId == id).ToList();

                List<Distributor> distributors = new List<Distributor>();

                foreach (DistributorsProvider pd in relatiosDistr)
                {
                    var distributor = _context.Sisg_Distributors.Where(d => d.id == pd.DistributorsId).FirstOrDefault();
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

        #region // PUT: api/Providers/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProvider([FromRoute] int id, [FromBody] Provider provider)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                if (id != provider.id)
                {
                    return BadRequest();
                }

                provider.creation_date = DateTime.Now;
                _context.Entry(provider).State = EntityState.Modified;

                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProviderExists(id))
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

        #region // POST: api/Providers
        [HttpPost]
        public async Task<IActionResult> PostProvider([FromBody] Provider provider)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                provider.creation_date = DateTime.Now;
                _context.Sisg_Providers.Add(provider);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetProvider", new { id = provider.id }, provider);
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(ex.Message);
            }
        }
        #endregion

        #region // DELETE: api/Providers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProvider([FromRoute] int id)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var provider = await _context.Sisg_Providers.FindAsync(id);
                if (provider == null)
                {
                    return NotFound();
                }

                _context.Sisg_Providers.Remove(provider);
                await _context.SaveChangesAsync();

                return Ok(provider);
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(ex.Message);
            }
        }
        #endregion

        private bool ProviderExists(int id)
        {
            return _context.Sisg_Providers.Any(e => e.id == id);
        }
    }

    #region Clases Requeridas
    [Serializable]
    internal class HttpResponseException : Exception
    {
        public HttpResponseException()
        {
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
    #endregion
}