using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sisgtfhka.Models
{
    public class Access
    {
        public int id { get; set; }
        public int level { get; set; }
        public string description { get; set; }
        public DateTime creation_date { get; set; }
    }
}
