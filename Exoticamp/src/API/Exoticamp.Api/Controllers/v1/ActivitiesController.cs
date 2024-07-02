using Exoticamp.Application.Features.Activities.Commands.AddActivities;
using Exoticamp.Application.Features.Activities.Commands.DeleteActivities;
using Exoticamp.Application.Features.Activities.Commands.UpdateActivities;
using Exoticamp.Application.Features.Activities.Query.GetActivityList;
using Exoticamp.Application.Features.Campsite.Commands.AddCampsite;
using Exoticamp.Application.Features.Campsite.Commands.UpdateCampsite;
using Exoticamp.Application.Features.Campsite.Query.GetCampsiteList;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Exoticamp.Api.Controllers.v1
{
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class ActivitiesController(IMediator _mediator, ILogger<ActivitiesController> _logger) : ControllerBase
    {
        

        [HttpPost(Name = "AddActivities")]
        public async Task<ActionResult> Create([FromBody] AddActivitiesCommands addActivityCommand)
        {
            var response = await _mediator.Send(addActivityCommand);
            return Ok(response);
        }

        [HttpGet("all", Name = "GetAllActivities")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> GetAllActivity()
        {
            _logger.LogInformation("GetAllActivity Initiated");
            var dtos = await _mediator.Send(new GetActivityListQuery());
            _logger.LogInformation("GetAllActivity Completed");
            return Ok(dtos);
        }

        [HttpPut("UpdateActivitiesById")]
        public async Task<IActionResult> UpdateById([FromBody] UpdateActivitiesCommand updateActivitiesCommand)
        {

            var response = await _mediator.Send(updateActivitiesCommand);
            return Ok(response);

        }

        [HttpDelete("{id}", Name = "DeleteActivities")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Delete(string id)
        {
            var deleteActivitiesCommand = new DeleteActivitiesCommand() { Id = id };
            await _mediator.Send(deleteActivitiesCommand);
            return NoContent();
        }
    }
}
