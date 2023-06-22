using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace Api_Utilities.Models
{
    public class UtilitiesContext : DbContext
    {
        public UtilitiesContext(DbContextOptions<UtilitiesContext> context)
            :base(context)
        {

        }


        public DbSet<SystemOper> Sisg_SystemOpers { get; set; }
        public DbSet<ProgramLenguage> Sisg_ProgramLenguages { get; set; }
        public DbSet<StatusIntegration> Sisg_StatusIntegrations { get; set; }
        public DbSet<CasesSoftwareHouse> Sisg_CasesSoftwareHouses { get; set; }
        public DbSet<CasesProducts> Sisg_CasesProducts { get; set; }
        public DbSet<Employee> Sisg_Employees { get; set; }
        public DbSet<DevelopersClients> Sisg_DevelopersClients { get; set; }
        public DbSet<Product> Sisg_Products { get; set; }
        public DbSet<Model> Sisg_Models { get; set; }

  }

}
