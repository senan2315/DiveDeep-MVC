
using DeepDive11.Models;

namespace DeepDive11.Persistence
{
    public interface IBookingRepository
    {
        void Add(Booking booking);
        void Delete(int bookingId);
        List<Booking> GetAll();
        Booking? GetById(int bookingId);
        void Update(Booking booking);
        List<Booking> GetBookingsByUserId(string userId);

        bool IsProductAvailable(
            int productId, 
            DateTime startDate, 
            DateTime endDate,
            int quantity);
    }
}
