using Exoticamp.UI.Models.Banners;
using Exoticamp.UI.Services.IRepositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Exoticamp.UI.Controllers
{
    public class BannerController : Controller
    {
        private readonly IBannerRepository _bannerRepository;

        public BannerController(IBannerRepository bannerRepository)
        {
            _bannerRepository = bannerRepository;
        }

        public async Task<IActionResult> AllBanners()
        {
            var banners = await _bannerRepository.GetAllBanners();
            return View(banners);
        }

        [HttpGet]
        public IActionResult AddBanners()
        {
            return View();
        }
        public async Task<IActionResult> AddBanners(BannerViewModel model)
        {
            var banners = await _bannerRepository.AddBanners(model);
            if (banners.Message == "success")
            {
                TempData["Message"] = banners.Message;
                return RedirectToAction("AllBanners");

            }
            else if (banners.Message == "Failed to add banner.")
            {
                TempData["Message"] = banners.Message;
                return View(model);
            }
            return View();

        }
        [HttpGet]
        public async Task<IActionResult> EditBanner(string id)
        {
            var bannerObj = await _bannerRepository.GetBannerById(id);
            return View(bannerObj.Data);
            }

        [HttpPost]
        public async Task<IActionResult> EditBanner(string id,BannerViewModel model)
        {
            if (ModelState.IsValid)
            {
                model.BannerId = Guid.Parse(id);
                var response = await _bannerRepository.EditBanner(model);
                return RedirectToAction("AllBanners");
            }
            else
            {
                ModelState.AddModelError("", "Oops! Some error occurred.");
                return View(model);
            }
        }
        public async Task<IActionResult> DeleteBanner(string id)
        {
            var deleteResponse = await _bannerRepository.DeleteBanner(id);

                return RedirectToAction("AllBanners");
      
        }
        public async Task<IActionResult> ViewBanner(string id)
        {
            // Fetch the banner details from your data source based on the id
            var banner = await _bannerRepository.GetBannerById(id);

            if (banner == null)
            {
                return NotFound(); // Return 404 if the banner is not found
            }

            return View(banner.Data);
        }
        public async Task<IActionResult> AllBannersUser()
        {
            var banners = await _bannerRepository.GetAllBanners();
            return View(banners);
        }
    }
}
