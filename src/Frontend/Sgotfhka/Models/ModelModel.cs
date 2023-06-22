using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sisgtfhka.Models
{
    public class ModelModel
    {
        //id
        public int id { get; set; }

        //description
        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "Debe asignar un valor a {0}")]
        [StringLength(50, ErrorMessage = "Error, el campo {0} supera los 50 caracteres", MinimumLength = 1)]
        public string name { get; set; }

        //markId
        [Display(Name = "Marca Relacionada")]
        [Required(ErrorMessage = "Debe asignar un valor a {0}")]
        public int markId { get; set; }

        //creation_date 
        [DataType(DataType.DateTime)]
        [Display(Name = "Fecha")]
        public DateTime creation_date { get; set; }

        public MarkModel Mark { get; set; }
    }
}