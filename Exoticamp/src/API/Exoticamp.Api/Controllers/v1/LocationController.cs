using Exoticamp.Application.Features.Activities.Commands.AddActivities;
using Exoticamp.Application.Features.Activities.Query.GetActivityList;
using Exoticamp.Application.Features.Locations.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Exoticamp.Api.Controllers.v1
{
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class LocationController(IMediator _mediator) : ControllerBase
    {
        
        [HttpGet("all")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> GetAll()
        {
            var dtos = await _mediator.Send(new GetLocationListQuery());
            return Ok(dtos);
        }

    }
}
