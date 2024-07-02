using Exoticamp.Domain.Entities;
using Exoticamp.UI.Models;
using Exoticamp.UI.Models.Events;
using Exoticamp.UI.Services.IRepositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Runtime.CompilerServices;

namespace Exoticamp.UI.Controllers
{
    public class EventController(IEventRepository _eventRepository, ICampsiteDetailsRepository _campsiteRepository,
            IActivitiesRepository _activitiesRepository, ILocationRepository _locationRepository) : Controller
    {
         
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
            AddEventVM model = new AddEventVM();
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


            return View(model); 
        }
        [HttpPost]
        public async Task<ActionResult> AddEvent( AddEventVM model)
        {
            var eventObj = new AddEventVM()//EventVM
            {

                Name = model.Name,
                Price = model.Price,
                Capacity = model.Capacity,
                StartDate = model.StartDate,
                EndDate = model.EndDate,
                Description = model.Description,
                Image=model.Image,
                Highlights = model.Highlights,
                EventRules = model.EventRules,
                CampsiteIds = model.CampsiteIds,
                ActivityIds = model.ActivityIds,
                LocationId = model.LocationId,
                Status = model.Status,
                IsDeleted = model.IsDeleted,
                
                EventLocationDto = new EventLocationDto
                {
                    
                    LocationId = Guid.Parse(model.LocationId.ToString()),
                     
                },
               
            };


            if (ModelState.IsValid)
            {
                
                    var fileName = $"{Guid.NewGuid()}{Path.GetExtension(model.Image.FileName)}";
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Assets/Images/Event/", fileName);
                    var imageList = new List<string>();

                    model.ImageUrl="/Assets/Images/Event/" + fileName;


                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await model.Image.CopyToAsync(fileStream);
                    }
             
                    var response = await _eventRepository.AddEvent(model);
                    if (response.Succeeded == false)
                    {
                        TempData["Message"] = response.Message;
                        TempData["Flag"] = response.Succeeded;  
                    }
                    else
                    {
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
            var eventObj = await _eventRepository.GetEventById(id);
        
            EventVM model = new EventVM()
            {
                EventId = eventObj.Data.EventId,
                Name = eventObj.Data.Name,
                Price = eventObj.Data.Price,
                Capacity = eventObj.Data.Capacity,
                StartDate = eventObj.Data.StartDate,
                EndDate = eventObj.Data.EndDate,
                Description = eventObj.Data.Description,
                ImageUrl = eventObj.Data.ImageUrl,
                Highlights = eventObj.Data.Highlights,
                EventRules = eventObj.Data.EventRules,
                CampsiteId = eventObj.Data.CampsiteId,
                ActivityId = eventObj.Data.ActivityId,
                LocationId = eventObj.Data.LocationId,
                Status = eventObj.Data.Status,
                IsDeleted = eventObj.Data.IsDeleted,
              
                EventLocationDto = new EventLocationDto
                {
                    Id = eventObj.Data.EventLocationDto.Id,
                    LocationId = eventObj.Data.EventLocationDto.LocationId,
                    LocationDetails = eventObj.Data.EventLocationDto.LocationDetails
                },
                EventActivityDto = new EventActivityDto
                {
                    Id = eventObj.Data.EventActivityDto.Id,
                    ActivityId = eventObj.Data.EventActivityDto.ActivityId,
                    ActivityDetails = eventObj.Data.EventActivityDto.ActivityDetails
                }


            };

            var Campsites = await _campsiteRepository.GetAllCampsites();
            var Activities = await _activitiesRepository.GetAllActivities();
            var Locations = await _locationRepository.GetAllLocations();
            if (Campsites == null || Activities == null || Locations == null)
            {
                return View("Error", new ErrorViewModel { });
            }

            model.Campsites = new SelectList(Campsites, "Id", "Name");
            model.ActivitiesVMs = new SelectList(Activities, "Id", "Name");
            model.Locations = new SelectList(Locations, "Id", "Name");

            return View(model);
        }
         
        
    [HttpGet]
        public async Task<IActionResult> Details(string id)
        {
            var eventObj = await _eventRepository.GetEventById(id);
            var campsite=await _campsiteRepository.GetCampsiteById(eventObj.Data.CampsiteId.ToString());
            if (campsite == null)
                ModelState.AddModelError("", "Campsite Not found");
            EventVM model = new EventVM()
            {
                EventId = eventObj.Data.EventId,
                Name = eventObj.Data.Name,
                Price = eventObj.Data.Price,
                Capacity = eventObj.Data.Capacity,
                StartDate = eventObj.Data.StartDate,
                EndDate = eventObj.Data.EndDate,
                Description = eventObj.Data.Description,
                ImageUrl = eventObj.Data.ImageUrl,
                Highlights = eventObj.Data.Highlights,
                EventRules = eventObj.Data.EventRules,
                CampsiteId = eventObj.Data.CampsiteId,
                ActivityId = eventObj.Data.ActivityId,
                LocationId = eventObj.Data.LocationId,
                Campsite = campsite.Data,
                Status= eventObj.Data.Status,
                IsDeleted= eventObj.Data.IsDeleted,
             
                EventLocationDto = new EventLocationDto
                {
                    Id = eventObj.Data.EventLocationDto.Id,
                    LocationId = eventObj.Data.EventLocationDto.LocationId,
                    LocationDetails = eventObj.Data.EventLocationDto.LocationDetails
                },
                EventActivityDto = new EventActivityDto
                {
                    Id = eventObj.Data.EventActivityDto.Id,
                    ActivityId = eventObj.Data.EventActivityDto.ActivityId,
                    ActivityDetails = eventObj.Data.EventActivityDto.ActivityDetails
                }


            };
            
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> DetailsUser(string id)
        {
            var eventObj = await _eventRepository.GetEventById(id);
            var campsite = await _campsiteRepository.GetCampsiteById(eventObj.Data.CampsiteId.ToString());
            if (campsite == null)
                ModelState.AddModelError("", "Campsite Not found");
            EventVM model = new EventVM()
            {
                EventId = eventObj.Data.EventId,
                Name = eventObj.Data.Name,
                Price = eventObj.Data.Price,
                Capacity = eventObj.Data.Capacity,
                StartDate = eventObj.Data.StartDate,
                EndDate = eventObj.Data.EndDate,
                Description = eventObj.Data.Description,
                ImageUrl = eventObj.Data.ImageUrl,
                Highlights = eventObj.Data.Highlights,
                EventRules = eventObj.Data.EventRules,
                CampsiteId = eventObj.Data.CampsiteId,
                ActivityId = eventObj.Data.ActivityId,
                LocationId = eventObj.Data.LocationId,
                Campsite = campsite.Data,
                Status = eventObj.Data.Status,
                IsDeleted = eventObj.Data.IsDeleted,

                EventLocationDto = new EventLocationDto
                {
                    Id = eventObj.Data.EventLocationDto.Id,
                    LocationId = eventObj.Data.EventLocationDto.LocationId,
                    LocationDetails = eventObj.Data.EventLocationDto.LocationDetails
                },
                EventActivityDto = new EventActivityDto
                {
                    Id = eventObj.Data.EventActivityDto.Id,
                    ActivityId = eventObj.Data.EventActivityDto.ActivityId,
                    ActivityDetails = eventObj.Data.EventActivityDto.ActivityDetails
                }


            };

            return View(model);
        }


        
        public async Task<IActionResult> Delete(string id)
        {
            var eventObj = await _eventRepository.DeleteEvent(id);
            // return RedirectToAction("GetAllEvents", "Event");
          
            
                return Json(new { success = true, message = "Event deleted successfully." });
             
        }

        [HttpGet]
        public async Task<JsonResult> GetCampsitesByLocation(Guid locationId)
        {
             
            var campsites = (await _campsiteRepository.GetAllCampsites())
                                                    .Where(d => d.Id == locationId)
                                                    .ToList();
            return Json(campsites);
        }

        [HttpGet]
        public async Task<JsonResult> GetActivitiesByCampsite(Guid campsiteId)
        {
            
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
