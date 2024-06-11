
using CarsManager.Application.Services.Interfaces;
using Flurl.Http;
using CarsManager.Application.Extensions.HttpClient;

namespace CarsManager.Application.Services;
public static class RegisterAppServices
{
    public static IServiceCollection AddAppServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<PollyClientFactory>();

        services.AddScoped(c =>
        {
            var pollyClientFactory = c.GetRequiredService<PollyClientFactory>();

            var url = configuration["WebConfiguration:BackendServicesUrl"];

            return new FlurlClient(url)
                         .Configure(settings =>
                         {
                             settings.HttpClientFactory = pollyClientFactory;
                         });
        });

        services.AddScoped<ICarsDetailsAppService, CarReservationsAppService>();
        services.AddScoped<IBookedCarsItemsAppService, CarBookedItemsAppService>();
        return services;
    }
}