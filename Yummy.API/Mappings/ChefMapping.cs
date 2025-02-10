using AutoMapper;
using Yummy.DTO.DTOs.ChefDTOs;
using Yummy.Entity.Entities;

namespace Yummy.API.Mappings
{
    public class ChefMapping : Profile
    {
        public ChefMapping()
        {
            CreateMap<CreateChefDTO, Chef>().ReverseMap();
            CreateMap<UpdateChefDTO, Chef>().ReverseMap();
            CreateMap<ResultChefDTO, Chef>().ReverseMap();
        }
    }
}