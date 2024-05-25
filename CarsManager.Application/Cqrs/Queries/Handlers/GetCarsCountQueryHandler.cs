using CarsManager.Application.Interfaces;
using MediatR;

namespace CarsManager.Application.Cqrs.Queries.Handlers;

internal class GetCarsCountQueryHandler(ICarsBookedItemRepository carsBookedItemRepository) : IRequestHandler<GetCarsCountQuery, int>
{
    private readonly ICarsBookedItemRepository _carsBookedItemRepository = carsBookedItemRepository;

    public async Task<int> Handle(GetCarsCountQuery request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);
        var allBookedCarItems = await _carsBookedItemRepository.GetAllAsync();


        return await Task.FromResult(0);
    }
}