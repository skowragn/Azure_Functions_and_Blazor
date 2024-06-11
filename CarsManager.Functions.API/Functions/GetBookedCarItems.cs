using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Net;
using MediatR;
using CarsManager.Application.Cqrs.Queries;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Attributes;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Enums;
using Microsoft.OpenApi.Models;
using CarsManager.Application.DTO;


namespace CarsManager.Functions.API.Functions;

public class GetBookedCarItems(ILogger<GetCars> logger, IMediator mediator)
{
    private readonly ILogger<GetCars> _logger = logger;
    private readonly IMediator _mediator = mediator;

    [Function("GetBookedCarItems")]
    [OpenApiOperation(operationId: "get-booked-car-items", tags: ["GetBookedCarItems"], Summary = "All Booked Car Items", Description = "This select all the booked cars items.", Visibility = OpenApiVisibilityType.Important)]
    [OpenApiResponseWithBody(statusCode: HttpStatusCode.OK, contentType: "application/json", bodyType: typeof(GetBookedCarItemsDto), Description = "OK response")]
    [OpenApiResponseWithoutBody(statusCode: HttpStatusCode.InternalServerError, Summary = "Internal Server Error", Description = "Something went wrong")]
    [OpenApiResponseWithoutBody(statusCode: HttpStatusCode.BadRequest, Summary = "Bad Request", Description = "Input data is incorrect")]
    [OpenApiResponseWithoutBody(statusCode: HttpStatusCode.NotFound, Summary = "", Description = "")]
    [OpenApiResponseWithoutBody(statusCode: HttpStatusCode.MethodNotAllowed, Summary = "Validation exception", Description = "Validation exception")]

    public async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "bookedcaritems")] HttpRequest request)
    {
        _logger.LogInformation("C# HTTP trigger function processed a request.");

        var bookedCarsItems = await _mediator.Send(new GetAllBookedCarsItemsQuery());

        return bookedCarsItems is null ? new NotFoundResult() : new OkObjectResult(bookedCarsItems);
    }
}
