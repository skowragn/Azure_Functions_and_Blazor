using Newtonsoft.Json;

namespace CarsManager.Application.DTOs.Response;

public class CarsDetailsResponseDto
{
    [JsonProperty("cardetails")]
    public required List<CarDetailsDto> CarDetails { get; set; }
}