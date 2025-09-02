using Mediator;
using Microsoft.EntityFrameworkCore;
using TreeDB;

namespace TreeLogic.Features.Node.Create;

public class Handler(
    AppDbContext db
) : IRequestHandler<Request>
{
    public async ValueTask<Unit> Handle(Request request, CancellationToken cancellationToken)
    {
        if (await db.Set<TreeDB.Entities.Node>().Where(m => m.TreeName == request.TreeName && m.Name == request.NodeName).AnyAsync(cancellationToken))
            throw new Exception($"Node name {request.NodeName} already exists");

        var parentNode = await db.Set<TreeDB.Entities.Node>()
            .FirstOrDefaultAsync(m => m.Id == request.ParentNodeId && m.TreeName == request.TreeName, cancellationToken)
            ?? throw new Exception($"Parent node not found");

        await db.AddAsync(new TreeDB.Entities.Node
        {
            ParentNodeId = parentNode.Id,
            TreeName = parentNode.TreeName,
            Name = request.NodeName,
        }, cancellationToken);
        
        await db.SaveChangesAsync(cancellationToken);
        
        return Unit.Value;
    }
}