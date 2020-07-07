using Microsoft.Extensions.DependencyInjection;
using poc.memory.leak.interfaces;
using poc.memory.leak.interfaces.Services;
using poc.memory.leak.repository;
using poc.memory.leak.services;

namespace poc.memory.leak.ioc
{
    public static class InjectorBootstrapper
    {
        public static void ConfigureDependencyInjection(this IServiceCollection services)
        {
            services.AddTransient<IExampleRepository, ExampleRepository>();
            services.AddTransient<IExampleService, ExampleService>();
        }
    }
}