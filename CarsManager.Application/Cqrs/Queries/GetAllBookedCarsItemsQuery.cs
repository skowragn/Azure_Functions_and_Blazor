using CarsManager.Application.DTO;
using MediatR;

namespace CarsManager.Application.Cqrs.Queries;

public record GetAllBookedCarsItemsQuery : IRequest<IEnumerable<CarBookedItemDto>>
{
   
}