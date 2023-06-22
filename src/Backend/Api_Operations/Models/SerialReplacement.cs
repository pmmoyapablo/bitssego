using Api_Clients.Models;
using Api_Products.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api_Operations.Models
{
    public class SerialReplacement
    {
        public int Id { get; set; }
        public string Serial { get; set; }
        public int ReplacementId { get; set; }
        public int DistributorId { get; set; }
        public int ProviderId { get; set; }
        public DateTime DateSale { get; set; }
        public string Observations { get; set; }
        public DateTime Creation_Date { get; set; }

        public Replacement replacement { get; set; }
        public Provider provider { get; set; }
        public Distributor distributor { get; set; }
    }
}
