using Exoticamp.Application.Features.Campsite.Commands.AddCampsite;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Exoticamp.Api.Controllers.v1
{
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class ActivitiesController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger _logger;

        public ActivitiesController(IMediator mediator, ILogger<ActivitiesController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpPost(Name = "AddActivities")]
        public async Task<ActionResult> Create([FromBody] AddCampsiteCommand addCampsiteCommand)
        {
            var response = await _mediator.Send(addCampsiteCommand);
            return Ok(response);
        }
    }
}
