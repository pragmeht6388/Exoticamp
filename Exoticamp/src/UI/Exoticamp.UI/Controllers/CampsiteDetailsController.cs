using Exoticamp.UI.AuthFilter;
using Exoticamp.UI.Models;
using Exoticamp.UI.Models.CampsiteDetails;
using Exoticamp.UI.Services.IRepositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using static Microsoft.AspNetCore.Razor.Language.TagHelperMetadata;

namespace Exoticamp.UI.Controllers
{
    //[VendorAuthFilter]
    //[]
    public class CampsiteDetailsController : Controller
    {
        private readonly ICampsiteDetailsRepository _campsiteRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IActivitiesRepository _activitiesRepository;



        public CampsiteDetailsController(ICampsiteDetailsRepository campsiteRepository, ICategoryRepository categoryRepository, IActivitiesRepository activitiesRepository)
        {
            _campsiteRepository = campsiteRepository;
            _categoryRepository = categoryRepository;
            _activitiesRepository = activitiesRepository;
        }

        public async Task<IActionResult> ShowCampsite()
        {
            var campsiteDetail = await _campsiteRepository.GetAllCampsites();
            if (TempData.ContainsKey("SuccessMessage"))
            {
                // Retrieve the success message from TempData
                ViewBag.SuccessMessage = TempData["SuccessMessage"].ToString();
            }
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



        [HttpGet]
        public async Task<IActionResult> AddCampsiteDetails()
        {
            // Fetch all categories from the repository
            var categories = await _categoryRepository.GetAllCategory();
            var activities = await _activitiesRepository.GetAllActivities();

            // Check if categories are null
            if (categories == null)
            {
                // Log the error or handle the null case as required
                return View("Error", new ErrorViewModel { });
            }

            // Populate the ViewBag with a SelectList for the dropdown
            ViewBag.CategoryList = new SelectList(categories, "CategoryId", "Name");
            ViewBag.ActivitiesList = new SelectList(activities, "Id", "Name");


            // Return the view
            return View();
        }
        public async Task<IActionResult> AddCampsiteDetails(CampsiteDetailsVM campsite)
        {
            var fileName = Path.GetFileName(campsite.ImageFile.FileName);
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Assets/Images/Campsite/", fileName);

            campsite.Images = "/Assets/Images/Campsite/" + campsite.ImageFile.FileName;

            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await campsite.ImageFile.CopyToAsync(fileStream);
            }

            var result = await _campsiteRepository.AddCampsiteDetails(campsite);

            if (result.Message != null)
            {
                TempData["SuccessMessage"] = "Campsite details added successfully.";

                ModelState.AddModelError(string.Empty, result.Message);
            }
            else
            {

                ModelState.AddModelError(string.Empty, "An error occurred while creating the SysPrefCompany.");
            }


            return RedirectToAction("AddCampsiteDetails");

        }

        [HttpGet]
        public async Task<IActionResult> EditCampsite(string id)
        {
            var eventObj = await _campsiteRepository.GetCampsiteById(id);

            var categoryList = await _categoryRepository.GetAllCategory();
            var activitiesList = await _activitiesRepository.GetAllActivities();

            if (categoryList != null && activitiesList != null)
            {
                ViewBag.CategoryList = categoryList.Select(c => new SelectListItem { Value = c.CategoryId.ToString(), Text = c.Name });
                ViewBag.ActivitiesList = activitiesList.Select(a => new SelectListItem { Value = a.Id.ToString(), Text = a.Name });
            }
            else
            {
                return RedirectToAction("Error");
            }

            return View(eventObj.Data);
        }

        public async Task<IActionResult> EditCampsite(CampsiteDetailsVM model)
        {
            var categoryList = await _categoryRepository.GetAllCategory();
            var activitiesList = await _activitiesRepository.GetAllActivities();

            ViewBag.CategoryList = categoryList.Select(c => new SelectListItem { Value = c.CategoryId.ToString(), Text = c.Name });
            ViewBag.ActivitiesList = activitiesList.Select(a => new SelectListItem { Value = a.Id.ToString(), Text = a.Name });

            if (model.ImageFile != null)
            {
                var fileName = Path.GetFileName(model.ImageFile.FileName);
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Assets/Images/Campsite/", fileName);

                model.Images = "/Assets/Images/Campsite/" + model.ImageFile.FileName;

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await model.ImageFile.CopyToAsync(fileStream);
                }
            }
            model.IsActive = true;
            var result = await _campsiteRepository.EditCampsiteDetails(model);
            if (result.Succeeded)
            {
                TempData["SuccessMessage"] = "Campsite details Updated successfully.";

                return RedirectToAction("ShowCampsite");
            }
            ModelState.AddModelError("", "Unable to update campsite.");

            return RedirectToAction("ShowCampsite");
        }

        public async Task<IActionResult> DeleteCampsite(string id)
        {
            var deleteResponse = await _campsiteRepository.DeleteCampsite(id);
            TempData["SuccessMessage"] = "Campsite deleted successfully!";

            return RedirectToAction("ShowCampsite");

        }

        public async Task<IActionResult> ShowCampsiteUser()
        {
            var campsiteDetail = await _campsiteRepository.GetAllCampsites();

            return View(campsiteDetail);
        }

        public async Task<IActionResult> DetailsUser(string id)
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

