namespace TreeLogic.Features.Tree.GetOrCreate;

public record Result
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public List<string> Children { get; set; } = [];
}