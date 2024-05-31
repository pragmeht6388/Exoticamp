using Exoticamp.UI.Models.Chatbot;
using Exoticamp.UI.Models.ResponseModels;
using Exoticamp.UI.Models.UserQuery;

namespace Exoticamp.UI.Services.IRepositories
{
    public interface IChatbotRepository
    {
        Task<Response<string>> CreateUserQuery(UserQueyVM userQuey);
        Task<Response<IEnumerable<ChatbotVM>>> GetChatbotResponseById(string Id);
    }
}
