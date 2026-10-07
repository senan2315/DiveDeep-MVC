
using DeepDive11.Models;

namespace DeepDive11.Persistence
{
    public interface IBookingRepository
    {
        Task Add(Booking booking);
        Task Delete(int bookingId);
        Task<List<Booking>> GetAll();
        Task<Booking?> GetById(int bookingId);
        Task Update(Booking booking);
        List<Booking> GetBookingsByUserId(string userId);
        
        bool IsProductAvailable(
            int productId, 
            DateTime startDate, 
            DateTime endDate,
            int quantity,
            int? excludeBookingId = null);
    }
}
