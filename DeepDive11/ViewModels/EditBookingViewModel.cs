using System.ComponentModel.DataAnnotations;

namespace DeepDive11.ViewModels
{
    public class EditBookingViewModel
    {
        public int BookingId { get; set; }

        public string Name { get; set; } = "";

        public string PhoneNumber { get; set; } = "";

        public List<EditBookingProductViewModel> Products { get; set; } = new();
    }

    public class EditBookingProductViewModel
    {
        public int ProductId { get; set; }

        public string ProductName { get; set; } = "";

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        [Range(1, 5, ErrorMessage = "Antal skal være mellem 1 og 5.")]
        public int Quantity { get; set; }
    }
}