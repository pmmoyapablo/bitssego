﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sisgtfhka.Models
{
    public class ProviderModel
    {
        //id
        [Key]
        [Display(Name = "ID")]
        public int id { get; set; }

        //rif
        [Display(Name = "RIF")]
        [Required(ErrorMessage = "Debe asignar un valor a {0}")]
        [RegularExpression("^[JGVEP][0-9]{9}$", ErrorMessage = "Por favor, introduzca un número de rif válido.")]
        public string rif { get; set; }

        //description
        [Display(Name = "Razón Social")]
        [Required(ErrorMessage = "Debe asignar un valor a {0}")]
        public string description { get; set; }

        //address
        [Display(Name = "Dirección")]
        [Required(ErrorMessage = "Debe asignar un valor a {0}")]
        public string address { get; set; }

        //phone
        [Required(ErrorMessage = "Debe asignar un valor a {0}")]
        [RegularExpression("^(?!0+$)(\\+\\d{1,3}[- ]?)?(?!0+$)\\d{10,15}$", ErrorMessage = "Por favor, introduzca un número de teléfono válido.")]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Teléfono")]
        public string phone { get; set; }

        //email
        [Display(Name = "Correo")]
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Debe asignar un valor a {0}")]
        public string email { get; set; }

        //image
        [Display(Name = "Logotipo")]
        //[Required(ErrorMessage = "Debe asignar un valor a {0}")]
        public string image { get; set; }

        //creation_date 
        [DataType(DataType.DateTime)]
        [Display(Name = "Fecha")]
        public DateTime creation_date { get; set; }
    }
}
