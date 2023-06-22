using Api_Clients.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api_Operations.Models
{
    public class Alienation
    {
        public int Id { get; set; }
        public string Serial { get; set; }
        public int ProviderId { get; set; }
        public int DistributorId { get; set; }
        public int FinalClientId { get; set; }
        public string Status { get; set; }
        public string Observations { get; set; }
        public DateTime AlienationDate { get; set; }
        public DateTime Creation_Date { get; set; }

        public Provider provider { get; set; }
        public Distributor distributor { get; set; }
        public Finalsclients FinalClient { get; set; }
    }
}
