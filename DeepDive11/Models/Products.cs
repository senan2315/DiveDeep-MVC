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
        public int PricePerDay { get; set; }
        public string? Type { get; set; }
       
        public enum Gender
        {
            Male,
            Female
        }
      
        public int? Thickness { get; set; }

        public int? Volume { get; set; }

        public Products(string brand, string model, int pricePerDay, string? type, int? thickness, int? volume)
        {
            Brand = brand;
            Model = model;
            PricePerDay = pricePerDay;
            Type = type;
            Thickness = thickness;
            Volume = volume;
        }
    }
}


