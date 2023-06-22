using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api_Utilities.Models
{
    public class Model
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int MarkId { get; set; }   
        public DateTime creation_date { get; set; }
        public Mark Mark { get; set; }
    }
}
