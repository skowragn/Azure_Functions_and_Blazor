using Newtonsoft.Json;

namespace CarsManager.Application.DTOs.Request;

public class CarBookedItemRequestDto
{
    [JsonProperty("userId")]
    public string UserId { get; set; } = null!;

    [JsonProperty("quantity")]
    public int Quantity { get; set; }
    
    [JsonProperty("car")]
    public CarDetailsRequestDto Car { get; set; } = null!;

    [JsonProperty("totalprice")]
    public decimal TotalPrice { get; set; }
}
