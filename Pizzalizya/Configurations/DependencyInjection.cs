using Pizzalizya.Repositories;
using Pizzalizya.Repositories.Interfaces;
using Pizzalizya.Services;
using Pizzalizya.Services.Interfaces;

namespace Pizzalizya.Configurations
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddProjectDependencies(this IServiceCollection services)
        {
            // Repositories
            services.AddScoped<IPedidoRepository, PedidoRepository>();

            // Services
            services.AddScoped<IPedidoService, PedidoService>();

            return services;
        }
    }
}
