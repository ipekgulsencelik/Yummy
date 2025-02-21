namespace Yummy.DTO.DTOs.ContactDTOs
{
    public class UpdateContactDTO
    {
        public int ContactID { get; set; }
        public string? Location { get; set; }
        public string? Address { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public string? OpeningHours { get; set; }
        public bool IsVisible { get; set; }
    }
}