using Mediator;
using Microsoft.EntityFrameworkCore;
using TreeDB;

namespace TreeLogic.Features.Journal.Get;

public class Handler
(
    AppDbContext db
) : IRequestHandler<Request, Result>
{
    public async ValueTask<Result> Handle(Request request, CancellationToken cancellationToken)
    {
        var errorLog = await db.Set<TreeDB.Entities.ErrorLog>()
            .FirstOrDefaultAsync(m => m.Id == request.Id, cancellationToken)
            ?? throw new Exception("Error log not found");

        return new Result()
        {
            Id = errorLog.Id,
            EventId = errorLog.EventId.ToString(),
            Text = errorLog.StackTrace!,
            CreatedAt = errorLog.Timestamp,
        };
    }
}