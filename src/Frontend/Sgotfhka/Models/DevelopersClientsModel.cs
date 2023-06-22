using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sisgtfhka.Models
{
    public class DevelopersClientsModel
    {
        //id
        [Key]
        [Display(Name = "ID")]
        public int id { get; set; }

        //document
        [Display(Name = "Documento")]
        [Required(ErrorMessage = "Debe asignar un valor a {0}")]
        //[StringLength(10, ErrorMessage = "El {0} debe tener {1} caracteres.")]
        //[RegularExpression("^[VEP][0-9]{9}$", ErrorMessage = "Por favor, introduzca un número de RIF válido.")]
        public string document { get; set; }

        //description
        [Display(Name = "Cliente Desarrollador")]
        [Required(ErrorMessage = "Debe asignar un valor a {0}")]
        public string description { get; set; }

        //address
        [Display(Name = "Dirección")]
        [Required(ErrorMessage = "Debe asignar un valor a {0}")]
        public string address { get; set; }

        //country
        [Display(Name = "País")]
        [Required(ErrorMessage = "Debe asignar un valor a {0}")]
        public string country { get; set; }

        //state
        [Display(Name = "Estado")]
        [Required(ErrorMessage = "Debe asignar un valor a {0}")]
        public string state { get; set; }

        //city
        [Display(Name = "Ciudad")]
        [Required(ErrorMessage = "Debe asignar un valor a {0}")]
        public string city { get; set; }

        //phone
        [Required(ErrorMessage = "Debe asignar un valor a {0}")]
        // [DataType(DataType.PhoneNumber)]
        [Display(Name = "Teléfono")]
        public string phone { get; set; }

        //email
        [Display(Name = "Correo Electrónico")]
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Debe asignar un valor a {0}")]
        public string email { get; set; }

        //enable
        [Display(Name = "Estatus")]
        public Boolean enable { get; set; }

        //creation_date 
        [DataType(DataType.DateTime)]
        [Display(Name = "Fecha")]
        public DateTime creation_date { get; set; }
    }
}
