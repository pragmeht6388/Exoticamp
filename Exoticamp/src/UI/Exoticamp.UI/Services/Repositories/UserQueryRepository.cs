using Exoticamp.UI.Helper;
using Exoticamp.UI.Models.Events;
using Exoticamp.UI.Models.ResponseModels;
using Exoticamp.UI.Models.ResponseModels.Events;
using Exoticamp.UI.Models.UserQuery;
using Exoticamp.UI.Services.IRepositories;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Text;

namespace Exoticamp.UI.Services.Repositories
{
    public class UserQueryRepository : IUserQueryRepository
    {
        private APIRepository _apiRepository;
        private Response<string> _oApiResponse;
        private string _sToken = string.Empty;
        private readonly IOptions<ApiBaseUrl> _apiBaseUrl;
        private readonly IConfiguration _configuration;
        public UserQueryRepository(IOptions<ApiBaseUrl> apiBaseUrl)
        {
            _apiBaseUrl = apiBaseUrl;

        }
        public async Task<IEnumerable<UserQueyVM>> GetAllUserQueries()
        {
            List<UserQueyVM> queries = new List<UserQueyVM>();
            _apiRepository = new APIRepository(_configuration);
            _oApiResponse = new Response<string>();
            byte[] content = Array.Empty<byte>();
            var bytes = new ByteArrayContent(content);
            _oApiResponse = await _apiRepository.APICommunication(_apiBaseUrl.Value.ExoticampApiBaseUrl, URLHelper.GetAllUserQueries, HttpMethod.Get, bytes, _sToken);
            if (_oApiResponse.data != null)
            {
                queries = (JsonConvert.DeserializeObject<Response<IEnumerable<UserQueyVM>>>(_oApiResponse.data)).data.ToList();
            }

            return queries;
        }

        public async Task<Response<UserQueyVM>> GetUserQueryById(string Id)
        {
            _apiRepository = new APIRepository(_configuration);

            var response = new Response<string>();
            var json = JsonConvert.SerializeObject(Id, Newtonsoft.Json.Formatting.Indented);
            byte[] content = Encoding.ASCII.GetBytes(json);

            var bytes = new ByteArrayContent(content);
            response = await _apiRepository.APICommunication(_apiBaseUrl.Value.ExoticampApiBaseUrl, URLHelper.GetUserQueryById.Replace("{0}", Id), HttpMethod.Get, bytes, _sToken);
            if (response.data != null)
            {
                return (JsonConvert.DeserializeObject<Response<UserQueyVM>>(response.data));

            }

            return new Response<UserQueyVM>
            {
                Success = false,
                Message = "Event Not Found"
            };

        }

        public async Task<Response<string>> RespondToUserQuery(UserQueyVM userQuey)
        {
            _apiRepository = new APIRepository(_configuration);
            var response = new Response<string>();
            var json = JsonConvert.SerializeObject(userQuey, Formatting.Indented);
            byte[] content = Encoding.ASCII.GetBytes(json);
            var bytes = new ByteArrayContent(content);
            _oApiResponse = await _apiRepository.APICommunication(_apiBaseUrl.Value.ExoticampApiBaseUrl, URLHelper.RespondToUserQuery, HttpMethod.Put, bytes, _sToken);

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
