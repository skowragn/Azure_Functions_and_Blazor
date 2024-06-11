using CarsManager.Domain.Entities;
using CarsManager.Application.DTO.Request;
using CarsManager.Application.DTO;

namespace CarsManager.Application.Mappers;

public static class CarDetailsRequestMapper
{
    public static CarDetailsRequestDto ToCarDetailsRequestDto(this CarDetails carDetails)
    {
        return new CarDetailsRequestDto()
        {
            Name = carDetails.Name,
            Model = carDetails.Model,
            Engine = carDetails.Engine,
            Year = carDetails.Year,
            Description = carDetails.Description,
            Category = new CarCategoryDto() { CategoryName = carDetails.Category.CategoryName, Description = carDetails.Category.Description },
            Price = carDetails.Price,
            Currency = carDetails.Currency,
            ImageUrl = carDetails.ImageUrl
        };
}

    public static CarDetails ToCarDetails(this CarDetailsRequestDto carDetailsRequestDto)
    {
        return new CarDetails()
        {
            Name = carDetailsRequestDto.Name,
            Model = carDetailsRequestDto.Model,
            Engine = carDetailsRequestDto.Engine,
            Year = carDetailsRequestDto.Year,
            Description = carDetailsRequestDto.Description,
            Category = new CarCategories() { CategoryName = carDetailsRequestDto.Category.CategoryName, Description = carDetailsRequestDto.Category.Description },
            Price = carDetailsRequestDto.Price,
            Currency = carDetailsRequestDto.Currency,
            ImageUrl = carDetailsRequestDto.ImageUrl
        };
    }
}