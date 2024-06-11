using Newtonsoft.Json;

namespace CarsManager.Application.DTO.Response;

public class CarsDetailsResponseDto
{
    [JsonProperty("cardetails")]
    public required List<CarDetailsDto> CarDetails { get; set; }
}