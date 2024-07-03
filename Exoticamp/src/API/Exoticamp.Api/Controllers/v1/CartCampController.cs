using Exoticamp.Application.Features.CartCampsite.Commands.AddCartCampsite;
using Exoticamp.Application.Features.CartCampsite.Commands.DeleteCartCamp;
using Exoticamp.Application.Features.CartCampsite.Queries.GetCartById;
using Exoticamp.Application.Features.CartCampsite.Query.GetCartCampList;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Exoticamp.Api.Controllers.v1
{
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class CartCampController(IMediator _mediator, ILogger<CartCampController> _logger) : ControllerBase
    {


        [HttpPost("add")]
        public async Task<IActionResult> AddCartCamp( AddCartCampsite command)
        {
            if (command == null)
            {
                return BadRequest("Invalid cart camp data.");
            }

            var response = await _mediator.Send(command);

            if (response == null )
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error adding cart camp.");
            }

            return Ok(response);
        }
        [HttpGet("GetAllCart")]
        public async Task<IActionResult> GetAllCart()
        {
            _logger.LogInformation("GetAllCart Initiated");

            var query = new GetCartCampListQuery();
            var response = await _mediator.Send(query);

            _logger.LogInformation("GetAllCart Completed");

            return Ok(response);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCartById(Guid id)
        {
            var query = new GetCampCartIdQuery { Id = id.ToString() };
            var response = await _mediator.Send(query);

            if (response.Succeeded)
            {
                return Ok(response.Data);
            }

            return NotFound(response.Message);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCart(Guid id)
        {
            var command = new DeleteCartCampCommand { CartId = id };
            var response = await _mediator.Send(command);

            if (response.Succeeded)
            {
                return Ok(response);
            }

            return NotFound(response.Message);
        }
    }
}
