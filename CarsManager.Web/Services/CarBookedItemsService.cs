using CarsManager.Web.Mapper;
using CarsManager.Web.Model;
using CarsManager.Web.Services.Interfaces;
using CarsManager.Application.Services.Interfaces;

namespace CarsManager.Web.Services;

public class CarBookedItemsService(ICarsDetailsAppService carDetailsAppService, IBookedCarsItemsAppService bookedCarsItemsService, 
                                   ILogger<CarReservationsService> logger) : IBookedCarsItemsService
{
    private readonly ILogger _logger = logger;
    private readonly ICarsDetailsAppService _carDetailsAppService = carDetailsAppService;
    private readonly IBookedCarsItemsAppService _bookedCarsItemsService = bookedCarsItemsService;

    public Task<bool> AddOrUpdateItem(int quantity, CarsDetailsViewModel car)
    {
        var carDetailsDto = car.ToCarDetailsDto();
        return _carDetailsAppService.AddOrUpdateItem(quantity, carDetailsDto);
    }


    public async Task<IEnumerable<CarsBookedItemViewModel>?> GetAllBookedCarsItems()
    {
        var response = await _bookedCarsItemsService.GetAllBookedCarsItems();
        if (response != null && response.Any())
        {
            var carsBookedItems = response.Select(item => item.ToCarsBookedItemViewModel()).ToList();
            return carsBookedItems;
        }
        return [];
    }
    public Task<string> RemoveBookedCarsItem(string carNameItem, string userId)
    {
        return _bookedCarsItemsService.RemoveBookedCarsItem(carNameItem, userId);
    }

    public async Task EmptyCarsItem()
    {
        await _bookedCarsItemsService.EmptyCarsItem();
    }
}