using Exoticamp.UI.Models;
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
            _locationRepository = locationRepository;
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
        public async Task<IActionResult> AddEvent()
        {
            EventVM model = new EventVM();
            var Campsites=await _campsiteRepository.GetAllCampsites();
            var Activities =await  _activitiesRepository.GetAllActivities();
            var Locations = await _locationRepository.GetAllLocations();
            if (Campsites==null || Activities==null|| Locations==null)
            {
                return View("Error", new ErrorViewModel { });
            }

            model.Campsites = new SelectList(Campsites ,"Id","Name");
            model.ActivitiesVMs = new SelectList(Activities, "Id", "Name");
            model.Locations = new SelectList(Locations,"Id","Name");


            return RedirectToAction("GetAllEvents","Event"); 
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

        [HttpGet]
        public async Task<JsonResult> GetCampsitesByLocation(Guid locationId)
        {
            // Fetch departments based on the selected hospital
            var campsites = (await _campsiteRepository.GetAllCampsites())
                                                    .Where(d => d.Id == locationId)
                                                    .ToList();
            return Json(campsites);
        }

        [HttpGet]
        public async Task<JsonResult> GetActivitiesByCampsite(Guid campsiteId)
        {
            // Fetch doctors based on the selected department
            var activities = (await _activitiesRepository.GetAllActivities())
                                            .Where(d => d.Id == campsiteId)
                                            .ToList();
            return Json(activities);
        }
        public async Task<IActionResult> GetAllEventsUser()
        {
            var events = await _eventRepository.GetAllEvents();
            return View(events);
        }

    }
}
