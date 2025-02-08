namespace Yummy.Entity.Entities
{
    public class Message
    {
        public int MessageID { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Subject { get; set; }
        public string? Content { get; set; }
        public DateTime SendDate { get; set; } = DateTime.UtcNow;
        public bool IsRead { get; set; } = false;
    }
}