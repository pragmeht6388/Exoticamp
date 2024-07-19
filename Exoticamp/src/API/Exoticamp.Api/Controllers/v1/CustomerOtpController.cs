using Exoticamp.Application.Features.Activities.Commands.AddActivities;
using Exoticamp.Application.Features.CampsiteDetails.Query.GetCampsiteDetails;
using Exoticamp.Application.Features.CustomerOtp.Commands.AddCustomerOtp;
using Exoticamp.Application.Features.CustomerOtp.Query.GetByCustomerId;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Exoticamp.Api.Controllers.v1
{
	[ApiVersion("1")]
	[Route("api/v{version:apiVersion}/[controller]")]
	[ApiController]
	public class CustomerOtpController(IMediator _mediator, ILogger<CustomerOtpController> _logger) : ControllerBase
	{
		[HttpPost(Name = "AddCustomerDto")]
		public async Task<ActionResult> Create([FromBody] AddCustomerOtpCommand addCustomerOtpCommand)
		{
			var response = await _mediator.Send(addCustomerOtpCommand);
			return Ok(response);
		}

		[HttpGet("{id}", Name = "GetCustomerOtpById")]
		public async Task<ActionResult> GetCustomerOtpById(int id)
		{
			var getCustomerOtpQuery = new GetCustomerOtpQuery() { OtpId = id };
			return Ok(await _mediator.Send(getCustomerOtpQuery));
		}
	}
}
