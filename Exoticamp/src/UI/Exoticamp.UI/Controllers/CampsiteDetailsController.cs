using Exoticamp.UI.Models;
using Exoticamp.UI.Models.CampsiteDetails;
using Exoticamp.UI.Services.IRepositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using static Microsoft.AspNetCore.Razor.Language.TagHelperMetadata;

namespace Exoticamp.UI.Controllers
{
    public class CampsiteDetailsController : Controller
    {
        private readonly ICampsiteDetailsRepository _campsiteRepository;
        private readonly ICategoryRepository _categoryRepository;


        public CampsiteDetailsController(ICampsiteDetailsRepository campsiteRepository, ICategoryRepository categoryRepository)
        {
            _campsiteRepository = campsiteRepository;
            _categoryRepository = categoryRepository;
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

        //[HttpGet]
        //public async Task<IActionResult> CreateCampsiteDetails(CampsiteDetailsVM campsite)
        //{
        //    var sysPrefCompanies = await _campsiteRepository.AddCampsiteDetails(campsite); ;
        //    ViewBag.CompanyList = new SelectList(sysPrefCompanies, "CompanyID", "CompanyName");
        //    return View();
        //}

        [HttpGet]
        public async Task<IActionResult> AddCampsiteDetails()
        {
            // Fetch all categories from the repository
            var categories = await _categoryRepository.GetAllCategory();

            // Check if categories are null
            if (categories == null)
            {
                // Log the error or handle the null case as required
                return View("Error", new ErrorViewModel {  });
            }

            // Populate the ViewBag with a SelectList for the dropdown
            ViewBag.CategoryList = new SelectList(categories, "CategoryId", "Name");

            // Return the view
            return View();
        }


    }
}
