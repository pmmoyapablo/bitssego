using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sisgtfhka.Models
{
    public class Chargue
    {
        public int id { get; set; }

        //description
        [Display(Name = "Descripción")]
        [Required(ErrorMessage = "Debe asignar un valor a {0}")]
        public string description { get; set; }

        //rolId 
        [Display(Name = "Rol")]
        [Required(ErrorMessage = "Debe asignar un valor a {0}")]
        public int rolId { get; set; }

        //Rol
        public RolModel Rol { get; set; }
    }
}