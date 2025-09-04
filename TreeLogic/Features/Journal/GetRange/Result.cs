namespace TreeLogic.Features.Journal.GetRange;

public record Result
{
    public int Count { get; set; }
    
    public int Skip { get; set; }

    public List<Item> Items { get; set; } = [];

    public record Item
    {
        public required int Id { get; set; }

        public required string EventId { get; set; }
        
        public DateTimeOffset CreatedAt { get; set; }
    }
}