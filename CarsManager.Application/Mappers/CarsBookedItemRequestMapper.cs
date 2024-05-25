using CarsManager.Domain.Entities;
using CarsManager.Application.Mappers;
using CarsManager.Application.DTOs.Request;


namespace CarsManager.Application.Mapper;

public static class CarsBookedItemRequestMapper
{
    public static CarBookedItemRequestDto ToCarsBookedItemRequestDto(this CarsBookedItem carBookedItem)
    {
        return new CarBookedItemRequestDto
        {
            UserId = carBookedItem.UserId,
            Quantity = carBookedItem.Quantity,
            Car = carBookedItem.Car.ToCarDetailsRequestDto(),
            TotalPrice = carBookedItem.TotalPrice
        };
    }

    public static CarsBookedItem ToCarsBookedItem(this CarBookedItemRequestDto carBookedItemRequestDto)
    {
        return new CarsBookedItem()
        {
            UserId = carBookedItemRequestDto.UserId,
            Quantity = carBookedItemRequestDto.Quantity,
            Car = carBookedItemRequestDto.Car.ToCarDetails()
        };
    }
}
