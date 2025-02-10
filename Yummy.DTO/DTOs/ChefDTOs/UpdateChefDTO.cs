namespace Yummy.DTO.DTOs.ChefDTOs
{
    public class UpdateChefDTO
    {
        public int ChefID { get; set; }
        public string? Name { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? ImageUrl { get; set; }
        public bool IsVisible { get; set; } 
        public bool IsActive { get; set; } 
    }
}