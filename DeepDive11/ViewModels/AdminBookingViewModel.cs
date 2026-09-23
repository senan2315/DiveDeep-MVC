using DeepDive11.Models;

namespace DeepDive11.ViewModels
{
    public class AdminBookingViewModel
    {
        public Booking Booking { get; set; } = null!;

        public string Email { get; set; } = "";
    }
}