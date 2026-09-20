using DeepDive11.Data;
using DeepDive11.Models;
using Microsoft.EntityFrameworkCore;

namespace DeepDive11.Persistence
{
    public class BookingRepository : IBookingRepository
    {
        private readonly DeepDiveContext _context;
        public BookingRepository(DeepDiveContext deepDiveContext)
        {
            _context = deepDiveContext;
        }
        public void Add(Booking booking)
        {
            _context._bookings.Add(booking);
            _context.SaveChanges();
        }

        public void Delete(int bookingId)
        {
            throw new NotImplementedException();
        }

        public List<Booking> GetAll()
        {
            throw new NotImplementedException();
        }

        public Booking? GetById(int bookingId)
        {
            throw new NotImplementedException();
        }

        public void Update(Booking booking)
        {
            throw new NotImplementedException();
        }
        
        public List<Booking> GetBookingsByUserId(string userId)
        {
            return _context._bookings
                .Where(b => b.UserId == userId)
                .Include(b => b.BookingProducts) 
                .ThenInclude(bp => bp.Product)
                .ToList();
        }
    }
}
