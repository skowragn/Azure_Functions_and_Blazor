using CarsManager.Application.DTO;
using CarsManager.Web.Model;

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
