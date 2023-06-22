using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Api_Operations.Models;
using static Api_Operations.Controllers.FiscalsOperationsController;
using Microsoft.EntityFrameworkCore;

namespace Api_Operations.Controllers

{
    [Authorize("Bearer")]
    [Route("api/[controller]")]
    [ApiController]
    public class TechnicalsOperationsController : ControllerBase
    {
        private readonly OperationsContext _context;

        public TechnicalsOperationsController(OperationsContext context)
        {
            _context = context;
        }

        #region GET: api/TechnicalsOperations
        [HttpGet]
        public IEnumerable<TechnicalOperationModel> GetSisg_TechnicalsOperations()
        {
            try
            {
                foreach (TechnicalOperationModel to in _context.Sisg_TechnicalsOperations.ToList())
                {
                    to.provider = _context.Sisg_Providers.Where(p => p.id == to.ProviderId).FirstOrDefault();
                    to.distributor = _context.Sisg_Distributors.Where(d => d.id == to.DistributorId).FirstOrDefault();
                    to.finalclient = _context.Sisg_FinalsClients.Where(f => f.id == to.FinalClientId).FirstOrDefault();
                    to.technician = _context.Sisg_Technicians.Where(t => t.id == to.TechnicianId).FirstOrDefault();
                    to.typeOperationTech = _context.Sisg_TypeOperationsTechs.Where(o => o.Id == to.TypeOperationTechId).FirstOrDefault();
                }

                return _context.Sisg_TechnicalsOperations;

            }
            catch (Exception ex)
            {
                throw new HttpResponseException(ex.Message);
            }
        }
        #endregion
                
        #region GET api/TechnicalsOperations/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTechnicalsOperationsById([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var technicaloperation = await _context.Sisg_TechnicalsOperations.FindAsync(id);

            if (technicaloperation == null)
            {
                return NotFound();
            }
            else
            {
                technicaloperation.provider = _context.Sisg_Providers.Where(p => p.id == technicaloperation.ProviderId).FirstOrDefault();
                technicaloperation.distributor = _context.Sisg_Distributors.Where(d => d.id == technicaloperation.DistributorId).FirstOrDefault();
                technicaloperation.finalclient = _context.Sisg_FinalsClients.Where(f => f.id == technicaloperation.FinalClientId).FirstOrDefault();
                technicaloperation.technician = _context.Sisg_Technicians.Where(t => t.id == technicaloperation.TechnicianId).FirstOrDefault();
                technicaloperation.typeOperationTech = _context.Sisg_TypeOperationsTechs.Where(o => o.Id == technicaloperation.TypeOperationTechId).FirstOrDefault();
            }

            return Ok(technicaloperation);

        }


        #endregion

        #region GET api/TechnicalsOperations/BySerial/Z1B4444557
        [HttpGet("BySerial/{serial}")]
        public async Task<IEnumerable<TechnicalOperationModel>> GetTechnicalsOperationsBySerial([FromRoute] string serial)
        {
            try
            {             

                var technicalsoperations = await _context.Sisg_TechnicalsOperations.Where(t => t.Serial == serial).ToListAsync();
                
                if (technicalsoperations == null)
                {
                    return null;
                }
                else
                {
                    foreach (TechnicalOperationModel technicaloperation in technicalsoperations)
                    {
                        technicaloperation.provider = _context.Sisg_Providers.Where(p => p.id == technicaloperation.ProviderId).FirstOrDefault();
                        technicaloperation.distributor = _context.Sisg_Distributors.Where(d => d.id == technicaloperation.DistributorId).FirstOrDefault();
                        technicaloperation.finalclient = _context.Sisg_FinalsClients.Where(f => f.id == technicaloperation.FinalClientId).FirstOrDefault();
                        technicaloperation.technician = _context.Sisg_Technicians.Where(t => t.id == technicaloperation.TechnicianId).FirstOrDefault();
                        technicaloperation.typeOperationTech = _context.Sisg_TypeOperationsTechs.Where(o => o.Id == technicaloperation.TypeOperationTechId).FirstOrDefault();
                    }

                    return technicalsoperations;
                }

            }
            catch (Exception ex)
            {
                throw new HttpResponseException(ex.Message);
            }
        }

        #endregion

