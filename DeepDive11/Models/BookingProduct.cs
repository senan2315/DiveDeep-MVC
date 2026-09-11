namespace DeepDive11.Models
{
    public class BookingProduct
    {
        public int BookingId { get; set; }
        public Booking Booking { get; set; } = null!;

        public int ProductId { get; set; }
        public Products Product { get; set; } = null!;
    }
}
