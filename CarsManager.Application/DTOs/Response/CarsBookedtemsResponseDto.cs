using Newtonsoft.Json;

namespace CarsManager.Application.DTOs.Response;

public class CarsBookedItemsResponseDto
{
    [JsonProperty("bookedCarItems")]
    public required List<CarBookedItemDto> CarBookedItems { get; set; }
}