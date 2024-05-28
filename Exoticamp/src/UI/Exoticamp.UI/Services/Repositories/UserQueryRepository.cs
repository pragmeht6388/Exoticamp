using Exoticamp.UI.Helper;
using Exoticamp.UI.Models.Events;
using Exoticamp.UI.Models.ResponseModels;
using Exoticamp.UI.Models.ResponseModels.Events;
using Exoticamp.UI.Models.UserQuery;
using Exoticamp.UI.Services.IRepositories;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

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

        public Task<UserQueyVM> GetUserQueryById(Guid Id)
        {
            throw new NotImplementedException();
        }

        public Task<Guid> RespondToUserQuery(UserQueyVM userQuey)
        {
            throw new NotImplementedException();
        }
    }
}
