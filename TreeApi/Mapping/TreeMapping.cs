using AutoMapper;
using TreeApi.Controllers.Tree.DTO.Responses;

namespace TreeApi.Mapping;

public class TreeMapping : Profile
{
    public TreeMapping()
    {
        CreateMap<TreeLogic.Features.Tree.GetOrCreate.Result, GetTreeResponse>();
    }
}