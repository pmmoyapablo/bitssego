using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api_Clients.Models
{
    public class Distributor
    {
        public int id { get; set; }
        public int idSA { get; set; }
        public string rif { get; set; }
        public string description { get; set; }
        public string represent { get; set; }
        public string address { get; set; }
        public string country { get; set; }
        public string state { get; set; }
        public string city { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
        public string nit { get; set; }
        public string codeZone { get; set; }
        public string nameSeller { get; set; }
        public string rifSeller { get; set; }
        public string phoneSeller { get; set; }
        public string typeAgreement { get; set; }
        public int enable { get; set; }
        public DateTime creation_date { get; set; }
    }
}
