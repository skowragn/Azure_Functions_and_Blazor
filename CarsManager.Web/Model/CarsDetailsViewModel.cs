using CarsManager.Domain.Entities;

namespace CarsManager.Web.Model;
public class CarsDetailsViewModel
{
    public string UserId { get; set; } = null!;
    public string Name { get; set; } = null!;
    public string Model { get; set; } = null!;
    public string Engine { get; set; } = null!;
    public int Year { get; set; }
    public string Description { get; set; } = null!;
    public CarCategoryViewModel Category { get; set; }
    public decimal Price { get; set; }
    public string Currency { get; set; } = null!;
    public string ImageUrl { get; set; } = null!;
}
