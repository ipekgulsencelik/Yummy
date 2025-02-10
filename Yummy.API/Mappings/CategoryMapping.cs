using AutoMapper;
using Yummy.DTO.DTOs.CategoryDTOs;
using Yummy.Entity.Entities;

namespace Yummy.API.Mappings
{
    public class CategoryMapping : Profile
    {
        public CategoryMapping()
        {
            CreateMap<CreateCategoryDTO, Category>().ReverseMap();
            CreateMap<UpdateCategoryDTO, Category>().ReverseMap();
            CreateMap<ResultCategoryDTO, Category>().ReverseMap();
        }
    }
}