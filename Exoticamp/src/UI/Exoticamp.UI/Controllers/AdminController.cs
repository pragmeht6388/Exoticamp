using Exoticamp.UI.AuthFilter;
using Exoticamp.UI.Models.Registration;
using Exoticamp.UI.Services.IRepositories;
using Exoticamp.UI.Services.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Exoticamp.UI.Controllers
{
    [AdminAuthFilter]
    public class AdminController : Controller
    {
        private readonly IRegistrationRepository _registrationRepository;
        private readonly IUsersRepository _userRepository;
        public AdminController(IUsersRepository userRepository, IRegistrationRepository registrationRepository)
        {
            _userRepository = userRepository;
            _registrationRepository = registrationRepository;
            
        }
        [HttpGet]
       
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _userRepository.GetAllUsersAsync();
            return View(users);
        }

        public async Task<IActionResult> GetAllUsersPartial()
        {
            var users = await _userRepository.GetAllUsersAsync();
            return PartialView("GetAllUsersPartial", users);
        }

        public async Task<IActionResult> GetAllVendors()
        {
            var users = await _userRepository.GetAllVendorsAsync();
            return PartialView("_GetAllVendorsPartial",users);
        }
        [HttpGet]
        public async Task<IActionResult> CreateVendor( )
        {
            return View( );
        }

        [HttpPost]


        public async Task<IActionResult> CreateVendor(RegistrationVM registrationVM)
        {

            var result = await _registrationRepository.CreateVendorRegistration(registrationVM);

            if (result.Message != null)
            {
                // ModelState.AddModelError(string.Empty, result.Message);
                TempData["Message"] = result.Message;
                return View(registrationVM);
            }
            else
            {

                ModelState.AddModelError(string.Empty, "An error occurred while creating the  User.");
            }


            return RedirectToAction("login");

        }

        [HttpDelete]
        public async Task<IActionResult> IsDeleteUser(  string Email)
        {
            var users = await _userRepository.IsDeleteAsync( Email  );

            return RedirectToAction("GetAllUsers", "Admin");
        }

        [HttpPut]
        public async Task<IActionResult> IsLockedUsers(string Email)
        {
            var users = await _userRepository.IsLockedUsersAsync(Email);
           return RedirectToAction("GetAllUsers", "Admin");
            //return Json(new { success = true, message = "Vendor deleted successfully." });
        }


    }
}
