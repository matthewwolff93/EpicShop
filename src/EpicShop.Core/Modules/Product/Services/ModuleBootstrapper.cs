using EpicShop.Core.Infrastructure.Data;
using EpicShop.Core.Infrastructure.Extensions;
using EpicShop.Core.Modules.Product.Models;
using Microsoft.Extensions.DependencyInjection;

namespace EpicShop.Core.Modules.Product.Services
{
    public class ModuleBootstrapper : IModuleBootstrapper
    {
        public void Run(IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<ProductService>()
                .AddScoped<BaseRepository<ProductModel>>();
        }
    }
}
