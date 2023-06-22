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
    public class SerialsReplacementsController : ControllerBase
    {
        private readonly OperationsContext _context;

        public SerialsReplacementsController(OperationsContext context)
        {
            _context = context;
        }

        #region GET api/SerialsReplacements
        [HttpGet]
        public IEnumerable<SerialReplacement> GetSisg_Serials()
        {
            try
            {
                foreach (SerialReplacement sr in _context.Sisg_SerialsReplacements.ToList())
                {

                    sr.replacement = _context.Sisg_Replacements.Where(r => r.Id == sr.ReplacementId).FirstOrDefault();

                    if (sr.replacement != null)
                    {
                        sr.replacement.Model = _context.Sisg_Models.Where(m => m.Id == sr.replacement.ModelId).FirstOrDefault();

                        if (sr.replacement.Model != null)
                        {
                            sr.replacement.Model.Mark = _context.Sisg_Marks.Where(mk => sr.replacement.Model.MarkId == mk.Id).FirstOrDefault();
                        }
                        sr.replacement.Prefix = _context.Sisg_Prefixes.Where(p => p.id == sr.replacement.PrefixId).FirstOrDefault();
                    }



                    sr.provider = _context.Sisg_Providers.Where(p => p.id == sr.ProviderId).FirstOrDefault();

                    sr.distributor = _context.Sisg_Distributors.Where(d => d.id == sr.DistributorId).FirstOrDefault();
                }

                return _context.Sisg_SerialsReplacements;
                

            }catch (Exception ex)
            {
                throw new HttpResponseException(ex.Message);
            }
        }
        #endregion

        #region GET api/SerialsReplacements/BySerial/F05E8D00F45
        [HttpGet("BySerial/{serial}")]
        public async Task<IActionResult> GetSerialsReplacements([FromRoute] string serial)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var serialfr = await _context.Sisg_SerialsReplacements.Where(s => s.Serial == serial).FirstOrDefaultAsync();

                if (serialfr == null)
                {
                    return Ok(null);
                }
                else
                {
                    serialfr.replacement = _context.Sisg_Replacements.Where(p => p.Id == serialfr.ReplacementId).FirstOrDefault();

                    if (serialfr.replacement != null)
                    {                     
                        serialfr.replacement.Model = _context.Sisg_Models.Where(m => serialfr.replacement.ModelId == m.Id).FirstOrDefault();

                        if (serialfr.replacement.Model != null)
                        {
                            serialfr.replacement.Model.Mark = _context.Sisg_Marks.Where(mk => serialfr.replacement.Model.MarkId == mk.Id).FirstOrDefault();
                        }
                        serialfr.replacement.Prefix = _context.Sisg_Prefixes.Where(px => serialfr.replacement.PrefixId == px.id).FirstOrDefault();
                    }

                    serialfr.provider = _context.Sisg_Providers.Where(pro => pro.id == serialfr.ProviderId).FirstOrDefault();
                    serialfr.distributor = _context.Sisg_Distributors.Where(d => d.id == serialfr.DistributorId).FirstOrDefault();

                    return Ok(serialfr);
                }

            }
            catch (Exception ex)
            {
                //return StatusCode(500,ex.Message);
                throw new HttpResponseException(ex.Message);
            }

        }

        #endregion

        #region GET api/SerialsReplacements/5

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSerialsReplacement([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var serial = await _context.Sisg_SerialsReplacements.FindAsync(id);

            if (serial == null)
            {
                return NotFound();
            }
            else
            {
                serial.replacement = _context.Sisg_Replacements.Where(r => r.Id == serial.ReplacementId).FirstOrDefault();


                if (serial.replacement != null)
                {
                    serial.replacement.Model = _context.Sisg_Models.Where(m => m.Id == serial.replacement.ModelId).FirstOrDefault();

                    if (serial.replacement.Model != null)
                    {
                        serial.replacement.Model.Mark = _context.Sisg_Marks.Where(mk => serial.replacement.Model.MarkId == mk.Id).FirstOrDefault();
                    }
                    serial.replacement.Prefix = _context.Sisg_Prefixes.Where(p => p.id == serial.replacement.PrefixId).FirstOrDefault();
                }


                serial.provider = _context.Sisg_Providers.Where(p => p.id == serial.ProviderId).FirstOrDefault();

                serial.distributor = _context.Sisg_Distributors.Where(d => d.id == serial.DistributorId).FirstOrDefault();

            }


            return Ok(serial);
        }

        #endregion

        #region PUT api/SerialsReplacements
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSisg_Serials([FromRoute] int id, [FromBody] SerialReplacement serial)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != serial.Id)
            {
                return BadRequest();
            }

            _context.Entry(serial).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SerialExists(id))
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

        #region POST api/Serials/Replacements
        [HttpPost]
        public async Task<IActionResult> PostSisg_Serials([FromBody] SerialReplacement serial)
        {

            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                serial.Creation_Date = DateTime.Now;
                _context.Sisg_SerialsReplacements.Add(serial);

                await _context.SaveChangesAsync();

                return CreatedAtAction("GetSisg_Serials", new { id = serial.Id }, serial);
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(ex.Message);
            }
        }

        #endregion

        #region DELETE api/SerialsReplacements

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSisg_Serials([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var serial = await _context.Sisg_SerialsReplacements.FindAsync(id);

            if (serial == null)
            {
                return NotFound();
            }

            _context.Sisg_SerialsReplacements.Remove(serial);

            await _context.SaveChangesAsync();

            return Ok(serial);
        }

        #endregion

        #region Serial Exists
        private bool SerialExists(int id)
        {
            return _context.Sisg_SerialsReplacements.Any(e => e.Id == id);
        }

        #endregion
    }
}
 