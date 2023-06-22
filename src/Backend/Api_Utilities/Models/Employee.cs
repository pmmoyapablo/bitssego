using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api_Utilities.Models

{
    public class Employee
    {
        public int id { get; set; }
        public int supervitorId { get; set; }
        public string rif { get; set; }
        public string code { get; set; }
        public string description { get; set; }
        public int departamentId { get; set; }
        public int chargueId { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public int enable { get; set; }
        public DateTime creation_date { get; set; }

        public Departament departament { get; set; }
        public Chargue chargue { get; set; }
    }
}
