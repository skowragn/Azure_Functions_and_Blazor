using CarsManager.Application.Extensions;
using CarsManager.Application.Services.Interfaces;
using Flurl.Http;
using CarsManager.Application.DTO;

namespace CarsManager.Application.Services;

public class CarBookedItemsAppService(IFlurlClient flurlClient, ILogger<CarReservationsAppService> logger) : IBookedCarsItemsAppService
{

    private readonly IFlurlClient _flurlClient = flurlClient;
    private readonly ILogger _logger = logger;

    public Task<bool> AddOrUpdateItem(int quantity, CarDetailsDto car)
    {
        throw new NotImplementedException();
    }

    public async Task EmptyCarsItem()
    {

    }

    public async Task<IEnumerable<CarBookedItemDto>?> GetAllBookedCarsItems()
    {
        try
        {
            var json = await "http://localhost:7159/api/bookedcaritems".GetStringAsync();
  

            var response = await _flurlClient.Request(Endpoints.Booked_Car_Items)
                                             .GetJsonAsync<List<CarBookedItemDto>>();

            var carsBookedItems = response.ToList();
            return carsBookedItems;
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

        return [];
    }
    public Task<string> RemoveBookedCarsItem(string carNameItem, string userId)
    {
        try
        {

            string endpoint = string.Format(Endpoints.Remove_Car, userId);
            var response = _flurlClient.Request(endpoint).GetStringAsync();
            _logger.LogInformation("{carNameItem} has been removed for the {userId} user.", carNameItem, userId );
            return response;

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

        return Task.FromResult(string.Empty);
    }
}