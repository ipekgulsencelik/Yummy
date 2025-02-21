using AutoMapper;
using Yummy.DTO.DTOs.MessageDTOs;
using Yummy.Entity.Entities;

namespace Yummy.API.Mappings
{
    public class MessageMapping : Profile
    {
        public MessageMapping()
        {
            CreateMap<CreateMessageDTO, Message>().ReverseMap();
            CreateMap<UpdateMessageDTO, Message>().ReverseMap();
            CreateMap<ResultMessageDTO, Message>().ReverseMap();
        }
    }
}