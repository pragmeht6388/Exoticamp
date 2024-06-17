using Exoticamp.UI.Helper;
using Exoticamp.UI.Models.ResponseModels;
using Exoticamp.UI.Models.ResponseModels.Search;
using Exoticamp.UI.Models.Search;
using Exoticamp.UI.Services.IRepositories;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace Exoticamp.UI.Services.Repositories
{
    public class SearchRepository:ISearchRepository
    {

        private APIRepository _apiRepository;

        private Response<string> _oApiResponse;
        private string _sToken = string.Empty;
        private readonly IOptions<ApiBaseUrl> _apiBaseUrl;
        private readonly IConfiguration _configuration;
        public SearchRepository(IOptions<ApiBaseUrl> apiBaseUrl)
        {
            _apiBaseUrl = apiBaseUrl;

        }

    
        public async Task<SearchResponseModel> SearchContent(string text)
        {
            SearchResponseModel response = new SearchResponseModel();
            SearchDto searchResult = new SearchDto();
            _apiRepository = new APIRepository(_configuration);

            _oApiResponse = new Response<string>();
            byte[] content = Array.Empty<byte>();
            var bytes = new ByteArrayContent(content);
            _oApiResponse = await _apiRepository.APICommunication(_apiBaseUrl.Value.ExoticampApiBaseUrl, URLHelper.SearchContent.Replace("{text}", Uri.EscapeDataString(text)), HttpMethod.Get, bytes, _sToken);
            if (_oApiResponse.data != null)
            {
                response.Data = (JsonConvert.DeserializeObject<SearchResponseModel>(_oApiResponse.data)).Data;
            }

            return response;
        }
    }
}
