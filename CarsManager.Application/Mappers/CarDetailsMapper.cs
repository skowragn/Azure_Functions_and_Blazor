using CarsManager.Domain.Entities;
using CarsManager.Application.DTO;
using CarsManager.Application.Mapper;

namespace CarsManager.Application.Mappers;

public static class CarDetailsMapper
{
    public static CarDetailsDto ToCarDetailsDto(this CarDetails carDetails, CarCategories carCategory)
    {
        return new CarDetailsDto()
        {
            Name = carDetails.Name,
            Model = carDetails.Model,
            Engine = carDetails.Engine,
            Year = carDetails.Year,
            Description = carDetails.Description,
            Category = carCategory.ToCarsCategoryDto(),
            Price = carDetails.Price,
            Currency = carDetails.Currency,
            ImageUrl = carDetails.ImageUrl
        };
}

    public static CarDetails ToCarDetails(this CarDetailsDto carDetailsDto)
    {
        return new CarDetails()
        {
            Name = carDetailsDto.Name,
            Model = carDetailsDto.Model,
            Engine = carDetailsDto.Engine,
            Year = carDetailsDto.Year,
            Description = carDetailsDto.Description,
            Category = new CarCategories() { CategoryName = carDetailsDto.Category.CategoryName, Description = carDetailsDto.Category.Description },
            Price = carDetailsDto.Price,
            Currency = carDetailsDto.Currency,
            ImageUrl = carDetailsDto.ImageUrl
        };
    }
}