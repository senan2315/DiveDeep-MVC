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
            var booking = _context._bookings
                .Include(b => b.BookingProducts)
                .FirstOrDefault(b => b.BookingId == bookingId);

            if (booking == null)
            {
                return;
            }

            _context._bookingProducts.RemoveRange(booking.BookingProducts);
            _context._bookings.Remove(booking);

            _context.SaveChanges();
        }

        public List<Booking> GetAll()
        {
            return _context._bookings
                .Include(b => b.BookingProducts)
                .ThenInclude(bp => bp.Product)
                .OrderByDescending(b => b.BookingId)
                .ToList();
        }

        public Booking? GetById(int bookingId)
        {
            return _context._bookings
                .Include(b => b.BookingProducts)
                .ThenInclude(bp => bp.Product)
                .FirstOrDefault(b => b.BookingId == bookingId);
        }

        public void Update(Booking booking)
        {
            _context._bookings.Update(booking);
            _context.SaveChanges();
        }

        public List<Booking> GetBookingsByUserId(string userId)
        {
            return _context._bookings
                .Where(b => b.UserId == userId)
                .Include(b => b.BookingProducts) 
                .ThenInclude(bp => bp.Product)
                .ToList();
        }

        public bool IsProductAvailable(int productId, DateTime startDate, DateTime endDate, int quantity, int? excludeBookingId = null)
        {
            const int maxQuantity = 5;

            for (var date = startDate.Date; date < endDate.Date; date = date.AddDays(1))
            {
                var bookedQuantity = _context._bookingProducts
                    .Where(bp =>
                        bp.ProductId == productId &&
                        bp.StartDate.Date <= date &&
                        bp.EndDate.Date > date &&
                        (!excludeBookingId.HasValue ||
                         bp.BookingId != excludeBookingId.Value))
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
