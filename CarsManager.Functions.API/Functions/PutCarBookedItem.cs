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
using CarsManager.Application.Mapper;
using Microsoft.Azure.Functions.Worker.Http;
using Newtonsoft.Json;
using CarsManager.Application.DTO.Request;
using CarsManager.Application.DTO;
using CarsManager.Application.DTO.Response;
using CarsManager.Domain.Entities;

namespace CarsManager.Functions.API.Functions;

public class PutCarBookedItem(ILogger<PostCar> logger, IValidator<CarBookedItemRequestDto> validator, IMediator mediator)
{
    private readonly ILogger<PostCar> _logger = logger;
    private readonly IValidator<CarBookedItemRequestDto> _validator = validator;
    private readonly IMediator _mediator = mediator;

    [Function("PutCarBookedItem")]
    [OpenApiOperation(operationId: "update-car-Booked-item", "Put Car Booked Item", Summary = "Put Car Booked Ite", Description = "This updates a car with all details.", Visibility = OpenApiVisibilityType.Important)]
    [OpenApiRequestBody(contentType: "application/json", bodyType: typeof(GetBookedCarItemsDto), Required = true, Description = "Parameters")]
    [OpenApiResponseWithBody(statusCode: HttpStatusCode.OK, contentType: "application/json", bodyType: typeof(string), Description = "OK response")]
    [OpenApiResponseWithoutBody(statusCode: HttpStatusCode.InternalServerError, Summary = "Internal Server Error", Description = "Something went wrong")]
    [OpenApiResponseWithoutBody(statusCode: HttpStatusCode.BadRequest, Summary = "Bad Request", Description = "Input data is incorrect")]
    public async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Anonymous, "put", Route = "cars/{id}")] HttpRequestData httpRequest)
    {
        _logger.LogInformation("Update a car.");

        var carBookedItemToUpdate = await GetRequestData(httpRequest);

        var validationResult = await _validator.ValidateAsync(carBookedItemToUpdate);
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

        if (carBookedItemToUpdate != null)
        {
            var carBookedItem = await _mediator.Send(new AddOrUpdateCarBookedItemCommand(carBookedItemToUpdate.ToCarsBookedItem()));


            var response = new GetBookedCarItemsDto()
            {
                AppName = "put-new-car-booked-item",
                Version = "1",
                Request = carBookedItemToUpdate,
                Response = new CarsBookedItemsResponseDto() { CarBookedItems = [carBookedItem.ToCarsBookedItemDto(carBookedItem.Car)] }
            };
                
            return response is null ? new NotFoundResult() : new OkObjectResult(response);
        }
        return new NotFoundResult();
    }

    private static async Task<CarBookedItemRequestDto> GetRequestData(HttpRequestData httpRequestData)
    {
        string requestBody = await new StreamReader(httpRequestData.Body).ReadToEndAsync();
        
        if (string.IsNullOrEmpty(requestBody))
            return new CarBookedItemRequestDto();
        
        var requestData = JsonConvert.DeserializeObject<GetBookedCarItemsDto>(requestBody);

        return requestData.Request ?? new CarBookedItemRequestDto();
    }
}