using Microsoft.EntityFrameworkCore;
using CarsManager.Infrastructure.Configuration;
using CarsManager.Orleans.Infrastructure.Persistence.DbContext;

namespace CarsManager.Infrastructure.Extensions;
public static class RegisterDatabase 
{
    public static IServiceCollection AddMsSqlDatabase(this IServiceCollection services) 
    { 
        var serviceProvider = services.BuildServiceProvider();
        var connectionString = serviceProvider.GetService<ConnectionStrings>();

        if(connectionString!=null)
        _ = services.AddDbContext<AppDbContext>(options =>
                       options.UseSqlServer(connectionString: connectionString.MsSqlConnection,
                          opt => opt.MigrationsAssembly(typeof(RegisterDatabase).Assembly.FullName)));
        return services;
    }

    public static void InitDatabase(this IServiceCollection services)
    {
        var serviceProvider = services.BuildServiceProvider();
        using var serviceScope = serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope();
        var context = serviceScope.ServiceProvider.GetRequiredService<AppDbContext>();

        context.Database.EnsureCreated();

        var carsDefaultBuilder = new CarDetailsDataGenerator();

        var defaultCars = carsDefaultBuilder.GetAllCars().ToList();
        var defaultCarsBookedItems = carsDefaultBuilder.GetAllBookedItemCars();
        var defaultCarCategories = carsDefaultBuilder.GetAllCarCategories();

        if (!context.CarCategories.Any() && defaultCars.Count != 0)
        {
            context.CarCategories.AddRange(defaultCarCategories);
            context.SaveChanges();
        }

        if (!context.CarDetails.Any() && defaultCars.Count != 0 )
        {
            context.CarDetails.AddRange(defaultCars);
            context.SaveChanges();
        }
        if (!context.CarsBookedItem.Any() && defaultCarsBookedItems.Count != 0)
        {
            context.CarsBookedItem.AddRange(defaultCarsBookedItems);
            context.SaveChanges();
        }
       
    }
}