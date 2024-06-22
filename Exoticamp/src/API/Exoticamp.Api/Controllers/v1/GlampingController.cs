using Exoticamp.Application.Features.Banners.Queries.GetBanner;
using Exoticamp.Application.Features.Glamping.GetGlamping;
using Exoticamp.Application.Features.Glamping.GetGlampingList;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Exoticamp.Api.Controllers.v1
{
    [Route("api/[controller]")]
    [ApiController]
    public class GlampingController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<GlampingController> _logger;

        public GlampingController(IMediator mediator, ILogger<GlampingController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }


        [HttpGet("GetGlampingById")]
        public async Task<ActionResult> GetGlampingById(Guid id)
        {
            var getGlampingDetailQuery = new GetGlampingDetailQuery { GlampingId = id };
            var response = await _mediator.Send(getGlampingDetailQuery);

            if (response == null)
            {
                return NotFound();
            }

            return Ok(response);
        }
        [HttpGet("GetGlampingList")]
        public async Task<ActionResult> GetGlampingList()
        {
            var getGlampingListQuery = new GetGlampingListDetailQuery();
            var response = await _mediator.Send(getGlampingListQuery);

            if (response == null)
            {
                return NotFound();
            }

            return Ok(response);
        }
    }
}
