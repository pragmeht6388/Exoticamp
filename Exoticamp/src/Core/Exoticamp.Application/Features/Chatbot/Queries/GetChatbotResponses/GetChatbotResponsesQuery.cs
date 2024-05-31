using Exoticamp.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exoticamp.Application.Features.Chatbot.Queries.GetChatbotResponses
{
    public class GetChatbotResponsesQuery : IRequest<Response<List<GetChatbotResponsesQueryVM>>>
    {
    }
}
