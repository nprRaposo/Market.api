using AutoMapper;
using Market.Api.Domain.Models;
using Market.Api.Resources;

namespace Market.Api.Mapping
{
    public class ModelToResourceProfile : Profile
    {
        public ModelToResourceProfile()
        {
            CreateMap<Category, CategoryResource>();
        }
    }
}
