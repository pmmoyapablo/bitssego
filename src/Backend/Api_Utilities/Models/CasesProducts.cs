using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Api_Utilities.Models
{
    public class CasesProducts
    {
        public int id { get; set; }
        public int caseSoftwareHouseId { get; set; }
        [ForeignKey("product")]
        public int productId { get; set; }    
        public Product product { get; set; }
  }
}
