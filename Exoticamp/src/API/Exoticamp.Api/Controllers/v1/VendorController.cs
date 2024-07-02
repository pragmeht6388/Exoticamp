
using Exoticamp.Application.Features.Vendors.Commands.UpdateVendor;
using Exoticamp.Application.Features.Vendors.Queries.GetVendor;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Exoticamp.Api.Controllers.v1
{
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class VendorController(IMediator _mediator, ILogger<VendorController> _logger) : ControllerBase
    {
        
        [HttpGet("{id}")]
        public async Task<ActionResult> GetVendor(string id)
        {
            var vendorDto = await _mediator.Send(new GetVendorQueryByIdQuery { VendorId = id });
            return Ok(vendorDto);
        }

        [HttpPut("edit-profile")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> UpdateVendorProfile([FromBody] UpdateVendorCommand model)
        {
            var response = await _mediator.Send(model);
            return Ok(response);
        }
    }
}
