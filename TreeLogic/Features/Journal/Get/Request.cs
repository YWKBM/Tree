using Mediator;

namespace TreeLogic.Features.Journal.Get;

public record Request : IRequest<Result>
{
    public int Id { get; set; }
}