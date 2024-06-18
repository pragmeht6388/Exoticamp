using Exoticamp.UI.Models.Vendors;
using Exoticamp.UI.Services.IRepositories;
using Microsoft.AspNetCore.Mvc;

namespace Exoticamp.UI.Controllers
{
    public class VendorController : Controller
    {
        
            private readonly IVendorRepository _vendorsRepository;
            private readonly ILocationRepository _locationRepository;
          

            public VendorController(IVendorRepository vendorsRepository, ILocationRepository locationRepository)
            {
                _vendorsRepository = vendorsRepository;
                _locationRepository = locationRepository;
                
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
                return View(vendorDetails.data);
            }
            return RedirectToAction("Index", "Home");
        }

        // Edit Vendor Profile - Handle form submission
        [HttpPost]
        public async Task<IActionResult> EditProfile(VendorVM model)
        {
            if (ModelState.IsValid)
            {
                var response = await _vendorsRepository.UpdateVendorProfileAsync(model);
                if (response.Success)
                {
                    return RedirectToAction("Profile");
                }

                ModelState.AddModelError(string.Empty, response.Message);
            }
            ViewBag.Locations = await _locationRepository.GetAllLocations();
            return View(model);
        }
    }
    }
