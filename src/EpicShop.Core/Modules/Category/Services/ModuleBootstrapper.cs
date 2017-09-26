using EpicShop.Core.Infrastructure.Data;
using EpicShop.Core.Infrastructure.Extensions;
using EpicShop.Core.Modules.Category.Models;
using Microsoft.Extensions.DependencyInjection;

namespace EpicShop.Core.Modules.Category.Services
{
    public class ModuleBootstrapper : IModuleBootstrapper
    {
        public void Run(IServiceCollection serviceCollection)
        {
            serviceCollection
                .AddScoped<CategoryService>()
                .AddScoped<BaseRepository<CategoryModel>>();
        }
    }
}
