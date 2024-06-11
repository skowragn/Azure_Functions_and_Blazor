using CarsManager.Application.DTO;
using CarsManager.Domain.Entities;
using MediatR;

namespace CarsManager.Application.Cqrs.Commands;

public record AddOrUpdateCarBookedItemCommand : IRequest<CarsBookedItem>
{
    public AddOrUpdateCarBookedItemCommand(CarsBookedItem carBookedItem)
    {
        CarsBookedItem = carBookedItem;
    }

    public CarsBookedItem CarsBookedItem { get; }
}