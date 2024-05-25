using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using CarsManager.Infrastructure.Configuration;

namespace CarsManager.Functions.API.Extensions;

public static class RegisterConfiguration
{
    public static IServiceCollection AddConfiguration(this IServiceCollection services, IConfiguration configuration)
    {
        var applicationSetup = configuration.GetSection(nameof(ConnectionStrings)).Get<ConnectionStrings>();
        services.AddSingleton(applicationSetup);
        return services;
    }
}