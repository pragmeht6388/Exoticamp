using Exoticamp.UI.Models.Events;
using Exoticamp.UI.Services.IRepositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Runtime.CompilerServices;

namespace Exoticamp.UI.Controllers
{
    public class EventController : Controller
    {
        private readonly IEventRepository _eventRepository;
        private readonly ICampsiteDetailsRepository _campsiteRepository;
        private readonly IActivitiesRepository _activitiesRepository;
        private readonly ILocationRepository _locationRepository;

        public EventController(IEventRepository eventRepository, ICampsiteDetailsRepository campsiteRepository,
            IActivitiesRepository activitiesRepository, ILocationRepository locationRepository)
        {
            _eventRepository = eventRepository;   
            _campsiteRepository = campsiteRepository;
            _activitiesRepository = activitiesRepository;
        }
        public IActionResult Index()
        {
            return View();
        }


        public async Task<IActionResult> GetAllEvents()
        {
            var events=await _eventRepository.GetAllEvents();
            return View(events);
        }
        [HttpGet]
        public IActionResult AddEvent()
        {
            var Campsites=_campsiteRepository.GetAllCampsites();
            var Activities = _activitiesRepository.GetAllActivities();
            //ViewBag.Campsites=new SelectList
            //     ViewBag.Activities

            return View(); 
        }
        [HttpPost]
        public async Task<ActionResult> AddEvent(EventVM model)
        {
            if (ModelState.IsValid)
            {

                var fileName = $"{Guid.NewGuid()}{Path.GetExtension(model.Image.FileName)}";
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Assets/Images/Event/", fileName);

                model.ImageUrl = "/Assets/Images/Event/" + fileName;

                var response = await _eventRepository.AddEvent(model);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await model.Image.CopyToAsync(fileStream);
                }
                if (response.Succeeded == false)
                {
                    TempData["Message"] = response.Message;
                    TempData["Flag"] = response.Succeeded;
                }
                else {
                    TempData["Message"] = response.Message;
                    TempData["Flag"] = null;
                    return RedirectToAction("GetAllEvents", "Event");
                     }
            }
            else
                ModelState.AddModelError("", "Oops! Some error occured.");

            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
          var eventObj=await  _eventRepository.GetEventById(id);
            return View(eventObj.Data);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(EventVM model)
        {
            if (ModelState.IsValid)
            {
                var fileName = $"{Guid.NewGuid()}{Path.GetExtension(model.Image.FileName)}";
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Assets/Images/Event/", fileName);

                model.ImageUrl = "/Assets/Images/Event/" + fileName;

                var response = await _eventRepository.EditEvent(model);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await model.Image.CopyToAsync(fileStream);
                }
                 return View("Details", response.Data);
            }
            else
                ModelState.AddModelError("", "Oops! Some error occured.");

            return View(model);
           
          
        }
        [HttpGet]
        public async Task<IActionResult> Details(string id)
        {
            var eventObj = await _eventRepository.GetEventById(id);

            return View(eventObj.Data);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(string id)
        {
            var eventObj = await _eventRepository.DeleteEvent(id);
            return RedirectToAction("GetAllEvents", "Event");
        }

        
     
    }
}
