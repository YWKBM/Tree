using Mediator;
using Microsoft.EntityFrameworkCore;
using TreeDB;
using TreeLogic.Exceptions;

namespace TreeLogic.Features.Node.Rename;

public class Handler(
    AppDbContext db
) : IRequestHandler<Request>
{
    public async ValueTask<Unit> Handle(Request request, CancellationToken cancellationToken)
    {
        if (await db.Set<TreeDB.Entities.Node>().Where(m => m.TreeName == request.TreeName && m.Name == request.NewNodeName).AnyAsync(cancellationToken))
            throw new SecureException($"Node name {request.NewNodeName} already exists");  
        
        var node = await db.Set<TreeDB.Entities.Node>()
            .Where(m => m.TreeName == request.TreeName)
            .Where(m => m.Id == request.NodeId)
            .FirstOrDefaultAsync(cancellationToken)
            ?? throw new SecureException($"Node id {request.NodeId} not found");
        
        if (node.ParentNodeId == null)
        {
            await db.Set<TreeDB.Entities.Node>().Where(m => m.TreeName == node.TreeName)
                .ExecuteUpdateAsync(t => t.SetProperty(m => m.TreeName, request.NewNodeName), cancellationToken);
        }
        
        node.Name = request.NewNodeName;
        
        await db.SaveChangesAsync(cancellationToken);
        
        return Unit.Value;
    }
}