using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Sisgtfhka.Models
{
    public class ActivityModel
    {
        public int Id { get; set; }

        [Display(Name = "Usuario")]
        public int EmployeeId { get; set; }

        [Display(Name = "Departamento")]
        public int DepartamentId { get; set; }

        [Display(Name = "Cargo")]
        public int ChargueId { get; set; }

        [Display(Name = "Proceso")]
        public string Process { get; set; }

        [Display(Name = "Serial")]
        public string Serial { get; set; }

        [Display(Name = "Operación")]
        public string Operation { get; set; }

        [Display(Name = "Detalle")]
        public string Detail { get; set; }

        [Display(Name = "Fecha")]
        public DateTime OperationDate { get; set; }

        public EmployeeModel employee { get; set; }
    }
}
