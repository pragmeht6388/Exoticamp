using Exoticamp.UI.Models.ReviewReply;
using Exoticamp.UI.Models.Reviews;
using Exoticamp.UI.Services.IRepositories;
using Exoticamp.UI.Services.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Exoticamp.UI.Controllers
{
    public class ReviewReplyController(IReviewReplyRepository _reviewsRepository) : Controller
    {
        private readonly IReviewReplyRepository _reviewsRepository;

        public ReviewReplyController(IReviewReplyRepository reviewsRepository)
        {
            _reviewsRepository = reviewsRepository;
        }

        [HttpPost]
        public async Task<IActionResult> AddReviewReply(ReviewReplyVM reviewReply)
        {
            Console.WriteLine("AddReviewReply method called");

          
                var result = await _reviewsRepository.AddReviewsReply(reviewReply);

                if (result.Succeeded)
                {
                 
                    TempData["SuccessMessage"] = "Review reply added successfully.";
                }
                else
                {
                   
                    ModelState.AddModelError(string.Empty, result.Message);
                }

            return RedirectToAction("ShowReviews", "Reviews"); 
        }
    }
}
