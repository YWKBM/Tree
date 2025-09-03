using AutoMapper;
using Mediator;
using Microsoft.AspNetCore.Mvc;
using TreeApi.Controllers.Tree.DTO.Responses;

namespace TreeApi.Controllers.Tree;

public class TreeController(
    IMediator mediator,
    IMapper mapper) : ControllerBase
{
    [HttpGet("api.user.tree.get")]
    public async Task<ActionResult<GetTreeResponse>> GetOrCreateTree([FromQuery]  string treeName)
    {
        var result = await mediator.Send(new TreeLogic.Features.Tree.GetOrCreate.Request
        {
            TreeName = treeName
        });
        return mapper.Map<GetTreeResponse>(result);
    }
}