using Exoticamp.UI.Helper;
using Exoticamp.UI.Models.CampsiteDetails;
using Exoticamp.UI.Models.ResponseModels;
using Exoticamp.UI.Models.ResponseModels.Campsite;
using Exoticamp.UI.Models.ResponseModels.CampsiteDetails;
using Exoticamp.UI.Services.IRepositories;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Text;

namespace Exoticamp.UI.Services.Repositories
{
    public class CampsiteDetailsRepository:ICampsiteDetailsRepository
    {
        private APIRepository _apiRepository;

        private Response<string> _oApiResponse;
        private string _sToken = string.Empty;
        private readonly IOptions<ApiBaseUrl> _apiBaseUrl;
        private readonly IConfiguration _configuration;
        public CampsiteDetailsRepository(IOptions<ApiBaseUrl> apiBaseUrl)
        {
            _apiBaseUrl = apiBaseUrl;

        }
        public async Task<IEnumerable<CampsiteDetailsVM>> GetAllCampsites()
        {
            GetAllCampsiteDetailsResponseModels response = new GetAllCampsiteDetailsResponseModels();
            List<CampsiteDetailsVM> events = new List<CampsiteDetailsVM>();
            _apiRepository = new APIRepository(_configuration);

            _oApiResponse = new Response<string>();
            byte[] content = Array.Empty<byte>();
            var bytes = new ByteArrayContent(content);
            _oApiResponse = await _apiRepository.APICommunication(_apiBaseUrl.Value.ExoticampApiBaseUrl, URLHelper.GetAllCampsiteDetails, HttpMethod.Get, bytes, _sToken);
            if (_oApiResponse.data != null)
            {
                events = (JsonConvert.DeserializeObject<GetAllCampsiteDetailsResponseModels>(_oApiResponse.data)).Data.ToList();
            }

            return events;
        }

        public async Task<GetCampsiteDetailsByIdResponseModel> GetCampsiteById(string id)
        {

            _apiRepository = new APIRepository(_configuration);

            var response = new Response<string>();
            var json = JsonConvert.SerializeObject(id, Newtonsoft.Json.Formatting.Indented);
            byte[] content = Encoding.ASCII.GetBytes(json);

            var bytes = new ByteArrayContent(content);
            response = await _apiRepository.APICommunication(_apiBaseUrl.Value.ExoticampApiBaseUrl, URLHelper.GetDetailsById.Replace("{0}", id), HttpMethod.Get, bytes, _sToken);
            if (response.data != null)
            {
                return (JsonConvert.DeserializeObject<GetCampsiteDetailsByIdResponseModel>(response.data));
            }

            return new GetCampsiteDetailsByIdResponseModel
            {
                Succeeded = false,
                Message = "Event Not Found"
            };
        }
    }
}
