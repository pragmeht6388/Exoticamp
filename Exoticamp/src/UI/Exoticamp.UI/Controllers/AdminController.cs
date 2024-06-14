using Exoticamp.UI.AuthFilter;
using Exoticamp.UI.Models.Registration;
using Exoticamp.UI.Services.IRepositories;
using Exoticamp.UI.Services.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Exoticamp.UI.Controllers
{
    [AdminAuthFilter]
    [NoCache]
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

         
        [HttpGet]

        public async Task<IActionResult> GetAllVendors()
        {
             
            var users = await _userRepository.GetAllVendorsAsync();
            return View(users);
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

        
        public async Task<IActionResult> IsDeleteUser(string Email)
        {
            var users = await _userRepository.IsDeleteAsync(Email);

            return RedirectToAction("GetAllUsers");
        }

        public async Task<IActionResult> IsDeleteVendor(string Email)
        {
            var users = await _userRepository.IsDeleteAsync(Email);

            return RedirectToAction("GetAllVendors");
        }






        public async Task<IActionResult> IsLockedUsers(string Email)
        {
            var users = await _userRepository.IsLockedUsersAsync(Email);
           return RedirectToAction("GetAllUsers", "Admin");
            //return Json(new { success = true, message = "Vendor deleted successfully." });
        }

        public async Task<IActionResult> IsLockedVendor(string Email)
        {
            var users = await _userRepository.IsLockedUsersAsync(Email);
            return RedirectToAction("GetAllVendors", "Admin");
            //return Json(new { success = true, message = "Vendor deleted successfully." });
        }


    }
}
