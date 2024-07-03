using MediatR;
using Microsoft.AspNetCore.Mvc;
//using Exoticamp.Application.Features.Banners.Commands.AddBanner;
//using Exoticamp.Application.Features.Banners.Commands.UpdateBanner;
//using Exoticamp.Application.Features.Banners.Queries.GetBanner;
using Exoticamp.Application.Features.Banners.Queries.GetBannerList;
using Exoticamp.Application.Features.Banners.Commands.CreateBanner;
using Exoticamp.Application.Features.Banners.Commands.UpdateBanner;
using Exoticamp.Application.Features.Banners.Commands.DeleteBanner;
using Exoticamp.Application.Features.Banners.Queries.GetBanner;
using Exoticamp.Application.Responses;

namespace Exoticamp.Api.Controllers.v1
{
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class BannerController(IMediator _mediator, ILogger<BannerController> _logger) : ControllerBase
    {
        

        [HttpPost(Name = "AddBanner")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Create([FromBody] CreateBannerCommand createBannerCommand)
        {
     
        
   
                var response = await _mediator.Send(createBannerCommand);

                return Ok(response);

               
         


        }


        [HttpGet("{id}", Name = "GetBannerById")]
        public async Task<ActionResult> GetBannerById(string id)
        {
            var getBannerDetailQuery = new GetBannerDetailQuery { BannerId = id };
            return Ok(await _mediator.Send(getBannerDetailQuery));
        }

        [HttpGet("all", Name = "GetAllBanners")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> GetAllBanners()
        {
            _logger.LogInformation("GetAllBanners Initiated");
            var dtos = await _mediator.Send(new GetBannerListQuery());
            _logger.LogInformation("GetAllBanners Completed");
            return Ok(dtos);
        }



        [HttpPut("UpdateBanner", Name = "UpdateBanner")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)] 
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Update([FromBody] UpdateBannerCommand updateBannerCommand)
        {
       
            var response = await _mediator.Send(updateBannerCommand);

    
            if (response == null)
            {
                return NotFound(); 
            }

            return Ok(response);
        }



        [HttpDelete("{id}", Name = "DeleteBanner")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Delete(string id)
        {
            var deleteBannerCommand = new DeleteBannerCommand() { Id = id };
            await _mediator.Send(deleteBannerCommand);
            return NoContent();
        }
    }
}
