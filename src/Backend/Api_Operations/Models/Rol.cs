using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api_Access.Models
{
    public class Rol
    {
        public int id { get; set; }
        public string description { get; set; }
        public int accessId { get; set; }
        public int profileId { get; set; }       
        public DateTime creation_date { get; set; }
        public Access access { get; set; }
        public Profile profile { get; set; }
    }
}
