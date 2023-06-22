using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Sisgtfhka.Models
{
    public class AlienationModel
    {
        public int Id { get; set; }

        [Display(Name = "Serial")]
        [Required(ErrorMessage = "Debe asignar un valor a {0}")]
        [StringLength(13, ErrorMessage = "Error, el campo {0} supera los 13 caracteres", MinimumLength = 0)]
        public string Serial { get; set; }

        [Display(Name = "Proveedor")]
        [Required(ErrorMessage = "Debe asignar un valor a {0}")]
        public int ProviderId { get; set; }

        [Display(Name = "Distribuidor")]
        [Required(ErrorMessage = "Debe asignar un valor a {0}")]
        public int DistributorId { get; set; }

        [Display(Name = "Cliente Final")]
        [Required(ErrorMessage = "Debe asignar un valor a {0}")]
        public int FinalClientId { get; set; }

        [Display(Name = "Estatus")]
        [Required(ErrorMessage = "Debe asignar un valor a {0}")]
        public string Status { get; set; }

        [Display(Name = "Observaciones")]
        [Required(ErrorMessage = "Debe asignar un valor a {0}")]
        public string Observations { get; set; }

        [Display(Name = "Fecha de Enajenación")]
        [Required(ErrorMessage = "Debe asignar un valor a {0}")]
        public DateTime AlienationDate { get; set; }

        [Display(Name = "Fecha de Creación")]
        [Required(ErrorMessage = "Debe asignar un valor a {0}")]
        public DateTime Creation_Date { get; set; }

        //Password
        [Display(Name = "Clave")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Debe asignar un valor a {0}")]
        public string Verificador { get; set; }

        public ProviderModel Provider { get; set; }
        public DistributorModel Distributor { get; set; }
        public FinalsClientsModel FinalClient { get; set; }

    }
}
