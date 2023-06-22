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
    public class ModelsController : ControllerBase
    {
        private readonly ProductsContext _context;

        public ModelsController(ProductsContext context)
        {
            _context = context;
        }

        #region GET: api/Models
        [HttpGet]
        public IEnumerable<Model> GetSisg_Models()
        {
           
            foreach (Model mod in _context.Sisg_Models.ToList())
            {
                mod.Mark = _context.Sisg_Marks.Where(m => m.Id == mod.MarkId).FirstOrDefault();
            }

            return _context.Sisg_Models;
        }
        #endregion

        #region GET: api/Models/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetModel([FromRoute] int id)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var model = await _context.Sisg_Models.FindAsync(id);

                if (model == null)
                {
                    return NotFound();
                }
                else {
                    model.Mark = _context.Sisg_Marks.Where(m => m.Id == model.MarkId).FirstOrDefault();
                }

                return Ok(model);
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(ex.Message);
            }
        }

        #endregion

        #region GET: api/Models/5/Models
        [HttpGet("{idMark}/Models")]
        public IEnumerable<Model> GetModelsMark([FromRoute] int idMark)
        {
            try
            {
                var listModelsMark = _context.Sisg_Models.Where(a => a.MarkId == idMark).ToList();
                foreach (Model mod in listModelsMark)
                {
                    mod.Mark = _context.Sisg_Marks.Where(m => m.Id == mod.MarkId).FirstOrDefault();
                }
                return listModelsMark;
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(ex.Message);
            }
        }
        #endregion

        #region POST: api/Models
        [HttpPost]
        public async Task<IActionResult> PostModel([FromBody] Model model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                model.creation_date = DateTime.Now;
                _context.Sisg_Models.Add(model);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetModel", new { id = model.Id }, model);
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(ex.Message);
            }
        }
        #endregion

        #region PUT: api/Models/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutModel([FromRoute] int id, [FromBody] Model model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                if (id != model.Id)
                {
                    return BadRequest();
                }

                model.creation_date = DateTime.Now;
                _context.Entry(model).State = EntityState.Modified;

                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ModelExists(id))
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

        private bool ModelExists(int id)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region DELETE: api/Models/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProvider([FromRoute] int id)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var model = await _context.Sisg_Models.FindAsync(id);
                if (model == null)
                {
                    return NotFound();
                }

                _context.Sisg_Models.Remove(model);
                await _context.SaveChangesAsync();

                return Ok(model);
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(ex.Message);
            }
        }
        #endregion

        
    }

}
