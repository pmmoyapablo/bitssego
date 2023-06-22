using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Sisgtfhka.Models;

namespace Sisgtfhka.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<ApplicationUser>(i => { i.Property(o => o.EmailConfirmed).HasConversion<int>();
                i.Property(o => o.LockoutEnabled).HasConversion<int>();
                i.Property(o => o.PhoneNumberConfirmed).HasConversion<int>();
                i.Property(o => o.TwoFactorEnabled).HasConversion<int>(); });
            
            //builder.Entity<ApplicationUser>().ToTable("aspnetusers");
            //builder.Entity<IdentityRole>().ToTable("aspnetroles");
            //builder.Entity<IdentityUserClaim<string>>().ToTable("aspnetuserclaims");
            //builder.Entity<IdentityRoleClaim<string>>().ToTable("aspnetroleclaims");
            //builder.Entity<IdentityUserLogin<string>>().ToTable("aspnetuserlogins");
            //builder.Entity<IdentityUserToken<string>>().ToTable("aspnetusertokens");
            //builder.Entity<IdentityUserRole<string>>().ToTable("aspnetuserroles");

            base.OnModelCreating(builder);
            // Customize the ASP.NET Core Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Core Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }
}
