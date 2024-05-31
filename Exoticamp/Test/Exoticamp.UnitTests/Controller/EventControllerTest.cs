using Xunit;
using Moq;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Exoticamp.Application.Features.Events.Commands.CreateEvent;
using Exoticamp.Application.Responses;
using Exoticamp.Api.Controllers.v1;
using Exoticamp.Application.Features.Events.Commands.UpdateEvent;

namespace Exoticamp.Tests
{
    public class EventsControllerTests
    {
        private readonly Mock<IMediator> _mediatorMock;
        private readonly EventsController _controller;

        public EventsControllerTests()
        {
            _mediatorMock = new Mock<IMediator>();
            _controller = new EventsController(_mediatorMock.Object);
        }

        [Fact]
        public async Task Create_ShouldReturnOk_WhenDtoSucceeded()
        {
            // Arrange
            var createEventCommand = new CreateEventCommand { Name = "Test Event" };
            var createEventCommandDto = new CreateEventCommandDto { Name = "Test Event" };
            var response = new Response<CreateEventCommandDto> { Succeeded = true, Data = createEventCommandDto };

            _mediatorMock.Setup(m => m.Send(createEventCommand, default)).ReturnsAsync(response);

            // Act
            var result = await _controller.Create(createEventCommand);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnedDto = Assert.IsType<Response<CreateEventCommandDto>>(okResult.Value);
            Assert.True(returnedDto.Succeeded);
            Assert.Equal("Test Event", returnedDto.Data.Name);
        }

        [Fact]
        public async Task Create_ShouldReturnBadRequest_WhenDtoFailed()
        {
            // Arrange
            var createEventCommand = new CreateEventCommand { Name = "Test Event" };
            var response = new Response<CreateEventCommandDto> { Succeeded = false, Errors = new List<string> { "Error" } };

            _mediatorMock.Setup(m => m.Send(createEventCommand, default)).ReturnsAsync(response);

            // Act
            var result = await _controller.Create(createEventCommand);

            // Assert
            var badRequestResult = Assert.IsType<BadRequestResult>(result);
        }
        [Fact]
        public async Task Update_ShouldReturnOk_WhenUpdateSucceeded()
        {
            // Arrange
            var updateEventCommand = new UpdateEventCommand { EventId = Guid.NewGuid(), Name = "Updated Event" };
            var updateEventDto = new UpdateEventDto { EventId = updateEventCommand.EventId, Name = "Updated Event" };
            var response = new Response<UpdateEventDto> { Succeeded = true, Data = updateEventDto };

            _mediatorMock.Setup(m => m.Send(updateEventCommand, default)).ReturnsAsync(response);

            // Act
            var result = await _controller.Update(updateEventCommand);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnedDto = Assert.IsType<Response<UpdateEventDto>>(okResult.Value);
            Assert.True(returnedDto.Succeeded);
            Assert.Equal("Updated Event", returnedDto.Data.Name);
        }
        [Fact]
        public async Task Update_ShouldReturnNotFound_WhenUpdateFailed()
        {
            // Arrange
            var updateEventCommand = new UpdateEventCommand { EventId = Guid.NewGuid(), Name = "Updated Event" };
            var response = new Response<UpdateEventDto> { Succeeded = false, Errors = new List<string> { "Event not found" } };

            _mediatorMock.Setup(m => m.Send(updateEventCommand, default)).ReturnsAsync(response);

            // Act
            var result = await _controller.Update(updateEventCommand);

            // Assert
            var notFoundResult = Assert.IsType<NotFoundResult>(result);
        }
    }
}
