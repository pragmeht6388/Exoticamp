using Exoticamp.UI.Models;
using Exoticamp.UI.Models.CampCart;

using Exoticamp.UI.Services.IRepositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

namespace Exoticamp.UI.Controllers
{
    public class CartController : Controller
    {
        private readonly ICartRepository _cartRepository;
        private readonly ICampsiteDetailsRepository _campsiteDetailsRepository;
        private readonly ILocationRepository _locationRepository;
        private readonly IUsersRepository _usersRepository;

        public CartController(ICartRepository cartRepository, ICampsiteDetailsRepository campsiteDetailsRepository, ILocationRepository locationRepository, IUsersRepository usersRepository)
        {
            _cartRepository = cartRepository;
            _campsiteDetailsRepository = campsiteDetailsRepository;
            _locationRepository = locationRepository;
            _usersRepository = usersRepository;
        }

        [HttpGet]
        public async Task<ActionResult> AddCartItem(string id)
        {
            var userId = HttpContext.Session.GetString("UserId"); // Assuming UserId is stored in session
            var userDetails = await _usersRepository.GetUserByIdAsync(userId);

            if (userDetails.data == null)
            {
                // Handle the case where user details are not found (e.g., redirect to login)
                return RedirectToAction("Login", "Account");
            }

            var campsite = await _campsiteDetailsRepository.GetCampsiteById(id);
            var location = await _locationRepository.GetAllLocations();
            var loc = location.FirstOrDefault(x => x.Name == campsite.Data.Location);
            campsite.Data.LocationId = loc.Id;
            ViewBag.Campsite = campsite.Data;

            var model = new CartCampsite()
            {
                CampsiteId=campsite.Data.Id,
                Campsite = campsite.Data,
                Location = loc,
                LocationId = loc.Id,
                PriceForAdults = campsite.Data.Price,
                PriceForChildren = campsite.Data.Price / 2,
                CustomerName = userDetails.data.Name, // Set customer name from user details
                Email = userDetails.data.Email, // Set email from user details
                UserId = userId
            };

            return View(model);
        }


        [HttpPost]
        public async Task<IActionResult> AddCartItem(CartCampsite model)
        {

            
            var campsite = await _campsiteDetailsRepository.GetCampsiteById(model.CampsiteId.ToString());
            if (campsite.Data == null)
            {
                return NotFound();
            }
            model.Campsite = campsite.Data;

            if (model.NoOfAdults <= 0 && model.NoOfChildren <= 0)
            {
                ModelState.AddModelError("NoOfTents", $"Please enter at least one person.");
                return View(model);
            }

            var response = await _cartRepository.AddCartCamp(model);
            if (response.Succeeded)
            {
                return RedirectToAction("ViewCart", "Cart");
            }

            return View(model);
        }


        [HttpGet]
        public async Task<JsonResult> GetCampsitesByLocation(Guid locationId)
        {
            var campsites = await _campsiteDetailsRepository.GetAllCampsites();
            var filteredCampsites = campsites
                .Where(c => c.LocationId == locationId)
                .Select(c => new { value = c.Id, text = c.Name })
                .ToList();

            return Json(filteredCampsites);
        }
        [HttpGet]
        public async Task<IActionResult> ShowCart()
        {
            var userId = HttpContext.Session.GetString("UserId");
            if (string.IsNullOrEmpty(userId))
            {
                return RedirectToAction("Login", "Account");
            }

            var cartItems = await _cartRepository.GetAllCart();

            var userCartItems =  cartItems.Data.Where(item => item.UserId == userId);
            var Campsites = await _campsiteDetailsRepository.GetAllCampsites();

            foreach(var item in userCartItems)
            {
                item.Campsite = Campsites.FirstOrDefault(x => x.Id == item.CampsiteId);
            }

            return View(userCartItems);
        }
     
        public async Task<IActionResult> DeleteCart(string id)
        {
            var deleteResponse = await _cartRepository.DeleteCartId(id);
            if (deleteResponse.Succeeded)
            {
                TempData["SuccessMessage"] = "Event Cart deleted successfully!";
            }
            else
            {
                TempData["ErrorMessage"] = deleteResponse.Message;
            }
            return RedirectToAction("ShowCart");
        }
        public async Task<IActionResult> SummaryCart(Guid id)
        {
            var userId = HttpContext.Session.GetString("UserId");
            if (string.IsNullOrEmpty(userId))
            {
                return RedirectToAction("Login", "Account");
            }

            var cartItem = (await _cartRepository.GetAllCart()).Data.FirstOrDefault(item => item.CartId == id && item.UserId == userId);
            if (cartItem == null)
            {
                return NotFound();
            }

            var campsite = await _campsiteDetailsRepository.GetCampsiteById(cartItem.CampsiteId.ToString());
            if (campsite.Data == null)
            {
                return NotFound();
            }

            cartItem.Campsite = campsite.Data;

            var cartDetailVM = new CartDetailVM
            {
                Cart = cartItem,
                Campsite = campsite.Data
            };

            return View(cartDetailVM);
        }
    }
}