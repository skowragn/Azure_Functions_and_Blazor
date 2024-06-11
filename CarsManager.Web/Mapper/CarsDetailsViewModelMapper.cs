using CarsManager.Web.Model;
using CarsManager.Application.DTO;

namespace CarsManager.Web.Mapper;

public static class CarsDetailsViewModelMapper
{
    public static CarDetailsDto ToCarDetailsDto(this CarsDetailsViewModel carDetails)
    {
        return new CarDetailsDto()
        {
            Name = carDetails.Name,
            Model = carDetails.Model,
            Engine = carDetails.Engine,
            Year = carDetails.Year,
            Description = carDetails.Description,
            Category = carDetails.Category.ToCarCategoryDto(),
            Price = carDetails.Price,
            Currency = carDetails.Currency,
            ImageUrl = carDetails.ImageUrl
        };
    }

    public static CarsDetailsViewModel ToCarDetailsViewModel(this CarDetailsDto carDetailsRequestDto)
    {
        return new CarsDetailsViewModel()
        {
            Name = carDetailsRequestDto.Name,
            Model = carDetailsRequestDto.Model,
            Engine = carDetailsRequestDto.Engine,
            Year = carDetailsRequestDto.Year,
            Description = carDetailsRequestDto.Description,
            Category = carDetailsRequestDto.Category.ToCarCategoryViewModel(),
            Price = carDetailsRequestDto.Price,
            Currency = carDetailsRequestDto.Currency,
            ImageUrl = carDetailsRequestDto.ImageUrl
        };
    }
}
