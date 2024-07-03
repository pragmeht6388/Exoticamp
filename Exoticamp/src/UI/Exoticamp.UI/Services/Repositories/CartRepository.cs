using Exoticamp.UI.Helper;
using Exoticamp.UI.Models.CampCart;
using Exoticamp.UI.Models.ResponseModels;
using Exoticamp.UI.Services.IRepositories;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Text;
using System.Threading.Tasks;

namespace Exoticamp.UI.Services.Repositories
{
    public class CartRepository : ICartRepository
    {
        private Response<string> _oApiResponse;
        private APIRepository _apiRepository;
        private string _sToken = string.Empty;
        private readonly IOptions<ApiBaseUrl> _apiBaseUrl;
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CartRepository(IOptions<ApiBaseUrl> apiBaseUrl, IHttpContextAccessor httpContextAccessor)
        {
            _apiBaseUrl = apiBaseUrl;
            _httpContextAccessor = httpContextAccessor;

        }

        private ISession Session => _httpContextAccessor.HttpContext.Session;

        public async Task<AddCartResponseModel> AddCartCamp(CartCampsite campsiteVM)
        {
            _apiRepository = new APIRepository(_configuration);
            var response = new Response<string>();
            var json = JsonConvert.SerializeObject(campsiteVM, Newtonsoft.Json.Formatting.Indented);
            byte[] content = Encoding.ASCII.GetBytes(json);
            var bytes = new ByteArrayContent(content);
            _sToken = Session?.GetString("Token")?.ToString();

            response = await _apiRepository.APICommunication(_apiBaseUrl.Value.ExoticampApiBaseUrl, URLHelper.AddCart, HttpMethod.Post, bytes, _sToken);

            if (response.data != null)
            {
                return JsonConvert.DeserializeObject<AddCartResponseModel>(response.data);
            }

            return new AddCartResponseModel
            {
                Succeeded = false,
                Message = "Failed to add contact."
            };
        }
        public async Task<AllCartResponseModel> GetAllCart()
        {
            List<CartCampsite> carts = new List<CartCampsite>();
            AllCartResponseModel response=new AllCartResponseModel();
            _apiRepository = new APIRepository(_configuration);

            _oApiResponse = new Response<string>();
            byte[] content = Array.Empty<byte>();
            var bytes = new ByteArrayContent(content);
            _sToken = Session?.GetString("Token")?.ToString();


            _oApiResponse = await _apiRepository.APICommunication(_apiBaseUrl.Value.ExoticampApiBaseUrl, URLHelper.GetAllCart, HttpMethod.Get, bytes, _sToken);

            if (_oApiResponse.data != null)
            {
                response = JsonConvert.DeserializeObject<AllCartResponseModel>(_oApiResponse.data);
            }

            return response;
        }

        public async Task<AddCartResponseModel> CartById(string id)
        {
            _apiRepository = new APIRepository(_configuration);
            byte[] content = Array.Empty<byte>();
            var bytes = new ByteArrayContent(content);
            _sToken = Session?.GetString("Token");

            var response = await _apiRepository.APICommunication(
                _apiBaseUrl.Value.ExoticampApiBaseUrl,
                URLHelper.CartById.Replace("{0}", id),
                HttpMethod.Get,
                bytes,
                _sToken
            );

            if (response.data != null)
            {
                return JsonConvert.DeserializeObject<AddCartResponseModel>(response.data);
            }

            return new AddCartResponseModel
            {
                Succeeded = false,
                Message = "Event Not Found"
            };
        }

        public async Task<AddCartResponseModel> DeleteCartId(string id)
        {
            _apiRepository = new APIRepository(_configuration);
            byte[] content = Array.Empty<byte>();
            var bytes = new ByteArrayContent(content);
            _sToken = Session?.GetString("Token");

            try
            {
                var response = await _apiRepository.APICommunication(
                    _apiBaseUrl.Value.ExoticampApiBaseUrl,
                    URLHelper.DeleteCartId.Replace("{0}", id),
                    HttpMethod.Delete,
                    bytes,
                    _sToken
                );

                if (response.data != null)
                {
                    return JsonConvert.DeserializeObject<AddCartResponseModel>(response.data);
                }

                return new AddCartResponseModel
                {
                    Succeeded = false,
                    Message = "Event Not Found"
                };
            }
            catch (Exception ex)
            {
                return new AddCartResponseModel
                {
                    Succeeded = false,
                    Message = ex.Message
                };
            }
        }

    }
}
