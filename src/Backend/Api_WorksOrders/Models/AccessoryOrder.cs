using Api_Products.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Api_WorksOrders.Models
{
    public class AccessoryOrder
    {
        public int Id { get; set; }        
        public int OrderId { get; set; }
        
        [ForeignKey("Accessory")]
        public int AccesoryId { get; set; }                
        public Accessory Accessory { get; set; }
    }
}
