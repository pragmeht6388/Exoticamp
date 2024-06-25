using Exoticamp.UI.Helper;
using Exoticamp.UI.Models.Glamping;
using Exoticamp.UI.Models.ResponseModels;
using Exoticamp.UI.Models.ResponseModels.Banners;
using Exoticamp.UI.Models.ResponseModels.Glamping;
using Exoticamp.UI.Models.ResponseModels.Users;
using Exoticamp.UI.Models.Users;
using Exoticamp.UI.Services.IRepositories;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Text;

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

        
        public async Task<Response<IEnumerable<GlampingVM>>> GetGlampingListVAsync()
        {
            GetGlampingResponseModel glampingResponse = new GetGlampingResponseModel();
            _apiRepository = new APIRepository(_configuration);
            _oApiResponse = new Response<string>();

            // Prepare the HTTP content (empty in this case)
            byte[] content = Array.Empty<byte>();
            var bytes = new ByteArrayContent(content);

            // Make the API call
            _oApiResponse = await _apiRepository.APICommunication(
                _apiBaseUrl.Value.ExoticampApiBaseUrl,
                URLHelper.GetGlampingList,
                HttpMethod.Get,
                bytes,
                _sToken
            );

            // Initialize the response object
            var response = new Response<IEnumerable<GlampingVM>>();

            // Check if data is not null and deserialize
            if (_oApiResponse.data != null)
            {
                glampingResponse = JsonConvert.DeserializeObject<GetGlampingResponseModel>(_oApiResponse.data);

                response.data = glampingResponse.Data; // Assuming you want to return all items
                response.Message = glampingResponse.Message;
                response.Success = glampingResponse.IsSuccess;
            }

            return response;
        }

        //public async Task<GetGlampingResponseModel> GetGlampingByIdAsync(string id)
        //{
        //    _apiRepository = new APIRepository(_configuration);

        //    var response = new Response<string>();
        //    var json = JsonConvert.SerializeObject(id, Newtonsoft.Json.Formatting.Indented);
        //    byte[] content = Encoding.ASCII.GetBytes(json);

        //    var bytes = new ByteArrayContent(content);
        //    response = await _apiRepository.APICommunication(_apiBaseUrl.Value.ExoticampApiBaseUrl, URLHelper.GetGlampingById.Replace("{0}", id), HttpMethod.Get, bytes, _sToken);

        //    if (response.data != null)
        //    {
        //        return JsonConvert.DeserializeObject<GetGlampingResponseModel>(response.data);
        //    }
        //    else
        //    {
        //        // Handle the case where response.data is null (optional based on your needs)
        //        throw new Exception("Failed to fetch Glamping");
        //    }
        //}

        public async Task<Response<GlampingVM>> GetGlampingByIdAsync(string id)
        {
            _apiRepository = new APIRepository(_configuration);

            // Prepare the API request
            var response = new Response<string>();
            var json = JsonConvert.SerializeObject(id, Newtonsoft.Json.Formatting.Indented);
            byte[] content = Encoding.ASCII.GetBytes(json);
            var bytes = new ByteArrayContent(content);

            // Call the API to get Glamping by ID
            response = await _apiRepository.APICommunication(
                _apiBaseUrl.Value.ExoticampApiBaseUrl,
                URLHelper.GetGlampingById.Replace("{0}", id),
                HttpMethod.Get,
                bytes,
                _sToken
            );

            // Initialize the response object
            var apiResponse = new Response<GlampingVM>();

            // Deserialize the response
            if (response.data != null)
            {
                var glampingResponse = JsonConvert.DeserializeObject<Exoticamp.UI.Models.ResponseModels.Glamping.GetGlampingBYIdResponsModel>(response.data);
                glampingResponse.IsSuccess = response.Success;
                if (glampingResponse.IsSuccess)
                {
                    apiResponse.data = glampingResponse.Data; // Now it's a single GlampingVM
                    apiResponse.Message = glampingResponse.Message;
                    apiResponse.Success = glampingResponse.IsSuccess;
                }
                else
                {
                    apiResponse.Message = glampingResponse.Message;
                    apiResponse.Success = false;
                }
            }
            else
            {
                apiResponse.Message = "Failed to fetch Glamping";
                apiResponse.Success = false;
            }

            return apiResponse;
        }


    }
}
