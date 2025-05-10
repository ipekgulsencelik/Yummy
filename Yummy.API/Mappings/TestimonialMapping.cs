using AutoMapper;
using Yummy.DTO.DTOs.TestimonialDTOs;
using Yummy.Entity.Entities;

namespace Yummy.API.Mappings
{
    public class TestimonialMapping : Profile
    {
        public TestimonialMapping()
        {
            CreateMap<CreateTestimonialDTO, Testimonial>().ReverseMap();
            CreateMap<UpdateTestimonialDTO, Testimonial>().ReverseMap();
            CreateMap<ResultTestimonialDTO, Testimonial>().ReverseMap();
        }
    }
}