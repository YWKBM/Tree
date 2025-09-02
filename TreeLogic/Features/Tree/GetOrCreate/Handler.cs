using Mediator;
using Microsoft.EntityFrameworkCore;
using TreeDB;

namespace TreeLogic.Features.Tree.GetOrCreate;

public class Handler(
    AppDbContext db) : IRequestHandler<Request, Result>
{
    public async ValueTask<Result> Handle(Request request, CancellationToken cancellationToken)
    {
        var root = await db.Set<TreeDB.Entities.Node>()
            .FirstOrDefaultAsync(m => m.Name == request.TreeName, cancellationToken);

        if (root is null)
        {
            root = new TreeDB.Entities.Node()
            {
                Name = request.TreeName,
                ParentNodeId = null,
                TreeName = request.TreeName,
            };

            await db.AddAsync(root, cancellationToken);
            var id = await db.SaveChangesAsync(cancellationToken);
            
            return new Result()
            {
                Id = id,
                Name = root.Name,
                Children = [],
            };
        }
        var treeNodes = new List<TreeDB.Entities.Node>();
        
        var queue = new Queue<TreeDB.Entities.Node>();
        queue.Enqueue(root);
        
        while (queue.TryDequeue(out var node))
        {
            treeNodes.Add(node);
            
            var childNodes = await db.Set<TreeDB.Entities.Node>()
                .ToListAsync(cancellationToken);
            
            foreach (var childNode in childNodes) queue.Enqueue(childNode);
        }

        return new Result()
        {
            Id = root.Id,
            Name = root.Name,
            Children = treeNodes.Select(m => m.Name).ToList()
        };
    }
}