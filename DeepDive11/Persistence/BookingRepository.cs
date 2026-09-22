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

        public bool IsProductAvailable
            (int productId, 
            DateTime startDate, 
            DateTime endDate, 
            int quantity)
        {
            const int maxQuantity = 5;

            for (var date = startDate.Date;
                date < endDate.Date; 
                date = date.AddDays(1))
            {
                var bookedQuantity = _context._bookingProducts
                    .Where(bp => 
                            bp.ProductId == productId && 
                            bp.StartDate.Date <= date.AddDays(1) && 
                            bp.EndDate > date)
                    .Sum(bp => bp.Quantity);
                if (bookedQuantity + quantity > maxQuantity)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
