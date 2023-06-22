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
    public class ProductModel
    {
        //id
        public int Id { get; set; }

        //prefixId
        [Display(Name = "Prefijo")]
        [DefaultValue(0)]
        //[StringLength(11, ErrorMessage = "Error, el campo {0} supera los 11 caracteres", MinimumLength = 0)]
        public int PrefixId { get; set; }

        //categoryId
        [Display(Name = "Categoría")]
        [Required(ErrorMessage = "Debe asignar un valor a {0}")]
        public int CategoryId { get; set; }

        //Model
        [Display(Name = "Modelo")]
        [Required(ErrorMessage = "Debe asignar un valor a {0}")]
        public int ModelId { get; set; }

        //name
        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "Debe asignar un valor a {0}")]
        [StringLength(100, ErrorMessage = "Error, el campo {0} supera los 100 caracteres", MinimumLength = 1)]
        public string Name { get; set; }

        //description
        [Display(Name = "Descripción")]
        [StringLength(150, ErrorMessage = "Error, el campo {0} supera los 150 caracteres", MinimumLength = 0)]
        public string Description { get; set; }

        //code
        [Display(Name = "Código")]
        [Required(ErrorMessage = "Debe asignar un valor a {0}")]
        [StringLength(45, ErrorMessage = "Error, el campo {0} supera los 45 caracteres", MinimumLength = 0)]
        public string Code { get; set; }

        //State
        [Display(Name = "Estatus")]
        [Required(ErrorMessage = "Debe asignar un valor a {0}")]
        public int State { get; set; }

        //image
        [Display(Name = "Subir Foto")]
        public IFormFile image { get; set; }

        //imageUrl
        [Display(Name = "Foto")]
        [StringLength(150, ErrorMessage = "Error, el campo {0} supera los 150 caracteres", MinimumLength = 0)]
        public string ImageUrl { get; set; }

        //creation date
        [DataType(DataType.DateTime)]
        [Display(Name = "Fecha")]
        public DateTime Creation_date { get; set; }

        public CategoryModel Category { get; set; }

        public ModelModel Model { get; set; }

        public PrefixModel Prefix { get; set; }
    }
}
