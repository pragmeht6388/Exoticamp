using Exoticamp.Application.Features.Activities.Commands.AddActivities;
using Exoticamp.Application.Features.RewiewReply.Command.AddReviewReply;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Exoticamp.Api.Controllers.v1
{
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class ReviewReplyController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger _logger;

        public ReviewReplyController(IMediator mediator, ILogger<ReviewReplyController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpPost(Name = "AddReviewReply")]
        public async Task<ActionResult> Create([FromBody] AddReviewReplyCommand addActivityCommand)
        {
            var response = await _mediator.Send(addActivityCommand);
            return Ok(response);
        }
    }
}
