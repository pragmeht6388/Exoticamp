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
        public async Task<ActionResult> VendorHome()
        {
            var vendorId = HttpContext.Session.GetString("VendorId");
            var vendorDetails = await _vendorsRepository.GetVendorByIdAsync(vendorId);
            var allReviews = await _reviewsRepository.GetAllReviews();
            var allBookings = await _bookingRepository.GetAllBookings();

            // Filter bookings and reviews for the specific vendor
            var filteredBookings = allBookings.Where(b => b.Campsite.CreatedBy == vendorId);
//var filteredReviews = allReviews.Where(r => r.Booking.Campsite.CreatedBy == vendorId);

            var adminBookingVM = new AdminBookingVM
            {
                Bookings = filteredBookings,
                //TotalReviewsCount = filteredReviews.Count()
            };

            return View(adminBookingVM);
        }

    }
}
