namespace DeepDive11.Models
{
    public class Products
    {
        public string Brand { get; set; }

        public string Model { get; set; }
        
        public enum Size
        {
            
            ExtraSmall,
            Small,
            Medium,
            Large,
            ExtraLarge

        }

        public Size? ProductSize { get; set; }

        public int PricePerDay { get; set; }

        public string? Type { get; set; }
       
        public enum Gender
        {
            Male,
            Female
        }

        public Gender? ProductGender { get; set; }
      
        public double? Thickness { get; set; }

        public int? Volume { get; set; }

        public string? Image { get; set; }

        public string Category { get; set; }

        public int ProductId { get; set; }

        public List<string>? Sizes { get; set; }
    }
}


