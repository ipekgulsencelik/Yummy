namespace Yummy.Entity.Entities
{
    public class Reservation
    {
        public int ReservationID { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public DateTime ReservationDate { get; set; }
        public TimeSpan ReservationTime { get; set; }
        public int GuestCount { get; set; }
        public string? Message { get; set; }
        public string? ReservationStatus { get; set; }
        public bool IsApproved { get; set; } = false;
    }
}