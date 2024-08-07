﻿using Exoticamp.Application.Contracts.Persistence;
using Exoticamp.Application.Features.CampsiteDetails.Commands.AddCampsiteDetails;
using Exoticamp.Application.Features.CampsiteDetails.Commands.UpdateCampsite;
using Exoticamp.Application.Features.CampsiteDetails.Query.GetCampsiteDetails;
using Exoticamp.Application.Features.CampsiteDetails.Query.GetCampsiteDetailsList;
using Exoticamp.Application.Features.Reviews.Commands.AddReviews;
using Exoticamp.Application.Features.Reviews.Commands.UpdateReviews;
using Exoticamp.Application.Features.Reviews.Queryies.GetReviewById;
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
    public class ReviewsController(IMediator _mediator, ILogger<ReviewsController> _logger, UserManager<ApplicationUser> _userManager, IReviewRepository _reviewRepository) : ControllerBase
    {
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


        [HttpGet("{id}", Name = "GetReviewsById")]
        public async Task<ActionResult> GetReviewById(string id)
        {
            var getCampsiteDetailQuery = new GetReviewIdQuery() { Id = id };
            return Ok(await _mediator.Send(getCampsiteDetailQuery));
        }

        [HttpPut("UpdateReviewById")]
        public async Task<IActionResult> UpdateReviewsById([FromBody] UpdateReviewCommand updateReviewCommand)
        {

            var response = await _mediator.Send(updateReviewCommand);
            return Ok(response);

        }
    }
}
