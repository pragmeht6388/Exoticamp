using Exoticamp.UI.Services.IRepositories;
using Microsoft.AspNetCore.Mvc;

namespace Exoticamp.UI.Controllers
{
    public class BookingController : Controller
    {

        private readonly IBookingRepository _bookingRepository;
        public BookingController(IBookingRepository bookingRepository)
        {
          _bookingRepository = bookingRepository;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> GetAllBookings()
        {
            var bookings=await _bookingRepository.GetAllBookings();
            return View();
        }
    }
}
