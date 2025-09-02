using Mediator;
using Microsoft.EntityFrameworkCore;
using TreeDB;

namespace TreeLogic.Features.Node.Delete;

public class Handler(
    AppDbContext db
) : IRequestHandler<Request>
{
    public async ValueTask<Unit> Handle(Request request, CancellationToken cancellationToken)
    {
        if (await db.Set<TreeDB.Entities.Node>()
                .Where(m => m.TreeName == request.TreeName)
                .Where(m => m.ParentNodeId == request.NodeId)
                .AnyAsync(cancellationToken)
           )
        {
            throw new Exception("Unable to delete - node is parent");
        }

        await db.Set<TreeDB.Entities.Node>()
            .Where(m => m.TreeName == request.TreeName)
            .Where(m => m.Id == request.NodeId)
            .ExecuteDeleteAsync(cancellationToken);
        
        return Unit.Value;
    }
}