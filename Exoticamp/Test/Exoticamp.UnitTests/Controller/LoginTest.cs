using System;
using System.Collections.Generic;
using System.Security.Authentication;
using System.Threading.Tasks;
using Exoticamp.Application.Models.Authentication;
using Exoticamp.Application.Responses;
using Exoticamp.Identity.Models;
using Exoticamp.Identity.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Moq;
using Xunit;

namespace Exoticamp.UnitTests.Controller
{
    public class LoginTest
    {
        private readonly Mock<UserManager<ApplicationUser>> _userManagerMock;
        private readonly Mock<SignInManager<ApplicationUser>> _signInManagerMock;
        private readonly Mock<IOptions<JwtSettings>> _jwtSettingsMock;
        private readonly JwtSettings _jwtSettings;
        private readonly AuthenticationService _authenticationService;

        public LoginTest()
        {
            _userManagerMock = new Mock<UserManager<ApplicationUser>>(
                Mock.Of<IUserStore<ApplicationUser>>(), null, null, null, null, null, null, null, null);

            _signInManagerMock = new Mock<SignInManager<ApplicationUser>>(
                _userManagerMock.Object,
                Mock.Of<IHttpContextAccessor>(),
                Mock.Of<IUserClaimsPrincipalFactory<ApplicationUser>>(),
                null, null, null, null);

            _jwtSettings = new JwtSettings
            {
                Key = "very_long_secret_key_for_testing",
                Issuer = "Issuer",
                Audience = "Audience",
                DurationInMinutes = 30
            };

            _jwtSettingsMock = new Mock<IOptions<JwtSettings>>();
            _jwtSettingsMock.Setup(x => x.Value).Returns(_jwtSettings);

            _authenticationService = new AuthenticationService(_userManagerMock.Object, _jwtSettingsMock.Object, _signInManagerMock.Object);
        }

        [Fact]
        public async Task AuthenticateAsync_UserNotFound_ReturnsNotAuthenticated()
        {
            // Arrange
            var request = new AuthenticationRequest { Email = "test@example.com", Password = "Password123" };
            _userManagerMock.Setup(x => x.FindByEmailAsync(It.IsAny<string>())).ReturnsAsync((ApplicationUser)null);

            // Act
            var result = await _authenticationService.AuthenticateAsync(request);

            // Assert
            Assert.False(result.IsAuthenticated);
            Assert.Equal("No Accounts Registered with test@example.com.", result.Message);
        }

        [Fact]
        public async Task AuthenticateAsync_InvalidPassword_ThrowsAuthenticationException()
        {
            // Arrange
            var request = new AuthenticationRequest { Email = "test@example.com", Password = "InvalidPassword" };
            var user = new ApplicationUser { UserName = "testuser", Email = "test@example.com" };
            _userManagerMock.Setup(x => x.FindByEmailAsync(It.IsAny<string>())).ReturnsAsync(user);
            _signInManagerMock.Setup(x => x.PasswordSignInAsync(It.IsAny<string>(), It.IsAny<string>(), false, false)).ReturnsAsync(SignInResult.Failed);

            // Act & Assert
            await Assert.ThrowsAsync<AuthenticationException>(() => _authenticationService.AuthenticateAsync(request));
        }

        
    }
}
