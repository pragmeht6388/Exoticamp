using Exoticamp.Api.Controllers.v1;
using Exoticamp.Application.Features.Chatbot.Queries.ChatbotResponseById;
using Exoticamp.Application.Features.Chatbot.Queries.GetChatbotResponses;
using Exoticamp.Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Exoticamp.UnitTests.Controller
{
    public class ChatbotControllerTest
    {
        private readonly Mock<IMediator> _mediatorMock;
        private readonly ChatbotController _controller;

        public ChatbotControllerTest()
        {
            _mediatorMock = new Mock<IMediator>();
            _controller = new ChatbotController(_mediatorMock.Object);
        }

        [Fact]
        public async Task GetAllChatbotResponses_ReturnsOkResult_WithResponseData()
        {
            int parentId = 0; 
            var query = new GetChatbotResponseByIdQuery { ParentId = parentId };
            var expectedResponses = new List<GetChatbotResponsesQueryVM>
            {
                new GetChatbotResponsesQueryVM { Id = 1, Keyword = "Keyword1", Response = "Response1", ParentId = parentId },
                new GetChatbotResponsesQueryVM { Id = 2, Keyword = "Keyword2", Response = "Response2", ParentId = parentId }
            };
            var response = new Response<List<GetChatbotResponsesQueryVM>>(expectedResponses, "Success");

            _mediatorMock
                .Setup(m => m.Send(It.IsAny<GetChatbotResponseByIdQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(response);

            // Act
            var result = await _controller.GetAllChatbotResponses(parentId);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnedResponse = Assert.IsType<Response<List<GetChatbotResponsesQueryVM>>>(okResult.Value);

            Assert.Equal(expectedResponses, returnedResponse.Data);
            _mediatorMock.Verify(m => m.Send(It.IsAny<GetChatbotResponseByIdQuery>(), It.IsAny<CancellationToken>()), Times.Once);
        }
    }
}
