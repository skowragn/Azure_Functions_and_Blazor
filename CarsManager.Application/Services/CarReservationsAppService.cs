using Flurl.Http;
using CarsManager.Application.Services.Interfaces;
using CarsManager.Application.Extensions;
using CarsManager.Application.DTO;

namespace CarsManager.Application.Services;
public class CarReservationsAppService(IFlurlClient flurlClient, ILogger<CarReservationsAppService> logger) : ICarsDetailsAppService
{
    private readonly IFlurlClient _flurlClient = flurlClient;
    private readonly ILogger _logger = logger;

    async Task<IEnumerable<CarDetailsDto>?> ICarsDetailsAppService.GetAllCarReservations()
    {
        List<CarDetailsDto> results = [];
        
        try
        {
           //var json = await "http://localhost:7159/api/cars".GetStringAsync();
           var response = await _flurlClient.Request(Endpoints.Car_Details)
                                             .GetJsonAsync<GetCarDetailsDto>();
           results = [.. response.Response.CarDetails];
        }
        catch (FlurlHttpException ex)
        {
            switch (ex.StatusCode)
            {
                default:
                    _logger.LogInformation("API responded: {StatusCode}, {Message}.", ex.StatusCode, ex.Message);
                    break;
            }
        }

        return results; 
    }
    public async Task<bool> AddOrUpdateItem(int quantity, CarDetailsDto car)
    {
        try
        {
            var response = await _flurlClient.Request(Endpoints.Update_Car)
                                             .GetJsonAsync<GetBookedCarItemsDto>();

            var carBookedItem = response.Response.CarBookedItems.Where(item => item.Car.Name == car.Name)
                                                                .ToList();

            if (carBookedItem != null)
            { 
            
            }
            
        }
        catch (FlurlHttpException ex)
        {
            switch (ex.StatusCode)
            {
                default:
                    _logger.LogInformation("API responded: {StatusCode}, {Message}.", ex.StatusCode, ex.Message);
                    break;
            }
        }

        return false;
    }

    public async Task CreateOrUpdateCar(CarDetailsDto car)
    {

    }
}