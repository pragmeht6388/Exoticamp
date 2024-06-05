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


        public HomeController(ILogger<HomeController> logger, IEventRepository eventRepository)
        {
            _logger = logger;
            _eventRepository = eventRepository;
        }

        public async Task<IActionResult> Index()
        {
            var locationId = HttpContext.Session.GetString("LocationId");
            ViewBag.Locations = new List<LocationVM>()
            {
                new LocationVM()
                {
                    Id = "1",
                    Name = "Mumbai"
                },
                new LocationVM()
                {
                    Id = "2",
                    Name = "Pune"
                },
            };
            ViewBag.Events = await _eventRepository.GetAllEvents();
            return View();
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
    }
}
