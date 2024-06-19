using Exoticamp.UI.Models.ReviewReply;
using Exoticamp.UI.Models.Reviews;
using Exoticamp.UI.Services.IRepositories;
using Exoticamp.UI.Services.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Exoticamp.UI.Controllers
{
    public class ReviewReplyController : Controller
    {
        private readonly IReviewReplyRepository _reviewsRepository;

        public ReviewReplyController(IReviewReplyRepository reviewsRepository)
        {
            _reviewsRepository = reviewsRepository;
        }
        //[HttpGet]
        //public IActionResult AddReviewReply(int reviewId)
        //{
        //    var model = new ReviewReplyVM { ReviewId = Guid.Parse(reviewId.ToString()) };
        //    return View(model);
        //}
        //// [HttpPost]
        //public async Task<IActionResult> AddReviewReply(ReviewReplyVM reviews)
        //{

        //    var result = await _reviewsRepository.AddReviewsReply(reviews);

        //    if (result.Message != null)
        //    {
        //        ModelState.AddModelError(string.Empty, result.Message);
        //    }
        //    else
        //    {

        //        ModelState.AddModelError(string.Empty, "An error occurred while creating the SysPrefCompany.");
        //    }


        //    return RedirectToAction("ShowCampsite");

        //}

        [HttpPost]
        public async Task<IActionResult> AddReviewReply(ReviewReplyVM reviewReply)
        {
            Console.WriteLine("AddReviewReply method called");

          
                var result = await _reviewsRepository.AddReviewsReply(reviewReply);

                if (result.Succeeded)
                {
                    // Optionally add a success message to TempData
                    TempData["SuccessMessage"] = "Review reply added successfully.";
                }
                else
                {
                    // Add error message to ModelState
                    ModelState.AddModelError(string.Empty, result.Message);
                }
            

            // Redirect back to the action where reviews are shown
            return RedirectToAction("ShowReviews", "Reviews"); // Assuming "ShowReviews" is your action in "Review" controller
        }
    }
}
