using DeepDive11.Models;
using DeepDive11.Persistence;
using DeepDive11.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace DeepDive11.Controllers
{
    [Authorize(Roles = "admin")]
    public class AdminController : Controller
    {
        private readonly IBookingRepository _bookingRepository;
        private readonly UserManager<ApplicationUser> _userManager;

        public AdminController(IBookingRepository bookingRepository, UserManager<ApplicationUser> userManager)
        {
            _bookingRepository = bookingRepository;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var bookings = _bookingRepository.GetAll();

            var viewModels = new List<AdminBookingViewModel>();

            foreach (var booking in bookings)
            {
                var user = await _userManager.FindByIdAsync(booking.UserId);

                viewModels.Add(new AdminBookingViewModel
                {
                    Booking = booking,
                    Email = user?.Email ?? ""
                });
            }

            return View(viewModels);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var booking = _bookingRepository.GetById(id);

            if (booking == null)
            {
                return NotFound();
            }

            var viewModel = new EditBookingViewModel
            {
                BookingId = booking.BookingId,
                Name = booking.Name,
                PhoneNumber = booking.PhoneNumber,

                Products = booking.BookingProducts.Select(bp => new EditBookingProductViewModel
                    {
                        ProductId = bp.ProductId,
                        ProductName = $"{bp.Product?.Brand} {bp.Product?.Model}",
                        StartDate = bp.StartDate,
                        EndDate = bp.EndDate,
                        Quantity = bp.Quantity
                    }).ToList()
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken] 
        public IActionResult Edit(EditBookingViewModel viewModel)
        {
            var booking = _bookingRepository.GetById(viewModel.BookingId);

            if (booking == null)
            {
                return NotFound();
            }

            // Tjek datoerne først
            for (int i = 0; i < viewModel.Products.Count; i++)
            {
                var product = viewModel.Products[i];

                if (product.EndDate.Date <= product.StartDate.Date)
                {
                    ModelState.AddModelError($"Products[{i}].EndDate", "Slutdato skal være senere end startdato.");
                }
                var isAvailable = _bookingRepository.IsProductAvailable(product.ProductId, product.StartDate, product.EndDate, product.Quantity, viewModel.BookingId);

                if (!isAvailable)
                {
                    ModelState.AddModelError($"Products[{i}].Quantity", "Der er ikke nok af dette produkt ledigt i den valgte periode.");
                }
            }

            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            // Opdater hvert produkt i bookingen
            foreach (var editedProduct in viewModel.Products)
            {
                var bookingProduct = booking.BookingProducts
                    .FirstOrDefault(bp => bp.ProductId == editedProduct.ProductId);

                if (bookingProduct == null)
                {
                    continue;
                }

                bookingProduct.StartDate = editedProduct.StartDate.Date;
                bookingProduct.EndDate = editedProduct.EndDate.Date;
                bookingProduct.Quantity = editedProduct.Quantity;

                var days = (bookingProduct.EndDate - bookingProduct.StartDate).Days;

                bookingProduct.TotalPrice = days * bookingProduct.Product.PricePerDay * bookingProduct.Quantity;
            }

            // Opdater bookingens samlede periode
            booking.StartDate = booking.BookingProducts.Min(bp => bp.StartDate);

            booking.EndDate = booking.BookingProducts.Max(bp => bp.EndDate);

            _bookingRepository.Update(booking);

            TempData["SuccessMessage"] = "Bookingen er blevet opdateret.";

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            var booking = _bookingRepository.GetById(id);

            if (booking == null)
            {
                return NotFound();
            }

            _bookingRepository.Delete(id);

            TempData["SuccessMessage"] = "Bookingen er blevet slettet.";

            return RedirectToAction(nameof(Index));
        }
    }
}