using Exoticamp.Application.Features.Activities.Commands.AddActivities;
using Exoticamp.Application.Features.Reviews.Queryies.GetReviewById;
using Exoticamp.Application.Features.Reviews.Queryies.GetReviewList;
using Exoticamp.Application.Features.RewiewReply.Command.AddReviewReply;
using Exoticamp.Application.Features.RewiewReply.Query.GetReplyById;
using Exoticamp.Application.Features.RewiewReply.Query.GetReplyList;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Exoticamp.Api.Controllers.v1
{
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class ReviewReplyController(IMediator _mediator, ILogger<ReviewReplyController> _logger) : ControllerBase
    {
        

        [HttpPost(Name = "AddReviewReply")]
        public async Task<ActionResult> Create([FromBody] AddReviewReplyCommand addActivityCommand)
        {
            var response = await _mediator.Send(addActivityCommand);
            return Ok(response);
        }

        [HttpGet("{id}", Name = "GetReplyById")]
        public async Task<ActionResult> GetReplyById(string id)
        {
            var getCampsiteDetailQuery = new GetReplyIdQuery() { Id = id };
            return Ok(await _mediator.Send(getCampsiteDetailQuery));
        }


        [HttpGet("allReply", Name = "GetAllReply")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> GetAllReply()
        {
            _logger.LogInformation("GetAllCampsite Initiated");
            var dtos = await _mediator.Send(new GetReplyListQuery());
            _logger.LogInformation("GetAllCampsite Completed");
            return Ok(dtos);
        }
    }
}
