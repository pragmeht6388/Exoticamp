using Exoticamp.Api.Controllers.v1;
using Exoticamp.Application.Features.Banners.Commands.CreateBanner;
using Exoticamp.Application.Features.UserQueries.Commands.CreateUserQuery;
using Exoticamp.Application.Features.UserQueries.Commands.RespondToUserQuery;
using Exoticamp.Application.Features.UserQueries.Queries.GetUserQueryList;
using Exoticamp.Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Exoticamp.UnitTests.Controller
{
    public class UserQueryControllerTest
    {
        private readonly Mock<IMediator> _mediatorMock;
        private readonly Mock<ILogger<UserQueryController>> _loggerMock;
        private readonly UserQueryController _controller;

        public UserQueryControllerTest()
        {
            _mediatorMock = new Mock<IMediator>();
            _loggerMock = new Mock<ILogger<UserQueryController>>();
            _controller = new UserQueryController(_mediatorMock.Object);
        }

        [Fact]
        public async Task Create_ReturnsOkResult_WithUserQuery()
        {
            // Arrange
            var command = new CreateUserQueryCommand
            {
               Email = "a@gmail.com",
               Query = "khkjhjkj"
            };



            var response = new Response<int>
            {
                Data = 7,
                Message = "Success",
                Succeeded = true
            };

            _mediatorMock
                .Setup(m => m.Send(It.IsAny<CreateUserQueryCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(response);

            // Act
            var result = await _controller.Create(command);

            // Assert
            // Assert
            var okResult = result as OkObjectResult;
            Assert.NotNull(okResult);
            var returnedResponse = okResult.Value as Response<int>;
            Assert.NotNull(returnedResponse);
            Assert.True(returnedResponse.Succeeded);
        }

        [Fact]
        public async Task GetAllUserQueris_ReturnsOkResult_WithUserQueryList()
        {
            // Arrange
            var userQueries = new List<GetUserQueryListVM>
            {
                new GetUserQueryListVM { Id = Guid.NewGuid(), Email = "test1@example.com", Query = "Test query 1" },
                new GetUserQueryListVM { Id = Guid.NewGuid(), Email = "test2@example.com", Query = "Test query 2" }
            };
            var response = new Response<IEnumerable<GetUserQueryListVM>>(userQueries);

            _mediatorMock
                .Setup(m => m.Send(It.IsAny<GetUserQueryListQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(response);

            // Act
            var result = await _controller.GetAllUserQueris();

            // Assert
            var okResult = result as OkObjectResult;
            Assert.NotNull(okResult);
            var returnedDtos = okResult.Value as Response<IEnumerable<GetUserQueryListVM>>;

            Assert.NotNull(returnedDtos);
            Assert.True(returnedDtos.Succeeded);

            _mediatorMock.Verify(m => m.Send(It.IsAny<GetUserQueryListQuery>(), It.IsAny<CancellationToken>()), Times.Once);
        }

        [Fact]
        public async Task Update_ReturnsOkResult_WithResponseGuid()
        {
            // Arrange
            var command = new RespondToUserQueryCommand
            {
                Id = Guid.NewGuid(),
                Response = "Thank you for your query",
                Email = "user@example.com"
            };
            var response = new Response<Guid>(command.Id, "Successfully added the query");

            _mediatorMock
                .Setup(m => m.Send(It.IsAny<RespondToUserQueryCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(response);

            // Act
            var result = await _controller.Update(command);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnedResponse = Assert.IsType<Response<Guid>>(okResult.Value);

            Assert.Equal(command.Id, returnedResponse.Data);
            Assert.Equal("Successfully added the query", returnedResponse.Message);
            _mediatorMock.Verify(m => m.Send(It.IsAny<RespondToUserQueryCommand>(), It.IsAny<CancellationToken>()), Times.Once);
        }
    }
}
