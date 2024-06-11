using CarsManager.Application.DTO;
using MediatR;

namespace CarsManager.Application.Cqrs.Queries;

public record GetAllCarReservationsQuery : IRequest<IEnumerable<CarDetailsDto>>
{
   
}