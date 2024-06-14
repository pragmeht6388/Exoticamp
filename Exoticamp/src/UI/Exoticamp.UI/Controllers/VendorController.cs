using Exoticamp.UI.Services.IRepositories;
using Microsoft.AspNetCore.Mvc;

namespace Exoticamp.UI.Controllers
{
    public class VendorController : Controller
    {
        
            private readonly IVendorRepository _vendorsRepository;
            private readonly ILocationRepository _locationRepository;
            private readonly IActivitiesRepository _activitiesRepository;

            public VendorController(IVendorRepository vendorsRepository, ILocationRepository locationRepository, IActivitiesRepository activitiesRepository)
            {
                _vendorsRepository = vendorsRepository;
                _locationRepository = locationRepository;
                _activitiesRepository = activitiesRepository;
            }
            public IActionResult Index()
            {
                return View();
            }
        }
    }
