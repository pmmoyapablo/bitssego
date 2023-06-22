using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api_Operations.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static Api_Operations.Controllers.SerialsProductsController;

namespace Api_Operations.Controllers
{
    [Authorize("Bearer")]
    [Route("api/[controller]")]
    [ApiController]
    public class AlienationsController : ControllerBase
    {

        private readonly OperationsContext _context;

        public AlienationsController(OperationsContext context)
        {
            _context = context;
        }


        #region GET api/Alienations
        [HttpGet]
        public IEnumerable<Alienation> GetSisg_Alienations()
        {
            try
            {
                foreach (Alienation a in _context.Sisg_Alienations.ToList())
                {
                    a.provider    =  _context.Sisg_Providers.Where(p => p.id == a.ProviderId).FirstOrDefault();
                    a.distributor =  _context.Sisg_Distributors.Where(d => d.id == a.DistributorId).FirstOrDefault();
                    a.FinalClient =  _context.Sisg_FinalsClients.Where(f => f.id == a.FinalClientId).FirstOrDefault();
                }

                return _context.Sisg_Alienations;

            }catch (Exception ex)
            {
                throw new HttpResponseException(ex.Message);
            }
        }
        #endregion

        #region GET api/Alienations/1
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAlienationsById([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var alienation = await _context.Sisg_Alienations.FindAsync(id);

            if (alienation == null)
            {
                return NotFound();
            }
            else
            {
                alienation.provider      = _context.Sisg_Providers.Where(p => p.id == alienation.ProviderId).FirstOrDefault();
                alienation.distributor   = _context.Sisg_Distributors.Where(d => d.id == alienation.DistributorId).FirstOrDefault();
                alienation.FinalClient   = _context.Sisg_FinalsClients.Where(f => f.id == alienation.FinalClientId).FirstOrDefault();
            }

            return Ok(alienation);

        }


        #endregion

        #region GET api/Alienations/BySerial/Z1B4444557
        [HttpGet("BySerial/{serial}")]
        public async Task<IActionResult> GetAlienationsBySerial([FromRoute] string serial)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var alienation = await _context.Sisg_Alienations.Where(a => a.Serial == serial).FirstOrDefaultAsync();

                if (alienation == null)
                {
                    return NotFound();
                }
                else
                {
                    alienation.provider = _context.Sisg_Providers.Where(p => p.id == alienation.ProviderId).FirstOrDefault();
                    alienation.distributor = _context.Sisg_Distributors.Where(d => d.id == alienation.DistributorId).FirstOrDefault();
                    alienation.FinalClient = _context.Sisg_FinalsClients.Where(f => f.id == alienation.FinalClientId).FirstOrDefault();

                    return Ok(alienation);
                }



            }
            catch (Exception ex)
            {
                throw new HttpResponseException(ex.Message);
            }
        }

        #endregion

        #region GET api/Alienations/ByProviderId/1
        [HttpGet("ByProviderId/{id}")]
        public IEnumerable<Alienation> GetAlienationsByProviderId([FromRoute] int id)
        {
            try
            {

                var alienation = _context.Sisg_Alienations.Where(a => a.ProviderId == id).ToList();

                foreach (Alienation a in alienation)
                {
                    a.provider = _context.Sisg_Providers.Where(p => p.id == a.ProviderId).FirstOrDefault();
                    a.distributor = _context.Sisg_Distributors.Where(d => d.id == a.DistributorId).FirstOrDefault();
                    a.FinalClient = _context.Sisg_FinalsClients.Where(f => f.id == a.FinalClientId).FirstOrDefault();
                }

                return alienation;

            }
            catch (Exception ex)
            {
                throw new HttpResponseException(ex.Message);
            }
        }
        #endregion

