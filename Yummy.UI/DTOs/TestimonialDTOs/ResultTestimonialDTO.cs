namespace Yummy.UI.DTOs.TestimonialDTOs
{
    public class ResultTestimonialDTO
    {
        public int TestimonialID { get; set; }
        public string? Name { get; set; }
        public string? Title { get; set; }
        public string? Comment { get; set; }
        public string? ImageUrl { get; set; }
        public int Star { get; set; }
        public bool IsVisible { get; set; }
        public bool IsActive { get; set; }
    }
}