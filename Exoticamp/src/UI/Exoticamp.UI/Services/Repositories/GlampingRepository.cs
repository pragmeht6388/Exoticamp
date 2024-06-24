using Exoticamp.UI.Helper;
using Exoticamp.UI.Models.Glamping;
using Exoticamp.UI.Models.ResponseModels;
using Exoticamp.UI.Services.IRepositories;
using Microsoft.Extensions.Options;

namespace Exoticamp.UI.Services.Repositories
{
    public class GlampingRepository : IGlampingRepository
    {
        private APIRepository _apiRepository;

        private Response<string> _oApiResponse;
        private string _sToken = string.Empty;
        private readonly IOptions<ApiBaseUrl> _apiBaseUrl;
        private readonly IConfiguration _configuration;

        public GlampingRepository(IOptions<ApiBaseUrl> apiBaseUrl)
        {
            _apiBaseUrl = apiBaseUrl;
        }

        public Task<Response<GlampingVM>> GetGlampingListVAsync()
        {
            throw new NotImplementedException();
        }
        //public Task<Response<GlampingVM>> GetGlampingListVAsync( )
        //{


        //}
    }
}
