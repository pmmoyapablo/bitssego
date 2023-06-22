using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sisgtfhka.Models
{
    public class CodeGeneratorModel
    {
        //id
        public int id { get; set; }
               
        //operation
        [Display(Name = "Operacion")]
        public string operation { get; set; }

        //technician
        [Display(Name = "Técnico")]
        [StringLength(10,ErrorMessage ="Rif debe contener 10 caracteres",MinimumLength =10)]
        public string technician { get; set; }

        //finalClientRif
        [Display(Name = "Rif Cliente Final")]
        [Required(ErrorMessage ="Debe asignar un valor a {0}")]
        public string rif { get; set; }

        //finalClientName
        [Display(Name = "Razon Social Cliente")]
        public string description { get; set; }

        //address
        [Display(Name = "Dirección Fiscal")]
        [Required(ErrorMessage = "Debe asignar un valor a {0}")]
        public string fiscalAddress { get; set; }

        //serial
        [Required(ErrorMessage = "Debe asignar un valor a {0}")]
        [Display(Name = "Nro Registro")]
        [StringLength(10, ErrorMessage = "Rif debe contener 10 caracteres", MinimumLength = 10)]
        public string serial { get; set; }

        //rifDistributor
        [Display(Name = "Rif Distribuidor")]
        [StringLength(10, ErrorMessage = "Rif debe contener 10 caracteres", MinimumLength = 10)]
        public string rifDistributor { get; set; }

        //serialMefi
        [Display(Name = "Serial MEFIS")]
        public string serialMefi { get; set; }

        //initSeal
        [Display(Name = "Precinto Inicial")]
        public string initSeal { get; set; }

        //finalSeal
        [Display(Name = "Precinto Final")]
        public string finalSeal { get; set; }

        //codePrinter
        [Display(Name = "Código Impresora")]
        public string codePrinter { get; set; }

        //codeOperation
        [Display(Name = "Código Obtenido")]
        public string codeOperation { get; set; }

        //Validator Serial
        [Display(Name = "")]
        public bool validator { get; set; }

        //Validator MEFI
        [Display(Name = "")]
        public bool validatorMefi { get; set; }

    }
}
