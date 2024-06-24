using Exoticamp.Application.Features.Locations.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Exoticamp.Api.Controllers.v1
{
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class TentAvailabilityController : ControllerBase
    {

        private readonly IMediator _mediator;

        public TentAvailabilityController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpGet("GetAll")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> GetTentAvailabilityByVendorAsync()
        {
            //var dtos = await _mediator.Send(new GetAllTentsListQuery());
            return Ok();//dtos
        }
    }
}
