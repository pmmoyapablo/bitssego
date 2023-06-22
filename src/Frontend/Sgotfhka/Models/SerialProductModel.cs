using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace Sisgtfhka.Models
{
    public class SerialProductModel
    {
        //id
        public int Id { get; set; }

        //Serial
        [Display(Name = "Serial")]
        [Required(ErrorMessage = "Debe asignar un valor a {0}")]
        [StringLength(13, ErrorMessage = "Error, el campo {0} supera los 13 caracteres", MinimumLength = 0)]
        public string Serial { get; set; }

        //ProductId
        [Display(Name = "Producto")]
        [Required(ErrorMessage = "Debe asignar un valor a {0}")]
        public int ProductId { get; set; }

        //DistributorId
        [Display(Name = "Distribuidor")]
        [Required(ErrorMessage = "Debe asignar un valor a {0}")]
        public int DistributorId { get; set; }

        //ProviderId
        [Display(Name = "Proveedor")]
        [Required(ErrorMessage = "Debe asignar un valor a {0}")]
        public int ProviderId { get; set; }

        //DateSale
        [DataType(DataType.DateTime)]
        [Display(Name = "Fecha de Venta")]
        [Required(ErrorMessage = "Debe asignar un valor a {0}")]
        public DateTime DateSale { get; set; }

        //Observation
        [Display(Name = "Observaciones")]
        [Required(ErrorMessage = "Debe asignar un valor a {0}")]
        public string Observations { get; set; }

        public string FileProcessMessage { get; set; }

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

        //creation date
        [DataType(DataType.DateTime)]
        [Display(Name = "Fecha")]
        public DateTime Creation_Date { get; set; }

        public ProductModel Product { get; set; }

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
