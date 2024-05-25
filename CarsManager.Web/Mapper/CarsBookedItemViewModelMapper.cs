using CarsManager.Application.DTOs;
using CarsManager.Web.Model;
using CarsManager.Web.Mapper;

namespace CarsManager.Web.Mapper;

public static class CarsBookedItemViewModelMapper
{
    public static CarBookedItemDto ToCarsBookedItemDto(this CarsBookedItemViewModel carBookedItemViewModel)
    {
        return new CarBookedItemDto
        {
            UserId = carBookedItemViewModel.UserId,
            Quantity = carBookedItemViewModel.Quantity,
            Car = carBookedItemViewModel.Car.ToCarDetailsDto(),
            TotalPrice = carBookedItemViewModel.TotalPrice
        };
    }

    public static CarsBookedItemViewModel ToCarsBookedItemViewModel(this CarBookedItemDto carBookedItemDto)
    {
        return new CarsBookedItemViewModel()
        {
            UserId = carBookedItemDto.UserId,
            Quantity = carBookedItemDto.Quantity,
            Car = carBookedItemDto.Car.ToCarDetailsViewModel(),
            TotalPrice = carBookedItemDto.TotalPrice
        };
    }
}
