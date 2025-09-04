using System.Text.Json.Serialization;

namespace TreeApi.Controllers.Journal.DTO.Responses;

public record GetRangeResponse
{
    [JsonPropertyName("count")]
    public int Count { get; set; }
    
    [JsonPropertyName("skip")]
    public int Skip { get; set; }

    [JsonPropertyName("items")]
    public List<Item> Items { get; set; } = [];

    public record Item
    {
        [JsonPropertyName("id")]
        public required int Id { get; set; }

        [JsonPropertyName("eventId")]
        public required string EventId { get; set; }
        
        [JsonPropertyName("createdAt")]
        public DateTimeOffset CreatedAt { get; set; }
    }
}