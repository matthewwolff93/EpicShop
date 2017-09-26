using EpicShop.Core.Infrastructure.Data;
using EpicShop.Core.Infrastructure.Extensions;
using EpicShop.Core.Modules.Shop.Models;
using Microsoft.Extensions.DependencyInjection;

namespace EpicShop.Core.Modules.Shop.Services
{
    public class ModuleBootstrapper : IModuleBootstrapper
    {
        public void Run(IServiceCollection serviceCollection)
        {
            serviceCollection
                .AddScoped<ShopService>()
                .AddScoped<BaseRepository<ShopModel>>();
        }
    }
}
