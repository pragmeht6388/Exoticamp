using Exoticamp.UI.Helper;
using Exoticamp.UI.Models.CampsiteDetails;
using Exoticamp.UI.Models.Category;
using Exoticamp.UI.Models.ResponseModels;
using Exoticamp.UI.Models.ResponseModels.CampsiteDetails;
using Exoticamp.UI.Models.ResponseModels.Category;
using Exoticamp.UI.Services.IRepositories;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace Exoticamp.UI.Services.Repositories
{
    public class CategoryRepository:ICategoryRepository
    {
        private APIRepository _apiRepository;

        private Response<string> _oApiResponse;
        private string _sToken = string.Empty;
        private readonly IOptions<ApiBaseUrl> _apiBaseUrl;
        private readonly IConfiguration _configuration;
        public CategoryRepository(IOptions<ApiBaseUrl> apiBaseUrl)
        {
            _apiBaseUrl = apiBaseUrl;

        }

        public async Task<IEnumerable<CategoryVM>> GetAllCategory()
        {
            GetAllCategoryResponseModels response = new GetAllCategoryResponseModels();
            List<CategoryVM> events = new List<CategoryVM>();
            _apiRepository = new APIRepository(_configuration);

            _oApiResponse = new Response<string>();
            byte[] content = Array.Empty<byte>();
            var bytes = new ByteArrayContent(content);
            _oApiResponse = await _apiRepository.APICommunication(_apiBaseUrl.Value.ExoticampApiBaseUrl, URLHelper.GetAllCategories, HttpMethod.Get, bytes, _sToken);
            if (_oApiResponse.data != null)
            {
                events = (JsonConvert.DeserializeObject<GetAllCategoryResponseModels>(_oApiResponse.data)).Data.ToList();
            }

            return events;
        }
    }
}
