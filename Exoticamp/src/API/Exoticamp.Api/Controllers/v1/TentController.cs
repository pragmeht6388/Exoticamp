using Exoticamp.Application.Features.Activities.Commands.AddActivities;
using Exoticamp.Application.Features.Activities.Query.GetActivityList;
using Exoticamp.Application.Features.TentType.Query;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Exoticamp.Api.Controllers.v1
{
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class TentController(IMediator _mediator, ILogger<TentController> _logger) : ControllerBase
    {

       

        [HttpGet("allTent", Name = "GetAllTent")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> GetAllTent()
        {
            _logger.LogInformation("GetAllTent Initiated");
            var dtos = await _mediator.Send(new GetTentListQuery());
            _logger.LogInformation("GetAllTent Completed");
            return Ok(dtos);
        }
    }
}
