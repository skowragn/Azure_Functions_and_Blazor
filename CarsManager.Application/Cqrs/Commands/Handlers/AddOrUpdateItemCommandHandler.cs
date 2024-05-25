using MediatR;
using CarsManager.Application.Cqrs.Commands;
using CarsManager.Application.Interfaces;
using CarsManager.Domain.Entities;

namespace CarsManager.IApplication.Extensions.Cqrs.Queries.Handlers;

internal class AddOrUpdateItemCommandHandler(ICarsBookedItemRepository carsBookedItemRepository) : IRequestHandler<AddOrUpdateCarBookedItemCommand, CarsBookedItem>
{
    private readonly ICarsBookedItemRepository _carsBookedItemRepository = carsBookedItemRepository;

    public async Task<CarsBookedItem> Handle(AddOrUpdateCarBookedItemCommand request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);

        var carBookedItem = await _carsBookedItemRepository.GetByIdAsync(request.CarsBookedItem.Id);

        if (carBookedItem != null)
        
            _carsBookedItemRepository.Update(request.CarsBookedItem);
        else
            _carsBookedItemRepository.Add(request.CarsBookedItem);

        await _carsBookedItemRepository.SaveChangesAsync();

        return await Task.FromResult(request.CarsBookedItem);
    }
}