using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Sisgtfhka.Models
{
    public class DeliveryOrderModel
    {
        public int Id { get; set; }
        //public bool DeliveryMode { get; set; }
        [Display(Name = "Forma de Envío")]
        public int DeliveryMode { get; set; }
        [Display(Name = "Cédula")]
        public int LiableId { get; set; }
        [Display(Name = "Nombre")]
        public string LiableName { get; set; }
        [Display(Name = "Teléfono")]
        public string LiablePhone { get; set; }
        [Display(Name = "Número de Guía")]
        public string GuideNumber { get; set; }
        [Display(Name = "Compañía")]
        public string CompanyName { get; set; }
        [Display(Name = "Dirección")]
        public string Address { get; set; }
        [Display(Name = "Observaciones")]
        public string Observation { get; set; }
        [Display(Name ="Fecha de Entrega")]
        public DateTime DispatchDate { get; set; }
    }
}
