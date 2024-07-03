using Exoticamp.Application.Features.UserQueries.Commands.RespondToUserQuery;
using Exoticamp.Application.Features.Users.Commands.UpdateUser;
using Exoticamp.Application.Features.Users.Queries.GetUser;
using Exoticamp.Application.Features.Users.Queries.GetUserList;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Exoticamp.Api.Controllers.v1
{
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class UserController(IMediator _mediator, ILogger<CategoryController> _logger) : ControllerBase
    {

        [HttpGet("{id}")]
        public async Task<ActionResult> GetUser(string id)
        {
            var dtos = await _mediator.Send(new GetUserQuery() { UserId = id});
            return Ok(dtos);
        }

        [HttpPut("edit-profile")]
       
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Update([FromBody] UpdateUserProfileCommand model)
        {
            var response = await _mediator.Send(model);
            return Ok(response);
        }
    }
}
