namespace DeepDive11API.DTOs
{
    public class CreateBookingProductRequest
    {
        public int ProductId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Quantity { get; set; }
    }
}