        #region GET api/Alienations/FinalClient/J314310895
        [HttpGet("FinalClient/{rif}")]
        public async Task<IEnumerable<Alienation>> GetAlienationsByFinald([FromRoute] string rif)
        {
            try
            {
                    var finalclient = _context.Sisg_FinalsClients.Where(fc => fc.rif == rif).FirstOrDefault();

                    if (finalclient != null)
                    {
                        var alienations = await _context.Sisg_Alienations.Where(a => a.FinalClientId == finalclient.id).ToListAsync();

                        foreach (Alienation a in alienations)
                        {
                            a.provider = _context.Sisg_Providers.Where(p => p.id == a.ProviderId).FirstOrDefault();
                            a.distributor = _context.Sisg_Distributors.Where(d => d.id == a.DistributorId).FirstOrDefault();
                            a.FinalClient = _context.Sisg_FinalsClients.Where(f => f.id == a.FinalClientId).FirstOrDefault();
                        }

                        return alienations;

                    }
                    else
                    { //Lista Vacia
                        return new List<Alienation>();
                    }
                }
            catch (Exception ex)
            {
                throw new HttpResponseException(ex.Message);
            }
        }

        #endregion

        #region GET api/Alienations/Distributor/J312171197
        [HttpGet("Distributor/{rif}")]
        public async Task<IEnumerable<Alienation>> GetAlienationsByDistr([FromRoute] string rif)
        {
            try
            {
                var distributor = _context.Sisg_Distributors.Where(d => d.rif == rif).FirstOrDefault();

                if (distributor != null)
                {
                    var alienations = await _context.Sisg_Alienations.Where(a => a.DistributorId == distributor.id).ToListAsync();

                    foreach (Alienation a in alienations)
                    {
                        a.provider = _context.Sisg_Providers.Where(p => p.id == a.ProviderId).FirstOrDefault();
                        a.distributor = _context.Sisg_Distributors.Where(d => d.id == a.DistributorId).FirstOrDefault();
                        a.FinalClient = _context.Sisg_FinalsClients.Where(f => f.id == a.FinalClientId).FirstOrDefault();
                    }

                    return alienations;

                }else
                { //Lista Vacia
                    return new List<Alienation>();
                }

            }
            catch (Exception ex)
            {
                throw new HttpResponseException(ex.Message);
            }
        }

        #endregion

        #region GET api/Alienations/ByDate/2020-01-01
        [HttpGet("ByDate/{date}")]
        public async Task<IEnumerable<Alienation>> GetAlienationsByDate([FromRoute] string date)
        {
            try
            {
                DateTime datePeriod = Convert.ToDateTime(date);

                var alienations = await _context.Sisg_Alienations.Where(a => a.AlienationDate >= datePeriod).ToListAsync();

                if (alienations != null)
                {                   
                    foreach (Alienation a in alienations)
                    {
                        a.provider = _context.Sisg_Providers.Where(p => p.id == a.ProviderId).FirstOrDefault();
                        a.distributor = _context.Sisg_Distributors.Where(d => d.id == a.DistributorId).FirstOrDefault();
                        a.FinalClient = _context.Sisg_FinalsClients.Where(f => f.id == a.FinalClientId).FirstOrDefault();
                    }

                    return alienations;

                }
                else
                { //Lista Vacia
                    return new List<Alienation>();
                }

            }
            catch (Exception ex)
            {
                throw new HttpResponseException(ex.Message);
            }
        }

        #endregion

        #region POST api/Alienations

        [HttpPost]
        public async Task<IActionResult> PostSisg_Alienations([FromBody] Alienation alienation)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                //Consultamos existencia Serial Vendido de Maquina Fiscal con Distribuidor
                var serialfp = await _context.Sisg_SerialsProducts.Where(s => s.Serial == alienation.Serial ).FirstOrDefaultAsync();   //&& s.DistributorId == alienation.DistributorId

                if (serialfp == null)
                {
                    return Ok("El Serial de la Máquina Fiscal que se pretende enajenar no se encuentra en ningun registro de Proveedor. Verifique que su correcta denominación.");
                }

