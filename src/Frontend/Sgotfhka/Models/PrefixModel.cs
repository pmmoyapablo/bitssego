using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Sisgtfhka.Models
{
    public class PrefixModel
    {
        //id 
        public int Id { get; set; }

        //initCorrelative
        [Display(Name = "Prefijo Numérico")]
        [Required(ErrorMessage = "Debe asignar un valor a {0}")]
        [StringLength(4, ErrorMessage = "Error, el campo {0} supera los 4 caracteres", MinimumLength = 3)]
        public string InitCorrelative { get; set; }

        //initAlphaNum
        [Display(Name = "Prefijo Alfanumérico")]
        [Required(ErrorMessage = "Debe asignar un valor a {0}")]
        [StringLength(4, ErrorMessage = "Error, el campo {0} supera los 4 caracteres", MinimumLength = 3)]
        public string InitAlphaNum { get; set; }

        //creation date
        [DataType(DataType.DateTime)]
        [Display(Name = "Fecha")]
        public DateTime Creation_date { get; set; }
    }
}
