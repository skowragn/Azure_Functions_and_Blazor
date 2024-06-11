using CarsManager.Application.DTO;

namespace CarsManager.Application.Services.Interfaces;

public interface IBookedCarsItemsAppService
{
    Task<IEnumerable<CarBookedItemDto>?> GetAllBookedCarsItems();
    Task<string> RemoveBookedCarsItem(string carNameItem, string userId);
    Task<bool> AddOrUpdateItem(int quantity, CarDetailsDto car);
    Task EmptyCarsItem();
}
