using CarsManager.Application.Interfaces;
using CarsManager.Application.Mappers;
using MediatR;
using CarsManager.Application.DTOs;

namespace CarsManager.Application.Cqrs.Queries.Handlers;

public class GetAllCarsDetailsQueryHandler(ICarsRepository carsRepository, ICarsCategoryRepository carsCategoryRepository) : IRequestHandler<GetAllCarReservationsQuery, IEnumerable<CarDetailsDto>>
{
    private readonly ICarsRepository _carsRepository = carsRepository;
    private readonly ICarsCategoryRepository _carsCategoryRepository = carsCategoryRepository;

    public async Task<IEnumerable<CarDetailsDto>> Handle(GetAllCarReservationsQuery request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);

        List<CarDetailsDto> items = [];

        var allProducts = await _carsRepository.GetAllAsync();

        var allCarCategory = await _carsCategoryRepository.GetAllAsync();

        foreach (var item in allProducts)
        {
            foreach (var category in allCarCategory)
            {
                if(category.Id == item.CategoriesCarId)
                items.Add(item.ToCarDetailsDto(category));
            }
        }
         if (items.Count != 0)
            return items;
        else
            return [];
    }
 
}