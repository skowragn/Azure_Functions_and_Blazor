using CarsManager.Application.HttpClient;
using CarsManager.Web.Services.Interfaces;
using Flurl.Http;
namespace CarsManager.Web.Extensions;
public static class RegisterCarReservationsServices
{
    public static IServiceCollection AddCarReservationsServices(this IServiceCollection services)
    {

        services.AddScoped<PollyClientFactory>();

        services.AddScoped(c =>
        {
            var pollyClientFactory = c.GetRequiredService<PollyClientFactory>();

            var url = "http://localhost:7159/api";
            return new FlurlClient(url)
                         .Configure(settings =>
                            {
                               settings.HttpClientFactory = pollyClientFactory;
                            });
        });


        services.AddScoped<ICarReservationsService, CarReservationsService>();
        services.AddScoped<IBookedCarsItemsService, CarBookedItemsService>();

        return services;
    }
}