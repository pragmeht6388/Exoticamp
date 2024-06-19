using Exoticamp.UI.Helper;
using Exoticamp.UI.Models.ResponseModels;
using Exoticamp.UI.Models.ResponseModels.ReviewReply;
using Exoticamp.UI.Models.ResponseModels.Reviews;
using Exoticamp.UI.Models.ReviewReply;
using Exoticamp.UI.Services.IRepositories;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Text;

namespace Exoticamp.UI.Services.Repositories
{
    public class ReviewReplyRepositories:IReviewReplyRepository
    {
        private APIRepository _apiRepository;

        private Response<string> _oApiResponse;
        private string _sToken = string.Empty;
        private readonly IOptions<ApiBaseUrl> _apiBaseUrl;
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ReviewReplyRepositories(IOptions<ApiBaseUrl> apiBaseUrl, IHttpContextAccessor httpContextAccessor)
        {
            _apiBaseUrl = apiBaseUrl;
            _httpContextAccessor = httpContextAccessor;

        }
        private ISession Session => _httpContextAccessor.HttpContext.Session;

        public async Task<CreateReviewReplyResponseModel> AddReviewsReply(ReviewReplyVM campsiteVM)
        {
            _apiRepository = new APIRepository(_configuration);
            var response = new Response<string>();
            var json = JsonConvert.SerializeObject(campsiteVM, Newtonsoft.Json.Formatting.Indented);
            byte[] content = Encoding.ASCII.GetBytes(json);
            var bytes = new ByteArrayContent(content);
            _sToken = Session?.GetString("Token")?.ToString();


            response = await _apiRepository.APICommunication(_apiBaseUrl.Value.ExoticampApiBaseUrl, URLHelper.AddReviewReply, HttpMethod.Post, bytes, _sToken);
            //campsiteVM.UserId = Guid.Parse(Session.Id.ToString());
            if (response.data != null)
            {
                return JsonConvert.DeserializeObject<CreateReviewReplyResponseModel>(response.data);
            }

            return new CreateReviewReplyResponseModel
            {
                Succeeded = false,
                Message = "Failed to add contact."
            };
        }

        public async Task<GetReplyByIdResponseModel> GetReplyById(string id)
        {

            _apiRepository = new APIRepository(_configuration);

            var response = new Response<string>();
            var json = JsonConvert.SerializeObject(id, Newtonsoft.Json.Formatting.Indented);
            byte[] content = Encoding.ASCII.GetBytes(json);

            var bytes = new ByteArrayContent(content);
            response = await _apiRepository.APICommunication(_apiBaseUrl.Value.ExoticampApiBaseUrl, URLHelper.GetReplyById.Replace("{0}", id), HttpMethod.Get, bytes, _sToken);
            if (response.data != null)
            {
                return (JsonConvert.DeserializeObject<GetReplyByIdResponseModel>(response.data));
            }

            return new GetReplyByIdResponseModel
            {
                Succeeded = false,
                Message = "Event Not Found"
            };
        }

        public async Task<IEnumerable<ReviewReplyVM>> GetAllReply()
        {
            GetAllReplyResponseModel response = new GetAllReplyResponseModel();
            List<ReviewReplyVM> events = new List<ReviewReplyVM>();
            _apiRepository = new APIRepository(_configuration);

            _oApiResponse = new Response<string>();
            byte[] content = Array.Empty<byte>();
            var bytes = new ByteArrayContent(content);
            _oApiResponse = await _apiRepository.APICommunication(_apiBaseUrl.Value.ExoticampApiBaseUrl, URLHelper.GetAllReply, HttpMethod.Get, bytes, _sToken);
            if (_oApiResponse.data != null)
            {
                events = (JsonConvert.DeserializeObject<GetAllReplyResponseModel>(_oApiResponse.data)).Data.ToList();
                // events = response.Data.Where(c => c.IsActive==true).ToList();
            }

            return events;
        }
    }
}
