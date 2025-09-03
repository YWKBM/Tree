using System.Text.Json.Serialization;

namespace TreeApi.Middlewares.DTO;

public record ErrorResponse
{
    [JsonPropertyName("type")]
    public required string Type { get; set; } 
    
    [JsonPropertyName("id")]
    public required string Id { get; set; }
    
    [JsonPropertyName("data")]
    public required DataItem Data { get; set; } 

    public record DataItem
    {
        [JsonPropertyName("message")]
        public string Message { get; set; } = string.Empty;
    }
}