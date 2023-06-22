using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sisgtfhka.Models
{
    public class TechnicalOperationModel
    {
        //Id
        [Display(Name = "Id")]
        public int Id { get; set; }

        //ProviderId
        [Display(Name = "Proveedor")]
        [Required(ErrorMessage = "Debe asignar un valor a {0}")]
        public int ProviderId { get; set; }

        //DistributorId
        [Display(Name = "Distribuidor")]
        [Required(ErrorMessage = "Debe asignar un valor a {0}")]
        public int DistributorId { get; set; }

        //FinalClientId
        [Display(Name = "Cliente Final")]
        [Required(ErrorMessage = "Debe asignar un valor a {0}")]
        public int FinalClientId { get; set; }

        //TechnicianId
        [Display(Name = "Rif del Técnico")]
        [Required(ErrorMessage = "Debe asignar un valor a {0}")]
        public int TechnicianId { get; set; }

        //TypeOperationTechId
        [Display(Name = "Tipo de Operación")]
        [Required(ErrorMessage = "Debe asignar un valor a {0}")]
        public int TypeOperationTechId { get; set; }

        //Serial        
        [Display(Name = "Serial de  Máquina")]
        [Required(ErrorMessage = "Debe asignar un valor a {0}")]
        public string Serial { get; set; }

        //Serial de Repuesto        
        [Display(Name = "Serial de Repuesto")]
        public string SerialRepuesto { get; set; }

        //Status        
        [Display(Name = "Estatus")]
        [Required(ErrorMessage = "Debe asignar un valor a {0}")]
        public string Status { get; set; }

        [Display(Name = "Aplica")]
        [Required(ErrorMessage = "Debe asignar un valor a {0}")]
        public bool Aplica { get; set; }

        //Observation
        [Display(Name = "Observaciones")]
        [Required(ErrorMessage = "Debe asignar un valor a {0}")]
        public string Observation { get; set; }

        //Operation_Date
        [DataType(DataType.DateTime)]
        [Display(Name = "Fecha de Operación")]
        public DateTime Operation_Date { get; set; }

        //Creation_Date
        [Display(Name = "Fecha de Creación")]
        [Required(ErrorMessage = "Debe asignar un valor a {0}")]
        public DateTime Creation_Date { get; set; }

        //TypeOperationTech
        public TypeOperationTech TypeOperationTech { get; set; }

        public ProviderModel Provider { get; set; }

        public DistributorModel Distributor { get; set; }

        public FinalsClientsModel FinalClient { get; set; }

        public TechnicianModel Technician { get; set; }

        //Password
        [Display(Name = "Clave")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Debe asignar un valor a {0}")]
        public string Verificador { get; set; }

        //Solo para uso de Create y Edit
        [Display(Name = "Rif del Técnico")]
        [Required(ErrorMessage = "Debe asignar un valor a {0}")]
        [RegularExpression("^[VEP][0-9]{9}$", ErrorMessage = "Por favor, introduzca un número de RIF válido.")]
        [StringLength(10, ErrorMessage = "Rif debe contener 10 caracteres", MinimumLength = 10)]
        public string rifTechnician { get; set; }
    }
}
