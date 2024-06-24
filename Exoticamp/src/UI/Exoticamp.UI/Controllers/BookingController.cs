using Exoticamp.Domain.Entities;
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
            var Campsites = await _campsiteDetailsRepository.GetAllCampsites();

            var Locations = await _locationRepository.GetAllLocations();
            if (Campsites == null || Locations == null)
            {
                return View("Error", new ErrorViewModel { });
            }
            var CampSiteList = new List<CampsiteDetails>();
            var LocationList = new List<Location>();
        
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

        [HttpGet]
        public async Task<ActionResult> UserBooking(string id)
        {
            var campsite = await _campsiteDetailsRepository.GetCampsiteById(id);
            var location = await _locationRepository.GetAllLocations();
            var loc = location.FirstOrDefault(x => x.Name == campsite.Data.Location);
            campsite.Data.LocationId = loc.Id;
            ViewBag.Campsite = campsite.Data;
            var model = new BookingVM()
            {
                Campsite = campsite.Data,
                Location = loc,
                PriceForAdults=campsite.Data.Price,
                PriceForChildrens=campsite.Data.Price/2,
              

            };
            return View(model);
        }
        [HttpPost]
        public async Task<ActionResult> UserBooking(BookingVM model)
        {
            var campsite = await _campsiteDetailsRepository.GetCampsiteById(model.CampsiteId.ToString());
            if (campsite.Data == null)
            {
                return NotFound();
            }

            if (model.NoOfTents > campsite.Data.NoOfTents)
            {
                ModelState.AddModelError("NoOfTents", $"You can only book up to {campsite.Data.NoOfTents} tents.");
                return View(model);
            }
            if (ModelState.IsValid)
            {
                var response = await _bookingRepository.AddBooking(model);
                if (response.Succeeded)
                {
                    return RedirectToAction("GetAllBookings", "Booking");
                }
            }
            return View(model);

        }

        [HttpGet]
        public async Task<ActionResult> Details(string id)
        {
            var bookingResponse = await _bookingRepository.GetBookingById(id);
            var campsite = await _campsiteDetailsRepository.GetCampsiteById(bookingResponse.Data.CampsiteId.ToString());
            var location = await _locationRepository.GetAllLocations();
            var loc = location.FirstOrDefault(x => x.Name == campsite.Data.Location);
            campsite.Data.LocationId = loc.Id;

            bookingResponse.Data.Campsite = campsite.Data;
            bookingResponse.Data.Location = loc;

            if (bookingResponse.Succeeded)
            {
                var booking = bookingResponse.Data; // Assuming Data contains the BookingVM
                return View(booking);
            }

            // Handle the case when booking is not found
            ViewBag.ErrorMessage = bookingResponse.Message;
            return View("GetAllBookings", "Booking");
        }
        [HttpGet]
        public async Task<ActionResult> Edit(string id)
        {
           var model=await _bookingRepository.GetBookingById(id);
            var campsite = await _campsiteDetailsRepository.GetCampsiteById(model.Data.CampsiteId.ToString());
            var location = await _locationRepository.GetAllLocations();
            var loc = location.FirstOrDefault(x => x.Name == campsite.Data.Location);
            campsite.Data.LocationId = loc.Id;
     
            model.Data.Campsite = campsite.Data;
            model.Data.Location = loc;
            ViewBag.Campsite = campsite.Data;

            return View(model.Data);
        }

        [HttpPost]
        public async Task<ActionResult> Edit(BookingVM model)
        {
            var updatedBooking = await _bookingRepository.UpdateBooking(model);

            if (updatedBooking.Succeeded)
            {
                return RedirectToAction("Details", new { id = model.BookingId });
            }
            var campsite = await _campsiteDetailsRepository.GetCampsiteById(model.CampsiteId.ToString());
            var location = await _locationRepository.GetAllLocations();
            var loc = location.FirstOrDefault(x => x.Name == campsite.Data.Location);
            campsite.Data.LocationId = loc.Id;
            model.Campsite = campsite.Data;
            model.Location = loc;
            ViewBag.ErrorMessage = updatedBooking.Message;
            return View(model);
        }
        [HttpGet]
        public async Task<ActionResult> VendorManageBooking()
        {
            var bookingList = await _bookingRepository.GetAllBookings();
            var campsiteList = await _campsiteDetailsRepository.GetAllCampsites();

            var loggedInVendor = HttpContext.Session.GetString("VendorId");

            // Filter campsites by the logged in vendor
            var vendorCampsites = campsiteList.Where(c => c.CreatedBy == loggedInVendor).ToList();

            // Filter bookings by the vendor's campsites
            var vendorBookings = bookingList.Where(b => vendorCampsites.Any(c => c.Id == b.CampsiteId)).ToList();
            var now = DateTime.Now;
            var upcomingBookings = vendorBookings.Where(b => b.CheckIn > now).ToList();
            var pastBookings = vendorBookings.Where(b => b.CheckIn <= now).ToList();
            BookingCampsiteList Vendorsbookings = new BookingCampsiteList
            {
                Bookings = vendorBookings,
                Campsites = vendorCampsites,
                UpcomingBookings = upcomingBookings,
                PastBookings = pastBookings
               

            };
            ViewBag.BookingsWithCampsite= Vendorsbookings;
            return View();
        }



    }
}
