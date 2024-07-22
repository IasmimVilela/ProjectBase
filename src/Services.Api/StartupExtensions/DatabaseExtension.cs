using TaskB3.Infra.Data.Context; 
using Microsoft.EntityFrameworkCore;
using TaskB3.Infra.CrossCutting.Identity.Data;

namespace TaskB3.Services.Api.StartupExtensions
{
    public static class DatabaseExtension
    {
        public static IServiceCollection AddCustomizedDatabase(this IServiceCollection services, IConfiguration configuration, IWebHostEnvironment env)
        {
            services.AddDbContext<AuthDbContext>(options => {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")); 
                if (!env.IsProduction())
                {
                    options.EnableDetailedErrors();
                    options.EnableSensitiveDataLogging();
                }
            });

            services.AddDbContext<ApplicationDbContext>(options => {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")); 
                if (!env.IsProduction())
                {
                    options.EnableDetailedErrors();
                    options.EnableSensitiveDataLogging();
                }
            });

            services.AddDbContext<EventStoreSqlContext>(options => {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")); 
                if (!env.IsProduction())
                {
                    options.EnableDetailedErrors();
                    options.EnableSensitiveDataLogging();
                }
            });

            return services;
        }
    }
}
