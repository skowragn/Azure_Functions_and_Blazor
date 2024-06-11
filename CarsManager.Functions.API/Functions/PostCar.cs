using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Net;
using FluentValidation;
using MediatR;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Attributes;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Enums;
using Microsoft.OpenApi.Models;
using CarsManager.Application.Cqrs.Commands;
using CarsManager.Application.Mappers;
using Microsoft.Azure.Functions.Worker.Http;
using Newtonsoft.Json;
using CarsManager.Application.DTO.Request;
using CarsManager.Application.DTO.Response;
using CarsManager.Application.DTO;

namespace CarsManager.Functions.API.Functions;

public class PostCar(ILogger<PostCar> logger, IValidator<CarDetailsRequestDto> validator, IMediator mediator)
{
    private readonly ILogger<PostCar> _logger = logger;
    private readonly IValidator<CarDetailsRequestDto> _validator = validator;
    private readonly IMediator _mediator = mediator;

    [Function("PostCar")]
    [OpenApiOperation(operationId: "create-car-details", "Create Car", Summary = "Create Car Details", Description = "This creates a new car with all details.", Visibility = OpenApiVisibilityType.Important)]
    [OpenApiRequestBody(contentType: "application/json", bodyType: typeof(CarDetailsRequestDto), Required = true, Description = "Parameters")]
    [OpenApiResponseWithBody(statusCode: HttpStatusCode.OK, contentType: "application/json", bodyType: typeof(string), Description = "OK response")]
    [OpenApiResponseWithoutBody(statusCode: HttpStatusCode.InternalServerError, Summary = "Internal Server Error", Description = "Something went wrong")]
    [OpenApiResponseWithoutBody(statusCode: HttpStatusCode.BadRequest, Summary = "Bad Request", Description = "Input data is incorrect")]
    public async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "cars")] HttpRequestData httpRequest)
    {
        _logger.LogInformation("C# HTTP trigger CreateCars function processed a request.");

        var carDetailsToCreate = await GetRequestData(httpRequest);

        var validationResult = await _validator.ValidateAsync(carDetailsToCreate);
        if (!validationResult.IsValid)
        {
            _logger.LogWarning("Invalid request body");
            return new BadRequestObjectResult(validationResult.Errors.Select(e => new
            {
                e.ErrorCode,
                e.PropertyName,
                e.ErrorMessage
            }));
        }

        var carDetails = await _mediator.Send(new CreateOrUpdateCarCommand(carDetailsToCreate.ToCarDetails()));

        var response = new GetCarDetailsDto()
        {
            AppName = "post-new-car-details",
            Version = "1",
            Request = carDetailsToCreate,
            Response = new CarsDetailsResponseDto() { CarDetails = [carDetails.ToCarDetailsDto(carDetails.Category)] }
        };
        return response is null ? new NotFoundResult() : new OkObjectResult(response);
    }

    private static async Task<CarDetailsRequestDto> GetRequestData(HttpRequestData httpRequestData)
    {
        string requestBody = await new StreamReader(httpRequestData.Body).ReadToEndAsync();
        
        if (string.IsNullOrEmpty(requestBody))
            return new CarDetailsRequestDto();
        
        var requestData = JsonConvert.DeserializeObject<CarDetailsRequestDto>(requestBody);
        return requestData ?? new CarDetailsRequestDto();
    }
}