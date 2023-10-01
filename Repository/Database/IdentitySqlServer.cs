using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Database
{
    public class IdentitySqlServer : IdentityDbContext 
    {
        public IdentitySqlServer(DbContextOptions<IdentitySqlServer> option):base(option)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
 
            builder.Entity<IdentityUserLogin<string>>()
                .HasKey(p => new { p.LoginProvider, p.ProviderKey });
            builder.Entity<IdentityUserRole<string>>()
                .HasKey(p => new { p.UserId, p.RoleId });
            builder.Entity<IdentityUserToken<string>>()
                .HasKey(p => new { p.UserId, p.LoginProvider, p.Name });

           base.OnModelCreating(builder);
        }
    }
}
