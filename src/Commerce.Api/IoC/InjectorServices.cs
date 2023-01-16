using Commerce.Application.Interfaces.Services;
using Commerce.Data.Context;
using Commerce.Identity.Data;
using Commerce.Identity.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Commerce.Api.IoC
{
    public static class InjectorServices
    {
        public static void AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            var version = new MySqlServerVersion(new Version(8, 0, 29));
            var connectionString = configuration.GetConnectionString("default");

            services.AddDbContext<DatabaseContext>(x => x
                    .UseMySql(connectionString, version, mySqlOptions =>
                    {
                        mySqlOptions.MigrationsAssembly(typeof(DatabaseContext).Assembly.FullName);
                    }));

            services.AddDbContext<IdentityDataContext>(x => x
                    .UseMySql(connectionString, version, mySqlOptions =>
                    {
                        mySqlOptions.MigrationsAssembly(typeof(IdentityDataContext).Assembly.FullName);
                    }));

            services.AddDefaultIdentity<IdentityUser>()
                    .AddRoles<IdentityRole>()
                    .AddEntityFrameworkStores<IdentityDataContext>()
                    .AddDefaultTokenProviders();

            services.AddScoped<IIdentityService, IdentityService>();
        }
    }
}
