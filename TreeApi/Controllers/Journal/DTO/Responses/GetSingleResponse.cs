using System.Text.Json.Serialization;

namespace TreeApi.Controllers.Journal.DTO.Responses;

public record GetSingleResponse
{
    [JsonPropertyName("text")]
    public string Text { get; set; } = string.Empty;
    
    [JsonPropertyName("id")]
    public required int Id { get; set; }
    
    [JsonPropertyName("eventId")]
    public required string EventId { get; set; }
    
    [JsonPropertyName("createdAt")]
    public required DateTimeOffset CreatedAt { get; set; }
}