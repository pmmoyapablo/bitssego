using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Api_WorksOrders.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace Api_WorksOrders.Controllers
{
    [Authorize("Bearer")]
    [Route("api/[controller]")]
    [ApiController]
    public class WorkshopOrderController : ControllerBase
    {
        private readonly WorksOrdersContext _context;

        public WorkshopOrderController(WorksOrdersContext context)
        {
            _context = context;

        }
        #region // GET: api/WorkshopOrder
        /// <summary>
        /// Retorna todas las ordenes de Taller
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<WorkshopOrder> GetSisg_WorkshopOrders()
        {
            try
            {
              var listordes = _context.Sisg_WorkshopOrders
                .Include(d => d.Distributor)
                        .Include(t => t.TypeFailure)
                        .Include(s => s.StatesOrder)
                        .Include(x => x.DeliveryOrder)
                        .Include(e => e.Employee)
                        .Include(w => w.Warranty)
                .ToList();
          
                return listordes;
              
            }
            catch (Exception ex)
            {

              if (ex.InnerException != null)
                throw ex.InnerException;
              else
                throw ex;
            }
    }
        #endregion

        #region // GET: api/WorkshopOrder/5
        /// <summary>
        /// Retorna una orden de taller por ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}", Name = "Get")]
        public async Task<IActionResult>GetSisg_WorkshopOrder([FromRoute]int id)
        {
          try
          {
            if (!ModelState.IsValid)
            {
              return BadRequest(ModelState);
            }
            var workshopOrder = await _context.Sisg_WorkshopOrders.Where(x => x.Id == id)
                .Include(d => d.Distributor)
                .Include(t => t.TypeFailure)
                .Include(s => s.StatesOrder)
                .Include(x => x.DeliveryOrder)
                .Include(e => e.Employee)
                .Include(w => w.Warranty)
                .FirstOrDefaultAsync();
            if (workshopOrder == null)
            {
              return NotFound();
            }
            return Ok(workshopOrder);
          }
          catch (Exception ex)
          {

            if (ex.InnerException != null)
              throw ex.InnerException;
            else
              throw ex;
          }
        }
        #endregion

        #region // POST: api/WorkshopOrder
        /// <summary>
        /// Crea una orden de Taller
        /// </summary>
        /// <param name="workshopOrder">JSON</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> PostSisg_WorkshopOrder([FromBody] WorkshopOrder workshopOrder)
        {
            var response = new Responce();
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                
                //Validar Status del Distribuidor
                var distributor = await _context.Sisg_Distributors.Where(d => d.id == workshopOrder.DistributorId && d.enable == 1).FirstOrDefaultAsync();
                if (distributor == null)
                {
                    response.isValid = false;
                    response.message = "Distribuidor no encontrado, o se encuentra inactivo";
                    return Ok(response);
                }
                //Validacion del Serial
                if (workshopOrder.KindEquipment == 1)//Producto
                {
                    var serialValidation = await _context.Sisg_SerialsProducts.Where(sv => sv.Serial == workshopOrder.Serial).FirstOrDefaultAsync();
                    if (serialValidation == null)
                    {
                        response.isValid = false;
                        response.message = "El serial suministrado no está registrado en nuestra base de datos. Verifique su denominación.";
                        return Ok(response);

                    }
                }

                //Validar que el equipo no tenga orden activa
                var duplicateordercheck = await _context.Sisg_WorkshopOrders.Where(o => o.Serial == workshopOrder.Serial && o.KindEquipment == 1).ToListAsync();
                var find = duplicateordercheck.Count(x => x.StateOrderId != 11 && x.StateOrderId != 12);
                if (find > 0)
                {
                    response.isValid = false;
                    response.message = $"La orden no pudo ser creada, el serial: {workshopOrder.Serial} posee una orden activa. Por favor verifique";
                    return Ok(response);
                }

                if(workshopOrder.Serial == null)
                  { workshopOrder.Serial = ""; }

                workshopOrder.Distributor = await _context.Sisg_Distributors.FindAsync(workshopOrder.DistributorId);
                workshopOrder.TypeFailure = await _context.Sisg_TypesFailures.FindAsync(workshopOrder.TypeFailurId);
                workshopOrder.StatesOrder = await _context.Sisg_StatesOrder.FindAsync(workshopOrder.StateOrderId);
                workshopOrder.DeliveryOrder = await _context.Sisg_DeliveryOrder.FindAsync(workshopOrder.DeliveryOrderId);
                workshopOrder.Employee = await _context.Sisg_Employees.FindAsync(workshopOrder.EmployeeId);
                string nroOrderTemp = workshopOrder.DistributorId.ToString() + DateTime.Now.Millisecond.ToString();
                workshopOrder.NumerOrder = nroOrderTemp;

                if(workshopOrder.AlienationDate == DateTime.MinValue)
                {
                 workshopOrder.AlienationDate = Convert.ToDateTime("1753-01-01");
                }

                _context.Sisg_WorkshopOrders.Add(workshopOrder);                
                await _context.SaveChangesAsync();

                //Actualizo su Numero de Orden en funcion de su Id generado
                workshopOrder.NumerOrder = workshopOrder.Id.ToString().PadLeft(5,'0');
                //Retardo para que actualice el Nro de Orden
                System.Threading.Thread.Sleep(1500);
                UpdateWorkshopOrderInternal(workshopOrder);
            
                return CreatedAtAction("PostSisg_WorkshopOrder", new { id = workshopOrder.Id }, workshopOrder);
            }
            catch (Exception ex)
            {
              return StatusCode(500, ex.Message + ". " + ex.InnerException != null ? ex.InnerException.Message : "");
            }
        }
        #endregion

        #region // PUT: api/WorkshopOrder/5
        /// <summary>
        /// Actualiza una orden de Taller por ID
        /// </summary>
        /// <param name="id"></param>
        /// <param name="workshopOrder">JSON</param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSisg_WorkshopOrder([FromRoute]int id, [FromBody] WorkshopOrder workshopOrder)
        {
           var response = new Responce();
        
            if(id != workshopOrder.Id)
            {
                return BadRequest();
            }

              //Validar Status del Distribuidor
              var distributor = await _context.Sisg_Distributors.Where(d => d.id == workshopOrder.DistributorId && d.enable == 1).FirstOrDefaultAsync();
              if (distributor == null)
              {
                response.isValid = false;
                response.message = "Distribuidor no encontrado, o se encuentra inactivo";
                return Ok(response);
              }
             _context.Entry(distributor).State = EntityState.Detached;
      
              //Validacion del Serial
              if (workshopOrder.KindEquipment == 1)//Producto
              {
                var serialValidation = await _context.Sisg_SerialsProducts.Where(sv => sv.Serial == workshopOrder.Serial).FirstOrDefaultAsync();
                if (serialValidation == null)
                {
                  response.isValid = false;
                  response.message = "El serial suministrado no está registrado en nuestra base de datos. Verifique su denominación.";
                  return Ok(response);

                }
                  _context.Entry(serialValidation).State = EntityState.Detached;
              }

              //Validar que el equipo no tenga mas de una orden activa que debe ser ella misma
              var duplicateordercheck = await _context.Sisg_WorkshopOrders.Where(o => o.Serial == workshopOrder.Serial && o.KindEquipment == 1).ToListAsync();
              var find = duplicateordercheck.Count(x => x.StateOrderId != 11 && x.StateOrderId != 12);
              if (find > 0)
              {
               bool isRepet = false;
               if(find == 1)
               {
                  var workorder = duplicateordercheck.FirstOrDefault();

                  if(workorder.Id != id)
                  {
                   isRepet = true;                
                  }
                _context.Entry(workorder).State = EntityState.Detached;
              }
               else
               {
                  isRepet = true;
               }

                if(isRepet)
                  {
                    response.isValid = false;
                    response.message = $"La orden no pudo ser actualidad con el serial: {workshopOrder.Serial} posee una orden activa. Por favor verifique";
                    return Ok(response);
                  }
       
               }
            
              if (workshopOrder.Serial == null)
              { workshopOrder.Serial = ""; }

            if (workshopOrder.AlienationDate == DateTime.MinValue)
            {
              workshopOrder.AlienationDate = Convert.ToDateTime("1753-01-01");
            }

            _context.Entry(workshopOrder).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException) when (!workshopOrderExist(id))
            {
                return NotFound();                   
            }
            catch (Exception ex)
            {
              return StatusCode(500, ex.Message + ". " + ex.InnerException != null ? ex.InnerException.Message : "");
            }

             return NoContent();
        }       
        #endregion

        #region // DELETE: api/WorkshopOrder/5
        /// <summary>
        /// Elimina una orden de Taller por ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSisg_WorkshopOrder([FromRoute]int id)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var workshopOrder = await _context.Sisg_WorkshopOrders.Where(x => x.Id == id)
                    .Include(d => d.Distributor)
                    .Include(t => t.TypeFailure)
                    .Include(s => s.StatesOrder)
                    .Include(x => x.DeliveryOrder)
                    .Include(e => e.Employee)
                    .Include(w => w.Warranty)
                    .FirstOrDefaultAsync();

                if (workshopOrder == null)
                {
                    return NotFound();
                }

                _context.Sisg_WorkshopOrders.Remove(workshopOrder);
                await _context.SaveChangesAsync();

                return Ok(workshopOrder);
            }
            catch (Exception ex)
            {
              return StatusCode(500, ex.Message + ". " + ex.InnerException != null ? ex.InnerException.Message : "");
            }
          }
    #endregion

        #region Operaciones Privadas

        private async void UpdateWorkshopOrderInternal(WorkshopOrder workshopOrder)
        {
          _context.Entry(workshopOrder).State = EntityState.Modified;

          try
          {
            await _context.SaveChangesAsync();
          }
          catch (Exception ex)
          {

          }
        }

        private bool workshopOrderExist(long id) =>
            _context.Sisg_WorkshopOrders.Any(e => e.Id == id);

        #endregion
  }
}
