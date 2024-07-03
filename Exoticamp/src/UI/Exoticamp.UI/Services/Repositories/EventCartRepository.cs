using Exoticamp.UI.Helper;
using Exoticamp.UI.Models.EventCart;
using Exoticamp.UI.Models.ResponseModels;
using Exoticamp.UI.Models.ResponseModels.CampsiteDetails;
using Exoticamp.UI.Models.ResponseModels.EventCart;
using Exoticamp.UI.Services.IRepositories;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Text;

namespace Exoticamp.UI.Services.Repositories
{
    public class EventCartRepository:IEventCartRepository
    {
        private APIRepository _apiRepository;

        private Response<string> _oApiResponse;
        private string _sToken = string.Empty;
        private readonly IOptions<ApiBaseUrl> _apiBaseUrl;
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public EventCartRepository(IOptions<ApiBaseUrl> apiBaseUrl, IHttpContextAccessor httpContextAccessor)
        {
            _apiBaseUrl = apiBaseUrl;
            _httpContextAccessor = httpContextAccessor;

        }
        private ISession Session => _httpContextAccessor.HttpContext.Session;

        public async Task<IEnumerable<EventCartVM>> GetAllEventCart()
        {
            GetAllEventCartResponseModel response = new GetAllEventCartResponseModel();
            List<EventCartVM> events = new List<EventCartVM>();
            _apiRepository = new APIRepository(_configuration);

            _oApiResponse = new Response<string>();
            byte[] content = Array.Empty<byte>();
            var bytes = new ByteArrayContent(content);
            _sToken = Session?.GetString("Token")?.ToString();



            _oApiResponse = await _apiRepository.APICommunication(_apiBaseUrl.Value.ExoticampApiBaseUrl, URLHelper.GetAllEventCart, HttpMethod.Get, bytes, _sToken);
            if (_oApiResponse.data != null)
            {
                events = (JsonConvert.DeserializeObject<GetAllEventCartResponseModel>(_oApiResponse.data)).Data.ToList();
            }

            return events;
        }
        public async Task<CreateEventCartResponseModel> AddEventCart(EventCartVM campsiteVM)
        {
            _apiRepository = new APIRepository(_configuration);
            var response = new Response<string>();
            var json = JsonConvert.SerializeObject(campsiteVM, Newtonsoft.Json.Formatting.Indented);
            byte[] content = Encoding.ASCII.GetBytes(json);
            var bytes = new ByteArrayContent(content);
            _sToken = Session?.GetString("Token")?.ToString();

            response = await _apiRepository.APICommunication(_apiBaseUrl.Value.ExoticampApiBaseUrl, URLHelper.AddEventCart, HttpMethod.Post, bytes, _sToken);

            if (response.data != null)
            {
                return JsonConvert.DeserializeObject<CreateEventCartResponseModel>(response.data);
            }

            return new CreateEventCartResponseModel
            {
                Succeeded = false,
                Message = "Failed to add contact."
            };
        }


        public async Task<GetEventCartByIdResponseModel> GetEventCartById(string id)
        {

            _apiRepository = new APIRepository(_configuration);

            var response = new Response<string>();
            var json = JsonConvert.SerializeObject(id, Newtonsoft.Json.Formatting.Indented);
            byte[] content = Encoding.ASCII.GetBytes(json);

            var bytes = new ByteArrayContent(content);
            response = await _apiRepository.APICommunication(_apiBaseUrl.Value.ExoticampApiBaseUrl, URLHelper.GetEventCartById.Replace("{0}", id), HttpMethod.Get, bytes, _sToken);
            if (response.data != null)
            {
                return (JsonConvert.DeserializeObject<GetEventCartByIdResponseModel>(response.data));
            }

            return new GetEventCartByIdResponseModel
            {
                Succeeded = false,
                Message = "Event Not Found"
            };
         }
        public async Task<DeleteEventCartResponseModel> DeleteEventCart(string id)
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
                    URLHelper.DeleteEventCart.Replace("{0}", id), // Replace {0} with the campsite ID in the URL
                    HttpMethod.Delete,                       // HTTP method DELETE
                    bytes,                                   // Byte content
                    _sToken                                  // Security token
                );

                // Check if response data is not null
                if (response.data != null)
                {
                    // Deserialize response data to DeleteCampsiteResponseModel and return
                    return JsonConvert.DeserializeObject<DeleteEventCartResponseModel>(response.data);
                }

                // Return a failure response if no data found
                return new DeleteEventCartResponseModel
                {
                    Succeeded = false,
                    Message = "Event Not Found"
                };
            }
            catch (Exception ex)
            {
                // Log the exception (log implementation is not shown here)
                // Return a failure response with the exception message
                return new DeleteEventCartResponseModel
                {
                    Succeeded = false,
                    Message = ex.Message
                };
            }
        }
    }
}