                //Validamos que el Serial no tenga una Enajenacion previa
                var alien = await _context.Sisg_Alienations.Where(a => a.Serial == alienation.Serial).FirstOrDefaultAsync();

                if(alien != null)
                {
                    return Ok("El Serial de Máquina " + alienation.Serial + " ya fue enajenado anteriormente.");
                }

                 alienation.Creation_Date = DateTime.Now;
                _context.Sisg_Alienations.Add(alienation);

                await _context.SaveChangesAsync();

                return CreatedAtAction("GetSisg_Alienations", new { id = alienation.Id}, alienation);

            }
            catch (Exception ex)
            {
                throw new HttpResponseException(ex.Message);
            }
        }

        #endregion

        #region PUT api/Alienations

        [HttpPut("{id}")]
        public async Task<IActionResult> PutSisg_Alienations([FromRoute] int id, [FromBody] Alienation alienation)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != alienation.Id)
            {
                return BadRequest();
            }

            try
            {
                //Consultamos existencia Serial Vendido de Maquina Fiscal con Distribuidor
                var serialfp = await _context.Sisg_SerialsProducts.Where(s => s.Serial == alienation.Serial).FirstOrDefaultAsync();  //&& s.DistributorId == alienation.DistributorId

                if (serialfp == null)
                {
                    return Ok("El Serial de la Máquina Fiscal que se pretende editar no se encuentra en ningun registro de Proveedor. Verifique que su correcta denominación.");
                }

                //Validamos que el Serial si es editado no tenga una Enajenacion previa
                var alien = await _context.Sisg_Alienations.Where(a => a.Id == alienation.Id).FirstOrDefaultAsync();

                if (alien.Serial != alienation.Serial)
                {
                    alien = await _context.Sisg_Alienations.Where(a => a.Serial == alienation.Serial).FirstOrDefaultAsync();

                    if (alien != null)
                    {
                        return Ok("El Nuevo Serial de Máquina que se pretende editar " + alienation.Serial + " ya fue enajenado anteriormente.");
                    }
                }

                _context.Entry(alien).State = EntityState.Detached;

                _context.Entry(alienation).State = EntityState.Modified;
                
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AlienationExists(id))
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

        #region PUT api/Alienations Anys

        [HttpPut("{providerId}/{periodDate}")]
        public async Task<IActionResult> PutSisg_AlienationsAnys([FromRoute] int providerId, [FromRoute] string periodDate)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (providerId == 0 && periodDate == null)
            {
                return BadRequest();
            }

            try
            {
                DateTime date = DateTime.Parse(periodDate);
                //Consultamos las Enajenaciones para Actualizar
                var alienations = await _context.Sisg_Alienations.Where(a => a.ProviderId == providerId && a.AlienationDate.Year == date.Year && a.AlienationDate.Month == date.Month).ToListAsync();

                if (alienations.Count == 0)
                {

                    return Ok("No se encontraron registros de Enajenaciones con los parámetros solisitados para actualizar.");

                }
                else
                {
                    foreach (Alienation alien in alienations)
                    {
                        // _context.Entry(alien).State = EntityState.Detached;
                        alien.Status = "DECLARADO";
                        alien.Creation_Date = DateTime.Now;

                        _context.Entry(alien).State = EntityState.Modified;
                    }

                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception)
            {             
               throw;              
            }

            return NoContent();
        }

        #endregion

        #region DELETE api/Alienations

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSisg_Alienations([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var alienation = await _context.Sisg_Alienations.FindAsync(id);

            if (alienation == null)
            {
                return NotFound();
            }

            _context.Sisg_Alienations.Remove(alienation);

            await _context.SaveChangesAsync();

            return Ok(alienation);

        }

        #endregion

        #region Alienation Exists
        private bool AlienationExists(int id)
        {
            return _context.Sisg_Alienations.Any(e => e.Id == id);
        }
        #endregion

    }
}