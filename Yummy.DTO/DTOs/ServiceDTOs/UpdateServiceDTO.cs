namespace Yummy.DTO.DTOs.ServiceDTOs
{
    public class UpdateServiceDTO
    {
        public int ServiceID { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? Icon { get; set; }
        public bool IsVisible { get; set; }
        public bool IsActive { get; set; }
    }
}