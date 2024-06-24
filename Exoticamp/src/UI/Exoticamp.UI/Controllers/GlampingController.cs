using Microsoft.AspNetCore.Mvc;

namespace Exoticamp.UI.Controllers
{
    public class GlampingController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]

        public async Task<IActionResult> GetAllGlamping()
        {
           // var users = await _userRepository.GetAllUsersAsync();
            return View( );
        }

    }
}
