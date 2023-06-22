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
    public class MarksController : ControllerBase
    {
        private readonly ProductsContext _context;

        public MarksController(ProductsContext context)
        {
            _context = context;
        }

        #region  GET: api/Marks
        [HttpGet]
        public IEnumerable <Mark> GetSisg_Marks()
        {
            return _context.Sisg_Marks;
        }
        #endregion

        #region GET: api/Mark/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMark([FromRoute] int id)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var mark = await _context.Sisg_Marks.FindAsync(id);

                if (mark == null)
                {
                    return NotFound();
                }

                return Ok(mark);
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(ex.Message);
            }
        }
        #endregion

        #region POST: api/Mark
        [HttpPost]
        public async Task <IActionResult> PostMark([FromBody] Mark mark)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                mark.creation_date = DateTime.Now;
                _context.Sisg_Marks.Add(mark);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetMark", new { id = mark.Id }, mark);
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(ex.Message);
            }
        }
        #endregion

        #region PUT: api/Mark/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMark([FromRoute] int id, [FromBody] Mark mark)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                if (id != mark.Id)
                {
                    return BadRequest();
                }
                
                mark.creation_date = DateTime.Now;
                _context.Entry(mark).State = EntityState.Modified;

                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MarkExists(id))
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

        private bool MarkExists(int id)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region DELETE: api/Mark/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProvider([FromRoute] int id)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var mark = await _context.Sisg_Marks.FindAsync(id);
                if (mark == null)
                {
                    return NotFound();
                }
                _context.Sisg_Marks.Remove(mark);
                await _context.SaveChangesAsync();

                return Ok(mark);
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(ex.Message);
            }
        }         
        #endregion        
    }
}
