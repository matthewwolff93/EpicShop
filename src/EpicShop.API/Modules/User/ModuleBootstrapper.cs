using EpicShop.Core.Infrastructure.Extensions;
using EpicShop.Core.Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;

namespace EpicShop.API.Modules.User
{
    public class ModuleBootstrapper : IModuleBootstrapper
    {
        public void Run(IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IUserManager, UserManager>();
        }
    }
}
