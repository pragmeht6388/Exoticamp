using Exoticamp.Domain.Entities;
using Exoticamp.UI.AuthFilter;
using Exoticamp.UI.Models.Reviews;
using Exoticamp.UI.Services.IRepositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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


        public async Task<IActionResult> ShowReviewsUser()
        {
            var campsiteDetail = await _reviewsRepository.GetAllReviews();

            // Filter the campsiteDetail to include only those with isActive set to true
            var activeCampsites = campsiteDetail.Where(c => c.Status == true).ToList();

            return View("ShowReviewsUser",activeCampsites);
        }


        public async Task<IActionResult> ShowReviewsAdmin()
        {
            var campsiteDetail = await _reviewsRepository.GetAllReviews();

            // Filter the campsiteDetail to include only those with isActive set to true
            var activeCampsites = campsiteDetail.Where(x=>x.Status==false).ToList();

            return View(activeCampsites);
        }

        //[HttpPost]
        //public async Task<IActionResult> ToggleReviewStatus(string id)
        //{
        //    var review = await _reviewsRepository.GetReviewById(id);
        //    if (review == null)
        //    {
        //        return NotFound();
        //    }

        //    // Toggle the review status
        //    review.Data.Status = !review.Data.Status; // Invert the current status

        //    _reviewsRepository.EditReview(review);
        //    //await _context.SaveChangesAsync();

        //    return NoContent(); // Return a 204 No Content response
        //}


        [HttpPost]
        public async Task<IActionResult> ApproveReview(string id)
        {
            var review = await _reviewsRepository.GetReviewById(id);

            if (review == null|| review.Data== null)
            {
                return NotFound(); // Handle scenario where review is not found
            }

            // Update review status to approved
            review.Data.Status = true; // Assuming Status is a boolean property

            // Save changes to repository
            var result = await _reviewsRepository.EditReview(review.Data);

            if (result.Data.Status)
            {
                TempData["SuccessMessage"] = "Review approved successfully.";
            }
            else
            {
                TempData["ErrorMessage"] = "Failed to approve review.";
            }

            return RedirectToAction("ShowReviewsAdmin");
        }

        [HttpPost]
        public async Task<IActionResult> RejectReview(string id)
        {
            var review = await _reviewsRepository.GetReviewById(id);

            if (review == null)
            {
                return NotFound(); // Handle scenario where review is not found
            }

            // Update review status to rejected
            review.Data.Status = false; // Assuming Status is a boolean property

            // Save changes to repository
            var result = await _reviewsRepository.EditReview(review.Data);

            if (result.Data.Status)
            {
                TempData["SuccessMessage"] = "Review rejected successfully.";
            }
            else
            {
                TempData["ErrorMessage"] = "Failed to reject review.";
            }

            return RedirectToAction("ShowReviewsAdmin");
        }
    }
}
