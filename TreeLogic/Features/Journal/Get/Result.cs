namespace TreeLogic.Features.Journal.Get;

public record Result
{
    public string Text { get; set; } = string.Empty;
    
    public required int Id { get; set; }
    
    public required string EventId { get; set; }
    
    
    public required DateTimeOffset CreatedAt { get; set; }
}
