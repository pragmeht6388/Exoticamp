using Exoticamp.UI.Models;
using Exoticamp.UI.Models.Campsite;
using Exoticamp.UI.Models.ContactUs;
using Exoticamp.UI.Services.IRepositories;
using Microsoft.AspNetCore.Mvc;

namespace Exoticamp.UI.Controllers
{
    public class CampsiteController (ICampsiteRepository _campsiteRepository) : Controller
    {
         
        [HttpGet]
        public IActionResult AddCampsite()
        {
            return View();
        }


        public async Task<IActionResult> AddCampsite(CampsiteVM campsite)
        {

            var result = await _campsiteRepository.AddCampsite(campsite);

            if (result.Message != null)
            {
                ModelState.AddModelError(string.Empty, result.Message);
            }
            else
            {

                ModelState.AddModelError(string.Empty, "An error occurred while creating the SysPrefCompany.");
            }


            return RedirectToAction("ShowCampsite");

        }

        public async Task<IActionResult> ShowCampsite()
        {
            var campsiteDetail = await _campsiteRepository.GetAllCampsites();

            // Filter the campsiteDetail to include only those with isActive set to true
            var activeCampsites = campsiteDetail.Where(c => c.isActive == true).ToList();

            return View(activeCampsites);
        }


        [HttpGet]
        public async Task<IActionResult> EditCampsite(string id)
        {
            var eventObj = await _campsiteRepository.GetCampsiteById(id);
            return View(eventObj.Data);
        }
        [HttpPost]
        public async Task<IActionResult> EditCampsite(CampsiteVM model)
         { 
            if (ModelState.IsValid)
            {
                model.isActive = true;
                var response = await _campsiteRepository.EditCampsite(model);
                
                return RedirectToAction("ShowCampsite");
            }
            else
                ModelState.AddModelError("", "Oops! Some error occured.");

            return View(model);


        }

        public async Task<IActionResult> DeleteCampsite(string id)
        {
            var deleteResponse = await _campsiteRepository.DeleteCampsite(id);

            return RedirectToAction("ShowCampsite");
            
        }

        public IActionResult AddCampsiteDetails()
        {
            return View();
        }
    }
}
