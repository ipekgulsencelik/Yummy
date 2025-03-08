using AutoMapper;
using Yummy.DTO.DTOs.ProductDTOs;
using Yummy.Entity.Entities;

namespace Yummy.API.Mappings
{
    public class ProductMapping : Profile
    {
        public ProductMapping()
        {
            CreateMap<CreateProductDTO, Product>().ReverseMap();
            CreateMap<UpdateProductDTO, Product>().ReverseMap();
            CreateMap<ResultProductDTO, Product>().ReverseMap();
        }
    }
}