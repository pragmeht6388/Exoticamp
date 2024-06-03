using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exoticamp.Application.Features.Chatbot.Queries.GetChatbotResponses
{
    public class GetChatbotResponsesQueryVM
    {
        public int Id { get; set; }
        public string? Keyword { get; set; }
        public string? Response { get; set; }
        public int? ParentId { get; set; }
        public List<GetChatbotResponsesQueryVM>? ChildResponses { get; set; }
    }
}
