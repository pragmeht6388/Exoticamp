using Exoticamp.UI.Models;
using Exoticamp.UI.Models.Booking;
using Exoticamp.UI.Services.IRepositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

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
        public async Task<ActionResult> AddBooking()
        {
            BookingVM model = new BookingVM();

            var Campsites = await _campsiteDetailsRepository.GetAllCampsites();
   
            var Locations = await _locationRepository.GetAllLocations();
            if (Campsites == null ||  Locations == null)
            {
                return View("Error", new ErrorViewModel { });
            }

            model.CampsitesList= new SelectList(Campsites, "Id", "Name");
            model.LocationsList = new SelectList(Locations, "Id", "Name");


            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> AddBooking(BookingVM model)
        {

            return View();
        }
    }
}
