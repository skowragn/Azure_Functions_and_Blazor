using CarsManager.Application.Cqrs.Commands;
using CarsManager.Application.Interfaces;
using CarsManager.Domain.Entities;
using MediatR;

namespace CarsManager.Application.Extensions.Cqrs.Queries.Handlers;

internal class CreateOrUpdateCarCommandHandler(ICarsRepository carsRepository) : IRequestHandler<CreateOrUpdateCarCommand, CarDetails>
{
    private readonly ICarsRepository _carsRepository = carsRepository;

    public async Task<CarDetails> Handle(CreateOrUpdateCarCommand request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);

        _carsRepository.Add(request.CarDetails);

        await _carsRepository.SaveChangesAsync();

        return await Task.FromResult(request.CarDetails);
    }
}