using Exoticamp.UI.Models;
using Exoticamp.UI.Models.Location;
using Exoticamp.UI.Services.IRepositories;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Exoticamp.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IEventRepository _eventRepository;
        private readonly ILocationRepository _locationRepository;



        public HomeController(ILogger<HomeController> logger, IEventRepository eventRepository, ILocationRepository locationRepository)
        {
            _logger = logger;
            _eventRepository = eventRepository;
            _locationRepository = locationRepository;
        }

        public async Task<IActionResult> Index()
        {
            var events = await _eventRepository.GetAllEvents();
            var locationId = HttpContext.Session.GetString("LocationId");
            ViewBag.Locations = await _locationRepository.GetAllLocations();
            ViewBag.Events = events;
            ViewBag.Preferences = await _activitiesRepository.GetAllActivities();
            ViewBag.sortedEvents = events.Where(x => x.StartDate <= DateTime.Now.AddDays(10) && x.StartDate >= DateTime.Now).OrderBy(x => x.StartDate).ToList();
            return View();
        }

        [HttpPost]
        public IActionResult SetLocationId(int locationId)
        {
            try
            {
                HttpContext.Session.SetInt32("LocationId", locationId);
                return Json(new { success = true });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public IActionResult HomePage()
        {
            return View();
        }
        public IActionResult AdminPage()
        {
            return View();
        }
        public IActionResult InfoPage()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetLocations()
        {
            // Simulate fetching data from a database or API
            var locations = await _locationRepository.GetAllLocations();

            return Json(locations);
        }
        public IActionResult MA()
        {
            return View();
        }
        public IActionResult MB()
        {
            return View();
        }
        public IActionResult BR()
        {
            return View();
        }
        public IActionResult MR()
        {
            return View();
        }
        public IActionResult Reports()
        {
            return View();
        }
        public IActionResult Settings()
        {
            return View();
        }
        public IActionResult Dashboard()
        {
            return View();
        }

    }
}
