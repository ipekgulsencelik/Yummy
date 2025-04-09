using AutoMapper;
using Yummy.DTO.DTOs.ServiceDTOs;
using Yummy.Entity.Entities;

namespace Yummy.API.Mappings
{
    public class ServiceMapping : Profile
    {
        public ServiceMapping()
        {
            CreateMap<CreateServiceDTO, Service>().ReverseMap();
            CreateMap<UpdateServiceDTO, Service>().ReverseMap();
            CreateMap<ResultServiceDTO, Service>().ReverseMap();
        }
    }
}