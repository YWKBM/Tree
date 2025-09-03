using System.Text.Json.Serialization;

namespace TreeApi.Controllers.Tree.DTO.Responses;

public record GetTreeResponse
{
    [JsonPropertyName("id")]
    public required int Id { get; set; }
    
    [JsonPropertyName("name")]
    public required string Name { get; set; }
    
    [JsonPropertyName("children")]
    public List<string> Children { get; set; } = [];
}