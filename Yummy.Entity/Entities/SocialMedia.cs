namespace Yummy.Entity.Entities
{
    public class SocialMedia
    {
        public int SocialMediaID { get; set; }
        public string? Icon { get; set; }
        public string? Url { get; set; }
        public string? Title { get; set; }
        public bool IsVisible { get; set; } = false;
        public bool IsActive { get; set; } = true;
    }
}