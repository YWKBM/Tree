namespace TreeDB.Entities;

public class Node
{
    public int Id { get; set; }

    public required string Name { get; set; }
    
    public int? ParentNodeId { get; set; }
    
    public required string TreeName { get; set; }
}