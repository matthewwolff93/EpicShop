using System;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;

namespace EpicShop.Core.Infrastructure.Extensions
{
    public static class ConfigureDependencyInjection
    {
        public static IServiceCollection AddDependencyInjection(this IServiceCollection services)
        {
            // getting the list of all IModuleBootstrapper implementations
            var bootstrappers = AppDomain.CurrentDomain
                .GetAssemblies()
                .SelectMany(s => s.GetTypes())
                .Where(p => typeof(IModuleBootstrapper).IsAssignableFrom(p))
                .Where(p => p != typeof(IModuleBootstrapper));

            foreach (var bootstrapper in bootstrappers)
            {
                // instantiating each bootstrapper and running startup code.
                var instance = (IModuleBootstrapper)Activator.CreateInstance(bootstrapper);
                instance.Run(services);
            }

            return services;
        }
    }
}