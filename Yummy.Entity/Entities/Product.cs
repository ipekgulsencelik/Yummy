using System.Text.Json.Serialization;

namespace Yummy.Entity.Entities
{
    public class Product
    {
        public int ProductID { get; set; }
        public string? ProductName { get; set; }
        public string? ProductDescription { get; set; }
        public decimal Price { get; set; }
        public string? ImageUrl { get; set; }

        public int CategoryID { get; set; }
        [JsonIgnore]
        public virtual Category? Category { get; set; }

        public bool IsVisible { get; set; } = false;
        public bool IsActive { get; set; } = true;
    }
}