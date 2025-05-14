namespace Yummy.DTO.DTOs.YummyEventDTOs
{
    public class CreateYummyEventDTO
    {
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? ImageUrl { get; set; }
        public decimal Price { get; set; }
    }
}