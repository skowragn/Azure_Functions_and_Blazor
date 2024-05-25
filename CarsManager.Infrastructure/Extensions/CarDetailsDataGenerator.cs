using CarsManager.Domain.Entities;

namespace CarsManager.Infrastructure.Extensions;
public class CarDetailsDataGenerator
{
    private static readonly Dictionary<CarTypes, CarDetails?> _carsStorage = new()
    {
        [CarTypes.Porsche] = CreateCare(CarTypes.Porsche.ToString(), "X", "2.4", 2004, "speedy", (int)CarCategoryEnum.Sport, 100000, "$", "/Images/Porsche.jpg"),
        [CarTypes.BMW] = CreateCare(CarTypes.BMW.ToString(), "C", "2.4", 2022, "modern", (int)CarCategoryEnum.SUV, 10000, "$", "/Images/BMW.jpg"),
        [CarTypes.BMW2] = CreateCare(CarTypes.BMW2.ToString(), "X", "2.4", 2020, "comfortable", (int)CarCategoryEnum.Sport, 10000, "$", "/Images/BMW2.jpg"),
        [CarTypes.Jaguar] = CreateCare(CarTypes.Jaguar.ToString(), "X", "2.8", 2021, "extra speedy", (int)CarCategoryEnum.Other, 10000, "$", "/Images/Jaguar.jpg"),

        [CarTypes.AlfaRomeo] = CreateCare(CarTypes.AlfaRomeo.ToString(), "P", "2.8", 2021, "sport", (int)CarCategoryEnum.Hatchback, 10000, "$", "/Images/AlfaRomeo.jpg"),
        [CarTypes.Alpine] = CreateCare(CarTypes.Alpine.ToString(), "Y", "1.7", 2021, "family", (int)CarCategoryEnum.Other, 10000, "$", "/Images/Alpine.jpg"),
        [CarTypes.Bentley] = CreateCare(CarTypes.Bentley.ToString(), "F", "2.4", 2021, "extra speedy", (int)CarCategoryEnum.Sport, 10000, "$", "/Images/Bentley.jpg"),
        [CarTypes.Mercedes] = CreateCare(CarTypes.Mercedes.ToString(), "G", "3.0", 2021, "extra speedy", (int)CarCategoryEnum.Sport, 10000, "$", "/Images/Mercedes.jpg"),
    };

    private readonly Dictionary<string, CarsBookedItem?> _carsBookedItemStorage = new()
    {
        ["Anna"]= CarsBookedItemCreate("Anna", 2, GetCar(CarTypes.Porsche)),
        ["Jan"] = CarsBookedItemCreate("Jan", 1, GetCar(CarTypes.Porsche)),
        ["Piotr"] = CarsBookedItemCreate("Piotr", 3, GetCar(CarTypes.BMW)),
        ["Luke"] = CarsBookedItemCreate("Luke", 1, GetCar(CarTypes.Jaguar))
    };

    private readonly Dictionary<CarCategoryEnum, CarCategories?> _carCategories = new()
    {
        [CarCategoryEnum.Sport] = CarCategoriesCreate(CarCategoryEnum.Sport, "Sport Car"),
        [CarCategoryEnum.SUV] = CarCategoriesCreate(CarCategoryEnum.SUV, "SUV Car"),
        [CarCategoryEnum.Hatchback] = CarCategoriesCreate(CarCategoryEnum.Hatchback, "Hatchback Car"),
        [CarCategoryEnum.Other] = CarCategoriesCreate(CarCategoryEnum.Other, "Other Car")
    };


    public List<CarDetails> GetAllCars()
    {
        return [.. _carsStorage.Values];
    }

    public List<CarsBookedItem> GetAllBookedItemCars()
    {
        return [.. _carsBookedItemStorage.Values];
    }

    public static CarDetails? GetCar(CarTypes carTypes)
    {
        return _carsStorage.TryGetValue(carTypes, out CarDetails? value) ? value : new CarDetails();
    }

    public List<CarCategories> GetAllCarCategories()
    {
        return [.. _carCategories.Values];
    }

    private static CarDetails CreateCare(string name, string model, string engine, int year, string desc, int category, decimal price, string currency, string imagePath)
    {
        return new CarDetails()
        {
            Name = name,
            Model = model,
            Engine = engine,
            Year = year,
            Description = desc,
            CategoriesCarId = category,
            Price = price,
            Currency = currency,
            ImageUrl = imagePath
        };
    }

    private static CarsBookedItem CarsBookedItemCreate(string userId, int quantity, CarDetails car)
    {
        return new CarsBookedItem()
        {
            UserId = userId,
            Quantity = quantity,
            Car = car
        };
    }

    private static CarCategories CarCategoriesCreate(CarCategoryEnum categoryName, string description)
    {
        return new CarCategories()
        {
            CategoryName = categoryName.ToString(),
            Description = description
        };
    }
}
