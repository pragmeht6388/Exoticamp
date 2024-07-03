using Exoticamp.Application.Features.Search.Query.GetSearchResults;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Exoticamp.Api.Controllers.v1
{
    [ApiController]
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/[controller]")]

    public class SearchController(IMediator _mediator) : ControllerBase
    {
       

        [HttpGet(Name = "Search")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> Search(string text)
        {
            var search = new GetSearchResultQuery() { Text = text };
            return Ok(await _mediator.Send(search));
        }
    }
}

