using System.ComponentModel.DataAnnotations.Schema;


namespace CarsManager.Domain.Entities;

[Table("CarsCategory")]
public class CarCategories() : BaseEntity
{
    public string? CategoryName { get; set; }
    public string? Description { get; set; }
    public CarDetails CategoriesCarDetails { get; set; } = null!;
}
