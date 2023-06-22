using System;
using System.Net;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Web.Http;
using System.Runtime.Serialization;
using Microsoft.AspNetCore.Authorization;
using Api_Operations.Models;
using System.Security.Cryptography;
using System.Text;

namespace Api_Operations.Controllers
{
    [Authorize("Bearer")]
    [Route("api/[controller]")]
    [ApiController]
    public class ReplacementsOpeTechsController : ControllerBase
    {

        private readonly OperationsContext _context;

        public ReplacementsOpeTechsController(OperationsContext context)
        {
            _context = context;
        }

        #region GET api/ReplacementsOpeTechs
        [HttpGet]
        public IEnumerable<ReplacementOpeTech> GetSisg_ReplacementsOpeTechs()
        {
            //try
            //{
            //    foreach (ReplacementOpeTech rt in _context.Sisg_ReplacementsOpeTechs.ToList())
            //    {
                    //rt.TechnicalOperationModel = _context.Sisg_TechnicalsOperations.Where(to => rt.Id == rt.OperationTechId).FirstOrDefault();

                    //if (rt.TechnicalOperationModel != null)
                    //{
                    //    rt.TechnicalOperationModel.provider = _context.Sisg_Providers.Where(p => p.id == rt.TechnicalOperationModel.ProviderId).FirstOrDefault();
                    //    rt.TechnicalOperationModel.distributor = _context.Sisg_Distributors.Where(d => d.id == rt.TechnicalOperationModel.DistributorId).FirstOrDefault();
                    //    rt.TechnicalOperationModel.finalclient = _context.Sisg_FinalsClients.Where(f => f.id == rt.TechnicalOperationModel.FinalClientId).FirstOrDefault();
                    //    rt.TechnicalOperationModel.technician = _context.Sisg_Technicians.Where(t => t.id == rt.TechnicalOperationModel.TechnicianId).FirstOrDefault();
                    //    rt.TechnicalOperationModel.typeOperationTech = _context.Sisg_TypeOperationsTechs.Where(o => o.Id == rt.TechnicalOperationModel.TypeOperationTechId).FirstOrDefault();
                    //}
                    //rt.Replacement = _context.Sisg_Replacements.Where(sr => rt.Id == rt.ReplacementId).FirstOrDefault();
                //}
                return _context.Sisg_ReplacementsOpeTechs;
            //}

            //catch (Exception ex)
            //{
            //    throw new HttpResponseException(ex.Message);
            //}
        }
        #endregion

        #region GET api/ReplacementsOpeTechs/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetReplacementOpeTech([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var ReplacementOpeTech = await _context.Sisg_ReplacementsOpeTechs.FindAsync(id);

            if (ReplacementOpeTech == null)
            {
                return NotFound();
            }

            return Ok(ReplacementOpeTech);
        }
        #endregion

        #region GET api/ReplacementsOpeTechs/BySerial/F012123223A
        [HttpGet("BySerial/{serial}")]
        public async Task<IActionResult> GetReplacementOpeTechBySerial([FromRoute] string serial)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var ReplacementOpeTech = await _context.Sisg_ReplacementsOpeTechs.Where(rt => rt.Serial == serial).FirstOrDefaultAsync();

            if (ReplacementOpeTech == null)
            {
                return Ok(null);
            }

            return Ok(ReplacementOpeTech);
        }
        #endregion

        #region PUT api/ReplacementsOpeTechs
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSisg_ReplacementsOpeTechs([FromRoute] int id, [FromBody] ReplacementOpeTech replacementOpeTech)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != replacementOpeTech.Id)
            {
                return BadRequest();
            }

            replacementOpeTech.Date = DateTime.Now;
            _context.Entry(replacementOpeTech).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReplacementsOpeTechsExists(id))
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

        #region POST  api/ReplacementsOpeTechs
        [HttpPost]
        public async Task<IActionResult> PostSisg_ReplacementsOpeTechs([FromBody] ReplacementOpeTech replacementOpeTech)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                replacementOpeTech.Date = DateTime.Now;
                _context.Sisg_ReplacementsOpeTechs.Add(replacementOpeTech);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetReplacementOpeTech", new { id = replacementOpeTech.Id }, replacementOpeTech);
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(ex.Message);
            }
        }
        #endregion

        #region DELETE api/ReplacementsOpeTechs
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSisg_ReplacementsOpeTechs([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var replacementsOpeTechs = await _context.Sisg_ReplacementsOpeTechs.FindAsync(id);

            if (replacementsOpeTechs == null)
            {
                return NotFound();
            }

            _context.Sisg_ReplacementsOpeTechs.Remove(replacementsOpeTechs);
            await _context.SaveChangesAsync();

            return Ok(replacementsOpeTechs);
        }

        #endregion

        #region ReplacementsOpeTechs Exists
        private bool ReplacementsOpeTechsExists(int id)
        {
            return _context.Sisg_ReplacementsOpeTechs.Any(e => e.Id == id);
        }
        #endregion

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
}