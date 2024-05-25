using CarsManager.Application.Cqrs.Commands;
using CarsManager.Application.Interfaces;
using CarsManager.Domain.Entities;
using MediatR;

namespace CarsManager.Application.Extensions.Cqrs.Queries.Handlers;

internal class RemoveBookedCarsItemCommandHandler(ICarsBookedItemRepository carsBookedItemRepository) : IRequestHandler<RemoveBookedCarsItemCommand, CarsBookedItem>
{
    private readonly ICarsBookedItemRepository _carsBookedItemRepository = carsBookedItemRepository;

    public async Task<CarsBookedItem> Handle(RemoveBookedCarsItemCommand request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);

        var carsBookedItem = await _carsBookedItemRepository.GetByIdAsync(request.CarsBookedItem.Car.Id);

        if (carsBookedItem != null)
        {
            _carsBookedItemRepository.Delete(carsBookedItem);
            await _carsBookedItemRepository.SaveChangesAsync();
            return await Task.FromResult(carsBookedItem);
        }
        else
            return await Task.FromResult(new CarsBookedItem());
    }
}