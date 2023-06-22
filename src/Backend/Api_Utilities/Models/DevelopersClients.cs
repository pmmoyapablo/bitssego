using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api_Utilities.Models
{
    public class DevelopersClients
    {
        public int id { get; set; }
        public string document { get; set; }
        public string description { get; set; }
        public string address { get; set; }
        public string country { get; set; }
        public string state { get; set; }
        public string city { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
        public int enable { get; set; }
        public DateTime creation_date { get; set; }
    }
}

