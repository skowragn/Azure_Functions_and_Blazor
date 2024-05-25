using CarsManager.Application.DTOs;
using MediatR;

namespace CarsManager.Application.Cqrs.Queries;

public record GetAllBookedCarsItemsQuery : IRequest<IEnumerable<CarBookedItemDto>>
{
   
}