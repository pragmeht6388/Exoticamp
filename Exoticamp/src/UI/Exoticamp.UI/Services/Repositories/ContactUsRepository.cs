using Exoticamp.UI.Helper;
using Exoticamp.UI.Models.ContactUs;
using Exoticamp.UI.Models.ResponseModels;
using Exoticamp.UI.Models.ResponseModels.ContactUs;
using Exoticamp.UI.Services.IRepositories;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Text;

namespace Exoticamp.UI.Services.Repositories
{
    public class ContactUsRepository : IContactUsRepository
    {
        private APIRepository _apiRepository;

        private Response<string> _oApiResponse;
        private string _sToken = string.Empty;
        private readonly IOptions<ApiBaseUrl> _apiBaseUrl;
        private readonly IConfiguration _configuration;
        public ContactUsRepository(IOptions<ApiBaseUrl> apiBaseUrl)
        {
            _apiBaseUrl = apiBaseUrl;

        }
        public async Task<IEnumerable<ContactUsVM>> GetAllContacts()
        {
            GetAllContactUsResponseModel response = new GetAllContactUsResponseModel();
            List<ContactUsVM> events = new List<ContactUsVM>();
            _apiRepository = new APIRepository(_configuration);

            _oApiResponse = new Response<string>();
            byte[] content = Array.Empty<byte>();
            var bytes = new ByteArrayContent(content);
            _oApiResponse = await _apiRepository.APICommunication(_apiBaseUrl.Value.ExoticampApiBaseUrl, URLHelper.GetAllContactUs, HttpMethod.Get, bytes, _sToken);
            if (_oApiResponse.data != null)
            {
                events = (JsonConvert.DeserializeObject<GetAllContactUsResponseModel>(_oApiResponse.data)).Data.ToList();
            }

            return events;
        }
        public async Task<CreateContactUsResponse> AddContact(ContactUsVM contactUsVM)
        {
            _apiRepository = new APIRepository(_configuration);
            var response = new Response<string>();
            var json = JsonConvert.SerializeObject(contactUsVM, Formatting.Indented);
            byte[] content = Encoding.ASCII.GetBytes(json);
            var bytes = new ByteArrayContent(content);


            response = await _apiRepository.APICommunication(_apiBaseUrl.Value.ExoticampApiBaseUrl, URLHelper.AddContact, HttpMethod.Post, bytes, _sToken);

            if (response.data != null)
            {
                return JsonConvert.DeserializeObject<CreateContactUsResponse>(response.data);
            }

            return new CreateContactUsResponse
            {
                Succeeded = false,
                Message = "Failed to add contact."
            };
        }
    }
}
