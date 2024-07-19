using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Exoticamp.Application.Responses;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Exoticamp.Application.Features.Customer.Commands.CreateCustomer;

namespace Exoticamp.Api.Controllers.v1
{
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<CustomerController> _logger;

        public CustomerController(IMediator mediator, ILogger<CustomerController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpPost(Name = "AddCustomer")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Create( CreateCustomerCommand createCustomerCommand)
        {
            try
            {
                var response = await _mediator.Send(createCustomerCommand);
                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError($"An error occurred while creating the customer: {ex.Message}");
                return BadRequest("An error occurred while processing your request.");
            }
        }

        
        }


    }

