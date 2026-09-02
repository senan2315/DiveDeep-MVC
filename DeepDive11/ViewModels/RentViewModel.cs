using DeepDive11.Models;

namespace DeepDive11.ViewModels
{
    public class RentViewModel
    {
        public Products Product { get; set; }

        public string? SelectedSize { get; set; }

        public int Quantity { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public int TotalPrice { get; set; }
    }
}
