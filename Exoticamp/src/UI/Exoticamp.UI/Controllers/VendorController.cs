using Exoticamp.UI.Models.Booking;
using Exoticamp.UI.Models.Vendors;
using Exoticamp.UI.Services.IRepositories;
using Microsoft.AspNetCore.Mvc;

namespace Exoticamp.UI.Controllers
{
    public class VendorController : Controller
    {
        private readonly IReviewsRepository _reviewsRepository;

        private readonly IVendorRepository _vendorsRepository;
        private readonly ILocationRepository _locationRepository;
        private readonly IBookingRepository _bookingRepository;
        public readonly ICampsiteDetailsRepository _campsiteDetailsRepository;


        public VendorController(IVendorRepository vendorsRepository, ILocationRepository locationRepository, IBookingRepository bookingRepository, ICampsiteDetailsRepository campsiteDetailsRepository, IReviewsRepository reviewsRepository)
        {
            _vendorsRepository = vendorsRepository;
            _locationRepository = locationRepository;
            _bookingRepository = bookingRepository;
            _campsiteDetailsRepository = campsiteDetailsRepository;
            _reviewsRepository = reviewsRepository;
        }
        public async Task<IActionResult> Profile()
        {
            var vendorId = HttpContext.Session.GetString("VendorId");
            //ViewBag.Locations = await _locationRepository.GetAllLocations();
            var vendorDetails = await _vendorsRepository.GetVendorByIdAsync(vendorId);


            if (vendorDetails.data != null)
            {
                return View(vendorDetails.data);
            }
            return RedirectToAction("Index", "Home");
        }
        [HttpGet]
        public async Task<IActionResult> EditProfile()
        {
            var vendorId = HttpContext.Session.GetString("VendorId");
            var vendorDetails = await _vendorsRepository.GetVendorByIdAsync(vendorId);
            ViewBag.Locations = await _locationRepository.GetAllLocations();

            if (vendorDetails.data != null)
            {
                vendorDetails.data.Id = vendorId;
                return View(vendorDetails.data);
            }
            return RedirectToAction("Index", "Home");
        }

        // Edit Vendor Profile - Handle form submission
        [HttpPost]
        public async Task<IActionResult> EditProfile(VendorVM model)
        {

            ViewBag.Locations = await _locationRepository.GetAllLocations();

            var response = await _vendorsRepository.UpdateVendorProfileAsync(model);

            if (!response.Success)
            {
                return RedirectToAction("Profile");
            }


            return View();
        }

        [HttpGet]
        public async Task<ActionResult> VendorManageBooking()
        {
            var bookingList = await _bookingRepository.GetAllBookings();
            var campsiteList = await _campsiteDetailsRepository.GetAllCampsites();
            var reviewList = await _reviewsRepository.GetAllReviews();
            var loggedInVendor = HttpContext.Session.GetString("VendorId");

       
            if (string.IsNullOrEmpty(loggedInVendor))
            {
                return RedirectToAction("Login", "Account");
            }

     
            var vendorCampsites = campsiteList.Where(c => c.CreatedBy == loggedInVendor).ToList();

            // Filter bookings by the vendor's campsites
            var vendorBookings = bookingList.Where(b => vendorCampsites.Any(c => c.Id == b.CampsiteId)).ToList();
            var now = DateTime.Now;
            var upcomingBookings = vendorBookings.Where(b => b.CheckIn > now).ToList();
            var pastBookings = vendorBookings.Where(b => b.CheckIn <= now).ToList();
            var vendorReviews = reviewList.Where(r =>
            vendorBookings.Any(b =>
            b.BookingId == r.BookingId &&
            vendorCampsites.Any(c => c.Id == b.CampsiteId)
            )
            ).ToList();
            // Calculate total revenue
            var totalRevenue = vendorBookings.Sum(b => b.TotalPrice);

            VendorBookVM vendorsBookings = new VendorBookVM
            {
                Bookings = vendorBookings,
                Campsite = vendorCampsites,
                TotalReviewsCount = vendorReviews.Count,
                TotalRevenue = totalRevenue
            };

            ViewBag.BookingsWithCampsite = vendorsBookings;
            return View(vendorsBookings);
        }

    }
}
