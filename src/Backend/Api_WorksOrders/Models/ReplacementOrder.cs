using Api_Products.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Api_WorksOrders.Models
{
    public class ReplacementOrder
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        
        [ForeignKey("Replacement")]
        public int ReplacementId { get; set; }        
        public Replacement Replacement { get; set; }
    }
}
