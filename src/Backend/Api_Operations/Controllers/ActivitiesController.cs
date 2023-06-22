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
using Api_Employees.Models;
using System.Security.Cryptography;

namespace Api_Operations.Controllers
{
  /// <summary>
  /// Controlador Actividades
  /// </summary>
    [Authorize("Bearer")]
    [Route("api/[controller]")]
    [ApiController]
    public class ActivitiesController : ControllerBase
    {

        private readonly OperationsContext _context;
     
        public ActivitiesController(OperationsContext context)
        {
            _context = context;
        }

        #region GET api/Activities
        /// <summary>
        /// Retorna todas las Actividades
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<Activity> GetSisg_Activities()
        {
            try
            {
                foreach (Activity a in _context.Sisg_Activities.ToList())
                {
                    a.employee = _context.Sisg_Employees.Where(e => e.id == a.EmployeeId).FirstOrDefault();
                  
                    if (a.employee != null)
                    {                       
                        a.employee.departament = _context.Sisg_Departaments.Where(d => d.Id == a.employee.departamentId).FirstOrDefault();
                        a.employee.chargue = _context.Sisg_Chargues.Where(c => c.Id == a.employee.chargueId).FirstOrDefault();
                    }
                }
                   return _context.Sisg_Activities;
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(ex.Message);
            }
        }
        #endregion

        #region GET api/Activities/1
        [HttpGet("{id}")]
        public async Task<IActionResult> GetActivity([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var activity = await _context.Sisg_Activities.FindAsync(id);

            if (activity == null)
            {
                return NotFound();
            }
            else
            {
                activity.employee = _context.Sisg_Employees.Where(e => e.id == activity.EmployeeId).FirstOrDefault();

                if (activity.employee != null)
                {
                    activity.employee.departament = _context.Sisg_Departaments.Where(d => d.Id == activity.employee.departamentId).FirstOrDefault();
                    activity.employee.chargue = _context.Sisg_Chargues.Where(c => c.Id == activity.employee.chargueId).FirstOrDefault();
                }
            }
            return Ok(activity);
        }
        #endregion

        #region POST: api/Activities
        [HttpPost]
        public async Task<IActionResult> PostActivities([FromBody] Activity activities)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                activities.OperationDate = DateTime.Now;
                _context.Sisg_Activities.Add(activities);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetActivity", new { id = activities.Id }, activities);
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(ex.Message);
            }
        }
        #endregion

        #region Activity Exists
        private bool ActivityExists(int id)
        {
            return _context.Sisg_Activities.Any(e => e.Id == id);
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