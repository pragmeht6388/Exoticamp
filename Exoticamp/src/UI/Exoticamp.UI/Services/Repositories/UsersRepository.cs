using Exoticamp.UI.Helper;
using Exoticamp.UI.Models.ResponseModels;
using Exoticamp.UI.Models.ResponseModels.Users;
using Exoticamp.UI.Models.Users;
using Exoticamp.UI.Services.IRepositories;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Text;

namespace Exoticamp.UI.Services.Repositories
{
    public class UsersRepository : IUsersRepository
    {
        private  APIRepository _apiRepository;
        private readonly IOptions<ApiBaseUrl> _apiBaseUrl;
        private readonly IConfiguration _configuration;
        private string _sToken = string.Empty;
        private Response<string> _oApiResponse;

        public UsersRepository(IOptions<ApiBaseUrl> apiBaseUrl, IConfiguration configuration)
        {
            _apiBaseUrl = apiBaseUrl;
            _configuration = configuration;
            _apiRepository = new APIRepository(_configuration);
        }

        //public async Task<CreateUserResponse> CreateUserAsync(UsersVM usersVM)
        //{
        //    var json = JsonConvert.SerializeObject(usersVM, Formatting.Indented);
        //    byte[] content = Encoding.ASCII.GetBytes(json);
        //    var bytes = new ByteArrayContent(content);

        //    var response = await _apiRepository.APICommunication(_apiBaseUrl.Value.ExoticampApiBaseUrl, URLHelper.Users, HttpMethod.Post, bytes, _sToken);

        //    if (response.data != null)
        //    {
        //        return JsonConvert.DeserializeObject<CreateUserResponse>(response.data);
        //    }

        //    return new CreateUserResponse
        //    {
        //        Succeeded = false,
        //        Message = "Failed to create user."
        //    };
        //}

        //public async Task<UsersResponse> GetAllUsersAsync()
        //{
        //    var response = await _apiRepository.APICommunication(_apiBaseUrl.Value.ExoticampApiBaseUrl, URLHelper.GetAllUsers, HttpMethod.Get, null, _sToken);

        //    if (response.data != null)
        //    {
        //        return JsonConvert.DeserializeObject<UsersResponse>(response.data);
        //    }

        //    return new List<UsersResponse>();
        //}
        public async Task<IEnumerable<UsersVM>> GetAllUsersAsync()
        {
             UsersResponse response = new UsersResponse();
            List<UsersVM> events = new List<UsersVM>();
            _apiRepository = new APIRepository(_configuration);

            _oApiResponse = new Response<string>();
            byte[] content = Array.Empty<byte>();
            var bytes = new ByteArrayContent(content);
            _oApiResponse = await _apiRepository.APICommunication(_apiBaseUrl.Value.ExoticampApiBaseUrl, URLHelper. GetAllUsers, HttpMethod.Get, bytes, _sToken);
            if (_oApiResponse.data != null)
            {
                events = (JsonConvert.DeserializeObject< UsersResponse>(_oApiResponse.data)).Data.ToList();
            }

            return events;
        }
    }
}

