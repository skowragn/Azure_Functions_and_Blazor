using CarsManager.Web.Model;

namespace CarsManager.Web.Services.Interfaces;

public interface IBookedCarsItemsService
{
    Task<IEnumerable<CarsBookedItemViewModel>?> GetAllBookedCarsItems();
    Task<string> RemoveBookedCarsItem(string carNameItem, string userId);
    Task<bool> AddOrUpdateItem(int quantity, CarsDetailsViewModel car);
    Task EmptyCarsItem();
}
