using AutoMapper;
using Yummy.DTO.DTOs.FeatureDTOs;
using Yummy.Entity.Entities;

namespace Yummy.API.Mappings
{
    public class FeatureMapping : Profile
    {
        public FeatureMapping()
        {
            CreateMap<CreateFeatureDTO, Feature>().ReverseMap();
            CreateMap<UpdateFeatureDTO, Feature>().ReverseMap();
            CreateMap<ResultFeatureDTO, Feature>().ReverseMap();
        }
    }
}