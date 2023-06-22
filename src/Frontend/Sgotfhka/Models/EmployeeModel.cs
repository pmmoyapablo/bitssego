using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sisgtfhka.Models
{
    public class EmployeeModel
    {
        //id
        [Key]
        [Display(Name = "ID")]
        public int id { get; set; }

        //supervitorId
        [Display(Name = "Supervisor")]
        [Required(ErrorMessage = "Debe asignar un valor a {0}")]
        public int supervitorId { get; set; }

        //rif
        [Display(Name = "RIF")]
        [Required(ErrorMessage = "Debe asignar un valor a {0}")]
        [StringLength(10, ErrorMessage = "El {0} debe tener {1} caracteres.")]
        [RegularExpression("^[VEP][0-9]{9}$", ErrorMessage = "Por favor, introduzca un número de RIF válido.")]
        public string rif { get; set; }

        //code
        [Display(Name = "Código")]
        [Required(ErrorMessage = "Debe asignar un valor a {0}")]
        public string code { get; set; }

        //description
        [Display(Name = "Descripción")]
        [Required(ErrorMessage = "Debe asignar un valor a {0}")]
        public string description { get; set; }

        //departament
        [Display(Name = "Departamento")]
        [Required(ErrorMessage = "Debe asignar un valor a {0}")]
        public int departamentId { get; set; }

        //chargue 
        [Display(Name = "Cargo")]
        [Required(ErrorMessage = "Debe asignar un valor a {0}")]
        public int chargueId { get; set; }

        //email
        [Display(Name = "Correo")]
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Debe asignar un valor a {0}")]
        public string email { get; set; }

        //phone
        [Required(ErrorMessage = "Debe asignar un valor a {0}")]
        //[DataType(DataType.PhoneNumber)]
        [Display(Name = "Teléfono")]
        public string phone { get; set; }

        //enable
        [Display(Name = "Estatus")]
        public Boolean Enable { get; set; }

        //creation_date 
        [DataType(DataType.DateTime)]
        [Display(Name = "Fecha")]
        public DateTime creation_date { get; set; }

        //departament
        public Departament Departament { get; set; }

        //chargue
        public Chargue Chargue { get; set; }
        //Name Supervitor
        public string nameSupervitor { get; set; }
    }
}
