using Exoticamp.Domain.Entities;
using Exoticamp.UI.AuthFilter;
using Exoticamp.UI.Models.Reviews;
using Exoticamp.UI.Services.IRepositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using System.Linq; // Ensure System.Linq is imported for LINQ queries


namespace Exoticamp.UI.Controllers
{
    public class ReviewsController(IReviewsRepository _reviewsRepository, IReviewReplyRepository _replyRepository, ICampsiteDetailsRepository _campsiteDetailsRepository) : Controller
    {
        private readonly IReviewsRepository _reviewsRepository;
        private readonly IReviewReplyRepository _replyRepository;
        private readonly ICampsiteDetailsRepository _campsiteDetailsRepository;
        private readonly IEventCartRepository _eventCartRepository;

        public ReviewsController(IReviewsRepository reviewsRepository, IReviewReplyRepository replyRepository, ICampsiteDetailsRepository campsiteDetailsRepository, IEventCartRepository eventCartRepository)
        {
            _reviewsRepository = reviewsRepository;
            _replyRepository = replyRepository;
            _campsiteDetailsRepository = campsiteDetailsRepository;
            _eventCartRepository = eventCartRepository;
        }
        [HttpGet]
        [UserAuthFilter]
        [NoCache]
        public IActionResult AddReview()
        {
            // Fetch all event carts
            //var eventCarts = _eventCartRepository.GetAllEventCart();

            //// Extract distinct BookingId values
            //var bookingIds = eventCarts.Select(ec => ec.BookingId)
            //                           .Where(id => !string.IsNullOrEmpty(id)) // Filter out null or empty BookingId values if needed
            //                           .Distinct()
            //                           .ToList();

            //ViewBag.BookingIds = bookingIds;

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


            return RedirectToAction("Index","Home");

        }
        [VendorAuthFilter]
        [NoCache]
        public async Task<IActionResult> ShowReviews()
        {
            var userId = HttpContext.Session.GetString("VendorId");
           
            var allReviews = await _reviewsRepository.GetAllReviews();
            var campsite = await _campsiteDetailsRepository.GetAllCampsites();
           var sorted=allReviews.Where(c=>c.CreatedBy== userId);
            // var campsite = allReviews.Where(x  => x. == userId).ToList();
            // Filter the campsiteDetail to include only those with isActive set to true
            var activeReviews = sorted.Where(c => c.Status == true ).ToList();

            return View(activeReviews);
        }


        public async Task<IActionResult> ShowReviewsUser()
        {
            var campsiteDetail = await _reviewsRepository.GetAllReviews();

            // Filter the campsiteDetail to include only those with isActive set to true
            var activeCampsites = campsiteDetail.Where(c => c.Status == true).ToList();

            return View("ShowReviewsUser",activeCampsites);
        }

        [AdminAuthFilter]
        [NoCache]
        public async Task<IActionResult> ShowReviewsAdmin()
        {
            var campsiteDetail = await _reviewsRepository.GetAllReviews();

            // Filter the campsiteDetail to include only those with isActive set to true
            var activeCampsites = campsiteDetail.ToList();

            return View(activeCampsites);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateReviewStatusById(string id)
        {
            var review =await _reviewsRepository.GetReviewById(id);
            if (review == null)
            {
                return NotFound(); // Handle case where review with given id is not found
            }

            // Update review status based on the 'approve' parameter
            if (review.Data.Status)
            {
                review.Data.Status = false;
            }
            else
            {
                review.Data.Status = true;
            }
            _reviewsRepository.EditReview(review.Data);

            return RedirectToAction(nameof(ShowReviewsAdmin)); // Redirect back to the list of reviews or any desired action
        }


        public async Task<IActionResult> ShowAllReviewsWithReplies()
        {
            var reviews = await _reviewsRepository.GetAllReviews(); // Assuming this method retrieves all reviews
            var approvedReview = reviews.Where(x => x.Status == true);
            var reviewReplies = await _replyRepository.GetAllReply(); // Assuming this method retrieves all replies

            var viewModelList = new List<ReviewDetailsViewModel>();

            foreach (var review in approvedReview)
            {
                var reply = reviewReplies.FirstOrDefault(r => r.ReviewId == review.Id); // Assuming ReviewId links to review

                var viewModel = new ReviewDetailsViewModel
                {
                    Review = review,
                    ReviewReply = reply
                };

                viewModelList.Add(viewModel);
            }

            return View(viewModelList);
        }
    }
}
