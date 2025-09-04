using AutoMapper;
using TreeApi.Controllers.Journal.DTO.Responses;

namespace TreeApi.Mapping;

public class ErrorLogMapping : Profile
{
    public ErrorLogMapping()
    {
        // GetSingle
        CreateMap<TreeLogic.Features.Journal.Get.Result, GetSingleResponse>();
        
        // GetRange
        CreateMap<TreeLogic.Features.Journal.GetRange.Result, GetRangeResponse>();
    }

}