using Exoticamp.UI.Helper;
using Exoticamp.UI.Models.Login;
using Exoticamp.UI.Models.ResponseModels.Users;
using Exoticamp.UI.Services.IRepositories;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Text;

namespace Exoticamp.UI.Services.Repositories
{
    public class LoginRepository: ILoginRepository
    {
        private readonly APIRepository _apiRepository;
        private readonly IOptions<ApiBaseUrl> _apiBaseUrl;
        private readonly IConfiguration _configuration;
        public LoginRepository(IOptions<ApiBaseUrl> apiBaseUrl, IConfiguration configuration)
        {
            _apiBaseUrl = apiBaseUrl;
            _configuration = configuration;
            _apiRepository = new APIRepository(_configuration);
        }
        public async Task<UserLoginResponse> AuthenticateAsync( LoginVM request)
        {
            var response = new UserLoginResponse();

            try
            {
                var jsonContent = JsonConvert.SerializeObject(request);
                var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

                var apiResponse = await _apiRepository.APICommunication(
                    _apiBaseUrl.Value.ExoticampApiBaseUrl,
                    URLHelper. Login,
                    HttpMethod.Post,
                    content,
                    string.Empty);

                if (!string.IsNullOrEmpty(apiResponse.data))
                {
                    response = JsonConvert.DeserializeObject<UserLoginResponse>(apiResponse.data);
                    response.IsAuthenticated = apiResponse.Success;
                     
                }
            }
            catch (Exception ex)
            {
                response.IsAuthenticated = false;
                response.Message = ex.Message; 
            }

            return response;
        }
    }
}
