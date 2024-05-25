using CarsManager.Web.Model;

namespace CarsManager.Web.Services.Interfaces;
public interface ICarReservationsService
{
    Task<IEnumerable<CarsDetailsViewModel>?> GetAllCarReservations();
    Task<bool> AddOrUpdateItem(int quantity, CarsDetailsViewModel car);
    Task CreateOrUpdateCar(CarsDetailsViewModel car);
}