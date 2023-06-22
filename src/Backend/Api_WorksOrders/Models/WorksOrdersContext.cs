using Api_Clients.Models;
using Api_Employees.Models;
using Api_Operations.Models;
using Api_Products.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api_WorksOrders.Models
{
    public class WorksOrdersContext : DbContext
    {
        public WorksOrdersContext(DbContextOptions<WorksOrdersContext> context)
            : base(context)
        {

        }

        //public DbSet<WorkshopOrder> Sisg_WorksShopsOrders { get; set; }
        public DbSet<TypeFailure> Sisg_TypesFailures { get; set; }
        public DbSet<StatesOrder> Sisg_StatesOrder { get; set; }
        public DbSet<DeliveryOrder> Sisg_DeliveryOrder { get; set; }
        public DbSet<PhotographOrder> Sisg_PhotographsOrder { get; set; }
        public DbSet<AccessoryOrder> Sisg_AccessoriesOrders { get; set; }
        public DbSet<ReplacementOrder> Sisg_ReplacementsOrders { get; set; }
        public DbSet<WorkshopOrder> Sisg_WorkshopOrders { get; set; }
        

        public DbSet<Accessory> Sisg_Accessories { get; set; }
        public DbSet<Replacement> Sisg_Replacements { get; set; }
        public DbSet<Distributor> Sisg_Distributors { get; set; }
        public DbSet<Employee> Sisg_Employees { get; set; }
        public DbSet<Product> Sisg_Products { get; set; }
        public DbSet<SerialProduct> Sisg_SerialsProducts { get; set; }
        public DbSet<WorkshopBinnacle> Sisg_WorkshopBinnacles { get; set; }
		public DbSet<StatesWarranty> Sisg_StatesWarranty { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
        }
    }
}
