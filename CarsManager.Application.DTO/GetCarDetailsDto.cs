using Newtonsoft.Json;
using CarsManager.Application.DTO.Request;
using CarsManager.Application.DTO.Response;

namespace CarsManager.Application.DTO;

public class GetCarDetailsDto
{
    [JsonProperty("appName")]
    public required string AppName { get; set; }

    [JsonProperty("version")]
    public required string Version { get; set; }

    [JsonProperty("request")]
    public required CarDetailsRequestDto Request { get; set; }

    [JsonProperty("response")]
    public required CarsDetailsResponseDto Response { get; set; }
}