using Exoticamp.Application.Contracts.Persistence;
using Exoticamp.Application.Features.Chatbot.Queries.GetChatbotResponses;
using Exoticamp.Application.Responses;
using Exoticamp.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exoticamp.Application.Features.Chatbot.Queries.ChatbotResponseById
{
    public class GetChatbotResponseByIdQueryHandler : IRequestHandler<GetChatbotResponseByIdQuery, Response<List<GetChatbotResponsesQueryVM>>>
    {
        private readonly IAsyncRepository<ChatbotResponse> _chatbotRepository;
        public GetChatbotResponseByIdQueryHandler(IAsyncRepository<ChatbotResponse> chatbotRepository)
        {
            _chatbotRepository = chatbotRepository;
        }


        public async Task<Response<List<GetChatbotResponsesQueryVM>>> Handle(GetChatbotResponseByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _chatbotRepository.ListAllAsync();
            var responseList = result.Select(x => new GetChatbotResponsesQueryVM()
            {
                Id = x.Id,
                Keyword = x.Keyword,
                Response = x.Response,
                ParentId = x.ParentId,
            }).Where(x => x.ParentId == request.ParentId).ToList();

            return new Response<List<GetChatbotResponsesQueryVM>>(responseList, "Success");
        }
    }
}
