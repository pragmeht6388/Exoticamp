using Exoticamp.Application.Features.Campsite.Commands.AddCampsite;
using Exoticamp.Application.Features.Campsite.Commands.DeleteCampsite;
using Exoticamp.Application.Features.Campsite.Commands.UpdateCampsite;
using Exoticamp.Application.Features.Campsite.Query;
using Exoticamp.Application.Features.Campsite.Query.GetCampsite;
using Exoticamp.Application.Features.Campsite.Query.GetCampsiteList;
using Exoticamp.Application.Features.ContactUs.Command.AddContactUs;
using Exoticamp.Application.Features.Events.Commands.DeleteEvent;
using Exoticamp.Application.Features.Products.Commands.UpdateProduct;
using Exoticamp.Application.Features.Products.Queries.GetProduct;
using Exoticamp.Application.Features.Products.Queries.GetProductList;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Exoticamp.Api.Controllers.v1
{
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class CampsiteController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger _logger;

        public CampsiteController(IMediator mediator, ILogger<CampsiteController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpPost(Name = "AddCampsite")]
        public async Task<ActionResult> Create([FromBody] AddCampsiteCommand addCampsiteCommand)
        {
            var response = await _mediator.Send(addCampsiteCommand);
            return Ok(response);
        }

        
        [HttpPut("UpdateById")]
        public async Task<IActionResult> UpdateById( [FromBody] UpdateCampsiteCommand updateCampsiteCommand)
        {
           
             var response = await _mediator.Send(updateCampsiteCommand);
             return Ok(response);
            
        }

        [HttpDelete("{id}", Name = "DeleteCampsite")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Delete(string id)
        {
            var deleteCampsiteCommand = new DeleteCampsiteCommand() { Id = id };
            await _mediator.Send(deleteCampsiteCommand);
            return NoContent();
        }

        [HttpGet("all", Name = "GetAllCampsite")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> GetAllCampsite()
        {
            _logger.LogInformation("GetAllCampsite Initiated");
            var dtos = await _mediator.Send(new GetCampsiteListQuery());
            _logger.LogInformation("GetAllCampsite Completed");
            return Ok(dtos);
        }

        [HttpGet("{id}", Name = "GetCampsiteById")]
        public async Task<ActionResult> GetCampsiteById(string id)
        {
            var getCampsiteDetailQuery = new GetCampsiteDetailQuery() { Id = id };
            return Ok(await _mediator.Send(getCampsiteDetailQuery));
        }
    }
}
