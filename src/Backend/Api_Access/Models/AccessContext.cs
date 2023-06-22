using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Api_Access.Models;


namespace Api_Access.Models
{
    public class AccessContext : DbContext
    {
        public AccessContext(DbContextOptions<AccessContext> contex)
            : base(contex)
        {
        }

        public DbSet<Rol> Sisg_Roles { get; set; }
        public DbSet<Access> Sisg_Accessroles { get; set; }
        public DbSet<Profile> Sisg_Profiles { get; set; }
		    public DbSet<User> Sisg_Users { get; set; }
        public DbSet<Menu> Sisg_Menus { get; set; }
        public DbSet<RolesMenu> Sisg_Rolesmenus { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        { 
           
        }
    }
}
