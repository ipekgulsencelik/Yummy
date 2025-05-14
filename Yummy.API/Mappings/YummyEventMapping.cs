using AutoMapper;
using Yummy.DTO.DTOs.YummyEventDTOs;
using Yummy.Entity.Entities;

namespace Yummy.API.Mappings
{
    public class YummyEventMapping : Profile
    {
        public YummyEventMapping()
        {
            CreateMap<CreateYummyEventDTO, YummyEvent>().ReverseMap();
            CreateMap<UpdateYummyEventDTO, YummyEvent>().ReverseMap();
            CreateMap<ResultYummyEventDTO, YummyEvent>().ReverseMap();
        }
    }
}