        #region GET api/TechnicalsOperations/ByProviderId/1
        [HttpGet("ByProviderId/{id}")]
        public IEnumerable<TechnicalOperationModel> GetSisg_TechnicalsOperationsByProviderId([FromRoute] int id)
        {
            try
            {

                var technicaloperation = _context.Sisg_TechnicalsOperations.Where(to => to.ProviderId == id).ToList();

                foreach (TechnicalOperationModel to in technicaloperation)
                {
                    to.provider = _context.Sisg_Providers.Where(p => p.id == to.ProviderId).FirstOrDefault();
                    to.distributor = _context.Sisg_Distributors.Where(d => d.id == to.DistributorId).FirstOrDefault();
                    to.finalclient = _context.Sisg_FinalsClients.Where(f => f.id == to.FinalClientId).FirstOrDefault();
                    to.technician = _context.Sisg_Technicians.Where(t => t.id == to.TechnicianId).FirstOrDefault();
                    to.typeOperationTech = _context.Sisg_TypeOperationsTechs.Where(o => o.Id == to.TypeOperationTechId).FirstOrDefault();
                }

                return technicaloperation;

            }
            catch (Exception ex)
            {
                throw new HttpResponseException(ex.Message);
            }
        }
        #endregion

        #region GET api/TechnicalsOperations/FinalClient/J314310895
        [HttpGet("FinalClient/{rif}")]
        public async Task<IEnumerable<TechnicalOperationModel>> GetTechnicalsOperationsByFinald([FromRoute] string rif)
        {
            try
            {
                var finalclient = _context.Sisg_FinalsClients.Where(fc => fc.rif == rif).FirstOrDefault();

                if (finalclient != null)
                {
                    var technicalsoperations = await _context.Sisg_TechnicalsOperations.Where(to => to.FinalClientId == finalclient.id).ToListAsync();

                    foreach (TechnicalOperationModel to in technicalsoperations)
                    {
                        to.provider = _context.Sisg_Providers.Where(p => p.id == to.ProviderId).FirstOrDefault();
                        to.distributor = _context.Sisg_Distributors.Where(d => d.id == to.DistributorId).FirstOrDefault();
                        to.finalclient = _context.Sisg_FinalsClients.Where(f => f.id == to.FinalClientId).FirstOrDefault();
                        to.technician = _context.Sisg_Technicians.Where(t => t.id == to.TechnicianId).FirstOrDefault();
                        to.typeOperationTech = _context.Sisg_TypeOperationsTechs.Where(o => o.Id == to.TypeOperationTechId).FirstOrDefault();
                    }

                    return technicalsoperations;

                }
                else
                { //Lista Vacia
                    return new List<TechnicalOperationModel>();
                }
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(ex.Message);
            }
        }

        #endregion

        #region GET api/TechnicalsOperations/Distributor/J312171197
        [HttpGet("Distributor/{rif}")]
        public async Task<IEnumerable<TechnicalOperationModel>> GetSisg_TechnicalsOperationsByDistr([FromRoute] string rif)
        {
            try
            {
                var distributor = _context.Sisg_Distributors.Where(d => d.rif == rif).FirstOrDefault();

                if (distributor != null)
                {
                    var technicalsoperations = await _context.Sisg_TechnicalsOperations.Where(to => to.DistributorId == distributor.id).ToListAsync();

                    foreach (TechnicalOperationModel to in technicalsoperations)
                    {
                        to.provider = _context.Sisg_Providers.Where(p => p.id == to.ProviderId).FirstOrDefault();
                        to.distributor = _context.Sisg_Distributors.Where(d => d.id == to.DistributorId).FirstOrDefault();
                        to.finalclient = _context.Sisg_FinalsClients.Where(f => f.id == to.FinalClientId).FirstOrDefault();                        
                        to.technician = _context.Sisg_Technicians.Where(t => t.id == to.TechnicianId).FirstOrDefault();
                        to.typeOperationTech = _context.Sisg_TypeOperationsTechs.Where(o => o.Id == to.TypeOperationTechId).FirstOrDefault();
                    }

                    return technicalsoperations;

                }
                else
                { //Lista Vacia
                    return new List<TechnicalOperationModel>();
                }

            }
            catch (Exception ex)
            {
                throw new HttpResponseException(ex.Message);
            }
        }

