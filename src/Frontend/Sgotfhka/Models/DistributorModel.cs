using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sisgtfhka.Models
{
    public class DistributorModel
    {
        //id
        [Key]
        [Display(Name = "ID")]
        public int id { get; set; }

        //idSA
        [Display(Name = "Código SA")]
        public int idSA { get; set; }

        //rif
        [Display(Name = "RIF")]
        [Required(ErrorMessage = "Debe asignar un valor a {0}")]
        [StringLength(10, ErrorMessage = "El {0} debe tener {1} caracteres.")]
        [RegularExpression("^[JGVEP][0-9]{9}$", ErrorMessage = "Por favor, introduzca un número de RIF válido.")]
        public string rif { get; set; }

        //description
        [Display(Name = "Descripción")]
        [Required(ErrorMessage = "Debe asignar un valor a {0}")]
        public string description { get; set; }

        //represent
        [Display(Name = "Representante")]
        [Required(ErrorMessage = "Debe asignar un valor a {0}")]
        public string represent { get; set; }

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
        [Display(Name = "Correo")]
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Debe asignar un valor a {0}")]
        public string email { get; set; }

        //nit
        [Display(Name = "NIT")]
        //[Required(ErrorMessage = "Debe asignar un valor a {0}")]
        //[RegularExpression("^[JGVEP][0-9]{9}$", ErrorMessage = "Por favor, introduzca un número de NIT válido.")]
        public string nit { get; set; }

        //codeZone
        [Display(Name = "Cód. Zona Postal")]
        //[Required(ErrorMessage = "Debe asignar un valor a {0}")]
        public string codeZone { get; set; }

        //nameSeller
        [Display(Name = "Vendedor")]
        [Required(ErrorMessage = "Debe asignar un valor a {0}")]
        public string nameSeller { get; set; }

        //rifSeller
        [Display(Name = "RIF Vendedor")]
        //[Required(ErrorMessage = "Debe asignar un valor a {0}")]
        //[RegularExpression("^[JGVEP][0-9]{9}$", ErrorMessage = "Por favor, introduzca un número de RIF válido.")]
        public string rifSeller { get; set; }

        //phoneSeller
        //[Required(ErrorMessage = "Debe asignar un valor a {0}")]
        //[RegularExpression("^(?!0+$)(\\+\\d{1,3}[- ]?)?(?!0+$)\\d{10,15}$", ErrorMessage = "Por favor, introduzca un número de teléfono válido.")]
        //[DataType(DataType.PhoneNumber)]
        [Display(Name = "Telf. Vendedor")]
        public string phoneSeller { get; set; }

        //typeAgreement
        [Display(Name = "Convenio")]
        //[Required(ErrorMessage = "Debe asignar un valor a {0}")]
        public string typeAgreement { get; set; }

        //enable
        [Display(Name = "Estatus")]
        public Boolean enable { get; set; }

        //creation_date 
        [DataType(DataType.DateTime)]
        [Display(Name = "Fecha")]
        public DateTime creation_date { get; set; }
    }
}
