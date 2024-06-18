using Azure.Core;
using Exoticamp.Application.Contracts.Identity;
using Exoticamp.Application.Features.Banners.Commands.DeleteBanner;
using Exoticamp.Application.Features.Banners.Commands.UpdateBanner;
using Exoticamp.Application.Features.Events.Queries.GetEventsList;
using Exoticamp.Application.Features.Users.Commands.DeleteUser;
using Exoticamp.Application.Features.Users.Queries.GetUserList;
using Exoticamp.Application.Features.Vendors.Queries.GetVendorList;
using Exoticamp.Application.Models.Authentication;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Exoticamp.Api.Controllers.v1
{
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    //[Authorize(Roles = "Vendor")]
    public class AdminController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger _logger;
        private readonly IAuthenticationService _authenticationService;

        public AdminController(IMediator mediator, ILogger<CategoryController> logger, IAuthenticationService authenticationService)
        {
            _mediator = mediator;
            _logger = logger;
            _authenticationService = authenticationService;
        }


        [HttpGet("GetAllUsers")]
         
        public async Task<ActionResult> GetAllUsers()
        {
            var dtos = await _mediator.Send(new  GetUserListQuery());
            return Ok(dtos);
        }
        [HttpGet("GetAllVendors")]

        public async Task<ActionResult> GetAllVendors()
        {
            var dtos = await _mediator.Send(new GetVendorListQuery());
            return Ok(dtos);
        }
        [HttpPut("IsDeleteUsers", Name = "IsDeleteUsers")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> IsDeleteUsers(string id)
        {
            var response = await _authenticationService.MarkUserAsDeletedAsync(id);

            if (!response.Succeeded)
            {
                return NotFound(response.Message);
            }

            return Ok(response.Message);
        }
        //IsLocked
        [HttpPut("IsLockedUsers", Name = "IsLockedUsers")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> IsLockedUsers(string id)
        {
            var response = await _authenticationService.MarkUserUnlockedAsync(id);

            if (!response.Succeeded)
            {
                return NotFound(response.Message);
            }

            return Ok(response.Message);
        }
        [HttpPost("forget")]
        public async Task<ActionResult<ForgotPasswordResponse>> ForgotPassword(ForgotPasswordRequest request)
        {
            return Ok(await _authenticationService.ForgotPasswordAsync(request));
        }

    }
}
