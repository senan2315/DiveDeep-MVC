namespace DeepDive11.Models
{
    public class BookingProduct
    {
        public int BookingId { get; set; }
        public Booking Booking { get; set; } = null!;

        public int ProductId { get; set; }
        public Products Product { get; set; } = null!;

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public int Quantity { get; set; }

        public decimal TotalPrice { get; set; }
    }
}
