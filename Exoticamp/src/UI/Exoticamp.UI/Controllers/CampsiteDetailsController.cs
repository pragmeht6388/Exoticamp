using Exoticamp.UI.Services.IRepositories;
using Microsoft.AspNetCore.Mvc;

namespace Exoticamp.UI.Controllers
{
    public class CampsiteDetailsController : Controller
    {
        private readonly ICampsiteDetailsRepository _campsiteRepository;

        public CampsiteDetailsController(ICampsiteDetailsRepository campsiteRepository)
        {
            _campsiteRepository = campsiteRepository;
        }

        public async Task<IActionResult> ShowCampsite()
        {
            var campsiteDetail = await _campsiteRepository.GetAllCampsites();
            return View(campsiteDetail);
        }
        public async Task<IActionResult> Details(string id)
        {
            var campsiteDetail = await _campsiteRepository.GetCampsiteById(id);
            if (campsiteDetail == null)
            {
                return NotFound();
            }
            return View(campsiteDetail.Data);
        }
    }
}
