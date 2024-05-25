namespace CarsManager.Domain.Entities;

public class CarsBookedItem () : BaseEntity
{
    public string UserId { get; set; } = null!;
    public int Quantity { get; set; }

    public int CarId { get; set; }
    public CarDetails Car { get; set; } = null!;

    [JsonIgnore]
    public decimal TotalPrice => Math.Round(Quantity * Car.Price, 2);

    public override string ToString() => $"{Car.Category} {Car.Name} {Quantity} {UserId} {TotalPrice}";
}
