using AutoMapper;
using Yummy.DTO.DTOs.ContactDTOs;
using Yummy.Entity.Entities;

namespace Yummy.API.Mappings
{
    public class ContactMapping : Profile
    {
        public ContactMapping()
        {
            CreateMap<CreateContactDTO, Contact>().ReverseMap();
            CreateMap<UpdateContactDTO, Contact>().ReverseMap();
            CreateMap<ResultContactDTO, Contact>().ReverseMap();
        }
    }
}