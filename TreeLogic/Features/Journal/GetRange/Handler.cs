using Mediator;
using Microsoft.EntityFrameworkCore;
using TreeDB;

namespace TreeLogic.Features.Journal.GetRange;

public class Handler(
    AppDbContext db
    ) : IRequestHandler<Request, Result>
{
    public async ValueTask<Result> Handle(Request request, CancellationToken cancellationToken)
    {
        var query = db.Set<TreeDB.Entities.ErrorLog>();
        var count = await query.CountAsync(cancellationToken);
        
        var paged = query    
            .Skip(request.Skip)
            .Take(request.Take);
        
        var items = await paged.Select(m => new Result.Item
        {
            Id = m.Id,
            EventId = m.EventId.ToString(),
            CreatedAt = m.Timestamp
        }).ToListAsync(cancellationToken);
        
        return new Result
        {
            Skip = request.Skip,
            Count = count,
            Items = items
        };
    }
}