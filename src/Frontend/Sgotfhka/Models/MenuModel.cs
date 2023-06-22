using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sisgtfhka.Models
{
    public class MenuModel
    {
        //id
        [Key]
        [Display(Name = "ID")]
        public int id { get; set; }

        //name
        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "Debe asignar un valor a {0}")]
        public string name { get; set; }

        //parentId 
        [Display(Name = "Padre")]
        [Required(ErrorMessage = "Debe asignar un valor a {0}")]
        public int parentId { get; set; }

        //view
        [Display(Name = "Vista")]
        [Required(ErrorMessage = "Debe asignar un valor a {0}")]
        public string view { get; set; }

        //level
        [Display(Name = "Nivel")]
        [Required(ErrorMessage = "Debe asignar un valor a {0}")]
        public int level { get; set; }

        //order
        [Display(Name = "Orden")]
        [Required(ErrorMessage = "Debe asignar un valor a {0}")]
        public int order { get; set; }


        //url
        [Display(Name = "URL")]
        [Required(ErrorMessage = "Debe asignar un valor a {0}")]
        public string url { get; set; }

        //visible
        [Display(Name = "Visible")]
        public Boolean visible { get; set; }

        //path_icon
        [Display(Name = "Imagen")]
        //[Required(ErrorMessage = "Debe asignar un valor a {0}")]
        public string path_icon { get; set; }

        [Display(Name = "Fecha")]
        public DateTime creation_date { get; set; }

        //rol
        public int RolId { get; set; }
    }
}
