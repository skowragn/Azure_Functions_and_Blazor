using CarsManager.Application.DTOs.Request;
using CarsManager.Application.DTOs.Response;
using Newtonsoft.Json;

namespace CarsManager.Application.DTOs;

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