using Exoticamp.Application.Features.Activities.Commands.AddActivities;
using Exoticamp.Application.Features.CustomerConsents.Command.AddCustomerConsent;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Exoticamp.Api.Controllers.v1
{

    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class CustomerConsentController(IMediator _mediator, ILogger<ActivitiesController> _logger) : ControllerBase
    {
        [HttpPost(Name = "AddCustomerConsent")]
        public async Task<ActionResult> Create([FromBody] CustomerConsentCommand customerConsentCommand)
        {
            var response = await _mediator.Send(customerConsentCommand);
            return Ok(response);
        }


    }
}
