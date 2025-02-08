namespace Yummy.Entity.Entities
{
    public class Image
    {
        public int ImageID { get; set; }
        public string? Title { get; set; }
        public string? ImageUrl { get; set; }
        public bool IsVisible { get; set; } = false;
        public bool IsActive { get; set; } = true;
    }
}
