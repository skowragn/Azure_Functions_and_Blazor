using CarsManager.Application.DTO;

namespace CarsManager.Application.Services.Interfaces;
public interface ICarsDetailsAppService
{
    Task<IEnumerable<CarDetailsDto>?> GetAllCarReservations();
    Task<bool> AddOrUpdateItem(int quantity, CarDetailsDto car);
    Task CreateOrUpdateCar(CarDetailsDto car);
}