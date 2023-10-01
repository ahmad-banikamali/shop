using Microsoft.AspNetCore.Identity;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Repository.Database;

namespace Api.Utils
{
    internal static class IdentityConfig
    {
        public static IServiceCollection AddIdentityService(this IServiceCollection services, IConfiguration configuration)
        { 
            services.AddDbContext<IdentitySqlServer>(option =>
            {
                var scsb = new SqlConnectionStringBuilder();
                scsb.DataSource = ".";
                scsb.InitialCatalog = "shop";
                scsb.IntegratedSecurity = true;
                scsb.TrustServerCertificate = true;
                scsb.MultipleActiveResultSets = true;

                option.UseSqlServer(scsb.ConnectionString); 
            });

            services.AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<IdentitySqlServer>()
                .AddDefaultTokenProviders()
                .AddRoles<IdentityRole>();


            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 8;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredUniqueChars = 1;
                options.Password.RequireNonAlphanumeric = false;
                options.User.RequireUniqueEmail = true;
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(30);
            });
            return services;
        }
    }
}
 
