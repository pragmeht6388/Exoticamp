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
using Microsoft.Extensions.Logging;
using Exoticamp.Application.Features.Banners.Commands.UpdateBanner;
using System;
using Exoticamp.Application.Features.Banners.Commands.DeleteBanner;

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
                IsDeleted = false,

                LocationId = Guid.NewGuid(),
                ImagePath = "/images/banner.jpg"
            };

            var responseDto = new CreateBannerDto
            {
                BannerId = Guid.NewGuid(),
                Link = command.Link,
                IsActive = command.IsActive,
                PromoCode = command.PromoCode,
                IsDeleted = false,
                LocationId = Guid.NewGuid(),
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
            var okResult = result as OkObjectResult;
            Assert.NotNull(okResult);
            var returnedResponse = okResult.Value as Response<CreateBannerDto>;
            Assert.NotNull(returnedResponse);
            Assert.True(returnedResponse.Succeeded);
            Assert.Equal(responseDto.BannerId, returnedResponse.Data.BannerId);
            Assert.Equal(responseDto.Link, returnedResponse.Data.Link);
            Assert.Equal(responseDto.IsActive, returnedResponse.Data.IsActive);
            Assert.Equal(responseDto.PromoCode, returnedResponse.Data.PromoCode);
            Assert.Equal(responseDto.LocationId, returnedResponse.Data.LocationId);
            Assert.Equal(responseDto.ImagePath, returnedResponse.Data.ImagePath);
        }

        [Fact]
        public async Task Create_ReturnsOkResult_WithMediatorResponse()
        {
            // Arrange
            var command = new CreateBannerCommand
            {
                Link = "https://example.com",
                IsActive = true,
                PromoCode = "",
                LocationId = Guid.NewGuid(),
                IsDeleted=false,
                ImagePath = "/images/banner.jpg"
            };

            var response = new Response<CreateBannerDto>
            {
                Data = null,
                Message = "Some message",
                Succeeded = false
            };

            _mediatorMock
                .Setup(m => m.Send(It.IsAny<CreateBannerCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(response);

            // Act
            var result = await _controller.Create(command);

            // Assert
            var okResult = result as OkObjectResult;
            Assert.NotNull(okResult);
            var returnedResponse = okResult.Value as Response<CreateBannerDto>;
            Assert.NotNull(returnedResponse);
            Assert.False(returnedResponse.Succeeded);
            Assert.Equal(response.Message, returnedResponse.Message);
        }

        [Fact]
        public async Task Update_ReturnsOkResult_WithUpdatedBanner()
        {
            // Arrange
            var command = new UpdateBannerCommand
            {
                BannerId = Guid.NewGuid(),
                Link = "http://example.com",
                IsActive = true,
                PromoCode = "PROMO123",
                LocationId = Guid.NewGuid(),
                IsDeleted = false,

                ImagePath = "path/to/image"
            };

            var responseDto = new UpdateBannerDto
            {
                BannerId = command.BannerId,
                Link = command.Link,
                IsActive = command.IsActive,
                PromoCode = command.PromoCode,
                LocationId = command.LocationId,
                ImagePath = command.ImagePath,
                IsDeleted = command.IsDeleted
            };

            var response = new Response<UpdateBannerDto>
            {
                Data = responseDto,
                Succeeded = true
            };

            _mediatorMock
                .Setup(m => m.Send(It.IsAny<UpdateBannerCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(response);

            // Act
            var result = await _controller.Update(command);

            // Assert
            var okResult = result as OkObjectResult;
            Assert.NotNull(okResult);
            var returnedResponse = okResult.Value as Response<UpdateBannerDto>;
            Assert.NotNull(returnedResponse);
            Assert.True(returnedResponse.Succeeded);
            Assert.Equal(responseDto.BannerId, returnedResponse.Data.BannerId);
            Assert.Equal(responseDto.Link, returnedResponse.Data.Link);
            Assert.Equal(responseDto.IsActive, returnedResponse.Data.IsActive);
            Assert.Equal(responseDto.PromoCode, returnedResponse.Data.PromoCode);
            Assert.Equal(responseDto.LocationId, returnedResponse.Data.LocationId);
            Assert.Equal(responseDto.ImagePath, returnedResponse.Data.ImagePath);
        }

        [Fact]
        public async Task Update_ReturnsNotFoundResult_WhenBannerIsNotFound()
        {
            // Arrange
            var command = new UpdateBannerCommand
            {
                BannerId = Guid.NewGuid(),
                Link = "http://example.com",
                IsActive = true,
                PromoCode = "PROMO123",
                LocationId = Guid.NewGuid(),
                ImagePath = "path/to/image",
                IsDeleted =false
            };

            _mediatorMock
                .Setup(m => m.Send(It.IsAny<UpdateBannerCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync((Response<UpdateBannerDto>)null);

            // Act
            var result = await _controller.Update(command);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }
        


        [Fact]
        public async Task Create_ReturnsOkResult_WhenMediatorResponseFails()
        {
            // Arrange
            var command = new CreateBannerCommand
            {
                Link = "https://example.com",
                IsActive = true,
                PromoCode = "",
                LocationId = Guid.NewGuid(),
                IsDeleted = true,

                ImagePath = "/images/banner.jpg"
            };

            var response = new Response<CreateBannerDto>
            {
                Data = null,
                Message = "Some error message",
                Succeeded = false
            };

            _mediatorMock
                .Setup(m => m.Send(It.IsAny<CreateBannerCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(response);

            // Act
            var result = await _controller.Create(command);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnedResponse = Assert.IsType<Response<CreateBannerDto>>(okResult.Value);
            Assert.False(returnedResponse.Succeeded);
            Assert.Equal(response.Message, returnedResponse.Message);
        }
        [Fact]
        public async Task Delete_ReturnsNoContent_WhenBannerExists()
        {
            // Arrange
            var bannerId = "valid-banner-id";

            // Mock the mediator to return a successful result (Unit) when sending the DeleteBannerCommand
            _mediatorMock
                .Setup(m => m.Send(It.IsAny<DeleteBannerCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(Unit.Value);

            // Act
            var result = await _controller.Delete(bannerId);

            // Assert
            // Ensure that the action returns NoContentResult
            Assert.IsType<NoContentResult>(result);
        }
  


    }
}
