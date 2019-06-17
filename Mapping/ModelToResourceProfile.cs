using AutoMapper;
using Market.Api.Domain.Models;
using Market.Api.Extensions;
using Market.Api.Resources;

namespace Market.Api.Mapping
{
    public class ModelToResourceProfile : Profile
    {
        public ModelToResourceProfile()
        {
            CreateMap<Category, CategoryResourceGet>();

            CreateMap<Product, ProductResourceGet>()
                .ForMember(src => src.UnitOfMeasurement,
                           opt => opt.MapFrom(src => src.UnitOfMeasurement.ToDescriptionString()));
        }
    }
}
