using System;
using System.Net;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Api_Employees.Models;
using System.Web.Http;
using System.Runtime.Serialization;
using Microsoft.AspNetCore.Authorization;

namespace Api_Employees.Controllers
{
  /// <summary>
  /// Clase Empleado
  /// </summary>
    [Authorize("Bearer")]
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly EmployeesContext _context;
        /// <summary>
        /// Construtor de la Clase
        /// </summary>
        /// <param name="context"></param>
        public EmployeesController(EmployeesContext context)
        {
            _context = context;
        }

        #region GET api/Employees
        /// <summary>
        /// Obtiene todos los Empleados
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<Employee> GetSisg_Employees()
        {
            try
            {
                foreach (Employee em in _context.Sisg_Employees.ToList())
                {
                    em.departament = _context.Sisg_Departaments.Where(d => d.Id == em.departamentId).FirstOrDefault();

                    em.chargue = _context.Sisg_Chargues.Where(c => c.Id == em.chargueId).FirstOrDefault();
                }

                return _context.Sisg_Employees;
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(ex.Message);
            }
        }
        #endregion

        #region GET api/Employees/5
        /// <summary>
        /// Obtiene un Empleado por ID
        /// </summary>
        /// <param name="id">Identificador</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployees([FromRoute] int id)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var employee = await _context.Sisg_Employees.FindAsync(id);

                if (employee == null)
                {
                    return NotFound();
                }

                return Ok(employee);
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(ex.Message);
            }
            {

            }
        }
        #endregion

        # region PUT: api/Employees/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmployees([FromRoute] int id, [FromBody] Employee employees)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                if (id != employees.id)
                {
                    return BadRequest();
                }

                employees.creation_date = DateTime.Now;
                _context.Entry(employees).State = EntityState.Modified;

                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!employeesExists(id))
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

        private bool employeesExists(int id)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region POST: api/Employees
        /// <summary>
        /// Establece un nuevo Empleado
        /// </summary>
        /// <param name="employees">Empleado</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> PostEmployees([FromBody] Employee employees)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                employees.creation_date = DateTime.Now;
                _context.Sisg_Employees.Add(employees);
                await _context.SaveChangesAsync();

                employees.departament = _context.Sisg_Departaments.Where(d => d.Id == employees.departamentId).FirstOrDefault();
                employees.chargue = _context.Sisg_Chargues.Where(c => c.Id == employees.chargueId).FirstOrDefault();

                return CreatedAtAction("Getemployees", new { id = employees.id }, employees);
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(ex.Message);
            }
        }
        #endregion

        #region DELETE: api/Employees/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Employees([FromRoute] int id)
        {
            try
            {

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var employee = await _context.Sisg_Employees.FindAsync(id);
                if (employee == null)
                {
                    return NotFound();
                }

                _context.Sisg_Employees.Remove(employee);
                await _context.SaveChangesAsync();

                return Ok(employee);
            }
            catch (Exception ex)

            {
                throw new HttpResponseException(ex.Message);
            }
        }
        #endregion

        #region POST: api/Employees/1/2
        [HttpPost("{id}/{idUser}")]
        public async Task<IActionResult> Postemployeesusers([FromRoute] int id, [FromRoute] int idUser)
        {
            try
            {
                //Se crea relación con un User
                EmployeesUsers du = new EmployeesUsers { userId = idUser, employeeId = id };
                _context.Sisg_Employeesusers.Add(du);

                await _context.SaveChangesAsync();

                return Ok(du);
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(ex.Message);
            }
        }
        #endregion

        #region DELETE: api/Employees/1/Users/2
        [HttpDelete("{id}/Users/{idUser}")]
        public async Task<IActionResult> Deleteemployeesusersr([FromRoute] int id, [FromRoute] int idUser)
        {
            try
            {
                //Se borra relación con un User
                var du = _context.Sisg_Employeesusers.Where(e => e.employeeId == id && e.userId == idUser).FirstOrDefault();
                _context.Sisg_Employeesusers.Remove(du);

                await _context.SaveChangesAsync();

                return Ok(du);
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(ex.Message);
            }
        }
        #endregion

        #region GET:EmployersToCharge
        [HttpGet("{id}/Employees")]
        public IEnumerable<Employee> GetEmployersToCharge([FromRoute] int id)
        {
            var sup = _context.Sisg_Employees.Where(s => s.supervitorId == id).ToList();

            List<Employee> employees = new List<Employee>();

            foreach (Employee rm in sup)
            {
                var employee = _context.Sisg_Employees.Find(rm.supervitorId);
            }
            return sup;
        }
        #endregion
    }

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

