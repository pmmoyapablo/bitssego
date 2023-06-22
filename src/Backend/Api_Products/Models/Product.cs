using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api_Products.Models
{
    public class Product
    {
        public int Id { get; set; }       
        public int PrefixId { get; set; }
        public int CategoryId { get; set; }
        public int ModelId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Code { get; set; }
        public int State { get; set; }
        public string ImageUrl { get; set; }
        public DateTime creation_date { get; set; }
        public Category Category { get; set; }
        public Model Model { get; set; }
        public Prefix Prefix { get; set; }
    }
}
