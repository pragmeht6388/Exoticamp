using Exoticamp.UI.Models.Booking;
using Exoticamp.UI.Models.Vendors;
using Exoticamp.UI.Services.IRepositories;
using Microsoft.AspNetCore.Mvc;

namespace Exoticamp.UI.Controllers
{
    public class VendorController(IVendorRepository _vendorsRepository, ILocationRepository _locationRepository, IBookingRepository _bookingRepository, ICampsiteDetailsRepository _campsiteDetailsRepository, IReviewsRepository _reviewsRepository) : Controller
    {
 
        public async Task<IActionResult> Profile()
        {
            var vendorId = HttpContext.Session.GetString("VendorId");
         
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

            // Ensure vendorId is not null or empty
            if (string.IsNullOrEmpty(loggedInVendor))
            {
                return RedirectToAction("Login", "Account");
            }

            // Filter campsites by the logged in vendor
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
