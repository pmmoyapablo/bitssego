using Api_Clients.Models;
using Api_Employees.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Api_WorksOrders.Models
{
    public class WorkshopOrder
    {
        public int Id { get; set; }
        public string NumerOrder { get; set; }
        public int KindEquipment { get; set; }
        public int Equipment { get; set; }
        public string Serial { get; set; }
        
        public string FirmwareVersion { get; set; }       
        public DateTime? DeliverDate { get; set; }
        public DateTime? ReceptionDate { get; set; }
        public DateTime? AlienationDate { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public string Address { get; set; }
        public string Contact { get; set; }
        public int InsertionOrigin { get; set; }
        public string WorkDone { get; set; }
        public string CustomerReview { get; set; }
        public string ObservationTechnical { get; set; }
		public string ExtraObservation { get; set; }
        public DateTime creation_date { get; set; }
        public string Phone { get; set; }

        [ForeignKey("Distributor")]
        public int DistributorId { get; set; }
        public Distributor Distributor { get; set; }

        [ForeignKey("TypeFailure")]
        public int TypeFailurId { get; set; }
        public TypeFailure TypeFailure { get; set; }

        [ForeignKey("StatesOrder")]
        public int StateOrderId { get; set; }
        public StatesOrder StatesOrder { get; set; }

        [ForeignKey("DeliveryOrder")]
        public int? DeliveryOrderId { get; set; }
        public DeliveryOrder DeliveryOrder { get; set; }

        [ForeignKey("Employee")]
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }

        [ForeignKey("Warranty")]
        public int? WarrantyId { get; set; }
        public StatesWarranty Warranty { get; set; }

    }
}
