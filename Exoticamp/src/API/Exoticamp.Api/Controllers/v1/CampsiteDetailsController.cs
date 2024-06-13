using Exoticamp.Application.Features.Campsite.Commands.AddCampsite;
using Exoticamp.Application.Features.Campsite.Commands.DeleteCampsite;
using Exoticamp.Application.Features.Campsite.Commands.UpdateCampsite;
using Exoticamp.Application.Features.Campsite.Query.GetCampsite;
using Exoticamp.Application.Features.Campsite.Query.GetCampsiteList;
using Exoticamp.Application.Features.CampsiteDetails.Commands.AddCampsiteDetails;
using Exoticamp.Application.Features.CampsiteDetails.Commands.DeleteCampsiteDetails;
using Exoticamp.Application.Features.CampsiteDetails.Commands.UpdateCampsite;
using Exoticamp.Application.Features.CampsiteDetails.Query.GetCampsiteDetails;
using Exoticamp.Application.Features.CampsiteDetails.Query.GetCampsiteDetailsList;
using Exoticamp.Identity.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Exoticamp.Api.Controllers.v1
{
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController] 
    public class CampsiteDetailsController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger _logger;
        private readonly UserManager<ApplicationUser> _userManager;
       // private readonly 

        public CampsiteDetailsController(IMediator mediator, ILogger<CampsiteDetailsController> logger, UserManager<ApplicationUser> userManager)

        {
            _mediator = mediator;
            _logger = logger;
            _userManager = userManager;
        }

        [HttpPost(Name = "AddCampsiteDetails")]
        public async Task<ActionResult> Create([FromBody] AddCampsiteDetailsCommand addCampsiteCommand)
        {
            var response = await _mediator.Send(addCampsiteCommand);
            return Ok(response);
        }


        [HttpPut("UpdateCampsiteById")]
        public async Task<IActionResult> UpdateById([FromBody] UpdateCampsiteDetailsCommand updateCampsiteCommand)
        {

            var response = await _mediator.Send(updateCampsiteCommand);
            return Ok(response);

        }

        [HttpDelete("{id}", Name = "DeleteCampsiteDetails")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Delete(string id)
        {
            var deleteCampsiteCommand = new DeleteCampsiteDetailsCommand() { Id = id };
            await _mediator.Send(deleteCampsiteCommand);
            return NoContent();
        }

        [HttpGet("all", Name = "GetAllCampsiteDetails")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> GetAllCampsite()
        {
            _logger.LogInformation("GetAllCampsite Initiated");
            var dtos = await _mediator.Send(new GetCampsiteDetailsListQuery());
            _logger.LogInformation("GetAllCampsite Completed");
            return Ok(dtos);
        }

        [HttpGet("{id}", Name = "GetCampsiteDetailsById")]
        public async Task<ActionResult> GetCampsiteById(string id)
        {
            var getCampsiteDetailQuery = new GetCampsiteDetailsIdIdQuery() { Id = id };
            return Ok(await _mediator.Send(getCampsiteDetailQuery));
        }

        //[HttpGet("{name}", Name = "GetCampsiteDetailsByName")]
        //public async Task<ActionResult> GetCampsiteByName(string name)
        //{
        //    var getCampsiteDetailQuery = new GetCampsiteDetailsNamedQuery() { Name = name };
        //    return Ok(await _mediator.Send(getCampsiteDetailQuery));
        //}



        //[HttpGet("all", Name = "GetAllCampsiteDetails1")]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //public async Task<ActionResult> GetAllCampsite1()
        //{
        //    _logger.LogInformation("GetAllCampsite Initiated");

        //    // Fetch campsite details along with user information
        //    var dtos = await _mediator.Send(new GetCampsiteDetailsListQuery());

        //    // Join the User and Location tables based on LocationId
        //    var joinedData = from campsite in dtos
        //                     join user in _userManager.Users on campsite.UserId equals user.Id
        //                     join location in _dbContext.Locations on user.LocationId equals location.Id
        //                     select new
        //                     {
        //                         Campsite = campsite,
        //                         LocationName = location.Name
        //                     };

        //    // Filter campsites based on the location name
        //    var filteredCampsites = joinedData.Where(j => j.LocationName == j.Campsite.LocationName)
        //                                      .Select(j => j.Campsite)
        //                                      .ToList();

        //    _logger.LogInformation("GetAllCampsite Completed");
        //    return Ok(filteredCampsites);
        //}



    }
}
