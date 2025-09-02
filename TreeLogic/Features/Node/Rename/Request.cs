using Mediator;

namespace TreeLogic.Features.Node.Rename;

public record Request : IRequest
{
    public required string TreeName { get; set; }
    
    public required int NodeId { get; set; }
    
    public required string NewNodeName { get; set; }
}