using DeepDive11.Models;
using DeepDive11.Persistence;
using Microsoft.AspNetCore.Mvc;
using DeepDive11.ViewModels;

namespace DeepDive11.Controllers
{
    public class CheckOutController : Controller
    {
        private readonly IProductsRepository _productsRepository;
        private readonly IBookingRepository _bookingRepository;

        public CheckOutController(
            IProductsRepository productsRepository,
            IBookingRepository bookingRepository)
        {
            _productsRepository = productsRepository;
            _bookingRepository = bookingRepository;
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
            if (cart.Count == 0)
            {
                TempData["BookingError"] = "Kurven er tom.";
                return RedirectToAction(nameof(Index));
            }

            var productIds = cart
                .Select(rent => rent.Product?.ProductId ?? 0)
                .ToList();

            var startDate = cart.Min(rent => rent.StartDate!.Value.Date); //Sætter "startDate" til at være den tidligste startdato i kurven
            var endDate = cart.Max(rent => rent.EndDate!.Value.Date); //Sætter "endDate" til at være den seneste slutdato i kurven

            var booking = new Booking
            {
                Name = Environment.MachineName,
                StartDate = startDate,
                EndDate = endDate,
                PhoneNumber = "12345678",
                BookingProducts = productIds
                    .Distinct()
                    .Select(productId => new BookingProduct
                    {
                        ProductId = productId
                    })
                    .ToList()
            };

            foreach (var productId in productIds.Distinct())
            {
                if (_productsRepository.GetById(productId) == null)
                {
                    return NotFound();
                }
            }

            _bookingRepository.Add(booking);
            cart.Clear();
            TempData["BookingSuccess"] = "Din booking er oprettet.";

            return RedirectToAction(nameof(Index));
        }

    }
}
