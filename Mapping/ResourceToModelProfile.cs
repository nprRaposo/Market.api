using AutoMapper;
using Market.Api.Domain.Models;
using Market.Api.Resources;

namespace Market.Api.Mapping
{
    public class ResourceToModelProfile : Profile
    {
        public ResourceToModelProfile()
        {
            CreateMap<CategoryResourceSave, Category>();
        }
    }
}
