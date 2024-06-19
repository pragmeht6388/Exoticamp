using Exoticamp.Application.Contracts.Persistence;
using Exoticamp.Application.Features.CampsiteDetails.Commands.AddCampsiteDetails;
using Exoticamp.Application.Features.CampsiteDetails.Query.GetCampsiteDetailsList;
using Exoticamp.Application.Features.Reviews.Commands.AddReviews;
using Exoticamp.Application.Features.Reviews.Queryies.GetReviewList;
using Exoticamp.Identity.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Exoticamp.Api.Controllers.v1
{
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class ReviewsController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger _logger;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IReviewRepository _reviewRepository;
        // private readonly 

        public ReviewsController(IMediator mediator, ILogger<ReviewsController> logger, UserManager<ApplicationUser> userManager, IReviewRepository reviewRepository)

        {
            _mediator = mediator;
            _logger = logger;
            _userManager = userManager;
            _reviewRepository = reviewRepository;
        }


        [HttpPost(Name = "AddReview")]
        public async Task<ActionResult> Create([FromBody] AddReviewCommand addReviewCommand)
        {
            var response = await _mediator.Send(addReviewCommand);
            return Ok(response);
        }


        [HttpGet("allReview", Name = "GetAllReview")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> GetAllReview()
        {
            _logger.LogInformation("GetAllCampsite Initiated");
            var dtos = await _mediator.Send(new GetReviewListQuery());
            _logger.LogInformation("GetAllCampsite Completed");
            return Ok(dtos);
        }
    }
}
