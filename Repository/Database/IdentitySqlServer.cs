using Domain.IdentityEntities;
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
    public class IdentitySqlServer : IdentityDbContext<ApplicationUser>
    {
        public IdentitySqlServer(DbContextOptions<IdentitySqlServer> option):base(option)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<IdentityRole<string>>().ToTable("Roles", "identity");
            builder.Entity<IdentityRoleClaim<string>>().ToTable("RoleClaims", "identity");
            builder.Entity<IdentityUserClaim<string>>().ToTable("UserClaims", "identity");
            builder.Entity<IdentityUserLogin<string>>().ToTable("UserLogins", "identity");
            builder.Entity<IdentityUserRole<string>>().ToTable("UserRoles", "identity");
            builder.Entity<IdentityUserToken<string>>().ToTable("UserTokens", "identity");

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
