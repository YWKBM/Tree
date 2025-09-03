using Microsoft.EntityFrameworkCore;

namespace TreeDB.Entities;

[PrimaryKey("Id", new string[] {})]
public class ErrorLog
{
    public int Id { get; set; }
    
    public Guid EventId { get; set; }
    
    public DateTimeOffset Timestamp { get; set; }

    public string? Body { get; set; } 
    
    public string? StackTrace { get; set; }
}