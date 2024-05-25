using MediatR;

namespace CarsManager.Application.Cqrs.Queries;
public record GetCarsCountQuery : IRequest<int>
{
}
