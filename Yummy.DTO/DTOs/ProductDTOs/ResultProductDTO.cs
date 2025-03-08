using Yummy.DTO.DTOs.CategoryDTOs;

namespace Yummy.DTO.DTOs.ProductDTOs
{
    public class ResultProductDTO
    {
        public int ProductID { get; set; }
        public string? ProductName { get; set; }
        public string? ProductDescription { get; set; }
        public decimal Price { get; set; }
        public string? ImageUrl { get; set; }
        public int CategoryID { get; set; }
        public ResultCategoryDTO? Category { get; set; }
        public bool IsVisible { get; set; } 
        public bool IsActive { get; set; } 
    }
}