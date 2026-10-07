using DeepDive11.Models;
using DeepDive11.Persistence;
using DeepDive11API.DTOs;
using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DeepDive11API.Contollers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingApiController : ControllerBase
    {
        private readonly IBookingRepository _bookingRepository;
        private readonly IProductsRepository _productsRepository;

        public BookingApiController(IBookingRepository bookingRepository, IProductsRepository productsRepository)
        {
            _bookingRepository = bookingRepository;
            _productsRepository = productsRepository;
        }

        [HttpGet]
        [Route("api/bookings")]
        public async Task<IActionResult> GetAll()
        {
            var bookings = await _bookingRepository.GetAll();
            var response = bookings.Adapt<List<BookingResponse>>();
            return Ok(response);
        }

        [HttpGet]
        [Route("api/bookings/{bookingId}")]
        public async Task<ActionResult<BookingResponse>> GetById(int bookingId)
        {
            var booking = await _bookingRepository.GetById(bookingId);
            if (booking == null)
            {
                return NotFound();
            }
            var response = booking.Adapt<BookingResponse>();
            return Ok(response);
        }

        [HttpPost]
        [Route("api/bookings")]
        public async Task<ActionResult<BookingResponse>> Create(CreateBookingRequest request)
        {
            var booking = request.Adapt<Booking>();
            booking.BookingId = 0;
            booking.BookingProducts = new List<BookingProduct>();

            foreach (var requestedProduct in request.Products)
            {
                if (requestedProduct.EndDate.Date <= requestedProduct.StartDate.Date)
                {
                    return BadRequest("Slutdato skal være senere end startdato.");
                }
                var product = await _productsRepository.GetById(requestedProduct.ProductId);

                if (product == null)
                {
                    return BadRequest($"Produkt med ID {requestedProduct.ProductId} findes ikke.");
                }
                var isAvailable = _bookingRepository.IsProductAvailable(
                    requestedProduct.ProductId,
                    requestedProduct.StartDate,
                    requestedProduct.EndDate,
                    requestedProduct.Quantity
                );
                if (!isAvailable)
                {
                    return BadRequest($"Der er ikke nok af produkt {requestedProduct.ProductId} ledigt i den valgte periode.");
                }

                var days = (requestedProduct.EndDate.Date - requestedProduct.StartDate.Date).Days;
                var bookingProduct = new BookingProduct
                {
                    ProductId = requestedProduct.ProductId,
                    StartDate = requestedProduct.StartDate.Date,
                    EndDate = requestedProduct.EndDate.Date,
                    Quantity = requestedProduct.Quantity,
                    TotalPrice = days * product.PricePerDay * requestedProduct.Quantity
                };

                booking.BookingProducts.Add(bookingProduct);

            }
            await _bookingRepository.Add(booking);
            var response = booking.Adapt<BookingResponse>();
            return CreatedAtAction(
                nameof(GetById),
                new { bookingId = booking.BookingId },
                response
            );
        }

        [HttpPut]
        [Route("api/bookings/{bookingId}")]
        public async Task<IActionResult> Update(int bookingId, UpdateBookingRequest request)
        {
            var existingBooking = await _bookingRepository.GetById(bookingId);
            if (existingBooking == null)
            {
                return NotFound();
            }
            existingBooking.Name = request.Name;
            existingBooking.PhoneNumber = request.PhoneNumber;
            foreach (var requestedProduct in request.Products)
            {
                if (requestedProduct.EndDate.Date <= requestedProduct.StartDate.Date)
                {
                    return BadRequest("Slutdato skal være senere end startdato.");
                }
                var product = await _productsRepository.GetById(requestedProduct.ProductId);
                if (product == null)
                {
                    return BadRequest(
                        $"Produkt med ID {requestedProduct.ProductId} findes ikke."
                    );
                }
                var isAvailable = _bookingRepository.IsProductAvailable(
                    requestedProduct.ProductId,
                    requestedProduct.StartDate,
                    requestedProduct.EndDate,
                    requestedProduct.Quantity,
                    bookingId);

                if (!isAvailable)
                {
                    return BadRequest(
                        $"Der er ikke nok af produkt {requestedProduct.ProductId} ledigt i den valgte periode."
                    );
                }
                var bookingProduct = existingBooking.BookingProducts.FirstOrDefault(bp => bp.ProductId == requestedProduct.ProductId);
                if (bookingProduct == null)
                {
                    return BadRequest(
                        $"Produkt {requestedProduct.ProductId} findes ikke på bookingen."
                    );
                }
                bookingProduct.StartDate = requestedProduct.StartDate.Date;
                bookingProduct.EndDate = requestedProduct.EndDate.Date;
                bookingProduct.Quantity = requestedProduct.Quantity;
                var days = (bookingProduct.EndDate - bookingProduct.StartDate).Days;
                bookingProduct.TotalPrice =
                    days * product.PricePerDay * bookingProduct.Quantity;
            }
            if (existingBooking.BookingProducts.Any())
            {
                existingBooking.StartDate =
                    existingBooking.BookingProducts.Min(bp => bp.StartDate);
                existingBooking.EndDate =
                    existingBooking.BookingProducts.Max(bp => bp.EndDate);
            }
            await _bookingRepository.Update(existingBooking);
            return NoContent();
        }
       
        [HttpDelete]
        [Route("api/bookings/{bookingId}")]
        public async Task<IActionResult> Delete(int bookingId)
        {
            var booking = await _bookingRepository.GetById(bookingId);
            if (booking == null)
            {
                return NotFound();
            }
            await _bookingRepository.Delete(bookingId);
            return NoContent();
        }

    }
}
