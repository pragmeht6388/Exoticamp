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


    }
}
