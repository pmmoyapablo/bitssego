using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api_Clients.Models
{
    public class Technician
    {
        public int id { get; set; }
        public string rif { get; set; }
        public string description { get; set; }
        public string address { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
        public int enable { get; set; }
        public DateTime creation_date { get; set; }
    }
}
