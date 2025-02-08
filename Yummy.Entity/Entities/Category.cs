namespace Yummy.Entity.Entities
{
    public class Category
    {
        public int CategoryID { get; set; }
        public string? CategoryName { get; set; }
        public bool IsVisible { get; set; } = false;
        public bool IsActive { get; set; } = true;

        public virtual List<Product>? Products { get; set; }
    }
}