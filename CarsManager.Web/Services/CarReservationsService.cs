using Flurl.Http;
using CarsManager.Web.Services.Interfaces;
using CarsManager.Web.Extensions;
using CarsManager.Web.Mapper;
using CarsManager.Web.Model;
using CarsManager.Application.DTOs;


namespace CarsManager.Web.Services;
public class CarReservationsService(IFlurlClient flurlClient, ILogger<CarReservationsService> logger) : ICarReservationsService
{
    private readonly IFlurlClient _flurlClient = flurlClient;
    private readonly ILogger _logger = logger;

    async Task<IEnumerable<CarsDetailsViewModel>?> ICarReservationsService.GetAllCarReservations()
    {
        List<CarsDetailsViewModel> results = [];
        
        try
        {
           //var json = await "http://localhost:7159/api/cars".GetStringAsync();
           var response = await _flurlClient.Request(Endpoints.Car_Details)
                                             .GetJsonAsync<GetCarDetailsDto>();
           results = response.Response.CarDetails.Select(item => item.ToCarDetailsViewModel()).ToList();
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
    public async Task<bool> AddOrUpdateItem(int quantity, CarsDetailsViewModel car)
    {
        try
        {
            var response = await _flurlClient.Request(Endpoints.Update_Car)
                                             .GetJsonAsync<GetBookedCarItemsDto>();

            var carBookedItem = response.Response.CarBookedItems.Where(item => item.Car.Name == car.Name)
                                                                .Select(item => item.ToCarsBookedItemViewModel())
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

    public async Task CreateOrUpdateCar(CarsDetailsViewModel car)
    {

    }
}