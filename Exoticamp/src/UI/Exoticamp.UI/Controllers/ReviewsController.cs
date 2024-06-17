using Exoticamp.Domain.Entities;
using Exoticamp.UI.AuthFilter;
using Exoticamp.UI.Models.Reviews;
using Exoticamp.UI.Services.IRepositories;
using Microsoft.AspNetCore.Mvc;

namespace Exoticamp.UI.Controllers
{
    public class ReviewsController : Controller
    {
        private readonly IReviewsRepository _reviewsRepository;

        public ReviewsController(IReviewsRepository reviewsRepository)
        {
            _reviewsRepository = reviewsRepository;
        }
        [HttpGet]
        [UserAuthFilter]
        [NoCache]
        public IActionResult AddReview()
        {
            return View();
        }
        // [HttpPost]
        [UserAuthFilter]
        [NoCache]
        public async Task<IActionResult> AddReview(ReviewsVM reviews)
        {

            var result = await _reviewsRepository.AddReviews(reviews);

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
        [VendorAuthFilter]
        [NoCache]
        public async Task<IActionResult> ShowReviews()
        {
            var campsiteDetail = await _reviewsRepository.GetAllReviews();

            // Filter the campsiteDetail to include only those with isActive set to true
            var activeCampsites = campsiteDetail.Where(c => c.Status == true).ToList();

            return View(activeCampsites);
        }
    }
}
