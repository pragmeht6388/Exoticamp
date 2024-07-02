using Exoticamp.UI.Models.ReviewReply;
using Exoticamp.UI.Models.Reviews;
using Exoticamp.UI.Services.IRepositories;
using Exoticamp.UI.Services.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Exoticamp.UI.Controllers
{
    public class ReviewReplyController(IReviewReplyRepository _reviewsRepository) : Controller
    {
         

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
