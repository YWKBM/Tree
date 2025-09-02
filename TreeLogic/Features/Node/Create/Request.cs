using Mediator;

namespace TreeLogic.Features.Node.Create;

public record Request : IRequest
{
    public required string TreeName { get; set; }
    
    public required int ParentNodeId { get; set; }
    
    public required string NodeName { get; set; }
}