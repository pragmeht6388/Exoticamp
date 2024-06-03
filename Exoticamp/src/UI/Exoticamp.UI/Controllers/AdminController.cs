using Exoticamp.UI.Services.IRepositories;
using Microsoft.AspNetCore.Mvc;

namespace Exoticamp.UI.Controllers
{
    public class AdminController : Controller
    {
        private readonly IUsersRepository _userRepository;
        public AdminController(IUsersRepository userRepository)
        {
            _userRepository = userRepository;
            
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


    }
}
