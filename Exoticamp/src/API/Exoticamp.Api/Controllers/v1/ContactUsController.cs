using Exoticamp.Application.Features.ContactUs.Command.AddContactUs;
using Exoticamp.Application.Features.ContactUs.Query.GetContactUs;
using Exoticamp.Application.Features.Products.Commands.AddProduct;
using Exoticamp.Application.Features.Products.Queries.GetProductList;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Exoticamp.Api.Controllers.v1
{
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class ContactUsController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger _logger;

        public ContactUsController(IMediator mediator, ILogger<ContactUsController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpPost(Name = "AddContactUs")]
        public async Task<ActionResult> Create([FromBody] AddContactUsCommand addContactUsCommand)
        {
            var response = await _mediator.Send(addContactUsCommand);
            return Ok(response);
        }

        [HttpGet("all", Name = "GetAllContactUs")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> GetAllContactUs()
        {
            _logger.LogInformation("GetAllContactUs Initiated");
            var dtos = await _mediator.Send(new GetContactUsListQuery());
            _logger.LogInformation("GetAllContactUs Completed");
            return Ok(dtos);
        }
    }
}
