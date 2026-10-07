namespace DeepDive11API.DTOs
{
    public class BookingResponse
    {
        public int BookingId { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string PhoneNumber { get; set; }
        public string? UserId { get; set; }
    }
}
