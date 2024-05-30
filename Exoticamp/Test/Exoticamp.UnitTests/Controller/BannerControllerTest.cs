using Xunit;
using Moq;
using Shouldly;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Exoticamp.Application.Features.Banners.Commands.CreateBanner;

using System.Threading;
using System.Threading.Tasks;
using Exoticamp.Api.Controllers.v1;
using Exoticamp.Application.Responses;
using Amazon.Runtime.Internal.Util;
using Microsoft.Extensions.Logging;

namespace Exoticamp.Tests
{
    public class BannerControllerTests
    {
        private readonly Mock<IMediator> _mediatorMock;
        private readonly Mock<ILogger<BannerController>> _loggerMock;
        private readonly BannerController _controller;

        public BannerControllerTests()
        {
            _mediatorMock = new Mock<IMediator>();
            _loggerMock = new Mock<ILogger<BannerController>>();
            _controller = new BannerController(_mediatorMock.Object, _loggerMock.Object);
        }

        [Fact]
        public async Task Create_ReturnsOkResult_WithCreatedBanner()
        {
            // Arrange
            var command = new CreateBannerCommand
            {
                Link = "https://example.com",
                IsActive = true,
                PromoCode = "",
                Locations = "Location1, Location2",
                ImagePath = "/images/banner.jpg"
            };

            var responseDto = new CreateBannerDto
            {
                BannerId = Guid.NewGuid(),
                Link = command.Link,
                IsActive = command.IsActive,
                PromoCode = command.PromoCode,
                Locations = command.Locations,
                ImagePath = command.ImagePath
            };

            var response = new Response<CreateBannerDto>
            {
                Data = responseDto,
                Message = "Success",
                Succeeded = true
            };

            _mediatorMock
                .Setup(m => m.Send(It.IsAny<CreateBannerCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(response);

            // Act
            var result = await _controller.Create(command);

            // Assert
            // Assert
            var okResult = result as OkObjectResult;
            Assert.NotNull(okResult);
            var returnedResponse = okResult.Value as Response<CreateBannerDto>;
            Assert.NotNull(returnedResponse);
            Assert.True(returnedResponse.Succeeded);
            Assert.Equal(responseDto.BannerId, returnedResponse.Data.BannerId);
            Assert.Equal(responseDto.Link, returnedResponse.Data.Link);
            Assert.Equal(responseDto.IsActive, returnedResponse.Data.IsActive);
            Assert.Equal(responseDto.PromoCode, returnedResponse.Data.PromoCode);
            Assert.Equal(responseDto.Locations, returnedResponse.Data.Locations);
            Assert.Equal(responseDto.ImagePath, returnedResponse.Data.ImagePath);
        }
    }
}