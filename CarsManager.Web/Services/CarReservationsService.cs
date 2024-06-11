using CarsManager.Web.Services.Interfaces;
using CarsManager.Web.Mapper;
using CarsManager.Web.Model;
using CarsManager.Application.Services.Interfaces;

namespace CarsManager.Web.Services;
public class CarReservationsService(ICarsDetailsAppService carDetailsAppService, ILogger<CarReservationsService> logger) : ICarReservationsService
{
    private readonly ICarsDetailsAppService _carDetailsAppService = carDetailsAppService;
    private readonly ILogger _logger = logger;

    async Task<IEnumerable<CarsDetailsViewModel>?> ICarReservationsService.GetAllCarReservations()
    {
       var cars = await _carDetailsAppService.GetAllCarReservations();
       var results = cars.Select(item => item.ToCarDetailsViewModel()).ToList();
       return results; 
    }

    public Task<bool> AddOrUpdateItem(int quantity, CarsDetailsViewModel car)
    {
        var carDetailsDto = car.ToCarDetailsDto();
        return _carDetailsAppService.AddOrUpdateItem(quantity, carDetailsDto);
    }

    public async Task CreateOrUpdateCar(CarsDetailsViewModel car)
    {
        var carDto = car.ToCarDetailsDto();
        await _carDetailsAppService.CreateOrUpdateCar(carDto);
    }
}