using Exoticamp.Application.Features.Categories.Queries.GetCategoriesList;
using Exoticamp.Application.Features.Chatbot.Queries.GetChatbotResponses;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Exoticamp.Api.Controllers.v1
{
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class ChatbotController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ChatbotController(IMediator mediator)
        {
            _mediator = mediator;
        }

        //[Authorize]
        [HttpGet("all")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> GetAllChatbotResponses()
        {
            var dtos = await _mediator.Send(new GetChatbotResponsesQuery());
            return Ok(dtos);
        }
    }
}
