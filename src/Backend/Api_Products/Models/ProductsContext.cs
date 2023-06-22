using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace Api_Products.Models
{
    public class ProductsContext : DbContext
    {
        public ProductsContext(DbContextOptions<ProductsContext> contex)
            : base(contex)
        {
        }

        public DbSet<Category> Sisg_Categories { get; set; }

        public DbSet<Mark> Sisg_Marks { get; set; }

        public DbSet<Model> Sisg_Models { get; set; }
		
		public DbSet<Accessory> Sisg_Accessories { get; set; }

        public DbSet<Replacement> Sisg_Replacements { get; set; }
		
		public DbSet<Product> Sisg_Products { get; set; }

        public DbSet<ProductsReplacement> Sisg_ProductsReplacements { get; set; }

        public DbSet<ProductsAccessories> Sisg_ProductsAccessories { get; set; }

        public DbSet<Prefix> Sisg_Prefixes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }
    }
}
