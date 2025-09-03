using Microsoft.EntityFrameworkCore;

namespace TreeDB.Entities;

[PrimaryKey("Id", new string[] {})]
public class Node
{
    public int Id { get; set; }

    public required string Name { get; set; }
    
    public int? ParentNodeId { get; set; }
    
    public required string TreeName { get; set; }
}