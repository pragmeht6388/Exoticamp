using Exoticamp.Application.Features.Events.Queries.GetEventsList;
using Exoticamp.Application.Features.Users.Queries.GetUserList;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Exoticamp.Api.Controllers.v1
{
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger _logger;

        public AdminController(IMediator mediator, ILogger<CategoryController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }


        [HttpGet("GetAllUsers")]
         
        public async Task<ActionResult> GetAllUsers()
        {
            var dtos = await _mediator.Send(new  GetUserListQuery());
            return Ok(dtos);
        }
    }
}
