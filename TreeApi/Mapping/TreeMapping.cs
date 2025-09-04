using AutoMapper;
using TreeApi.Controllers.Tree.DTO.Responses;

namespace TreeApi.Mapping;

public class TreeMapping : Profile
{
    public TreeMapping()
    {
        // Get
        CreateMap<TreeLogic.Features.Tree.GetOrCreate.Result, GetTreeResponse>();
    }
}