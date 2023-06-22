using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sisgtfhka.Models
{
    public class FiscalOperationModel
    {
        //id
        [Display(Name = "Id")]
        public int id { get; set; }

        //fiscalOperation        
        [Display(Name = "Operación Fiscal")]
        [Required(ErrorMessage = "Debe asignar un valor a {0}")]
        public string fiscalOperation { get; set; }

        //fiscalMode        
        [Display(Name = "Modo Fiscal")]
        [Required(ErrorMessage = "Debe asignar un valor a {0}")]
        public string fiscalMode { get; set; }

        //providerId
        [Display(Name = "Proveedor")]
        [Required(ErrorMessage = "Debe asignar un valor a {0}")]
        public int providerId { get; set; }

        //distributorId
        [Display(Name = "Distribuidor")]
        [Required(ErrorMessage = "Debe asignar un valor a {0}")]
        public int distributorId { get; set; }

        //technicianId
        [Display(Name = "Técnico")]
        [Required(ErrorMessage = "Debe asignar un valor a {0}")]
        public int technicianId { get; set; }

        //finalClientId
        [Display(Name = "Cliente Final")]
        [Required(ErrorMessage = "Debe asignar un valor a {0}")]
        public int finalClientId { get; set; }

        //serial        
        [Display(Name = "Serial")]
        [Required(ErrorMessage = "Debe asignar un valor a {0}")]
        public string serial { get; set; }

        //initSeal        
        [Display(Name = "Precinto Inicial")]
        [Required(ErrorMessage = "Debe asignar un valor a {0}")]
        public string initSeal { get; set; }

        //finalSeal        
        [Display(Name = "Precinto Final")]
        [Required(ErrorMessage = "Debe asignar un valor a {0}")]
        public string finalSeal   { get; set; }

        //fiscalAddress        
        [Display(Name = "Dirección Fiscal")]
        [Required(ErrorMessage = "Debe asignar un valor a {0}")]
        public string fiscalAddress { get; set; }

        //fiscalResult
        [Display(Name = "Resultado Fiscal")]
        [Required(ErrorMessage = "Debe asignar un valor a {0}")]
        public int fiscalResult { get; set; }

        //serialRetative        
        [Display(Name = "Serial Relativo")]
        [Required(ErrorMessage = "Debe asignar un valor a {0}")]
        public string serialRetative { get; set; }

        //codeOperation        
        [Display(Name = "Código de Operación")]
        [Required(ErrorMessage = "Debe asignar un valor a {0}")]
        public string codeOperation { get; set; }

        //creation date
        [DataType(DataType.DateTime)]
        [Display(Name = "Fecha")]
        public DateTime Creation_Date { get; set; }

        //observaciones        
        [Display(Name = "Observaciones")]
        [Required(ErrorMessage = "Debe asignar un valor a {0}")]
        public string observation { get; set; }

        public ProviderModel Provider { get; set; }

        public DistributorModel Distributor { get; set; }

        public FinalsClientsModel FinalClient { get; set; }

        public TechnicianModel Technician { get; set; }

        //password
        [Display(Name = "Clave")]
        [DataType(DataType.Password)]
        // [StringLength(16, ErrorMessage = "El {0} debe tener al menos {2} y con un máximo de {1} caracteres.", MinimumLength = 8)]
        [Required(ErrorMessage = "Debe asignar un valor a {0}")]
        public string Verificador { get; set; }
    }
}
