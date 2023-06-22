using Api_Employees.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Api_WorksOrders.Models
{
    public class WorkshopBinnacle
    {
        public int Id { get; set; }
        public DateTime Creation_Date { get; set; }
        public string Observation { get; set; }

        [ForeignKey("Order")]
        public int OrderId { get; set; }
        public WorkshopOrder Order { get; set; }

        [ForeignKey("StatusOrder")]
        public int StatusId { get; set; }
        public StatesOrder StatusOrder { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }
        public Employee User { get; set; }

    }
}
