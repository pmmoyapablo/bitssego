using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Sisgtfhka.Models
{
    public class StatesOrderModel
    {
        public int Id { get; set; }
        [Display(Name = "Descripción")]
        public string Description { get; set; }
        public DateTime Creation_Date { get; set; }
    }
}
