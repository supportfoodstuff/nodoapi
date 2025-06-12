using ApplicationLayer;
using InfrastructureLayer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace NoDoPayApi
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddMainDI(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddApplicationDI()
                .AddInfrastructureDI(configuration); // Pass IConfiguration to Infrastructure

            return services;
        }
    }
}
