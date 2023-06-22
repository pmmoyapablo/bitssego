using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Sisgtfhka.Models
{
    public class SerialReplacementModel
    {

        public int Id { get; set; }

        [Display(Name = "Serial")]
        [Required(ErrorMessage = "Debe asignar un valor a {0}")]
        [StringLength(13, ErrorMessage = "Error, el campo {0} supera los 13 caracteres", MinimumLength = 0)]
        public string Serial { get; set; }

        [Display(Name = "Repuesto")]
        [Required(ErrorMessage = "Debe asignar un valor a {0}")]
        public int ReplacementId { get; set; }

        [Display(Name = "Distribuidor")]
        [Required(ErrorMessage = "Debe asignar un valor a {0}")]
        public int DistributorId { get; set; }

        [Display(Name = "Proveedor")]
        [Required(ErrorMessage = "Debe asignar un valor a {0}")]
        public int ProviderId { get; set; }

        [DataType(DataType.DateTime)]
        [Display(Name = "Fecha de Venta")]
        [Required(ErrorMessage = "Debe asignar un valor a {0}")]
        public DateTime DateSale { get; set; }

        [Display(Name ="Observaciones")]
        [Required(ErrorMessage = "Debe asignar un valor a {0}")]
        public string Observations { get; set; }

        [DataType(DataType.DateTime)]
        [Display(Name = "Fecha de Creacion")]
        [Required(ErrorMessage = "Debe asignar un valor a {0}")]
        public DateTime Creation_Date { get; set; }

        [Display(Name = "RIF Distribuidor")]
        [Required(ErrorMessage = "Debe asignar un valor a {0}")]
        [StringLength(10, ErrorMessage = "El {0} debe tener {1} caracteres.")]
        [RegularExpression("^[JGVEP][0-9]{9}$", ErrorMessage = "Por favor, introduzca un número de RIF válido.")]
        public string rifDistributor { get; set; }

        [Required(ErrorMessage = "Debe asignar un valor a {0}")]
        [Display(Name = "Archivo de Lote")]
        public IFormFile FormSerialFile { get; set; }

        [Display(Name = "Distribuidor")]
        [Required(ErrorMessage = "Debe asignar un valor a {0}")]
        public int DistributorId2 { get; set; }

        public string FileProcessMessage { get; set; }

        public ReplacementModel Replacement { get; set; }

        public ProviderModel Provider { get; set; }

        public DistributorModel Distributor { get; set; }

        //password
        [Display(Name = "Clave")]
        [DataType(DataType.Password)]
       // [StringLength(16, ErrorMessage = "El {0} debe tener al menos {2} y con un máximo de {1} caracteres.", MinimumLength = 8)]
        [Required(ErrorMessage = "Debe asignar un valor a {0}")]
        public string Verificador { get; set; }

    }
}
