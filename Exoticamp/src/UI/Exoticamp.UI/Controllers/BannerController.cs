﻿using Exoticamp.UI.AuthFilter;
using Exoticamp.UI.Models.Banners;
using Exoticamp.UI.Services.IRepositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;
using System.Collections.Generic;
using System.Threading.Tasks;
using static Microsoft.VisualStudio.Services.Graph.GraphResourceIds;

namespace Exoticamp.UI.Controllers
{
    [AdminAuthFilter]
    [NoCache]
    public class BannerController(IBannerRepository _bannerRepository, ILocationRepository _locationRepository) : Controller
    {
         

        public async Task<IActionResult> AllBanners()
        {
            var banners = await _bannerRepository.GetAllBanners();
            return View(banners);
        }

        [HttpGet]
        public async Task<IActionResult> AddBanners()
        {
            var location = await _locationRepository.GetAllLocations();
            ViewBag.LocationList = new SelectList(location, "Id", "Name");
            return View();
        }
        public async Task<IActionResult> AddBanners(BannerViewModel model)
        {
            var fileName = Path.GetFileName(model.ImageFile.FileName);
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Assets/Images/Banner/", fileName);

            // Set the ImagePath property of the model
            model.ImagePath = "/Assets/Images/Banner/" + fileName;
            var banners = await _bannerRepository.AddBanners(model);
            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await model.ImageFile.CopyToAsync(fileStream);
            }
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
            var location = await _locationRepository.GetAllLocations();
            
            if (location != null )
            {
                ViewBag.LocationList = location.Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.Name });
               
            }
            return View(bannerObj.Data);
            }

        [HttpPost]
        public async Task<IActionResult> EditBanner(string id,BannerViewModel model)
        {
            var location = await _locationRepository.GetAllLocations();
            ViewBag.LocationList = location.Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.Name });
            model.BannerId = Guid.Parse(id);

            if (model.ImageFile!=null)
            {
                
                var fileName = Path.GetFileName(model.ImageFile.FileName);
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Assets/Images/Banner/", fileName);

                // Set the ImagePath property of the model
                model.ImagePath = "/Assets/Images/Banner/" + fileName;
                
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await model.ImageFile.CopyToAsync(fileStream);
                }
                
                
            }
            TempData["Message"] = "Banners Updated successfully.";
            var response = await _bannerRepository.EditBanner(model);
            return RedirectToAction("AllBanners");

        }
         
        public async Task<IActionResult> DeleteBanner(string id)
        {
            var deleteResponse = await _bannerRepository.DeleteBanner(id);

            if (deleteResponse != null)
            {
                return Json(new { success = true, message = "Banner deleted successfully." });
            }
            else
            {
                return Json(new { success = false, message = "Error deleting user." });
            }

        }

        public async Task<IActionResult> ViewBanner(string id)
        {
            // Fetch the banner details from your data source based on the id
            var banner = await _bannerRepository.GetBannerById(id);

            if (banner == null)
            {
                return NotFound(); // Return 404 if the banner is not found
            }
            var locations = await _locationRepository.GetAllLocations();
            var location = locations.FirstOrDefault(l => l.Id.ToString() == banner.Data.LocationId.ToString());

            // Pass the location name to ViewBag
            ViewBag.LocationName = location != null ? location.Name : "Unknown";
            return View(banner.Data);
        }
        public async Task<IActionResult> AllBannersUser()
        {
            var banners = await _bannerRepository.GetAllBanners();
            return PartialView("_PartialForAllBanners",banners);
        }
        
    }
}
