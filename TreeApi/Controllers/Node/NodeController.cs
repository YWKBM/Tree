using AutoMapper;
using Mediator;
using Microsoft.AspNetCore.Mvc;

namespace TreeApi.Controllers.Node;

public class NodeController(
    IMediator mediator,
    IMapper mapper) : ControllerBase
{
    [HttpPost("api.user.tree.create")]
    public async Task<ActionResult> CreateNode([FromQuery] string treeName, [FromQuery] int parentNodeId, [FromQuery] string nodeName)
    {
        await mediator.Send(new TreeLogic.Features.Node.Create.Request
        {
            TreeName = treeName,
            ParentNodeId = parentNodeId,
            NodeName =nodeName
        });
        
        return Ok();
    }
    
    [HttpPost("api.user.tree.delete")]
    public async Task<ActionResult> DeleteNode([FromQuery] string treeName, [FromQuery] int nodeId)
    {
        await mediator.Send(new TreeLogic.Features.Node.Delete.Request
        {
            TreeName = treeName,
            NodeId = nodeId
        });
        
        return Ok();
    }
    
    [HttpPost("api.user.tree.rename")]
    public async Task<ActionResult> RenameNode([FromQuery] string treeName, [FromQuery] int nodeId, [FromQuery] string newNodeName)
    {
        await mediator.Send(new TreeLogic.Features.Node.Rename.Request{
            TreeName = treeName,
            NodeId = nodeId,
            NewNodeName = newNodeName
        });
        
        return Ok();
    }
}