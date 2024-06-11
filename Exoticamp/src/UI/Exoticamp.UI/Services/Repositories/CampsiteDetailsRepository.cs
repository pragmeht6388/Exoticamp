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
    public class CampsiteDetailsRepository : ICampsiteDetailsRepository
    {
        private APIRepository _apiRepository;

        private Response<string> _oApiResponse;
        private string _sToken = string.Empty;
        private readonly IOptions<ApiBaseUrl> _apiBaseUrl;
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CampsiteDetailsRepository(IOptions<ApiBaseUrl> apiBaseUrl, IHttpContextAccessor httpContextAccessor)
        {
            _apiBaseUrl = apiBaseUrl;
            _httpContextAccessor = httpContextAccessor;

        }

        private ISession Session => _httpContextAccessor.HttpContext.Session;
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
                // events = response.Data.Where(c => c.IsActive==true).ToList();
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

        public async Task<CreateCampsiteDetailsResponseModel> AddCampsiteDetails(CampsiteDetailsVM campsiteVM)
        {
            _apiRepository = new APIRepository(_configuration);
            var response = new Response<string>();
            var json = JsonConvert.SerializeObject(campsiteVM, Newtonsoft.Json.Formatting.Indented);
            byte[] content = Encoding.ASCII.GetBytes(json);
            var bytes = new ByteArrayContent(content);
            _sToken = Session?.GetString("Token")?.ToString();

            response = await _apiRepository.APICommunication(_apiBaseUrl.Value.ExoticampApiBaseUrl, URLHelper.AddCampsiteDetails, HttpMethod.Post, bytes, _sToken);

            if (response.data != null)
            {
                return JsonConvert.DeserializeObject<CreateCampsiteDetailsResponseModel>(response.data);
            }

            return new CreateCampsiteDetailsResponseModel
            {
                Succeeded = false,
                Message = "Failed to add contact."
            };
        }

        public async Task<EditCampsiteDetailsResopnseModel> EditCampsiteDetails(CampsiteDetailsVM model)
        {


            _apiRepository = new APIRepository(_configuration);

            var response = new Response<string>();
            var json = JsonConvert.SerializeObject(model, Newtonsoft.Json.Formatting.Indented);
            byte[] content = Encoding.ASCII.GetBytes(json);

            var bytes = new ByteArrayContent(content);
            response = await _apiRepository.APICommunication(_apiBaseUrl.Value.ExoticampApiBaseUrl, URLHelper.EditCampsiteDetails, HttpMethod.Put, bytes, _sToken);
            if (response.data != null)
            {
                return (JsonConvert.DeserializeObject<EditCampsiteDetailsResopnseModel>(response.data));
            }

            return new EditCampsiteDetailsResopnseModel
            {

                Succeeded = false,
                Message = "Failed to Edit Event."
            };


        }




        public async Task<DeleteCampsiteDetailsResponseModel> DeleteCampsite(string id)
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
                    URLHelper.DeleteCampsiteById.Replace("{0}", id), // Replace {0} with the campsite ID in the URL
                    HttpMethod.Delete,                       // HTTP method DELETE
                    bytes,                                   // Byte content
                    _sToken                                  // Security token
                );

                // Check if response data is not null
                if (response.data != null)
                {
                    // Deserialize response data to DeleteCampsiteResponseModel and return
                    return JsonConvert.DeserializeObject<DeleteCampsiteDetailsResponseModel>(response.data);
                }

                // Return a failure response if no data found
                return new DeleteCampsiteDetailsResponseModel
                {
                    Succeeded = false,
                    Message = "Event Not Found"
                };
            }
            catch (Exception ex)
            {
                // Log the exception (log implementation is not shown here)
                // Return a failure response with the exception message
                return new DeleteCampsiteDetailsResponseModel
                {
                    Succeeded = false,
                    Message = ex.Message
                };
            }
        }

    }
}
