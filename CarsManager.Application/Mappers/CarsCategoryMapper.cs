using CarsManager.Domain.Entities;
using CarsManager.Application.Mappers;
using CarsManager.Application.DTOs.Request;


namespace CarsManager.Application.Mapper;

public static class CarsCategoryMapper
{
    public static CarCategoryDto ToCarsCategoryDto(this CarCategories carCategoryItem)
    {
        return new CarCategoryDto
        {
            CategoryName = carCategoryItem.CategoryName,
            Description = carCategoryItem.Description,
     
        };
    }

    public static CarCategories ToCarCategory(this CarCategoryDto carCategoryDto)
    {
        return new CarCategories()
        {
            CategoryName = carCategoryDto.CategoryName,
            Description = carCategoryDto.Description,
        };
    }
}
