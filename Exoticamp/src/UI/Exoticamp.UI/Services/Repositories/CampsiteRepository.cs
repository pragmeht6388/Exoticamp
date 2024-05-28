using Exoticamp.UI.Helper;
using Exoticamp.UI.Models.Campsite;
using Exoticamp.UI.Models.Events;
using Exoticamp.UI.Models.ResponseModels;
using Exoticamp.UI.Models.ResponseModels.Campsite;
using Exoticamp.UI.Services.IRepositories;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Text;
using System.Xml;

namespace Exoticamp.UI.Services.Repositories
{
    public class CamsiteRepository : ICampsiteRepository
    {
        private APIRepository _apiRepository;

        private Response<string> _oApiResponse;
        private string _sToken = string.Empty;
        private readonly IOptions<ApiBaseUrl> _apiBaseUrl;
        private readonly IConfiguration _configuration;
        public CamsiteRepository(IOptions<ApiBaseUrl> apiBaseUrl)
        {
            _apiBaseUrl = apiBaseUrl;

        }
        public async Task<IEnumerable<CampsiteVM>> GetAllCampsites()
        {
            GetAllCampsiteResponseModel response = new GetAllCampsiteResponseModel();
            List<CampsiteVM> events = new List<CampsiteVM>();
            _apiRepository = new APIRepository(_configuration);

            _oApiResponse = new Response<string>();
            byte[] content = Array.Empty<byte>();
            var bytes = new ByteArrayContent(content);
            _oApiResponse = await _apiRepository.APICommunication(_apiBaseUrl.Value.ExoticampApiBaseUrl, URLHelper.ShowCampsite, HttpMethod.Get, bytes, _sToken);
            if (_oApiResponse.data != null)
            {
                events = (JsonConvert.DeserializeObject<GetAllCampsiteResponseModel>(_oApiResponse.data)).Data.ToList();
            }

            return events;
        }
        public async Task<CreateCampsiteResponseModel> AddCampsite(CampsiteVM campsiteVM)
        {
            _apiRepository = new APIRepository(_configuration);
            var response = new Response<string>();
            var json = JsonConvert.SerializeObject(campsiteVM, Newtonsoft.Json.Formatting.Indented);
            byte[] content = Encoding.ASCII.GetBytes(json);
            var bytes = new ByteArrayContent(content);


            response = await _apiRepository.APICommunication(_apiBaseUrl.Value.ExoticampApiBaseUrl, URLHelper.AddCampsite, HttpMethod.Post, bytes, _sToken);

            if (response.data != null)
            {
                return JsonConvert.DeserializeObject<CreateCampsiteResponseModel>(response.data);
            }

            return new CreateCampsiteResponseModel
            {
                Succeeded = false,
                Message = "Failed to add contact."
            };
        }

        public async Task<EditCampsiteResponseModel> EditCampsite(CampsiteVM model)
        {


            _apiRepository = new APIRepository(_configuration);

            var response = new Response<string>();
            var json = JsonConvert.SerializeObject(model, Newtonsoft.Json.Formatting.Indented);
            byte[] content = Encoding.ASCII.GetBytes(json);

            var bytes = new ByteArrayContent(content);
            response = await _apiRepository.APICommunication(_apiBaseUrl.Value.ExoticampApiBaseUrl, URLHelper.EditCampsite, HttpMethod.Put, bytes, _sToken);
            if (response.data != null)
            {
                return (JsonConvert.DeserializeObject<EditCampsiteResponseModel>(response.data));
            }

            return new EditCampsiteResponseModel
            {
                
                Succeeded = false,
                Message = "Failed to Edit Event."
            };


        }

        public async Task<GetCampsiteByIdResponseModel> GetCampsiteById(string id)
        {

            _apiRepository = new APIRepository(_configuration);

            var response = new Response<string>();
            var json = JsonConvert.SerializeObject(id, Newtonsoft.Json.Formatting.Indented);
            byte[] content = Encoding.ASCII.GetBytes(json);

            var bytes = new ByteArrayContent(content);
            response = await _apiRepository.APICommunication(_apiBaseUrl.Value.ExoticampApiBaseUrl, URLHelper.GetById.Replace("{0}", id), HttpMethod.Get, bytes, _sToken);
            if (response.data != null)
            {
                return (JsonConvert.DeserializeObject<GetCampsiteByIdResponseModel>(response.data));
            }

            return new GetCampsiteByIdResponseModel
            {
                Succeeded = false,
                Message = "Event Not Found"
            };
        }

        public async Task<DeleteCampsiteResponseModel> DeleteCampsite(string id)
        {
            // Initialize the API repository with the configuration
            _apiRepository = new APIRepository(_configuration);

            // Create an empty byte array to send with the request
            byte[] content = Array.Empty<byte>();
            var bytes = new ByteArrayContent(content);

            try
            {
                // Send DELETE request to the API and await response
                var response = await _apiRepository.APICommunication(
                    _apiBaseUrl.Value.ExoticampApiBaseUrl,   // Base URL of the API
                    URLHelper.DeleteById.Replace("{0}", id), // Replace {0} with the campsite ID in the URL
                    HttpMethod.Delete,                       // HTTP method DELETE
                    bytes,                                   // Byte content
                    _sToken                                  // Security token
                );

                // Check if response data is not null
                if (response.data != null)
                {
                    // Deserialize response data to DeleteCampsiteResponseModel and return
                    return JsonConvert.DeserializeObject<DeleteCampsiteResponseModel>(response.data);
                }

                // Return a failure response if no data found
                return new DeleteCampsiteResponseModel
                {
                    Succeeded = false,
                    Message = "Event Not Found"
                };
            }
            catch (Exception ex)
            {
                // Log the exception (log implementation is not shown here)
                // Return a failure response with the exception message
                return new DeleteCampsiteResponseModel
                {
                    Succeeded = false,
                    Message = ex.Message
                };
            }
        }

    }
}
