using Xunit;
using Moq;
using Shouldly;
using MediatR;
using Microsoft.Extensions.Logging;
using Exoticamp.Api.Controllers.v1;
using Exoticamp.Application.Features.ContactUs.Command.AddContactUs;
using Exoticamp.Application.Responses;
using System.Threading;
using System.Threading.Tasks;
using System;
using Microsoft.AspNetCore.Mvc;
using Exoticamp.Application.Features.ContactUs.Query.GetContactUs;

namespace Exoticamp.Tests
{
    public class ContactUsControllerTests
    {
        private readonly Mock<IMediator> _mediatorMock;
        private readonly Mock<ILogger<ContactUsController>> _loggerMock;
        private readonly ContactUsController _controller;

        public ContactUsControllerTests()
        {
            _mediatorMock = new Mock<IMediator>();
            _loggerMock = new Mock<ILogger<ContactUsController>>();
            _controller = new ContactUsController(_mediatorMock.Object, _loggerMock.Object);
        }

        [Fact]
        public async Task Create_ReturnsOkResult_WhenCommandIsValid()
        {
            // Arrange
            var command = new AddContactUsCommand
            {
                Name = "John Doe",
                Email = "john@example.com",
                Message = "Hello, this is a test message."
            };

            var responseDto = new ContactUsDto
            {
                Id = Guid.NewGuid(),
                Name = command.Name,
                Email = command.Email,
                Message = command.Message
            };

            var response = new Response<ContactUsDto>
            {
                Data = responseDto,
                Message = "Success",
                Succeeded = true
            };

            _mediatorMock
                .Setup(m => m.Send(It.IsAny<AddContactUsCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(response);

            // Act
            var result = await _controller.Create(command);

            // Assert
            var okResult = result as OkObjectResult;
            okResult.ShouldNotBeNull();

            var returnedResponse = okResult.Value as Response<ContactUsDto>;
            returnedResponse.ShouldNotBeNull();
            returnedResponse.Succeeded.ShouldBeTrue();
            returnedResponse.Data.ShouldBe(responseDto);
        }
        [Fact]
        public async Task GetAllContactUs_ReturnsOkResult_WithContactUsList()
        {
            // Arrange
            var dtos = new List<ContactUsDto>
            {
                new ContactUsDto {  Name = "John", Email = "john@example.com", Message = "Test message 1" },
                new ContactUsDto {  Name = "Jane", Email = "jane@example.com", Message = "Test message 2" }
            };

            var response = new Response<IEnumerable<ContactUsDto>>
            {
                Data = dtos,
                Message = "Success",
                Succeeded = true
            };

            _mediatorMock.Setup(m => m.Send(It.IsAny<GetContactUsListQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(response);

            // Act
            var result = await _controller.GetAllContactUs();

            // Assert
            var okResult = result.ShouldBeOfType<OkObjectResult>();
            okResult.Value.ShouldBe(response);
        }
    }
}
