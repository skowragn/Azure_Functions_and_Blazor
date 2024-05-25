using Newtonsoft.Json;

namespace CarsManager.Application.DTOs;

public class CarBookedItemDto
{
    [JsonProperty("userId")]
    public string UserId { get; set; } = null!;
    
    [JsonProperty("quantity")]
    public int Quantity { get; set; }

    [JsonProperty("car")]
    public CarDetailsDto Car { get; set; } = new CarDetailsDto();

    [JsonProperty("totalPrice")]
    public decimal TotalPrice { get; set; }
}
