using CarsManager.Application.DTOs.Request;
using CarsManager.Application.DTOs.Response;
using Newtonsoft.Json;

namespace CarsManager.Application.DTOs;

public class GetBookedCarItemsDto
{
    [JsonProperty("appName")]
    public required string AppName { get; set; }

    [JsonProperty("version")]
    public required string Version { get; set; }

    [JsonProperty("request")]
    public required CarBookedItemRequestDto Request { get; set; }

    [JsonProperty("response")]
    public required CarsBookedItemsResponseDto Response { get; set; }
}