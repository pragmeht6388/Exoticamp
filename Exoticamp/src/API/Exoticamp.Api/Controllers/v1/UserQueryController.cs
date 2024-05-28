using Exoticamp.Application.Features.Categories.Queries.GetCategoriesList;
using Exoticamp.Application.Features.Chatbot.Queries.GetChatbotResponses;
using Exoticamp.Application.Features.Events.Commands.CreateEvent;
using Exoticamp.Application.Features.Events.Commands.UpdateEvent;
using Exoticamp.Application.Features.UserQueries.Commands.CreateUserQuery;
using Exoticamp.Application.Features.UserQueries.Commands.RespondToUserQuery;
using Exoticamp.Application.Features.UserQueries.Queries.GetUserQueryList;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Exoticamp.Api.Controllers.v1
{
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class UserQueryController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserQueryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("all")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> GetAllUserQueris()
        {
            var dtos = await _mediator.Send(new GetUserQueryListQuery());
            return Ok(dtos);
        }

        [HttpPost("add")]
        public async Task<ActionResult> Create([FromBody] CreateUserQueryCommand createUserQuery)
        {
            var id = await _mediator.Send(createUserQuery);
            return Ok(id);
        }

        [HttpPut("Respond")]
        //[ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Update([FromBody] RespondToUserQueryCommand respondToUser)
        {
            var response = await _mediator.Send(respondToUser);
            return Ok(response);
        }
    }
}
