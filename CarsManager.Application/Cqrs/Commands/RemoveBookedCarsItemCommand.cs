using MediatR;
using CarsManager.Domain.Entities;

namespace CarsManager.Application.Cqrs.Commands;

public record RemoveBookedCarsItemCommand : IRequest<CarsBookedItem>
{
    public RemoveBookedCarsItemCommand(int bookedCarId)
    {
        CarsBookedItem = new CarsBookedItem() { Id = bookedCarId };
    }

    public CarsBookedItem CarsBookedItem { get; private set; } 
}