namespace Yummy.Entity.Entities
{
    public class Feature
    {
        public int FeatureID { get; set; }
        public string? Title { get; set; }
        public string? SubTitle { get; set; }
        public string? Description { get; set; }
        public string? VideoUrl { get; set; }
        public string? ImageUrl { get; set; }
        public bool IsVisible { get; set; } = false;
        public bool IsActive { get; set; } = true;
    }
}