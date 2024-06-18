using Exoticamp.UI.Helper;
using Exoticamp.UI.Models.ResponseModels;
using Exoticamp.UI.Models.ResponseModels.CampsiteDetails;
using Exoticamp.UI.Models.ResponseModels.Reviews;
using Exoticamp.UI.Models.Reviews;
using Exoticamp.UI.Services.IRepositories;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Text;

namespace Exoticamp.UI.Services.Repositories
{
    public class ReviewRepository:IReviewsRepository
    {
        private APIRepository _apiRepository;

        private Response<string> _oApiResponse;
        private string _sToken = string.Empty;
        private readonly IOptions<ApiBaseUrl> _apiBaseUrl;
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ReviewRepository(IOptions<ApiBaseUrl> apiBaseUrl, IHttpContextAccessor httpContextAccessor)
        {
            _apiBaseUrl = apiBaseUrl;
            _httpContextAccessor = httpContextAccessor;

        }
        private ISession Session => _httpContextAccessor.HttpContext.Session;

        public async Task<CreateReviewsResponseModel> AddReviews(ReviewsVM campsiteVM)
        {
            _apiRepository = new APIRepository(_configuration);
            var response = new Response<string>();
            var json = JsonConvert.SerializeObject(campsiteVM, Newtonsoft.Json.Formatting.Indented);
            byte[] content = Encoding.ASCII.GetBytes(json);
            var bytes = new ByteArrayContent(content);
            _sToken = Session?.GetString("Token")?.ToString();
            

            response = await _apiRepository.APICommunication(_apiBaseUrl.Value.ExoticampApiBaseUrl, URLHelper.AddReviews, HttpMethod.Post, bytes, _sToken);
            campsiteVM.UserId = Guid.Parse(Session.Id.ToString());
            if (response.data != null)
            {
                return JsonConvert.DeserializeObject<CreateReviewsResponseModel>(response.data);
            }

            return new CreateReviewsResponseModel
            {
                Succeeded = false,
                Message = "Failed to add contact."
            };
        }

        public async Task<IEnumerable<ReviewsVM>> GetAllReviews()
        {
            GetAllReviewsResponseModel response = new GetAllReviewsResponseModel();
            List<ReviewsVM> events = new List<ReviewsVM>();
            _apiRepository = new APIRepository(_configuration);

            _oApiResponse = new Response<string>();
            byte[] content = Array.Empty<byte>();
            var bytes = new ByteArrayContent(content);
            _oApiResponse = await _apiRepository.APICommunication(_apiBaseUrl.Value.ExoticampApiBaseUrl, URLHelper.GetAllReview, HttpMethod.Get, bytes, _sToken);
            if (_oApiResponse.data != null)
            {
                events = (JsonConvert.DeserializeObject<GetAllReviewsResponseModel>(_oApiResponse.data)).Data.ToList();
                // events = response.Data.Where(c => c.IsActive==true).ToList();
            }

            return events;
        }


        public async Task<GetReviewByIdResponseModel> GetReviewById(string id)
        {

            _apiRepository = new APIRepository(_configuration);

            var response = new Response<string>();
            var json = JsonConvert.SerializeObject(id, Newtonsoft.Json.Formatting.Indented);
            byte[] content = Encoding.ASCII.GetBytes(json);

            var bytes = new ByteArrayContent(content);
            response = await _apiRepository.APICommunication(_apiBaseUrl.Value.ExoticampApiBaseUrl, URLHelper.GetReviewbyId.Replace("{0}", id), HttpMethod.Get, bytes, _sToken);
            if (response.data != null)
            {
                return (JsonConvert.DeserializeObject<GetReviewByIdResponseModel>(response.data));
            }

            return new GetReviewByIdResponseModel
            {
                Succeeded = false,
                Message = "Event Not Found"
            };
        }

        public async Task<UpdateReviewResponseModel> EditReview(ReviewsVM model)
        {


            _apiRepository = new APIRepository(_configuration);

            var response = new Response<string>();
            var json = JsonConvert.SerializeObject(model, Newtonsoft.Json.Formatting.Indented);
            byte[] content = Encoding.ASCII.GetBytes(json);

            var bytes = new ByteArrayContent(content);
            response = await _apiRepository.APICommunication(_apiBaseUrl.Value.ExoticampApiBaseUrl, URLHelper.UpdateReview, HttpMethod.Put, bytes, _sToken);
            if (response.data != null)
            {
                return (JsonConvert.DeserializeObject<UpdateReviewResponseModel>(response.data));
            }

            return new UpdateReviewResponseModel
            {

                Succeeded = false,
                Message = "Failed to Edit Event."
            };


        }
    }
}
