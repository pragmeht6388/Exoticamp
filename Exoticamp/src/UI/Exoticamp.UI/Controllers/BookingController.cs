using Exoticamp.UI.Models.Booking;
using Exoticamp.UI.Services.IRepositories;
using Microsoft.AspNetCore.Mvc;

namespace Exoticamp.UI.Controllers
{
    public class BookingController : Controller
    {
        private readonly IReviewsRepository _reviewsRepository;
        private readonly IBookingRepository _bookingRepository;
        public readonly ICampsiteDetailsRepository _campsiteDetailsRepository;
        public readonly ILocationRepository _locationRepository;

        public BookingController(IBookingRepository bookingRepository, ICampsiteDetailsRepository campsiteDetailsRepository, ILocationRepository locationRepository, IReviewsRepository reviewsRepository)
        {
            _bookingRepository = bookingRepository;
            _campsiteDetailsRepository = campsiteDetailsRepository;
            _locationRepository = locationRepository;
            _reviewsRepository = reviewsRepository;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<ActionResult> GetAllBookings()
        {
            var bookings=await _bookingRepository.GetAllBookings();
            return View(bookings);
        }

        [HttpGet]
        public async Task<ActionResult> AdminBooking()
        {
            var reviews = await _reviewsRepository.GetAllReviews();
            var bookings = await _bookingRepository.GetAllBookings();

            var adminBookingVM = new AdminBookingVM
            {
                Bookings = bookings,
                TotalReviewsCount = reviews.Count()
            };

            return View(adminBookingVM);
        }

    }
}
