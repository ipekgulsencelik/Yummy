namespace Yummy.DTO.DTOs.MessageDTOs
{
    public class CreateMessageDTO
    {
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Subject { get; set; }
        public string? Content { get; set; }
        public DateTime SendDate { get; set; } = DateTime.UtcNow;
        public bool IsRead { get; set; } = false;
    }
}