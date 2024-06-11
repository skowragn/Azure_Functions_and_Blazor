using CarsManager.Application.Services;
using CarsManager.Web.Services.Interfaces;
using Flurl.Http;
namespace CarsManager.Web.Extensions;
public static class RegisterCarReservationsServices
{
    public static IServiceCollection AddCarReservationsServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddAppServices(configuration);

        services.AddScoped<ICarReservationsService, CarReservationsService>();
        services.AddScoped<IBookedCarsItemsService, CarBookedItemsService>();

        return services;
    }
}