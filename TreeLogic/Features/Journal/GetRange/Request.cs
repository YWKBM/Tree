using Mediator;

namespace TreeLogic.Features.Journal.GetRange;

public record Request : IRequest<Result>
{
    public required int Skip { get; set; }
    
    public required int Take { get; set; }
}