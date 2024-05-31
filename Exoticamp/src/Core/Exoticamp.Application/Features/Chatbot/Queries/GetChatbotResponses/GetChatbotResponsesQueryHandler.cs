using Exoticamp.Application.Contracts.Persistence;
using Exoticamp.Application.Responses;
using Exoticamp.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exoticamp.Application.Features.Chatbot.Queries.GetChatbotResponses
{
    public class GetChatbotResponsesQueryHandler : IRequestHandler<GetChatbotResponsesQuery, Response<List<GetChatbotResponsesQueryVM>>>
    {
        private readonly IAsyncRepository<ChatbotResponse> _chatbotRepository;
        public GetChatbotResponsesQueryHandler(IAsyncRepository<ChatbotResponse> chatbotRepository)
        {
            _chatbotRepository = chatbotRepository;
        }

        public async Task<Response<List<GetChatbotResponsesQueryVM>>> Handle(GetChatbotResponsesQuery request, CancellationToken cancellationToken)
        {
            var result = await _chatbotRepository.ListAllAsync();
            var responseList = result.Select(x => new GetChatbotResponsesQueryVM()
            {
                Id = x.Id,
                Keyword = x.Keyword,
                Response = x.Response,
                ParentId = x.ParentId,
            }).ToList();

            return new Response<List<GetChatbotResponsesQueryVM>>(responseList, "Success");
        }
    }
}
