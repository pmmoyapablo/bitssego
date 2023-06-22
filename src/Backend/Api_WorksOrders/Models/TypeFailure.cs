using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Api_WorksOrders.Models
{
    public class TypeFailure
    {
        public int Id { get; set; }        
        public string Description { get; set; }
        public DateTime creation_date { get; set; }
    }
}
