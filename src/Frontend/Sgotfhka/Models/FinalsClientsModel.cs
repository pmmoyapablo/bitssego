using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
namespace Sisgtfhka.Models
{
    public class FinalsClientsModel
    { //id
        [Key]
        [Display(Name = "ID")]
        public int Id { get; set; }

        //rif
        [Display(Name = "RIF")]
        [Required(ErrorMessage = "Debe asignar un valor a {0}")]
        [RegularExpression("^[JGVEP][0-9]{9}$", ErrorMessage = "Por favor, introduzca un número de rif válido.")]
        public string Rif { get; set; }

        //description
        [Display(Name = "Nombre Comercial")]
        [Required(ErrorMessage = "Debe asignar un valor a {0}")]
        public string Description { get; set; }

        //name
        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "Debe asignar un valor a {0}")]
        public string Name { get; set; }

        //lastName
        [Display(Name = "Apellido")]
        [Required(ErrorMessage = "Debe asignar un valor a {0}")]
        public string LastName { get; set; }

        //phone
        [Required(ErrorMessage = "Debe asignar un valor a {0}")]
        [Display(Name = "Teléfono")]
        public string phone { get; set; }

        //email
        [Display(Name = "Correo")]
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Debe asignar un valor a {0}")]
        public string email { get; set; }

        //fiscalAddress
        [Display(Name = "Dirección Fiscal")]
        [Required(ErrorMessage = "Debe asignar un valor a {0}")]
        public string fiscalAddress { get; set; }

        //enable
        [Display(Name = "Estatus")]
        public Boolean enable { get; set; }

        //creation_date 
        [DataType(DataType.DateTime)]
        [Display(Name = "Fecha")]
        public DateTime creation_date { get; set; }
    }
}
