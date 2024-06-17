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
    }
    }
