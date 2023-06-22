using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Api_Products.Models;
using Microsoft.AspNetCore.Authorization;
using System.Runtime.Serialization;


namespace Api_Products.Controllers
{
    [Authorize("Bearer")]
    [Route("api/[controller]")]
    [ApiController]
    public class ReplacementsController : ControllerBase
    {
        private readonly ProductsContext _context;

        public ReplacementsController(ProductsContext context)
        {
            _context = context;
        }

        #region GET: api/Replacements
        [HttpGet]
        public IEnumerable<Replacement> GetSisg_Replacements()
        {
            foreach (Replacement rep in _context.Sisg_Replacements.ToList())
            {
                rep.Model = _context.Sisg_Models.Where(md => md.Id == rep.ModelId).FirstOrDefault();
                rep.Prefix = _context.Sisg_Prefixes.Where(pre => pre.id == rep.PrefixId).FirstOrDefault();

                if (rep.Model != null)
                {
                    rep.Model.Mark = _context.Sisg_Marks.Where(m => m.Id == rep.Model.MarkId).FirstOrDefault();
                }
            }

            return _context.Sisg_Replacements;
        }
        #endregion

        #region GET: api/Replacements/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetReplacement([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var replacement = await _context.Sisg_Replacements.FindAsync(id);

            if (replacement == null)
            {
                return NotFound();
            }
            else {

                replacement.Model = _context.Sisg_Models.Where(md => md.Id == replacement.ModelId).FirstOrDefault();
                replacement.Prefix = _context.Sisg_Prefixes.Where(pre => pre.id == replacement.PrefixId).FirstOrDefault();

                if (replacement.Model != null)
                {
                    replacement.Model.Mark = _context.Sisg_Marks.Where(m => m.Id == replacement.Model.MarkId).FirstOrDefault();
                }
            }

            return Ok(replacement);
        }
        #endregion

        #region GET: api/Replacements/5/Replacements
        [HttpGet("{idModel}/Replacements")]
        public IEnumerable<Replacement> GetReplacementsModel([FromRoute] int idModel)
        {
            try
            {
                var listReplacementsModel = _context.Sisg_Replacements.Where(a => a.ModelId == idModel).ToList();
                foreach (Replacement rep in listReplacementsModel)
                {
                    rep.Model = _context.Sisg_Models.Where(m => m.Id == rep.ModelId).FirstOrDefault();
                    rep.Prefix = _context.Sisg_Prefixes.Where(pre => pre.id == rep.PrefixId).FirstOrDefault();
                }
                return listReplacementsModel;
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(ex.Message);
            }
        }
        #endregion

        #region GET: api/ReplacementsByPrefix/Replacements/{PrefixId}
        [HttpGet("ReplacementsByPrefix/Replacements/{PrefixId}")]
        public IActionResult GetReplacementsByPrefix([FromRoute] int PrefixId)
        {
            try
            {
                var replacement = _context.Sisg_Replacements.Where(r => r.PrefixId == PrefixId).FirstOrDefault();

                if (replacement != null)
                {
                    replacement.Prefix = _context.Sisg_Prefixes.Where(pre => pre.id == replacement.PrefixId).FirstOrDefault();
                    replacement.Model = _context.Sisg_Models.Where(mod => mod.Id == replacement.ModelId).FirstOrDefault();

                    if (replacement.Model != null)
                    {
                        replacement.Model.Mark = _context.Sisg_Marks.Where(m => m.Id == replacement.Model.MarkId).FirstOrDefault();
                    }                  
                }

                return Ok(replacement);
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(ex.Message);
            }
        }
        #endregion

        #region PUT: api/Replacements/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutReplacement([FromRoute] int id, [FromBody] Replacement replacement)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != replacement.Id)
            {
                return BadRequest();
            }

            replacement.creation_date = DateTime.Now;
            _context.Entry(replacement).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReplacementExists(id))
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

        #region POST: api/Replacements
        [HttpPost]
        public async Task<IActionResult> PostReplacement([FromBody] Replacement replacement)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            replacement.creation_date = DateTime.Now;
            _context.Sisg_Replacements.Add(replacement);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetReplacement", new { id = replacement.Id }, replacement);
        }
        #endregion

        #region DELETE: api/Replacements/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReplacement([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var replacement = await _context.Sisg_Replacements.FindAsync(id);
            if (replacement == null)
            {
                return NotFound();
            }

            _context.Sisg_Replacements.Remove(replacement);
            await _context.SaveChangesAsync();

            return Ok(replacement);
        }
        #endregion

        private bool ReplacementExists(int id)
        {
            return _context.Sisg_Replacements.Any(e => e.Id == id);
        }
    }
}