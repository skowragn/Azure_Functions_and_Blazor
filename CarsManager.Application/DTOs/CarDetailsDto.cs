using CarsManager.Application.DTOs.Request;
using Newtonsoft.Json;

namespace CarsManager.Application.DTOs;

public class CarDetailsDto
{
    [JsonProperty("name")]
    public string Name { get; set; } = null!;

    [JsonProperty("model")]
    public string Model { get; set; } = null!;

    [JsonProperty("engine")]
    public string Engine { get; set; } = null!;

    [JsonProperty("year")]
    public int Year { get; set; }

    [JsonProperty("description")]
    public string Description { get; set; } = null!;

    [JsonProperty("category")]
    public CarCategoryDto Category { get; set; } = null!;

    [JsonProperty("price")]
    public decimal Price { get; set; }

    [JsonProperty("currency")]
    public string Currency { get; set; } = null!;

    [JsonProperty("imageUrl")]
    public string ImageUrl { get; set; } = null!;
}