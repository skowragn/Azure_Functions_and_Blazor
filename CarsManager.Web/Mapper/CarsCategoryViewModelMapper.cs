using CarsManager.Application.DTOs;
using CarsManager.Web.Model;
using CarsManager.Web.Mapper;
using CarsManager.Application.DTOs.Request;

namespace CarsManager.Web.Mapper;

public static class CarsCategoryViewModelMapper
{
    public static CarCategoryDto ToCarCategoryDto(this CarCategoryViewModel carCategoryViewModel)
    {
        return new CarCategoryDto
        {
           CategoryName = carCategoryViewModel.CategoryName,
           Description = carCategoryViewModel.Description
        };
    }

    public static CarCategoryViewModel ToCarCategoryViewModel(this CarCategoryDto carCategoryDto)
    {

        return new CarCategoryViewModel
        {
            CategoryName = carCategoryDto.CategoryName,
            Description = carCategoryDto.Description
        };
    }
}
