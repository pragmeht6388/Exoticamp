using Exoticamp.UI.Services.IRepositories;
using Microsoft.AspNetCore.Mvc;

namespace Exoticamp.UI.Controllers
{
    public class GlampingController : Controller
    {
        private readonly IGlampingRepository _glampingRepository;

        public GlampingController(IGlampingRepository glampingRepository)
        {
            _glampingRepository = glampingRepository;
            
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
       

        public async Task<IActionResult> GetAllGlamping()
        {
            var glamping = await _glampingRepository.GetGlampingListVAsync();
            return View(glamping );
        }
        [HttpGet]


        public async Task<IActionResult> GetGlampingById(string id)
        {
            var glamping = await _glampingRepository.GetGlampingByIdAsync(  id);
            
            return View(glamping);
        }

    }
}
