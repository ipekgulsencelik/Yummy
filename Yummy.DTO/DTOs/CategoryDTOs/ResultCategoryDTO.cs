namespace Yummy.DTO.DTOs.CategoryDTOs
{
    public class ResultCategoryDTO
    {
        public int CategoryID { get; set; }
        public string? CategoryName { get; set; }
        public bool IsVisible { get; set; }
        public bool IsActive { get; set; }
    }
}