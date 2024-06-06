using Exoticamp.UI.Helper;
using Exoticamp.UI.Models.Location;
using Exoticamp.UI.Models.ResponseModels;
using Exoticamp.UI.Models.ResponseModels.Events;
using Exoticamp.UI.Models.ResponseModels.Location;
using Exoticamp.UI.Services.IRepositories;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace Exoticamp.UI.Services.Repositories
{
    public class LocationRepository : ILocationRepository
    {
      
        private APIRepository _apiRepository;

        private Response<string> _oApiResponse;
        private string _sToken = string.Empty;
        private readonly IOptions<ApiBaseUrl> _apiBaseUrl;
        private readonly IConfiguration _configuration;
        public LocationRepository(IOptions<ApiBaseUrl> apiBaseUrl)
        {
            _apiBaseUrl = apiBaseUrl;

        }
        public async Task<IEnumerable<LocationVM>> GetAllLocations()
        {
            GetAllLocationResponseModel response = new GetAllLocationResponseModel();
            List<LocationVM> events = new List<LocationVM>();
            _apiRepository = new APIRepository(_configuration);

            _oApiResponse = new Response<string>();
            byte[] content = Array.Empty<byte>();
            var bytes = new ByteArrayContent(content);
            _oApiResponse = await _apiRepository.APICommunication(_apiBaseUrl.Value.ExoticampApiBaseUrl, URLHelper.GetAllLocation, HttpMethod.Get, bytes, _sToken);
            if (_oApiResponse.data != null)
            {
                events = (JsonConvert.DeserializeObject<GetAllLocationResponseModel>(_oApiResponse.data)).Data.ToList();
            }

            return events;
        }

 
}
}
