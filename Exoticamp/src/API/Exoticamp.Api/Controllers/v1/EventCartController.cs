using Exoticamp.Application.Contracts.Persistence;
using Exoticamp.Application.Contracts;
using Exoticamp.Identity.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Exoticamp.Application.Features.CampsiteDetails.Commands.AddCampsiteDetails;
using Exoticamp.Application.Features.EventBooking.Commands.AddBooking;
using Exoticamp.Application.Features.CampsiteDetails.Query.GetCampsiteDetailsList;
using Exoticamp.Application.Features.EventBooking.Query.EventBookingList;
using Exoticamp.Application.Features.Banners.Queries.GetBanner;
using Exoticamp.Application.Features.EventBooking.Query.EventCartById;
using Exoticamp.Application.Features.Events.Commands.DeleteEvent;
using Exoticamp.Application.Features.EventBooking.Commands.DeleteBookingCart;

namespace Exoticamp.Api.Controllers.v1
{
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class EventCartController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger _logger;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ILoactionRepository _loactionRepository;
        // private readonly 
        private readonly ILoggedInUserService _loggedInUserService;


        public EventCartController(IMediator mediator, ILogger<EventCartController> logger, UserManager<ApplicationUser> userManager, ILoactionRepository loactionRepository, ILoggedInUserService loggedInUserService)

        {
            _mediator = mediator;
            _logger = logger;
            _userManager = userManager;
            _loactionRepository = loactionRepository;
            _loggedInUserService = loggedInUserService;
        }

        [HttpPost(Name = "AddEventCart")]
        public async Task<ActionResult> Create([FromBody] CreateEventCartCommand createEventCartCommand)
        {
            var response = await _mediator.Send(createEventCartCommand);
            return Ok(response);
        }

        [HttpGet("all", Name = "GetAllEventCartDetails")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> GetAllEvents()
        {
            _logger.LogInformation("GetAllCampsite Initiated");
            var dtos = await _mediator.Send(new GetEventCartListQuery());
            _logger.LogInformation("GetAllCampsite Completed");
            return Ok(dtos);
        }

        [HttpGet("{id}", Name = "GetEventCartById")]
        public async Task<ActionResult> GetEventCartById(string id)
        {
            var getEventCartQuery = new GetEventCartIdQuery { CartId = id };
            return Ok(await _mediator.Send(getEventCartQuery));
        }

        [HttpDelete("{id}", Name = "DeleteEventCart")]
        public async Task<ActionResult> Delete(Guid id)
        {
            var command = new DeleteEventCartCommand { CartId = id };
            var result = await _mediator.Send(command);
            if (result.Data)
            {
                return Ok(result);
            }
            return NotFound(result);
        }
    }
}
