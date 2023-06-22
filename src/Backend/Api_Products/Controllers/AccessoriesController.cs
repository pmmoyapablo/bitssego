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
    public class AccessoriesController : ControllerBase
    {
        private readonly ProductsContext _context;

        public AccessoriesController(ProductsContext context)
        {
            _context = context;
        }

        #region GET: api/Accessories
        [HttpGet]
        public IEnumerable<Accessory> GetSisg_Accessories()
        {
            return _context.Sisg_Accessories;
        }
        #endregion

        #region GET: api/Accessories/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAccessory([FromRoute] int id)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var accessory = await _context.Sisg_Accessories.FindAsync(id);

                if (accessory == null)
                {
                    return NotFound();
                }

                return Ok(accessory);
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(ex.Message);
            }
        }
        #endregion

        #region POST: api/Accessories
        [HttpPost]
        public async Task<IActionResult> PostAccessory([FromBody] Accessory accessory)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                accessory.creation_date = DateTime.Now;
                _context.Sisg_Accessories.Add(accessory);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetAccessory", new { id = accessory.Id }, accessory);
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(ex.Message);
            }
        }
        #endregion

        #region PUT: api/Accessories/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutModel([FromRoute] int id, [FromBody] Accessory model)
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

        #region DELETE: api/Accessories/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAccessory([FromRoute] int id)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var accessory = await _context.Sisg_Accessories.FindAsync(id);
                if (accessory == null)
                {
                    return NotFound();
                }

                _context.Sisg_Accessories.Remove(accessory);
                await _context.SaveChangesAsync();

                return Ok(accessory);
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(ex.Message);
            }
        }
        #endregion
    }
}
