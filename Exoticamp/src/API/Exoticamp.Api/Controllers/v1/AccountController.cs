using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Exoticamp.Application.Models.Authentication;
using Exoticamp.Application.Contracts.Identity;
using Exoticamp.Identity.Configurations;

namespace Exoticamp.Api.Controllers.v1
{
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
   
    public class AccountController : ControllerBase
    {
    
        private readonly IAuthenticationService _authenticationService;
        private readonly RoleConfiguration  _roleConfiguration;
        public AccountController(IAuthenticationService authenticationService, RoleConfiguration roleConfiguration)
        {
            _authenticationService = authenticationService;
            _roleConfiguration = roleConfiguration;
        }

        [HttpPost("authenticate")]
        public async Task<ActionResult<AuthenticationResponse>> AuthenticateAsync(AuthenticationRequest request)
        {
            return Ok(await _authenticationService.AuthenticateAsync(request));
        }

        [HttpPost("register")]
        public async Task<ActionResult<RegistrationResponse>> RegisterAsync(RegistrationRequest request)
        {
            return Ok(await _authenticationService.RegisterAsync(request));
        }

        [HttpPost("refresh-token")]
        public async Task<IActionResult> RefreshTokenAsync(RefreshTokenRequest request)
        {
            return Ok(await _authenticationService.RefreshTokenAsync(request));
        }

        [HttpPost("revoke-token")]
        public async Task<IActionResult> RevokeTokenAsync(RevokeTokenRequest request)
        {
            var response = await _authenticationService.RevokeToken(request);
            if (response.Message == "Token is required")
                return BadRequest(response);
            else if (response.Message == "Token did not match any users")
                return NotFound(response);
            else
                return Ok(response);
        }

        //AddRole
        [HttpPost("AddRole")]
        public async Task<IActionResult> AddRole([FromBody] CreateRoleRequest createRole)
        {
            var result = await  _roleConfiguration.AddRoleAsync(createRole);

            if (result.Succeeded)
            {
                return Ok(new { Message = $"Role {createRole.RoleName} added successfully." });
            }

            return BadRequest(new { Errors = result.Errors });
        }
    }
}
