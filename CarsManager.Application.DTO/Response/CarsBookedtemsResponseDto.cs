using Newtonsoft.Json;

namespace CarsManager.Application.DTO.Response;

public class CarsBookedItemsResponseDto
{
    [JsonProperty("bookedCarItems")]
    public required List<CarBookedItemDto> CarBookedItems { get; set; }
}