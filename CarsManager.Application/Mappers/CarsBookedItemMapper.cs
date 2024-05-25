using CarsManager.Domain.Entities;
using CarsManager.Application.Mappers;
using CarsManager.Application.DTOs;


namespace CarsManager.Application.Mapper;

public static class CarsBookedItemMapper
{
    public static CarBookedItemDto ToCarsBookedItemDto(this CarsBookedItem carBookedItem, CarDetails car)
    {
        var carBookedItemDto = new CarBookedItemDto()
        {
            UserId = carBookedItem.UserId,
            Quantity = carBookedItem.Quantity,
            TotalPrice = carBookedItem.TotalPrice
        };
        if (carBookedItem != null && carBookedItem.Car != null)
            carBookedItemDto.Car = car.ToCarDetailsDto(car.Category);

        return carBookedItemDto;
    }

    public static CarsBookedItem ToCarsBookedItem(this CarBookedItemDto carBookedItemDto)
    {
        var carBookedItem = new CarsBookedItem()
        {
            UserId = carBookedItemDto.UserId,
            Quantity = carBookedItemDto.Quantity,
        };

        if (carBookedItemDto != null && carBookedItemDto.Car != null)
            carBookedItem.Car = carBookedItemDto.Car.ToCarDetails();

        return carBookedItem;
    }
}
