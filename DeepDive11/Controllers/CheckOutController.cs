using DeepDive11.Models;
using DeepDive11.Persistence;
using Microsoft.AspNetCore.Mvc;
using DeepDive11.ViewModels;
using Microsoft.AspNetCore.Identity;

namespace DeepDive11.Controllers
{
    public class CheckOutController : Controller
    {
        private readonly IProductsRepository _productsRepository;
        private readonly IBookingRepository _bookingRepository;
        private readonly UserManager<ApplicationUser> _userManager;

        public CheckOutController(
            IProductsRepository productsRepository,
            IBookingRepository bookingRepository,
            UserManager<ApplicationUser> userManager)
        {
            _productsRepository = productsRepository;
            _bookingRepository = bookingRepository;
            _userManager = userManager;
        }
        private static List<RentViewModel> cart = new List<RentViewModel>();

        public IActionResult Index()
        {
            return View(cart);
        }

        [HttpPost]
        public IActionResult AddToCart(RentViewModel rentViewModel)
        {
            var product = _productsRepository
                .GetById(rentViewModel.Product!.ProductId);

            if (product == null)
            {
                return NotFound();
            }

            // Størrelse skal vælges, hvis produktet har størrelser
            if (product.Sizes != null &&
                product.Sizes.Any() &&
                string.IsNullOrEmpty(rentViewModel.SelectedSize))
            {
                ModelState.AddModelError(
                    "SelectedSize",
                    "Du skal vælge en størrelse."
                );
            }

            // Startdato må ikke være i fortiden
            if (rentViewModel.StartDate.HasValue &&
                rentViewModel.StartDate.Value.Date < DateTime.Today)
            {
                ModelState.AddModelError(
                    "StartDate",
                    "Startdato må ikke være i fortiden."
                );
            }

            // Slutdato skal være senere end startdato
            if (rentViewModel.StartDate.HasValue &&
                rentViewModel.EndDate.HasValue &&
                rentViewModel.EndDate.Value.Date <= rentViewModel.StartDate.Value.Date)
            {
                ModelState.AddModelError(
                    "EndDate",
                    "Slutdato skal være senere end startdato."
                );
            }

            if (!ModelState.IsValid)
            {
                rentViewModel.Product = product;

                return View(
                    "~/Views/Products/Rent.cshtml",
                    rentViewModel
                );
            }

            rentViewModel.Product = product;

            var days =
                (rentViewModel.EndDate!.Value.Date -
                 rentViewModel.StartDate!.Value.Date).Days;

            rentViewModel.TotalPrice =
                days *
                product.PricePerDay *
                rentViewModel.Quantity;

            cart.Add(rentViewModel);

            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CompleteBooking()
        {
            var userId = _userManager.GetUserId(User);

            if (userId == null)
            {
                return Challenge();
            }

            if (cart.Count == 0)
            {
                TempData["BookingError"] = "Kurven er tom.";
                return RedirectToAction(nameof(Index));
            }

            // Tjek at alle produkter stadig findes
            foreach (var rent in cart)
            {
                if (rent.Product == null ||
                    _productsRepository.GetById(rent.Product.ProductId) == null)
                {
                    return NotFound();
                }
            }

            var booking = new Booking
            {
                UserId = userId,
                Name = Environment.MachineName,

                // Disse kan stadig bruges som bookingens samlede periode
                StartDate = cart.Min(rent => rent.StartDate!.Value.Date),
                EndDate = cart.Max(rent => rent.EndDate!.Value.Date),

                PhoneNumber = "12345678",

                // Nu gemmer vi oplysningerne for HVERT produkt
                BookingProducts = cart
                    .Select(rent => new BookingProduct
                    {
                        ProductId = rent.Product!.ProductId,
                        StartDate = rent.StartDate!.Value.Date,
                        EndDate = rent.EndDate!.Value.Date,
                        Quantity = rent.Quantity,
                        TotalPrice = rent.TotalPrice
                    })
                    .ToList()
            };

            _bookingRepository.Add(booking);

            cart.Clear();

            TempData["BookingSuccess"] = "Din booking er oprettet.";

            return RedirectToAction(nameof(Index));
        }

    }
}
