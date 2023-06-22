using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api_Clients.Models;

namespace Api_Operations.Models
{
    public class TechnicalOperationModel
    {
        public int Id { get; set; }
        public int ProviderId { get; set; }
        public int DistributorId { get; set; }
        public int FinalClientId { get; set; }
        public int TechnicianId { get; set;}
        public int TypeOperationTechId { get; set; }
        public string Serial { get; set; }
        public string Status { get; set; }
		public string Observation { get; set; }
        public DateTime Operation_Date { get; set; }
        public DateTime Creation_Date { get; set; }
		
        public Provider provider { get; set; }
        public Distributor distributor { get; set; }
        public Finalsclients finalclient { get; set; }
        public Technician technician { get; set; }
        public TypeOperationTech typeOperationTech { get; set; }
    }
}
