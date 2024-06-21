using AutoMapper;
using Exoticamp.Application.Contracts.Persistence;
using Exoticamp.Application.Contracts;
using Exoticamp.Application.Features.CampsiteDetails.Query.GetCampsiteDetailsList;
using Exoticamp.Application.Responses;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exoticamp.Application.Features.Campsite.Query.GetCampsiteList;
using Exoticamp.Domain.Entities;

namespace Exoticamp.Application.Features.Reviews.Queryies.GetReviewList
{
    public class GetReviewListQueryHandler : IRequestHandler<GetReviewListQuery, Response<IEnumerable<ReviewVM>>>
    {
        private readonly IReviewRepository _reviewRepository;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        private readonly ILoggedInUserService _loggedInUserService;
        private readonly ICampsiteDetailsRepository _campsiteDetailsRepository;
        private readonly IAsyncRepository<Domain.Entities.Booking> _booking;


        public GetReviewListQueryHandler(IMapper mapper, IReviewRepository reviewRepository, ILogger<GetCampsiteDetailsListQueryHandler> logger, ILoggedInUserService loggedInUserService, ICampsiteDetailsRepository campsiteDetailsRepository, IAsyncRepository<Booking> booking)
        {
            _mapper = mapper;
            _reviewRepository = reviewRepository;
            _logger = logger;
            _loggedInUserService = loggedInUserService;
            _campsiteDetailsRepository = campsiteDetailsRepository;
            _booking = booking;
        }

        //public async Task<Response<IEnumerable<ReviewVM>>> Handle(GetReviewListQuery request, CancellationToken cancellationToken)
        //{
        //    _logger.LogInformation("Handle Initiated");

        //    var allReviews = await _reviewRepository.ListAllAsync();

        //    var bookingId = request.BookingId; 
        //    var campsite = await _campsiteDetailsRepository.ListAllAsync();


        //    var activeReviews = allReviews;

        //    var orderedReview = activeReviews.OrderBy(x => x.Name);

        //    var reviewVMs = _mapper.Map<IEnumerable<ReviewVM>>(orderedReview);

        //    _logger.LogInformation("Hanlde Completed");

        //    return new Response<IEnumerable<ReviewVM>>(reviewVMs, "success");
        //}
        public async Task<Response<IEnumerable<ReviewVM>>> Handle(GetReviewListQuery request, CancellationToken cancellationToken)
         {
            _logger.LogInformation("Handle Initiated");

            var allReviews = await _reviewRepository.ListAllAsync();

            // Fetch all bookings and campsite details
            var bookings = await _booking.ListAllAsync();
            var campsiteDetails = await _campsiteDetailsRepository.ListAllAsync();

            var reviewVMs = new List<ReviewVM>();

            foreach (var review in allReviews)
            {
                var reviewVM = _mapper.Map<ReviewVM>(review);

                // Find the booking associated with the review
                var booking = bookings.FirstOrDefault(b => b.BookingId == review.BookingId);

                if (booking != null)
                {
                    // Find the campsite details using the campsite ID from the booking
                    var campsiteDetail = campsiteDetails.FirstOrDefault(c => c.Id == booking.CampsiteId);

                    if (campsiteDetail != null)
                    {
                        reviewVM.CampsiteName = campsiteDetail.Name;
                        reviewVM.CampsiteImage = campsiteDetail.Images;
                    }
                    else
                    {
                        reviewVM.CampsiteName = "Unknown";
                    }
                }
                else
                {
                    reviewVM.CampsiteName = "Unknown";
                }

                reviewVMs.Add(reviewVM);
            }

            _logger.LogInformation("Handle Completed");

            return new Response<IEnumerable<ReviewVM>>(reviewVMs, "success");
        }

        //public async Task<Response<IEnumerable<ReviewVM>>> Handle(GetReviewListQuery request, CancellationToken cancellationToken)
        //{
        //    _logger.LogInformation("Handle Initiated");

        //    // Fetch all reviews
        //    var allReviews = await _reviewRepository.ListAllAsync();

        //    // Fetch campsite details using reviews
        //    var campsiteIds = allReviews
        //           .Where(r => r.Booking != null && r.Booking.CampsiteId != Guid.Empty) // Ensure Booking and CampsiteId are not null or empty
        //           .Select(r => r.Booking.CampsiteId)
        //           .Distinct()
        //           .ToList();
        //    var campsiteDetails = await _campsiteDetailsRepository.GetAllCampsiteWithCategoryAndActivityDetails();

        //    // Map reviews to view models
        //    var reviewVMs = allReviews
        //        .Where(r => r.Status)
        //        .OrderBy(r => r.DateTime)
        //        .Select(r => new ReviewVM
        //        {
        //            Id = r.Id,
        //            Name = r.Name,
        //            DateTime = r.DateTime,
        //            Ratings = r.Ratings,
        //            Description = r.Description,
        //            CampsiteName = GetCampsiteNameForReview(r, campsiteDetails) 
        //        });

        //    _logger.LogInformation("Handle Completed");

        //    return new Response<IEnumerable<ReviewVM>>(reviewVMs, "success");
        //}

        //private string GetCampsiteNameForReview(Domain.Entities.Reviews review, IEnumerable<CampsiteDetailsVM> campsiteDetails)
        //{
        //    if (review == null || review.Booking == null || campsiteDetails == null)
        //    {
        //        return "Unknown"; // Handle null review, booking, or campsiteDetails gracefully
        //    }

        //    var campsiteDetail = campsiteDetails.FirstOrDefault(c => c.Id == review.Booking.CampsiteId);
        //    return campsiteDetail?.Name ?? "Unknown";
        //}


    }
}
