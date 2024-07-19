using Exoticamp.Application.Features.Activities.Commands.AddActivities;
using Exoticamp.Application.Features.CampsiteDetails.Query.GetCampsiteDetails;
using Exoticamp.Application.Features.CustomerMPINs.Commands.AddCustomerMPIN;
using Exoticamp.Application.Features.CustomerMPINs.GetById;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Exoticamp.Api.Controllers.v1
{
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class CustomerMPINController(IMediator _mediator, ILogger<ActivitiesController> _logger) : ControllerBase
    {
        [HttpPost(Name = "AddCustomerMPIN")]
        public async Task<ActionResult> Create([FromBody] CustomerMPINCommand customerMPINCommand)
        {
            var response = await _mediator.Send(customerMPINCommand);
            return Ok(response);
        }
        [HttpGet("{id}", Name = "GetCustomerMPINsById")]
        public async Task<ActionResult> GetCustomerMPINById(int id)
        {
            var getCampsiteDetailQuery = new GetCustomerMpinQuery() { CustomerId = id };
            return Ok(await _mediator.Send(getCampsiteDetailQuery));
        }
    }
}
