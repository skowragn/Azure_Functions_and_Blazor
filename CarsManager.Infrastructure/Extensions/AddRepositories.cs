using CarsManager.Application.Interfaces;
using CarsManager.Infrastructure.Persistence.Repositories;

namespace CarsManager.Infrastructure.Extensions;
public static class AddRepositories
{
    public static IServiceCollection AddRepositoriesServices(this IServiceCollection services)
    {
       services.AddScoped<ICarsRepository, CarsRepository>();
       services.AddScoped<ICarsBookedItemRepository, CarsBookedItemRepository>();
       services.AddScoped<ICarsCategoryRepository, CarsCategoryRepository>();
       return services;
    }
}