using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api_Products.Models
{
    public class Prefix
    {
        public int id { get; set; }
        public string initCorrelative { get; set; }
        public string initAlphaNum { get; set; }
        public DateTime creation_date { get; set; }
    }
}
