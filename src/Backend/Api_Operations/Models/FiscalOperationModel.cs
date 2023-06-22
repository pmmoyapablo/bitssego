using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api_Clients.Models;

namespace Api_Operations.Models
{
    public class FiscalOperationModel
    {
        public int Id { get; set; }
        public string FiscalOperation { get; set; }
        public string FiscalMode { get; set; }
        public int ProviderId { get; set; }
        public int DistributorId { get; set; }
        public int TechnicianId { get; set; }
        public int FinalClientId { get; set; }
        public string Serial { get; set; }
        public string InitSeal { get; set; }
        public string FinalSeal { get; set; }
        public string FiscalAddress { get; set; }
        public int FiscalResult { get; set; }
        public string SerialRetative { get; set; }
        public string CodeOperation { get; set; }
        public DateTime Creation_Date { get; set; }

        public Provider provider { get; set; }
        public Distributor distributor { get; set; }
        public Technician technician { get; set; }
        public Finalsclients finalClient { get; set; }
    }
}
