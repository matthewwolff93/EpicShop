using EpicShop.Core.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

namespace EpicShop.Core.Infrastructure.Extensions
{
    public static class DatabaseExtensions
    {
        public static string EpicShopDatabase;

        public static IServiceCollection AddSqlServer(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddDbContext<EpicShopContext>(options =>
             {
                 options.UseSqlServer(configuration.GetConnectionString(nameof(EpicShopDatabase)));
                 options.EnableSensitiveDataLogging();
             });

            return services;
        }
    }
}