using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api_Products.Models;
using Api_Clients.Models;
using Api_Access.Models;
using Api_Employees.Models;

namespace Api_Operations.Models
{
    public class OperationsContext: DbContext
    {

        public OperationsContext(DbContextOptions<OperationsContext> contex)
          : base(contex)
        {


        }

        public DbSet<SerialProduct> Sisg_SerialsProducts { get; set; }
        public DbSet<SerialReplacement> Sisg_SerialsReplacements { get; set; }
        public DbSet<Product> Sisg_Products { get; set; }
        public DbSet<Category> Sisg_Categories { get; set; }
        public DbSet<Mark> Sisg_Marks { get; set; }
        public DbSet<Model> Sisg_Models { get; set; }
        public DbSet<Prefix> Sisg_Prefixes { get; set; }
        public DbSet<Provider> Sisg_Providers { get; set; }
        public DbSet<Distributor> Sisg_Distributors { get; set; }
        public DbSet<Replacement> Sisg_Replacements { get; set; }
        public DbSet<Finalsclients> Sisg_FinalsClients { get; set; }
        public DbSet<Technician> Sisg_Technicians { get; set; }
        public DbSet<TechniciansUser> Sisg_TechniciansUsers { get; set; }
        public DbSet<TechniciansDistributor> Sisg_TechniciansDistributors { get; set; }
        public DbSet<User> Sisg_Users { get; set; }
        public DbSet<FiscalOperationModel> Sisg_FiscalsOperations { get; set; }
        public DbSet<Alienation> Sisg_Alienations { get; set; }
		    public DbSet<TechnicalOperationModel> Sisg_TechnicalsOperations { get; set; }
        public DbSet<TypeOperationTech> Sisg_TypeOperationsTechs { get; set; }
        public DbSet<Rol> Sisg_Roles { get; set; }
        public DbSet<Access> Sisg_Accessroles { get; set; }
        public DbSet<Profile> Sisg_Profiles { get; set; }
        public DbSet<Activity> Sisg_Activities { get; set; }
		    public DbSet<Employee> Sisg_Employees { get; set; }
        public DbSet<Departament> Sisg_Departaments { get; set; }
        public DbSet<Chargue> Sisg_Chargues { get; set; }
        public DbSet<ReplacementOpeTech> Sisg_ReplacementsOpeTechs { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }
    }
}
