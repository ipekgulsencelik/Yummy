namespace Yummy.DTO.DTOs.ProductDTOs
{
    public class ResultProductWithCategoryDTO
    {
        public int ProductID { get; set; }
        public string? ProductName { get; set; }
        public string? ProductDescription { get; set; }
        public decimal Price { get; set; }
        public string? ImageUrl { get; set; }
        public int CategoryID { get; set; }
        public string? CategoryName { get; set; }
    }
}