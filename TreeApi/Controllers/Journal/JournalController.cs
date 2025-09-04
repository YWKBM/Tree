using AutoMapper;
using Mediator;
using Microsoft.AspNetCore.Mvc;
using TreeApi.Controllers.Journal.DTO.Responses;

namespace TreeApi.Controllers.Journal;

public class JournalController(
    IMediator mediator,
    IMapper mapper) : ControllerBase
{
    public async Task<ActionResult<GetSingleResponse>> GetSingle([FromBody] int id)
    {
        var request = new TreeLogic.Features.Journal.Get.Request()
        {
            Id = id,
        };
        
        var result = await mediator.Send(request);
        
        return mapper.Map<GetSingleResponse>(result);
    }

    public async Task<ActionResult<GetRangeResponse>> GetRange([FromBody] int skip, [FromBody] int take)
    {
        var request = new TreeLogic.Features.Journal.GetRange.Request()
        {
            Skip = skip,
            Take = take
        };
        
        var result = await mediator.Send(request);
        
        return mapper.Map<GetRangeResponse>(result);
    }
}