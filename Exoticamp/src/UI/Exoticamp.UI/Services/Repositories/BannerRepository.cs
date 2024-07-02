using Exoticamp.UI.Helper;
using Exoticamp.UI.Models.Banners;
using Exoticamp.UI.Models.Events;
using Exoticamp.UI.Models.ResponseModels;
using Exoticamp.UI.Models.ResponseModels.Banners;
using Exoticamp.UI.Models.ResponseModels.Events;
using Exoticamp.UI.Services.IRepositories;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Text;

namespace Exoticamp.UI.Services.Repositories
{
    public class BannerRepository : IBannerRepository
    {
        private APIRepository _apiRepository;

        private Response<string> _oApiResponse;
        private string _sToken = string.Empty;
        private readonly IOptions<ApiBaseUrl> _apiBaseUrl;
        private readonly IConfiguration _configuration;
        public BannerRepository(IOptions<ApiBaseUrl> apiBaseUrl)
        {
            _apiBaseUrl = apiBaseUrl;

        }
        public async Task<IEnumerable<BannerViewModel>> GetAllBanners()
        {
            GetAllBannerResponseModel response = new GetAllBannerResponseModel();
            List<BannerViewModel> banners = new List<BannerViewModel>();
            _apiRepository = new APIRepository(_configuration);

            _oApiResponse = new Response<string>();
            byte[] content = Array.Empty<byte>();
            var bytes = new ByteArrayContent(content);
            _oApiResponse = await _apiRepository.APICommunication(_apiBaseUrl.Value.ExoticampApiBaseUrl, URLHelper.GetAllBanners, HttpMethod.Get, bytes, _sToken);
            if (_oApiResponse.data != null)
            {
                banners = (JsonConvert.DeserializeObject<GetAllBannerResponseModel>(_oApiResponse.data)).Data.ToList();
            }

            return banners;
        }
        public async Task<CreateBannerResponseModel> AddBanners(BannerViewModel bannerViewModel)
        {
            _apiRepository = new APIRepository(_configuration);
            var response = new Response<string>();
            var json = JsonConvert.SerializeObject(bannerViewModel, Newtonsoft.Json.Formatting.Indented);
            byte[] content = Encoding.ASCII.GetBytes(json);
            var bytes = new ByteArrayContent(content);

            response = await _apiRepository.APICommunication(_apiBaseUrl.Value.ExoticampApiBaseUrl, URLHelper.AddBanners, HttpMethod.Post, bytes, _sToken);

            if (response.data != null)
            {
                response.Message = "Failed to Add data ";
                return JsonConvert.DeserializeObject<CreateBannerResponseModel>(response.data);
            }

            return new CreateBannerResponseModel
            {
                Succeeded = false,
                Message = "Failed to add banner."
            };
        }
        public async Task<EditBannerResponseModel> EditBanner(BannerViewModel model)
        {
            _apiRepository = new APIRepository(_configuration);

            var response = new Response<string>();
            var json = JsonConvert.SerializeObject(model, Newtonsoft.Json.Formatting.Indented);
            byte[] content = Encoding.ASCII.GetBytes(json);

            var bytes = new ByteArrayContent(content);
            response = await _apiRepository.APICommunication(_apiBaseUrl.Value.ExoticampApiBaseUrl, URLHelper.UpdateBanners, HttpMethod.Put, bytes, _sToken);
            if (response.data != null)
            {
                return (JsonConvert.DeserializeObject<EditBannerResponseModel>(response.data));
            }

            return new EditBannerResponseModel
            {
                Succeeded = false,
                Message = "Failed to Edit Banner."
            };
        }

        public async Task<GetByIdResponseModel> GetBannerById(string id)
        {
            _apiRepository = new APIRepository(_configuration);

            var response = new Response<string>();
            var json = JsonConvert.SerializeObject(id, Newtonsoft.Json.Formatting.Indented);
            byte[] content = Encoding.ASCII.GetBytes(json);

            var bytes = new ByteArrayContent(content);
            response = await _apiRepository.APICommunication(_apiBaseUrl.Value.ExoticampApiBaseUrl, URLHelper.GetbyId.Replace("{0}", id), HttpMethod.Get, bytes, _sToken);
            if (response.data != null)
            {
                return (JsonConvert.DeserializeObject<GetByIdResponseModel>(response.data));
            }

            return new GetByIdResponseModel
            {
                Succeeded = false,
                Message = "Banner Not Found"
            };
        }
        public async Task<DeleteBannerResponseModel> DeleteBanner(string id)
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
                    URLHelper.DeleteBannerById.Replace("{0}", id), // Replace {0} with the banner ID in the URL
                    HttpMethod.Delete,                       // HTTP method DELETE
                    bytes,                                   // Byte content
                    _sToken                                  // Security token
                );

                // Check if response data is not null
                if (response.Success ==  true)
                {
                    response.Success = true;
                    response.Message = "Banner   Deleted";
                    // Deserialize response data to DeleteBannerResponseModel and return
                    return JsonConvert.DeserializeObject<DeleteBannerResponseModel>(response.data);
                }

                // Return a failure response if no data found
                return new DeleteBannerResponseModel
                {
                    Succeeded = false,
                    Message = "Banner Not Found"
                };
            }
            catch (Exception ex)
            {
                // Log the exception (log implementation is not shown here)
                // Return a failure response with the exception message
                return new DeleteBannerResponseModel
                {
                    Succeeded = false,
                    Message = ex.Message
                };
            }
        }
    }
}