        #endregion

        #region GET api/TechnicalsOperations/Technical/V145264164
        [HttpGet("Technical/{rif}")]
        public async Task<IEnumerable<TechnicalOperationModel>> GetSisg_TechnicalsOperationsByTech([FromRoute] string rif)
        {
            try
            {
                var technical = _context.Sisg_Technicians.Where(t => t.rif == rif).FirstOrDefault();

                if (technical != null)
                {
                    var technicalsoperations = await _context.Sisg_TechnicalsOperations.Where(to => to.TechnicianId == technical.id).ToListAsync();

                    foreach (TechnicalOperationModel to in technicalsoperations)
                    {
                        to.provider = _context.Sisg_Providers.Where(p => p.id == to.ProviderId).FirstOrDefault();
                        to.distributor = _context.Sisg_Distributors.Where(d => d.id == to.DistributorId).FirstOrDefault();
                        to.finalclient = _context.Sisg_FinalsClients.Where(f => f.id == to.FinalClientId).FirstOrDefault();
                        to.technician = _context.Sisg_Technicians.Where(t => t.id == to.TechnicianId).FirstOrDefault();
                        to.typeOperationTech = _context.Sisg_TypeOperationsTechs.Where(o => o.Id == to.TypeOperationTechId).FirstOrDefault();
                    }

                    return technicalsoperations;

                }
                else
                { //Lista Vacia
                    return new List<TechnicalOperationModel>();
                }

            }
            catch (Exception ex)
            {
                throw new HttpResponseException(ex.Message);
            }
        }

        #endregion

        #region GET api/TechnicalsOperations/ByDate/2020-01-01
        [HttpGet("ByDate/{date}")]
        public async Task<IEnumerable<TechnicalOperationModel>> GetTechnicalsOperationsByDate([FromRoute] string date)
        {
            try
            {
                DateTime datePeriod = Convert.ToDateTime(date);

                var technicalsoperations = await _context.Sisg_TechnicalsOperations.Where(to => to.Operation_Date >= datePeriod).ToListAsync();

                if (technicalsoperations != null)
                {
                    foreach (TechnicalOperationModel to in technicalsoperations)
                    {
                        to.provider = _context.Sisg_Providers.Where(p => p.id == to.ProviderId).FirstOrDefault();
                        to.distributor = _context.Sisg_Distributors.Where(d => d.id == to.DistributorId).FirstOrDefault();
                        to.finalclient = _context.Sisg_FinalsClients.Where(f => f.id == to.FinalClientId).FirstOrDefault();
                        to.technician = _context.Sisg_Technicians.Where(t => t.id == to.TechnicianId).FirstOrDefault();
                        to.typeOperationTech = _context.Sisg_TypeOperationsTechs.Where(o => o.Id == to.TypeOperationTechId).FirstOrDefault();
                    }

                    return technicalsoperations;

                }
                else
                { //Lista Vacia
                    return new List<TechnicalOperationModel>();
                }

            }
            catch (Exception ex)
            {
                throw new HttpResponseException(ex.Message);
            }
        }

        #endregion

        #region POST: api/TechnicalsOperations

        [HttpPost]
        public async Task<IActionResult> PostTechnicalsOperations([FromBody] TechnicalOperationModel technicaloperation)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                //Consultamos existencia Serial Vendido de Máquina Fiscal 
                var serialfp = await _context.Sisg_SerialsProducts.Where(s => s.Serial == technicaloperation.Serial).FirstOrDefaultAsync();

                if (serialfp == null)
                {
                    return Ok("El Serial de la Máquina Fiscal no esta en registro de proveedor");
                }else
                {  //Verifico Status y Relacion con Distribuidor
                    var distributor = _context.Sisg_Distributors.Find(serialfp.DistributorId);

                    if (distributor.enable == 0)
                    {
                       // return Ok("El representante Distribuidor que Enajenó la Máquina Fiscal se encuentra Inactivo. Comuníquese con el departamento de soporte The Factory HKA para mas información.");
                    }
                    else
                    { //Verifico Relacion con Distribuidor y Tecnico
                        var techDist = _context.Sisg_TechniciansDistributors.Where(td => td.techniciansId == technicaloperation.TechnicianId && distributor.id == td.distributorsId).FirstOrDefault();

                        if(techDist == null)
                        {
                           // return Ok("El Técnico que intenta hacer la declaración no tiene relación con el representante Distribuidor que enajeno la Máquina Fiscal del serial suministrado. Comuníquese con el departamento de soporte The Factory HKA para mas información.");
                        }
                    }
                }

