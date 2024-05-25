using CarsManager.Domain.Entities;
using MediatR;

namespace CarsManager.Application.Cqrs.Commands;

public record CreateOrUpdateCarCommand: IRequest<CarDetails>
{
    public CreateOrUpdateCarCommand(CarDetails Car)
    {
        CarDetails = Car;
    }

    public CarDetails CarDetails { get; }
    
}