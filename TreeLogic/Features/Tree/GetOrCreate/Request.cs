using Mediator;

namespace TreeLogic.Features.Tree.GetOrCreate;

public record Request : IRequest<Result>
{
    public required string TreeName { get; set; }
}