using Exoticamp.UI.Helper;
using Exoticamp.UI.Models.ResponseModels;
using Exoticamp.UI.Models.ResponseModels.ReviewReply;
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
    }
}
