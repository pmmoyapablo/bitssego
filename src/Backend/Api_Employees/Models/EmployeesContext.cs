using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace Api_Employees.Models
{
    public class EmployeesContext : DbContext
    {
        public EmployeesContext(DbContextOptions<EmployeesContext> contex)
            : base(contex)
        {
        }

        public DbSet<Employee> Sisg_Employees { get; set; }
        public DbSet<EmployeesUsers> Sisg_Employeesusers { get; set; }
        public DbSet<Departament> Sisg_Departaments { get; set; }
        public DbSet<Chargue> Sisg_Chargues { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }

    }
}