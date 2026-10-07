namespace DeepDive11API.DTOs
{
    public class UpdateBookingRequest
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }

        public List<CreateBookingProductRequest> Products { get; set; } = new();
    }
}
