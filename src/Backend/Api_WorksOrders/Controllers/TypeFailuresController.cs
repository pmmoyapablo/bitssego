using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Api_WorksOrders.Models;
using System.Runtime.Serialization;

namespace Api_WorksOrders.Controllers
{
    [Authorize("Bearer")]
    [Route("api/[controller]")]
    [ApiController]
    public class TypeFailuresController : Controller
    {
        private readonly WorksOrdersContext _context;

        public TypeFailuresController(WorksOrdersContext context)
        {
            _context = context;
        }

        #region // GET: api/TypeFailures
        /// <summary>
        /// Retorna todos los Tipos de Fallas
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<TypeFailure> GetSisg_TypeFailures()
        {
            return _context.Sisg_TypesFailures.ToList();
        }
        #endregion

        #region // GET: api/TypeFailures/5
        /// <summary>
        /// Retorna un Tipo de Falla por su ID
        /// </summary>
        /// <param name="id">Id de Falla</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTypeFailures([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var typeFailure = await _context.Sisg_TypesFailures
                .FindAsync(id);

            if (typeFailure == null)
            {
                return NotFound();
            }

            return Ok(typeFailure);
        }
        #endregion

        #region // POST: api/TypeFailures 
        /// <summary>
        /// Crea un Nuevo Tipo de Falla
        /// </summary>
        /// <param name="typefailure">JSON</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> PostTypeFailures([FromBody] TypeFailure typefailure)
        {  
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                typefailure.creation_date = DateTime.Now;
                _context.Sisg_TypesFailures.Add(typefailure);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetTypeFailures", new { id = typefailure.Id }, typefailure);
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(ex.Message);
            }
        }
        #endregion

        #region // PUT: api/TypeFailures/5
        /// <summary>
        /// Actualiza un Tipo de Falla
        /// </summary>
        /// <param name="id"></param>
        /// <param name="typefailure">JSON</param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTypeFailures([FromRoute] int id,[FromBody] TypeFailure typefailure)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                if(id != typefailure.Id)
                {
                    return BadRequest();
                }
                typefailure.creation_date = DateTime.Now;
                _context.Entry(typefailure).State = EntityState.Modified;

                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException) when (!TypeFailureExist(id))
                {
                    return NotFound();
                }

                return NoContent();
            }            
            catch (Exception ex)
            {
                throw new HttpResponseException(ex.Message);
            }
        }

        private bool TypeFailureExist(long id) =>
        _context.Sisg_TypesFailures.Any(e => e.Id == id);
        #endregion

        #region // DELETE: api/TypeFailures/5
        /// <summary>
        /// Elimina un Tipo de Falla
        /// </summary>
        /// <param name="id">ID de Falla a Borrar</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTypeFailures([FromRoute] int id)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var failure = await _context.Sisg_TypesFailures.FindAsync(id);
                if (failure==null)
                {
                    return NotFound();
                }
                _context.Sisg_TypesFailures.Remove(failure);
                await _context.SaveChangesAsync();

                return Ok(failure);
            }
            catch (Exception ex)
            {

                throw new HttpResponseException(ex.Message);
            }
        }
        #endregion
    }

    #region HttpResponseException
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