                technicaloperation.Creation_Date = DateTime.Now;
                _context.Sisg_TechnicalsOperations.Add(technicaloperation);

                await _context.SaveChangesAsync();

                return CreatedAtAction("GetSisg_TechnicalsOperations", new { id = technicaloperation.Id }, technicaloperation);

            }
            catch (Exception ex)
            {
                throw new HttpResponseException(ex.Message);
            }
        }

        #endregion

        #region PUT api/TechnicalsOperations

        [HttpPut("{id}")]
        public async Task<IActionResult> PutSisg_TechnicalsOperations([FromRoute] int id, [FromBody] TechnicalOperationModel technicaloperation)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != technicaloperation.Id)
            {
                return BadRequest();
            }

            try
            {
                //Consultamos existencia Serial Vendido de Máquina Fiscal 
                var serialfp = await _context.Sisg_SerialsProducts.Where(s => s.Serial == technicaloperation.Serial).FirstOrDefaultAsync();

                if (serialfp == null)
                {
                    return Ok("El Serial de la Máquina Fiscal que se pretende editar no esta en registro de proveedor");
                }
                else
                {  //Verifico Status y Relacion con Distribuidor
                    var distributor = _context.Sisg_Distributors.Find(serialfp.DistributorId);

                    if (distributor.enable == 0)
                    {
                       // return Ok("El representante Distribuidor que Enajenó la Máquina Fiscal se encuentra Inactivo. Comuníquese con el departamento de soporte The Factory HKA para mas información.");
                    }
                    else
                    { //Verifico Relacion con Distribuidor y Tecnico
                        var techDist = _context.Sisg_TechniciansDistributors.Where(td => td.techniciansId == technicaloperation.TechnicianId && distributor.id == td.distributorsId).FirstOrDefault();

                        if (techDist == null)
                        {
                          //  return Ok("El Tecnico que intenta hacer la declaración no tiene relación con el representante Distribuidor que enajeno la Máquina Fiscal del serial suministrado. Comuníquese con el departamento de soporte The Factory HKA para mas información.");
                        }
                    }
                }

                _context.Entry(technicaloperation).State = EntityState.Modified;

                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TechnicalOperationExists(id))
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

        #region PUT api/TechnicalsOperations Anys

        [HttpPut("{providerId}/{periodDate}")]
        public async Task<IActionResult> PutSisg_TechnicalsOperationsAnys([FromRoute] int providerId, [FromRoute] string periodDate)
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
                var operatiosTechs = await _context.Sisg_TechnicalsOperations.Where(ot => ot.ProviderId == providerId && ot.Operation_Date.Year == date.Year && ot.Operation_Date.Month == date.Month).ToListAsync();

                if (operatiosTechs.Count == 0)
                {

                    return Ok("No se encontraron registros de Operaciones Tecnicas con los parametros solisitados para actualizar.");

                }
                else
                {
                    foreach (TechnicalOperationModel opetec in operatiosTechs)
                    {
                        // _context.Entry(alien).State = EntityState.Detached;
                        opetec.Status = "DECLARADO";
                        opetec.Creation_Date = DateTime.Now;

                        _context.Entry(opetec).State = EntityState.Modified;
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

        #region DELETE api/TechnicalsOperations

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSisg_TechnicalsOperations([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var technicaloperation = await _context.Sisg_TechnicalsOperations.FindAsync(id);

            if (technicaloperation == null)
            {
                return NotFound();
            }

            _context.Sisg_TechnicalsOperations.Remove(technicaloperation);

            await _context.SaveChangesAsync();

            return Ok(technicaloperation);

        }

        #endregion

        #region TechnicalOperation Exists
        private bool TechnicalOperationExists(int id)
        {
            return _context.Sisg_TechnicalsOperations.Any(e => e.Id == id);
        }
        #endregion
    }
}
