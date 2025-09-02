using Mediator;

namespace TreeLogic.Features.Node.Delete;

public record Request : IRequest
{
    public required string TreeName { get; set; }
    
    public int NodeId { get; set; }
}