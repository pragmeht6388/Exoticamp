using Exoticamp.UI.Services.IRepositories;
using Microsoft.AspNetCore.Mvc;

namespace Exoticamp.UI.Controllers
{
    public class BookingController : Controller
    {

        private readonly IBookingRepository _bookingRepository;
        public readonly ICampsiteDetailsRepository _campsiteDetailsRepository;
        public readonly ILocationRepository _locationRepository;

        public BookingController(IBookingRepository bookingRepository, ICampsiteDetailsRepository campsiteDetailsRepository, ILocationRepository locationRepository)
        {
            _bookingRepository = bookingRepository;
            _campsiteDetailsRepository = campsiteDetailsRepository;
            _locationRepository = locationRepository;
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
            var bookings = await _bookingRepository.GetAllBookings();
            return View(bookings);
        }
    }
}
