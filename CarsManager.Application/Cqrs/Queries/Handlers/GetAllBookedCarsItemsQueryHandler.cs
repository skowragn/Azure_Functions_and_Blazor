using CarsManager.Application.DTO;
using CarsManager.Application.Interfaces;
using CarsManager.Application.Mapper;
using CarsManager.Application.Mappers;
using MediatR;

namespace CarsManager.Application.Cqrs.Queries.Handlers;

internal class GetAllBookedCarsItemsQueryHandler(ICarsBookedItemRepository carsBookedItemRepository, ICarsRepository carsRepository, ICarsCategoryRepository carsCategoryRepository) : IRequestHandler<GetAllBookedCarsItemsQuery, IEnumerable<CarBookedItemDto>>
{
    private readonly ICarsBookedItemRepository _carsBookedItemRepository = carsBookedItemRepository;
    private readonly ICarsRepository _carsRepository = carsRepository;
    private readonly ICarsCategoryRepository _carsCategoryRepository = carsCategoryRepository;

    public async Task<IEnumerable<CarBookedItemDto>> Handle(GetAllBookedCarsItemsQuery request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);

        var items = new List<CarBookedItemDto>();

        var allBookedCarItems = await _carsBookedItemRepository.GetAllAsync();
        var allCarsDetails = await _carsRepository.GetAllAsync();
        var allCarCategory = await _carsCategoryRepository.GetAllAsync();

        foreach (var item in allBookedCarItems)
        {
            foreach (var carDetails in allCarsDetails)
            {
               foreach (var category in allCarCategory)
               {
                    if (category.Id == carDetails.CategoriesCarId)
                    { 
                        carDetails.Category = category;
                     
                        if (item.Car.Id == carDetails.Id)
                            items.Add(item.ToCarsBookedItemDto(carDetails));
                    }
                }
               
            }
        }
        if (items.Count != 0)
            return items;
        else
            return [];
    }
}