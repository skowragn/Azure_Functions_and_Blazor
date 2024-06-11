using Newtonsoft.Json;
using CarsManager.Application.DTO.Request;
using CarsManager.Application.DTO.Response;

namespace CarsManager.Application.DTO;

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