using Exoticamp.UI.Helper;
using Exoticamp.UI.Models.Chatbot;
using Exoticamp.UI.Models.Events;
using Exoticamp.UI.Models.ResponseModels;
using Exoticamp.UI.Models.UserQuery;
using Exoticamp.UI.Services.IRepositories;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Text;

namespace Exoticamp.UI.Services.Repositories
{
    public class ChatbotRepository : IChatbotRepository
    {
        private APIRepository _apiRepository;
        private Response<string> _oApiResponse;
        private string _sToken = string.Empty;
        private readonly IOptions<ApiBaseUrl> _apiBaseUrl;
        private readonly IConfiguration _configuration;
        public ChatbotRepository(IOptions<ApiBaseUrl> apiBaseUrl)
        {
            _apiBaseUrl = apiBaseUrl;

        }

        public async Task<Response<IEnumerable<ChatbotVM>>> GetChatbotResponseById(string Id)
        {
            _apiRepository = new APIRepository(_configuration);

            var response = new Response<string>();
            var json = JsonConvert.SerializeObject(Id, Newtonsoft.Json.Formatting.Indented);
            byte[] content = Encoding.ASCII.GetBytes(json);

            var bytes = new ByteArrayContent(content);
            response = await _apiRepository.APICommunication(_apiBaseUrl.Value.ExoticampApiBaseUrl, URLHelper.GetChatbotResponses.Replace("{0}", Id ?? "0"), HttpMethod.Get, bytes, _sToken);
            if (response.data != null)
            {
                return (JsonConvert.DeserializeObject<Response<IEnumerable<ChatbotVM>>>(response.data));

            }

            return new Response<IEnumerable<ChatbotVM>>
            {
                Success = false,
                Message = "Response Not Found"
            };

        }
        public async Task<Response<string>> CreateUserQuery(UserQueyVM userQuey)
        {
            _apiRepository = new APIRepository(_configuration);
            var response = new Response<string>();
            var json = JsonConvert.SerializeObject(userQuey, Formatting.Indented);
            byte[] content = Encoding.ASCII.GetBytes(json);
            var bytes = new ByteArrayContent(content);
            _oApiResponse = await _apiRepository.APICommunication(_apiBaseUrl.Value.ExoticampApiBaseUrl, URLHelper.CreateUserQuery, HttpMethod.Post, bytes, _sToken);

            if (_oApiResponse.data != null)
            {
                return JsonConvert.DeserializeObject<Response<string>>(_oApiResponse.data);
            }

            return new Response<string>()
            {
                Success = false,
                Message = "Failed to add user query."
            };
        }
    }
}
