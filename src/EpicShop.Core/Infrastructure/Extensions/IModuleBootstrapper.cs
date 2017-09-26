using Microsoft.Extensions.DependencyInjection;

namespace EpicShop.Core.Infrastructure.Extensions
{
    public interface IModuleBootstrapper
    {
        void Run(IServiceCollection serviceCollection);
    }
}