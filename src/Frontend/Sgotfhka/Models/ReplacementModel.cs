using System;
using System.Web;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;

namespace Sisgtfhka.Models
{
    public class ReplacementModel
    {
        //id
        public int id { get; set; }

        //prefixId
        [Display(Name = "Prefijo")]
        [DefaultValue(0)]
        [Required(ErrorMessage = "Debe asignar un valor a {0}")]
        //[StringLength(11, ErrorMessage = "Error, el campo {0} supera los 11 caracteres", MinimumLength = 0)]
        public int PrefixId { get; set; }

        //Model
        [Display(Name = "Modelo Principal Relativo")]
        [Required(ErrorMessage = "Debe asignar un valor a {0}")]
        public int modelId { get; set; }

        //name
        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "Debe asignar un valor a {0}")]
        [StringLength(100, ErrorMessage = "Error, el campo {0} supera los 100 caracteres", MinimumLength = 1)]
        public string name { get; set; }

        //description
        [Display(Name = "Descripción")]
        [StringLength(150, ErrorMessage = "Error, el campo {0} supera los 150 caracteres", MinimumLength = 0)]
        public string description { get; set; }

        //code
        [Display(Name = "Código")]
        [Required(ErrorMessage = "Debe asignar un valor a {0}")]
        [StringLength(45, ErrorMessage = "Error, el campo {0} supera los 45 caracteres", MinimumLength = 0)]
        public string code { get; set; }

        //parts
        [Display(Name = "Partes")]
        [Required(ErrorMessage = "Debe asignar un valor a {0}")]
        [StringLength(45, ErrorMessage = "Error, el campo {0} supera los 45 caracteres", MinimumLength = 0)]
        public string parts { get; set; }

        //state
        [Display(Name = "Estatus")]
        public int state { get; set; }

        //image
        [Display(Name ="Subir Foto")]        
        public IFormFile image { get; set; } 

        //imageUrl
        [Display(Name = "Foto")]
        //[Required(ErrorMessage = "Debe asignar un valor a {0}")]
        [StringLength(150, ErrorMessage = "Error, el campo {0} supera los 150 caracteres", MinimumLength = 0)]
        public string imageUrl { get; set; }

        //creation date
        [DataType(DataType.DateTime)]
        [Display(Name = "Fecha")]
        public DateTime creation_date { get; set; }

        //mark name
        [Display(Name = "Marca Relacionada")]
        [Required(ErrorMessage = "Debe asignar un valor a {0}")]
        public int markId { get; set; } 
        
        public ModelModel Model { get; set; }

        public PrefixModel Prefix { get; set; }
    }
}
