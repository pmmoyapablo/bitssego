using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;

namespace Sisgtfhka.Models
{
    public class WorkshopBinnacleModel
    {
        //Id
        public int Id { get; set; }
        //OrderId
        [Display(Name ="Número de Orden")]
        public int OrderId { get; set; }
        //StatusId
        [Display(Name = "Status")]
        public int StatusId { get; set; }
        //UserId
        [Display(Name ="Usuario")]
        public int UserId { get; set; }
        //creation Date
        [Display(Name ="Fecha")]
        public DateTime creation_date { get; set; }
        //Observation
        [Display(Name ="Observaciones")]
        public string Observation { get; set; }

        public WorkshopModel Order { get; set; }
        public StatesOrderModel StatusOrder { get; set; }
        public EmployeeModel User { get; set; }


    }
}
