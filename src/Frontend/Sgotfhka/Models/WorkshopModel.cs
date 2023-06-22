using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Sisgtfhka.Models
{
    public class WorkshopModel
    {

        public int Id { get; set; }

        [Display(Name = "RIF Distribuidor")]
        [Required(ErrorMessage = "Debe asignar un valor a {0}")]
        [StringLength(10, ErrorMessage = "El {0} debe tener {1} caracteres.")]
        [RegularExpression("^[JGVEP][0-9]{9}$", ErrorMessage = "Por favor, introduzca un número de RIF válido.")]
        public string rifDistributor { get; set; }

        [Display(Name = "RIF Cliente Final")]
        [StringLength(10, ErrorMessage = "El {0} debe tener {1} caracteres.")]
        [RegularExpression("^[JGVEP][0-9]{9}$", ErrorMessage = "Por favor, introduzca un número de RIF válido.")]
        public string rifFinalClient { get; set; }

        [Display(Name = "Descripción")]
        [Required(ErrorMessage = "Debe asignar un valor a {0}")]
        public string Description { get; set; }

        [Display(Name = "Número de Orden")]
        [Required(ErrorMessage = "Debe asignar un valor a {0}")]
        public string NumerOrder { get; set; }

        [Display(Name = "Tipo de Equipo")]
        [Required(ErrorMessage = "Debe asignar un valor a {0}")]
        public int KindEquipment { get; set; }

        [Display(Name = "Equipo")]
        public int Equipment { get; set; }

        [Display(Name = "Producto")]
        public string Product { get; set; }

        [Display(Name = "Nro Serial / Nro de Registro")]
        [CustomValidationWorkshop]
        public string Serial { get; set; }

        [Display(Name = "Garantía")]
        public int WarrantyId { get; set; }

        [Display(Name = "Distribuidor")]
        [Required(ErrorMessage = "Debe asignar un valor a {0}")]
        public int DistributorId { get; set; }

        [Display(Name = "Tipo de Falla")]
        public int TypeFailurId { get; set; }

        [Display(Name = "Estatus")]
        public int StateOrderId { get; set; }

        [Display(Name = "Entrega")]
        public int DeliveryOrderId { get; set; }

        [Display(Name = "Empleado")]
        public int EmployeeId { get; set; }

        [Display(Name = "Firmware Versión")]
        public string FirmwareVersion { get; set; }

        [Display(Name = "Fecha de Entrega")]
        public DateTime DeliverDate { get; set; }

        [Display(Name = "Fecha de Recibido")]
        public DateTime ReceptionDate { get; set; }

        [Display(Name = "Fecha de Enajenación")]
        public DateTime AlienationDate { get; set; }

        [Display(Name = "Fecha de Expiración")]
        public DateTime ExpirationDate { get; set; }

        [Display(Name = "Dirección")]
        [Required(ErrorMessage = "Debe asignar un valor a {0}")]
        [StringLength(150, MinimumLength = 3, ErrorMessage = "La {0} debe tener un mínimo de {2} o un máximo de {1} caracteres.")]
        public string Address { get; set; }

        [Display(Name = "Contacto")]
        [Required(ErrorMessage = "Debe asignar un valor a {0}")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "El {0} debe tener un mínimo de {2} o un máximo de {1} caracteres.")]
        [RegularExpression("^[a-zA-Z ñÑ]*$", ErrorMessage = "Por favor, introduzca solo letras")]
        public string Contact { get; set; }

        [Display(Name = "Origen de Inserción")]
        public int InsertionOrigin { get; set; }

        [Display(Name = "Trabajo Hecho")]
        public string WorkDone { get; set; }

        [Display(Name = "Revisión del Cliente")]
        [Required(ErrorMessage = "Debe asignar un valor a {0}")]
        [StringLength(150, MinimumLength = 1, ErrorMessage = "La {0} debe tener un mínimo de {2} o un máximo de {1} caracteres.")]
        public string CustomerReview { get; set; }

        [Display(Name = "Descripción de la Falla")]
        [Required(ErrorMessage = "Debe asignar un valor a {0}")]
        [StringLength(150, MinimumLength = 3, ErrorMessage = "La {0} debe tener un mínimo de {2} o un máximo de {1} caracteres.")]
        public string ObservationTechnical { get; set; }

        [Display(Name = "Observaciones Extra")]
        [StringLength(150, MinimumLength = 0, ErrorMessage = "La {0} debe tener un mínimo de {2} o un máximo de {1} caracteres.")]
        public string ExtraObservation { get; set; }

        [Display(Name = "Fecha de Creación")]
        public DateTime creation_date { get; set; }

        [Display(Name = "Modelo")]
        public string Model { get; set; }

        [Display(Name = "Marca")]
        public string Mark { get; set; }

        [Display(Name = "Modo de Entrega")]
        [Required(ErrorMessage = "Debe asignar un valor a {0}")]
        public bool DeliveryMode { get; set; }

        [Display(Name = "Cédula del Responsable")]
        [Required(ErrorMessage = "Debe asignar un valor a {0}")]
        [Range(1000000, 99999999, ErrorMessage = "La {0} debe estar entre {1} y {2}")]
        public int LiableId { get; set; }

        [Display(Name = "Nombre del Responsable")]
        [Required(ErrorMessage = "Debe asignar un valor a {0}")]
        [StringLength(40, MinimumLength = 3, ErrorMessage = "El {0} debe tener un mínimo de {2} o un máximo de {1} caracteres.")]
        public string LiableName { get; set; }

        [Display(Name = "Teléfono del Responsable")]
        [Required(ErrorMessage = "Debe asignar un valor a {0}")]
        [StringLength(15, ErrorMessage = "El {0} debe tener un máximo de {1} caracteres.")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Por favor, introduzca un número de {0} válido.")]
        public string LiablePhone { get; set; }

        [Display(Name = "Teléfono")]
        [Required(ErrorMessage = "Debe asignar un valor a {0}")]
        [StringLength(15, ErrorMessage = "El {0} debe tener un máximo de {1} caracteres.")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Por favor, introduzca un número de {0} válido.")]
        public string Phone { get; set; }

        [Display(Name = "Número de Guía")]
        [StringLength(25, ErrorMessage = "El {0} debe tener un máximo de {1} caracteres.")]
        [CustomValidationWorkshop2]
        public string DeliveryGuideNumber { get; set; }

        [Display(Name = "Compañía")]
        [StringLength(50, ErrorMessage = "El {0} debe tener un máximo de {1} caracteres.")]
        [CustomValidationWorkshop2]
        public string DeliveryCompanyName { get; set; }

        [Display(Name = "Dirección")]
        [StringLength(150, MinimumLength = 10, ErrorMessage = "La {0} debe tener un mínimo de {2} o un máximo de {1} caracteres.")]
        [CustomValidationWorkshop2]
        public string DeliveryAddress { get; set; }

        [Display(Name = "Observaciones")]
        [StringLength(150, MinimumLength = 0, ErrorMessage = "La {0} debe tener un mínimo de {2} o un máximo de {1} caracteres.")]
        [CustomValidationWorkshop2]
        public string DeliveryObservations { get; set; }

        [Display(Name = "Fecha de Entrega")]
        public DateTime DeliveryDispatcherDate { get; set; }

        [Display(Name = "Distribuidor Contacto")]
        public string distributorName { get; set; }

        [Display(Name = "Teléfono del distribuidor")]
        public string distributorPhone { get; set; }

        [Display(Name = "Dirección del distribuidor")]
        public string distributorAddress { get; set; }

        [Display(Name = "Vendedor")]
        public string distributorSeller { get; set; }

        [Display(Name = "Vendedor RIF")]
        public string distributorSellerRif { get; set; }

        [Display(Name = "Garantía")]
        public string warrantyMessage { get; set; }

        [Display(Name = "Razón Social")]
        public string BusinessName { get; set; }

        public DistributorModel Distributor { get; set; }
        public TypesFailuresModel typeFailure { get; set; }
        public StatesOrderModel statesOrder { get; set; }
        public DeliveryOrderModel deliveryOrder { get; set; }
        public EmployeeModel employee { get; set; }
        public StatesWarrantyModel warranty { get; set; }

        

        public List<AccesoryOrderModel> lstAccesories { get; set; }
        public List<PhotographOrderModel> lstPhoto { get; set; }

        [Display(Name = "Clave")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Debe asignar un valor a {0}")]
        public string Verificador { get; set; }

        public bool Aplica { get; set; }

        public string StateOrderName { get; set; }

        [Display(Name = "Serial Reincidente")]
        public bool serialRecidivist { get; set; }

    }
}
