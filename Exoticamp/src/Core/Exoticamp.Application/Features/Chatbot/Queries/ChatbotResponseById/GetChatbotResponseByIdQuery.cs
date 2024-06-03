using Exoticamp.Application.Features.Chatbot.Queries.GetChatbotResponses;
using Exoticamp.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exoticamp.Application.Features.Chatbot.Queries.ChatbotResponseById
{
    public class GetChatbotResponseByIdQuery : IRequest<Response<List<GetChatbotResponsesQueryVM>>>
    {
        public int ParentId { get; set; }
    }
}
