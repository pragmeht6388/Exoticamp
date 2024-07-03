using Exoticamp.Domain.Entities;
using Exoticamp.UI.Models.EventCart;
using Exoticamp.UI.Models.Events;
using Exoticamp.UI.Services.IRepositories;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Exoticamp.UI.Controllers
{
    public class EventCartController : Controller
    {
        private readonly IEventCartRepository _eventCartRepository;
        private readonly IEventRepository _eventRepository;
        private readonly IUsersRepository _usersRepository;

        public EventCartController(IEventCartRepository eventCartRepository,IEventRepository eventRepository, IUsersRepository usersRepository)
        {
            _eventCartRepository = eventCartRepository;
            _eventRepository = eventRepository;
            _usersRepository = usersRepository;
        }
        [HttpGet]
        public async Task<ActionResult> AddEventCart(string id)
        {
            var userId = HttpContext.Session.GetString("UserId");
            var userDetails = await _usersRepository.GetUserByIdAsync(userId);
            if (userDetails.data == null)
            {
                return RedirectToAction("Login", "Account");
            }
            var eventCarts = await _eventCartRepository.GetAllEventCart();
            var isAlreadyInCart = eventCarts.Any(ec => ec.UserId.ToString() == userId && ec.EventId.ToString() == id);
            if (isAlreadyInCart)
            {
                TempData["SuccessMessage"] = "Campsite details added successfully.";
                return RedirectToAction("GetAllEventsUser", "Event");
            }
            var events = await _eventRepository.GetEventById(id);
            if (events == null || events.Data == null || !(events.Data is EventVM))
            { 
                ViewBag.ErrorMessage = "Event details not found.";
                return View("Error"); 
            }
            ViewBag.Events = events.Data;
            var model = new EventCartVM()
            {
                Event = (EventVM)events.Data,
                PriceForAdults = ((EventVM)events.Data).Price,
                PriceForChildrens = ((EventVM)events.Data).Price / 2,
                CustomerName = userDetails.data.Name, 
                Email = userDetails.data.Email 
            };
            return View(model);
        }



        public async Task<IActionResult> AddEventCart(EventCartVM eventCart)
        {

            var events = await _eventRepository.GetEventById(eventCart.EventId.ToString());
            var capacity = events.Data.Capacity;
            var Person = await _eventCartRepository.GetAllEventCart();
            var filteredEventCarts = Person.Where(ec => ec.EventId.ToString() == eventCart.EventId.ToString()).ToList();

            var totalAdults = filteredEventCarts.Sum(ec => ec.NoOfAdults);
            var totalChildren = filteredEventCarts.Sum(ec => ec.NoOfChildrens);
           
            var totalPersons = totalAdults + totalChildren+ eventCart.NoOfAdults + eventCart.NoOfChildrens;
            if (events.Data == null)
            {
                return NotFound();
            }
            //if (capacity < (totalPersons))
            //{
            //    return View(eventCart);
            //}
            eventCart.Event = events.Data;
            var response = await _eventCartRepository.AddEventCart(eventCart);
            if (response.Succeeded)
            {
                return RedirectToAction("GetAllBookings", "Booking");
            }

            return View(eventCart);


        }

        

        public async Task<IActionResult> ShowEventCart()
        {
            var userId = HttpContext.Session.GetString("VendorId");
            var campsiteDetail = await _eventCartRepository.GetAllEventCart();
            var eventNameList = await _eventRepository.GetAllEvents();
            var eventNamesMap = eventNameList.ToDictionary(e => e.EventId.ToString(), e => e.Name);
            var eventImagesMap = eventNameList.ToDictionary(e => e.EventId.ToString(), e => e.ImageUrl);
            ViewBag.EventNames = eventNamesMap;
            ViewBag.EventImages = eventImagesMap;
            var campsite = campsiteDetail.Where(x => x.UserId.ToString() == userId).ToList();
            if (TempData.ContainsKey("SuccessMessage"))
            {
                ViewBag.SuccessMessage = TempData["SuccessMessage"].ToString();
            }
            return View(campsite);
        }

        
        public async Task<IActionResult> DeleteEventCart(string id)
        {
            var deleteResponse = await _eventCartRepository.DeleteEventCart(id);
            TempData["SuccessMessage"] = "Event Cart deleted successfully!";
            return RedirectToAction("ShowEventCart");

        }
    }
}
