using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api_Products.Models
{
    public class ProductsReplacement
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int ReplacementId { get; set; }
    }
}
