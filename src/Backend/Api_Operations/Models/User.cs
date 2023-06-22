using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api_Access.Models
{
    public class User
    {
        public int id { get; set; }
        public int rolId { get; set; } 
        public string username { get; set; }
        public string password { get; set; }
        public int enable { get; set; }
        public DateTime creation_date { get; set; }

        public Rol rol { get; set; }      
    }
}
