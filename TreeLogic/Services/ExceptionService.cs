using TreeDB;
using TreeDB.Entities;

namespace TreeLogic.Services;

public class ExceptionService(
    AppDbContext db)
{
    public async Task<Guid> AddToJournal(Exception ex, string? requestBody)
    {
        var eventId = Guid.NewGuid();
        
        var errorLog = new ErrorLog()
        {
            EventId = eventId,
            Timestamp = DateTimeOffset.UtcNow,
            StackTrace = ex.StackTrace!,
            Body = requestBody
        };
        
        await db.AddAsync(errorLog);
        await db.SaveChangesAsync();

        return eventId;
    }
}