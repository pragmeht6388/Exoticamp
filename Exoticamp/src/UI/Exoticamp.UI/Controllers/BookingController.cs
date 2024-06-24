using Exoticamp.UI.Models;
using Exoticamp.UI.Models.Booking;
using Exoticamp.UI.Models.Booking;
using Exoticamp.UI.Services.IRepositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

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
        public async Task<ActionResult> AddBooking()
        {
            BookingVM model = new BookingVM();

            var Campsites = await _campsiteDetailsRepository.GetAllCampsites();
   
            var Locations = await _locationRepository.GetAllLocations();
            if (Campsites == null ||  Locations == null)
            {
                return View("Error", new ErrorViewModel { });
            }

            model.CampsitesList= new SelectList(Campsites, "Id", "Name","Price");
            model.LocationsList = new SelectList(Locations, "Id", "Name");


            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> AddBooking(BookingVM model)
        {
            var response=await _bookingRepository.AddBooking(model);
            if (response.Succeeded)
            {
                return RedirectToAction("GetAllBookings", "Booking");
            }
            return View(model);

        }
        [HttpGet]
        public async Task<JsonResult> GetCampsitesByLocation(Guid locationId)
        {
            var locations = await _locationRepository.GetAllLocations();
            var loc = locations.FirstOrDefault(x => x.Id == locationId);
            //var campsites = await  _campsiteDetailsRepository.GetAllCampsites();
            //    campsites.Where(c => c.Location == loc.Name)
            //    .Select(c => new { value = c.Value, text = c.Text })
            //    .ToList();


            if (loc == null)
            {
                return Json(new List<object>());
            }

            var campsites = await _campsiteDetailsRepository.GetAllCampsites();
            var filteredCampsites = campsites
                .Where(c => c.Location == loc.Name)
                .Select(c => new { value = c.Id, text = c.Name })
                .ToList();

            return Json(filteredCampsites);
        }
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
