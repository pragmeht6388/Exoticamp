using Exoticamp.Domain.Entities;
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
                //Campsite = campsite!.Data,
                EventLocationDto = new EventLocationDto
                {
                    //Id = model.EventLocationDto.Id,
                    LocationId = Guid.Parse(model.LocationId.ToString()),
                    //LocationDetails = new LocationDetails
                    //{
                    //    Name = model.EventLocationDto.LocationDetails.Name
                    //}
                },
                //EventActivityDto = new EventActivityDto
                //{
                //    //Id = model.EventActivityDto.Id,
                //    ActivityId = Guid.Parse(model.ActivityId[0].ToString()),
                //    //ActivityDetails = new ActivityDetails
                //    //{
                //    //    Name = model.EventActivityDto.ActivityDetails.Name
                //    //}
                //}
            };


            if (ModelState.IsValid)
            {
                //foreach (var item in model.Image)
                //{
                    var fileName = $"{Guid.NewGuid()}{Path.GetExtension(model.Image.FileName)}";
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Assets/Images/Event/", fileName);
                    var imageList = new List<string>();

                    model.ImageUrl="/Assets/Images/Event/" + fileName;


                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await model.Image.CopyToAsync(fileStream);
                    }
                //}
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
                

                //var fileName = $"{Guid.NewGuid()}{Path.GetExtension(model.Image.FileName)}";
                //var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Assets/Images/Event/", fileName);
                //   var imageList=new List<string>();
                //foreach (var item in model.ImageUrl)
                //{
                    
                //}

                //var response = await _eventRepository.AddEvent(model);
                //using (var fileStream = new FileStream(filePath, FileMode.Create))
                //{
                //    await model.Image.CopyToAsync(fileStream);
                //}
                //if (response.Succeeded == false)
                //{
                //    TempData["Message"] = response.Message;
                //    TempData["Flag"] = response.Succeeded;
                //}
                //else
                //{
                //    TempData["Message"] = response.Message;
                //    TempData["Flag"] = null;
                //    return RedirectToAction("GetAllEvents", "Event");
                //}
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
        [HttpPost]
        //public async Task<IActionResult> Edit(EventVM model)
        //{
        //    var eventObj = await _eventRepository.GetEventById(model.EventId);
           

         
        //    eventObj.Data.EventId = model.EventId;
        //    eventObj.Data.Name = model.Name;
        //     eventObj.Data.Price = model.Price;
        //        eventObj.Data.Capacity = model.Capacity;
        //        eventObj.Data.StartDate = model.StartDate;
        //        eventObj.Data.EndDate = model.EndDate;
        //        eventObj.Data.Description = model.Description;
        //        eventObj.Data.ImageUrl = model.ImageUrl;
        //        eventObj.Data.Highlights = model.Highlights;
        //        eventObj.Data.EventRules = model.EventRules;
        //        eventObj.Data.CampsiteId = model.CampsiteId;
        //        eventObj.Data.ActivityId = model.ActivityId;
        //        eventObj.Data.LocationId = model.LocationId;
        //        eventObj.Data.Status = model.Status;
        //        eventObj.Data.IsDeleted = model.IsDeleted;
               
        //        eventObj.Data.EventLocationDto = new EventLocationDto
        //        {
        //            Id = model.EventLocationDto.Id,
        //            LocationId = Guid.Parse(model.LocationId.ToString()),
        //            //LocationDetails = new LocationDetails
        //            //{
        //            //    Name = model.EventLocationDto.LocationDetails.Name
        //            //}
        //        };
        //       eventObj.Data.EventActivityDto = new EventActivityDto
        //       {
        //           Id = model.EventActivityDto.Id,
        //           ActivityId = Guid.Parse(model.ActivityId.ToString()),
        //           //ActivityDetails = new ActivityDetails
        //           //{
        //           //    Name = model.EventActivityDto.ActivityDetails.Name
        //           //}
        //       };


        //    //};


        //    //if (ModelState.IsValid)
        //    //{
        //        if (model.Image == null)
        //        {
        //            //var fileName = $"{Guid.NewGuid()}{Path.GetExtension(modelObj.Image.FileName)}";
        //            //var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Assets/Images/Event/", fileName);

        //            //model.ImageUrl = "/Assets/Images/Event/" + fileName;

        //            var response = await _eventRepository.EditEvent(eventObj.Data);
        //        //using (var fileStream = new FileStream(filePath, FileMode.Create))
        //        //{
        //        //    await modelObj.Image.CopyToAsync(fileStream);
        //        //}
        //        return RedirectToAction("Details", response.Data);
        //    }
        //        else
        //        {
        //        eventObj.Data.Image = model.Image;
        //            var fileName = $"{Guid.NewGuid()}{Path.GetExtension(eventObj.Data.Image.FileName)}";
        //            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Assets/Images/Event/", fileName);

        //             eventObj.Data.ImageUrl = "/Assets/Images/Event/" + fileName;

        //            var response = await _eventRepository.EditEvent(eventObj.Data);
        //            using (var fileStream = new FileStream(filePath, FileMode.Create))
        //            {
        //                await eventObj.Data.Image.CopyToAsync(fileStream);
        //            }
        //            return RedirectToAction("Details", response.Data);
        //        }

        //    //}
        //    //else
        //    //    ModelState.AddModelError("", "Oops! Some error occured.");

        //    //return View(model);



        //}
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
