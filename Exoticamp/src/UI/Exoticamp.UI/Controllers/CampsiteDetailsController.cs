using Exoticamp.UI.AuthFilter;
using Exoticamp.UI.Models;
using Exoticamp.UI.Models.CampsiteDetails;
using Exoticamp.UI.Services.IRepositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
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
        private readonly ILocationRepository _locationRepository;



        public CampsiteDetailsController(ICampsiteDetailsRepository campsiteRepository, ICategoryRepository categoryRepository, IActivitiesRepository activitiesRepository,ILocationRepository locationRepository)
        {
            _campsiteRepository = campsiteRepository;
            _categoryRepository = categoryRepository;
            _activitiesRepository = activitiesRepository;
            _locationRepository=locationRepository;
        }
        [VendorAuthFilter]
        [NoCache]
        public async Task<IActionResult> ShowCampsite()
        {
            var campsiteDetail = await _campsiteRepository.GetAllCampsites();
            if (TempData.ContainsKey("SuccessMessage"))
            {
                ViewBag.SuccessMessage = TempData["SuccessMessage"].ToString();
            }
            return View(campsiteDetail);
        }
        [VendorAuthFilter]
      
        [NoCache]
        public async Task<IActionResult> Details(string id)
        {
            var campsiteDetail = await _campsiteRepository.GetCampsiteById(id);
            ViewBag.CampsiteCorousel = await _campsiteRepository.GetAllCampsites();

            if (campsiteDetail == null)
            {
                return NotFound();
            }
            return View(campsiteDetail.Data);
        }


        [VendorAuthFilter]
        [NoCache]
        [HttpGet]
        public async Task<IActionResult> AddCampsiteDetails()
        {
            var categories = await _categoryRepository.GetAllCategory();
            var activities = await _activitiesRepository.GetAllActivities();
            var loaction = await _locationRepository.GetAllLocations();

            if (categories == null)
            {
                return View("Error", new ErrorViewModel { });
            }

            ViewBag.CategoryList = new SelectList(categories, "CategoryId", "Name");
            ViewBag.ActivitiesList = new SelectList(activities, "Id", "Name");

            return View();
        }
        [VendorAuthFilter]
        [NoCache]
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
        [VendorAuthFilter]
        [NoCache]
        [HttpGet]
        public async Task<IActionResult> EditCampsite(string id)
        {
            var eventObj = await _campsiteRepository.GetCampsiteById(id);
            eventObj.Data.ActivitiesId = eventObj.Data.Activities[0].Id;
            var categoryList = await _categoryRepository.GetAllCategory();
            var activitiesList = await _activitiesRepository.GetAllActivities();
           // var Activities = await _activitiesRepository.GetAllActivities();

            if (activitiesList != null)
            {
                ViewBag.CategoryList = categoryList.Select(c => new SelectListItem { Value = c.CategoryId.ToString(), Text = c.Name });
                var activitiesSelectList = activitiesList.Select(a => new SelectListItem
                {
                    Value = a.Id.ToString(),
                    Text = a.Name,
                    Selected = eventObj.Data.ActivitiesId == a.Id
                }).ToList();

                //ViewBag.ActivitiesList = activitiesSelectList;
                ViewBag.ActivitiesList = new SelectList(activitiesList, "Id", "Name");

            }
            else
            {
                return RedirectToAction("Error");
            }

            return View(eventObj.Data);
        }
        [VendorAuthFilter]
        [NoCache]
        public async Task<IActionResult> EditCampsite(CampsiteDetailsVM model)
        {
            var categoryList = await _categoryRepository.GetAllCategory();
            var activitiesList = await _activitiesRepository.GetAllActivities();

            ViewBag.CategoryList = categoryList.Select(c => new SelectListItem
            {
                Value = c.CategoryId.ToString(),
                Text = c.Name
            }).ToList(); 

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
                TempData["SuccessMessage"] = "Campsite details updated successfully.";
                return RedirectToAction("ShowCampsite");
            }
            TempData["ErrorMessage"] = "Unable to update campsite.";
            return RedirectToAction("ShowCampsite");
        }
        [VendorAuthFilter]
        [NoCache]
        public async Task<IActionResult> DeleteCampsite(string id)
        {
            var deleteResponse = await _campsiteRepository.DeleteCampsite(id);
            TempData["SuccessMessage"] = "Campsite deleted successfully!";

            return RedirectToAction("ShowCampsite");

        }

        public async Task<IActionResult> ShowCampsiteUser()
        {
            var campsiteDetail = await _campsiteRepository.GetAllCampsites();
            var approvedCampsites = campsiteDetail.Where(c => c.ApprovedBy != null).ToList();

            return PartialView("_PartialCampsiteCorousel", campsiteDetail);
        }
        public async Task<IActionResult> ShowCampsiteEndUser()
        {
            var campsiteDetail = await _campsiteRepository.GetAllCampsites();

            // Filter the campsiteDetail to include only the approved campsites
            var approvedCampsites = campsiteDetail.Where(c => c.ApprovedBy != null).ToList();

            return PartialView("_ShowCampsiteEndUser", approvedCampsites);
        }


        public async Task<IActionResult> DetailsUser(string id)
        {
            var campsiteDetail = await _campsiteRepository.GetCampsiteById(id);
            ViewBag.CampsiteCorousel = await _campsiteRepository.GetAllCampsites();

            if (campsiteDetail == null)
            {
                return NotFound();
            }
            return View(campsiteDetail.Data);
        }

        [AdminAuthFilter]
        [NoCache]
        public async Task<IActionResult> ShowCampsiteAdmin()
        {
            var campsiteDetail = await _campsiteRepository.GetAllCampsites();
            if (TempData.ContainsKey("SuccessMessage"))
            {
                ViewBag.SuccessMessage = TempData["SuccessMessage"].ToString();
            }
            return View(campsiteDetail);
        }

        [AdminAuthFilter]
        [NoCache]
        [HttpGet]
        public async Task<IActionResult> EditCampsiteAdmin(string id)
        {
            var eventObj = await _campsiteRepository.GetCampsiteById(id);
            eventObj.Data.ActivitiesId = eventObj.Data.Activities[0].Id;
            var categoryList = await _categoryRepository.GetAllCategory();
            //var Approved = eventObj.Data.ApprovedBy;
            //ViewBag.ApprovedBy = Approved;
            var activitiesList = await _activitiesRepository.GetAllActivities();

            if (activitiesList != null)
            {
                ViewBag.CategoryList = categoryList.Select(c => new SelectListItem { Value = c.CategoryId.ToString(), Text = c.Name });
                var activitiesSelectList = activitiesList.Select(a => new SelectListItem
                {
                    Value = a.Id.ToString(),
                    Text = a.Name,
                    Selected = eventObj.Data.ActivitiesId == a.Id
                }).ToList();

                ViewBag.ActivitiesList = new SelectList(activitiesList, "Id", "Name");

            }
            else
            {
                return RedirectToAction("Error");
            }

            return View(eventObj.Data);
        }

        [AdminAuthFilter]
        [NoCache]
        [HttpPost]
        public async Task<IActionResult> EditCampsiteAdmin(CampsiteDetailsVM model)
        {
            var categoryList = await _categoryRepository.GetAllCategory();
            var activitiesList = await _activitiesRepository.GetAllActivities();

            ViewBag.CategoryList = categoryList.Select(c => new SelectListItem
            {
                Value = c.CategoryId.ToString(),
                Text = c.Name
            }).ToList();

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
                TempData["SuccessMessage"] = "Campsite details updated successfully.";
                return RedirectToAction("ShowCampsiteAdmin");
            }
            TempData["ErrorMessage"] = "Unable to update campsite.";
            return RedirectToAction("ShowCampsiteAdmin");
        }

        [AdminAuthFilter]
        [NoCache]
        [HttpPost]
        public async Task<IActionResult> ToggleApproval(string id)
        {
            var campsite = await _campsiteRepository.GetCampsiteById(id);
            campsite.Data.ActivitiesId = campsite.Data.Activities[0].Id;
            var activitiesList = await _activitiesRepository.GetAllActivities();

            var activitiesSelectList = activitiesList.Select(a => new SelectListItem
            {
                Value = a.Id.ToString(),
                Text = a.Name,
                Selected = campsite.Data.ActivitiesId == a.Id
            }).ToList();

            ViewBag.ActivitiesList = new SelectList(activitiesList, "Id", "Name");

           

            if (campsite == null)
            { 
                return NotFound();
            }

            if (campsite.Data.ApprovedBy == null)
            {
                campsite.Data.ApprovedBy = "Admin"; // Approve the campsite
            }
            else
            {
                campsite.Data.ApprovedBy = null; // Reject the campsite
            }

            var result = await _campsiteRepository.EditCampsiteDetails(campsite.Data);
            if (result.Succeeded)
            {
                TempData["SuccessMessage"] = campsite.Data.ApprovedBy == null ? "Campsite rejected successfully." : "Campsite approved successfully.";
            }
            else
            {
                TempData["ErrorMessage"] = "Failed to update campsite approval status.";
            }

            return RedirectToAction("ShowCampsiteAdmin");
        }

        [AdminAuthFilter]
        [NoCache]
        public async Task<IActionResult> DeleteCampsiteAdmin(string id)
        {
            var deleteResponse = await _campsiteRepository.DeleteCampsite(id);
            TempData["SuccessMessage"] = "Campsite deleted successfully!";

            return RedirectToAction("ShowCampsiteAdmin");

        }


        [HttpGet]
        [AdminAuthFilter]
        [NoCache]
        public async Task<IActionResult> AddCampsiteDetailsAdmin()
        {
            var categories = await _categoryRepository.GetAllCategory();
            var activities = await _activitiesRepository.GetAllActivities();
            var loaction = await _locationRepository.GetAllLocations();
           // var vendorId=await _

            if (categories == null)
            {
                return View("Error", new ErrorViewModel { });
            }

            ViewBag.CategoryList = new SelectList(categories, "CategoryId", "Name");
            ViewBag.ActivitiesList = new SelectList(activities, "Id", "Name");

            return View();
        }
       
        public async Task<IActionResult> AddCampsiteDetailsAdmin(CampsiteDetailsVM campsite)
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


            return RedirectToAction("AddCampsiteDetailsAdmin");

        }


        public async Task<IActionResult> DetailsAdmin(string id)
        {
            var campsiteDetail = await _campsiteRepository.GetCampsiteById(id);
            ViewBag.CampsiteCorousel = await _campsiteRepository.GetAllCampsites();

            if (campsiteDetail == null)
            {
                return NotFound();
            }
            return View(campsiteDetail.Data);
        }
    }
}

