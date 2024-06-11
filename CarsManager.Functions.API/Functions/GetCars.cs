using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Net;
using MediatR;
using CarsManager.Application.DTO;
using CarsManager.Application.Cqrs.Queries;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Attributes;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Enums;
using Microsoft.OpenApi.Models;
using CarsManager.Application.DTO.Response;
using CarsManager.Application.DTO.Request;
using Newtonsoft.Json;
using CarsManager.Domain.Entities;


namespace CarsManager.Functions.API.Functions;

public class GetCars(ILogger<GetCars> logger, IMediator mediator)
{
    private readonly ILogger<GetCars> _logger = logger;
    private readonly IMediator _mediator = mediator;

    [Function("GetCars")]
    [OpenApiOperation(operationId: "get-all-cars-details", tags: ["GetCars"], Summary = "All Cars Details", Description = "This select all the cars details.", Visibility = OpenApiVisibilityType.Important)]
    [OpenApiResponseWithBody(statusCode: HttpStatusCode.OK, contentType: "application/json", bodyType: typeof(GetCarDetailsDto), Description = "OK response")]
    [OpenApiResponseWithoutBody(statusCode: HttpStatusCode.InternalServerError, Summary = "Internal Server Error", Description = "Something went wrong")]
    [OpenApiResponseWithoutBody(statusCode: HttpStatusCode.BadRequest, Summary = "Bad Request", Description = "Input data is incorrect")]
    [OpenApiResponseWithoutBody(statusCode: HttpStatusCode.NotFound, Summary = "", Description = "")]
    [OpenApiResponseWithoutBody(statusCode: HttpStatusCode.MethodNotAllowed, Summary = "Validation exception", Description = "Validation exception")]

    public async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "cars")] HttpRequest request)
    {
        _logger.LogInformation("C# HTTP trigger function processed a request.");

        var carReservations = await _mediator.Send(new GetAllCarReservationsQuery());

        var requestData = await GetRequestData(request);
        var response = new GetCarDetailsDto() { AppName = "get-all-cars-details", 
                                                Version = "1", 
                                                Request = requestData, 
                                                Response = new CarsDetailsResponseDto() { CarDetails = carReservations.ToList() } };
        return response is null ? new NotFoundResult() : new OkObjectResult(response);
    }

    private static async Task<CarDetailsRequestDto> GetRequestData(HttpRequest httpRequestData)
    {
        string requestBody = await new StreamReader(httpRequestData.Body).ReadToEndAsync();

        if (string.IsNullOrEmpty(requestBody))
            return new CarDetailsRequestDto();

        var requestData = JsonConvert.DeserializeObject<CarDetailsRequestDto>(requestBody);
        return requestData ?? new CarDetailsRequestDto();
    }



}
