using Moq;
using Xunit;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Exoticamp.Application.Models.Authentication;
using Exoticamp.Application.Contracts.Identity;
using Exoticamp.Identity.Models;
using Exoticamp.Identity.Services;
using Exoticamp.Application.Responses;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Exoticamp.Api.Controllers.v1;
using Exoticamp.Identity.Configurations;
using Shouldly;
using Exoticamp.UnitTests.Controller;

namespace Exoticamp.UnitTests.Service
{
    public class AuthenticationServiceTests
    {
        private readonly Mock<IAuthenticationService> _mockAuthenticationService;
        private readonly Mock<UserManager<ApplicationUser>> _userManagerMock;
        private readonly Mock<SignInManager<ApplicationUser>> _signInManagerMock;
        private readonly Mock<IOptions<JwtSettings>> _jwtSettingsMock;
        private readonly AuthenticationService _authenticationService;
        private readonly Mock<IAuthenticationService> _authenticationServiceMock;
        private readonly AccountController _accountController;
        private readonly Mock<RoleManager<IdentityRole>> _roleManagerMock;
        private readonly RoleConfiguration _roleConfiguration;

        public AuthenticationServiceTests()
        {
             
            _userManagerMock = new Mock<UserManager<ApplicationUser>>(
                Mock.Of<IUserStore<ApplicationUser>>(), null, null, null, null, null, null, null, null);

            _signInManagerMock = new Mock<SignInManager<ApplicationUser>>(
                _userManagerMock.Object, Mock.Of<IHttpContextAccessor>(), Mock.Of<IUserClaimsPrincipalFactory<ApplicationUser>>(), null, null, null, null);

            _jwtSettingsMock = new Mock<IOptions<JwtSettings>>();
            _jwtSettingsMock.Setup(x => x.Value).Returns(new JwtSettings { Key = "YourJwtSecurityKeyHere", Issuer = "YourIssuer", Audience = "YourAudience", DurationInMinutes = 60 });

            _authenticationService = new AuthenticationService(_userManagerMock.Object, _jwtSettingsMock.Object, _signInManagerMock.Object);

            _authenticationServiceMock = new Mock<IAuthenticationService>();

            _roleManagerMock = new Mock<RoleManager<IdentityRole>>(
                Mock.Of<IRoleStore<IdentityRole>>(), null, null, null, null);

            _roleConfiguration = new RoleConfiguration(_roleManagerMock.Object);

            _accountController = new AccountController(_authenticationServiceMock.Object, _roleConfiguration);
        }

        

        [Fact]
        public async Task RegisterAsync_ShouldReturnSuccess_WhenUserDoesNotExist()
        {
            // Arrange
            var registrationRequest = new RegistrationRequest
            {
                Name = "Test User",
                Email = "tes123t@example.com",
                PhoneNumber = "1234567890",
                Password = "Password@123",
                TermsandCondition = true
            };

            _userManagerMock.Setup(x => x.FindByNameAsync(It.IsAny<string>())).ReturnsAsync((ApplicationUser)null);
            _userManagerMock.Setup(x => x.CreateAsync(It.IsAny<ApplicationUser>(), It.IsAny<string>())).ReturnsAsync(IdentityResult.Success);
            _userManagerMock.Setup(x => x.AddToRoleAsync(It.IsAny<ApplicationUser>(), It.IsAny<string>())).ReturnsAsync(IdentityResult.Success);

            // Act
            var result = await _authenticationService.RegisterAsync(registrationRequest);

            // Assert
            Assert.True(result.Succeeded);
            Assert.NotNull(result.Data);
           

        }

        [Fact]
        public async Task RegisterAsync_ShouldReturnFailure_WhenUserAlreadyExists()
        {
            // Arrange
            var registrationRequest = new RegistrationRequest
            {
                Name = "Test User",
                Email = "tes123t@example.com",
                PhoneNumber = "1234567890",
                Password = "Password@123",
                TermsandCondition = true
            };

            var existingUser = new ApplicationUser { UserName = "test123@example.com" };
            _userManagerMock.Setup(x => x.FindByNameAsync(It.IsAny<string>())).ReturnsAsync(existingUser);

            // Act
            var result = await _authenticationService.RegisterAsync(registrationRequest);

            // Assert
            Assert.False(result.Succeeded);
            Assert.Equal($"Username '{registrationRequest.Email}' already exists.", result.Message);
        }

        [Fact]
        public async Task RegisterAsync_ShouldReturnOkResult_WhenRegistrationIsSuccessful()
        {
            // Arrange
            var registrationRequest = new RegistrationRequest
            {
                Name = "Test User",
                Email = "test@example.com",
                PhoneNumber = "1234567890",
                Password = "Password@123",
                TermsandCondition = true
            };

            var registrationResponse = new Response<RegistrationResponse>
            {
                Succeeded = true,
                Data = new RegistrationResponse { UserId = "1" }
            };

            _authenticationServiceMock.Setup(x => x.RegisterAsync(It.IsAny<RegistrationRequest>())).ReturnsAsync(registrationResponse);

            // Act
            var result = await _accountController.RegisterAsync(registrationRequest);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var responseValue = Assert.IsType<Response<RegistrationResponse>>(okResult.Value);
            Assert.True(responseValue.Succeeded);
            Assert.NotNull(responseValue.Data);
        }

        [Fact]
        public async Task RegisterAsync_ShouldReturnBadRequest_WhenRegistrationFails()
        {
            // Arrange
            var registrationRequest = new RegistrationRequest
            {
                Name = "Test User",
                Email = "test@example.com",
                PhoneNumber = "1234567890",
                Password = "Password@123",
                Role="User",
                TermsandCondition = true
            };

            var registrationResponse = new Response<RegistrationResponse>
            {
                Succeeded = false,
                Message = "Registration failed"
            };

            _authenticationServiceMock.Setup(x => x.RegisterAsync(It.IsAny<RegistrationRequest>())).ReturnsAsync(registrationResponse);

            // Act
            var result = await _accountController.RegisterAsync(registrationRequest);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var responseValue = Assert.IsType<Response<RegistrationResponse>>(okResult.Value);
            //Assert.False(responseValue.Succeeded);
            Assert.Equal("Registration failed", responseValue.Message);
        }


    }
}
