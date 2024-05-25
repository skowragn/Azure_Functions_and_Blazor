namespace CarsManager.Domain.Entities;

public class CarDetails : BaseEntity
{
    public string Name { get; set; } = null!;
    public string Model { get; set; } = null!;
    public string Engine { get; set; } = null!;
    public int Year { get; set; }
    public string Description { get; set; } = null!;

    public int CategoriesCarId { get; set; }
    public CarCategories Category { get; set; } = null!;
    public decimal Price { get; set; }
    public string Currency { get; set; } = null!;
    public string ImageUrl { get; set; } = null!;

    public CarsBookedItem? CarsBookedItem { get; set; }

    public override string ToString() => $"{Category} {Name}";
}