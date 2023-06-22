using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Api_Clients.Models;


namespace Api_Clients.Models
{
    public class ClientsContext : DbContext
    {
        public ClientsContext(DbContextOptions<ClientsContext> contex)
            : base(contex)
        {
        }

        public DbSet<Provider> Sisg_Providers { get; set; }
        public DbSet<Distributor> Sisg_Distributors { get; set; }
        public DbSet<DistributorsProvider> Sisg_DistributorsProviders { get; set; }
        public DbSet<DistributorsUser> Sisg_DistributorsUsers { get; set; }
		public DbSet<Technician> Sisg_Technicians { get; set; }
        public DbSet<TechniciansUser> Sisg_TechniciansUsers { get; set; }
        public DbSet<TechniciansDistributor> Sisg_TechniciansDistributors { get; set; }
        public DbSet<DevelopersClients> Sisg_DevelopersClients { get; set; }
        public DbSet<DevelopersClientsusers> Sisg_DevelopersClientsusers { get; set; }
        public DbSet<Finalsclients> Sisg_FinalsClients { get; set; }
        public DbSet<Finalsclientsusers> Sisg_FinalsClientsusers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }
    }
}