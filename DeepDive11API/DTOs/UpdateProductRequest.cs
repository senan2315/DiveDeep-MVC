namespace DeepDive11API.DTOs
{
    public class UpdateProductRequest
    {
        public string Brand { get; set; }
        public string? Model { get; set; }
        public int PricePerDay { get; set; }
        public string? Type { get; set; }
        public string Category { get; set; }
        public string? Image { get; set; }
        public string? Description { get; set; }
    }
}
