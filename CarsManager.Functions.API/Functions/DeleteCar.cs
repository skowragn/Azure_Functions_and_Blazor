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
using CarsManager.Application.DTOs.Request;
using CarsManager.Domain.Entities;

namespace CarsManager.Functions.API.Functions;

public class DeleteCar
{
    private readonly ILogger<PostCar> _logger;
    private readonly IValidator<CarDetailsRequestDto> _validator;
    private readonly IMediator _mediator;

    public DeleteCar(ILogger<PostCar> logger, IValidator<CarDetailsRequestDto> validator, IMediator mediator)
    {
        _logger = logger;
        _validator = validator;
        _mediator = mediator;
    }

    [Function("DeleteCarDetailsItem")]
    [OpenApiOperation(operationId: "remove-car-details", "Delete Car", Summary = "Remove Car Details", Description = "This removes the car details.", Visibility = OpenApiVisibilityType.Important)]
    [OpenApiParameter(name: "id", In = ParameterLocation.Path, Required = true, Type = typeof(int), Description = "Id of car to be deleted.")]
    [OpenApiResponseWithBody(statusCode: HttpStatusCode.OK, contentType: "application/json", bodyType: typeof(string), Description = "OK response")]
    [OpenApiResponseWithoutBody(statusCode: HttpStatusCode.InternalServerError, Summary = "Internal Server Error", Description = "Something went wrong")]
    [OpenApiResponseWithoutBody(statusCode: HttpStatusCode.BadRequest, Summary = "Bad Request", Description = "Input data is incorrect")]
    public async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Anonymous, "delete", Route = "cars/{id}")] HttpRequestData httpRequest, int id)
    {
        _logger.LogInformation($"Delete Car Item with ID");
                    
        await _mediator.Send(new RemoveBookedCarsItemCommand(id));

        return new OkObjectResult("The Car has been removed");
    }
}