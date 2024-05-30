using Exoticamp.UI.Helper;
using Exoticamp.UI.Models.Events;
using Exoticamp.UI.Models.ResponseModels;
using Exoticamp.UI.Models.ResponseModels.Events;
using Exoticamp.UI.Services.IRepositories;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Reflection;
using System.Text;

namespace Exoticamp.UI.Services.Repositories
{
    public class EventRepository : IEventRepository
    {
        private APIRepository _apiRepository;

        private Response<string> _oApiResponse;
        private string _sToken = string.Empty;
        private readonly IOptions<ApiBaseUrl> _apiBaseUrl;
        private readonly IConfiguration _configuration;
        public EventRepository(IOptions<ApiBaseUrl> apiBaseUrl)
        {
            _apiBaseUrl = apiBaseUrl;
            
        }
        public async Task<IEnumerable<EventVM>> GetAllEvents()
        {
            GetAllEventResponseModel response = new GetAllEventResponseModel();
            List<EventVM> events = new List<EventVM>();
            _apiRepository = new APIRepository(_configuration);

            _oApiResponse = new Response<string>();
            byte[] content = Array.Empty<byte>();
            var bytes = new ByteArrayContent(content);
            _oApiResponse = await _apiRepository.APICommunication(_apiBaseUrl.Value.ExoticampApiBaseUrl, URLHelper.GetAllEvents, HttpMethod.Get, bytes, _sToken);
            if (_oApiResponse.data != null)
            {
                events = (JsonConvert.DeserializeObject<GetAllEventResponseModel>(_oApiResponse.data)).Data.ToList();
            }

            return events;
        }

        public async Task<AddEventResponseModel> AddEvent(EventVM model)
        {
            AddEventResponseModel res=new AddEventResponseModel();

            _apiRepository = new APIRepository(_configuration);

           var response = new Response<string>();
            var json = JsonConvert.SerializeObject(model, Formatting.Indented);
            byte[] content = Encoding.ASCII.GetBytes(json);
           
            var bytes = new ByteArrayContent(content);
            response = await _apiRepository.APICommunication(_apiBaseUrl.Value.ExoticampApiBaseUrl, URLHelper.AddEvent, HttpMethod.Post, bytes, _sToken);
            if (response.data != null)
            {
               return (JsonConvert.DeserializeObject<AddEventResponseModel>(response.data));
            }

            return new AddEventResponseModel
            {
                Succeeded = false,
               Message =response.Message
            };


        }

        public async Task<EditEventResponseModel> EditEvent(EventVM model)
        {
            

            _apiRepository = new APIRepository(_configuration);

            var response = new Response<string>();
            var json = JsonConvert.SerializeObject(model, Formatting.Indented);
            byte[] content = Encoding.ASCII.GetBytes(json);

            var bytes = new ByteArrayContent(content);
            response = await _apiRepository.APICommunication(_apiBaseUrl.Value.ExoticampApiBaseUrl, URLHelper.EditEvent, HttpMethod.Put, bytes, _sToken);
            if (response.data != null)
            {
                return (JsonConvert.DeserializeObject<EditEventResponseModel>(response.data));
            }

            return new EditEventResponseModel
            {
                Succeeded = false,
                Message = response.Message
            };


        }

        public async Task<GetEventByIdResponseModel> GetEventById(string id)
        {

            _apiRepository = new APIRepository(_configuration);

            var response = new Response<string>();
            var json = JsonConvert.SerializeObject(id, Formatting.Indented);
            byte[] content = Encoding.ASCII.GetBytes(json);

            var bytes = new ByteArrayContent(content);
            response = await _apiRepository.APICommunication(_apiBaseUrl.Value.ExoticampApiBaseUrl, URLHelper.GetEventById.Replace("{0}",id), HttpMethod.Get,bytes, _sToken);
            if (response.data != null)
            {
                return (JsonConvert.DeserializeObject<GetEventByIdResponseModel>(response.data));
            }

            return new GetEventByIdResponseModel
            {
                Succeeded = false,
                Message = "Event Not Found"
            };
        }

        public async Task<DeleteEventResponseModel> DeleteEvent(string id)
        {

            _apiRepository = new APIRepository(_configuration);

            var response = new Response<string>();

            byte[] content = Array.Empty<byte>();
            var bytes = new ByteArrayContent(content);
            response = await _apiRepository.APICommunication(_apiBaseUrl.Value.ExoticampApiBaseUrl, URLHelper.DeleteEvent.Replace("{0}",id), HttpMethod.Delete, bytes, _sToken);
            if (response.data != null)
            {
                return (JsonConvert.DeserializeObject<DeleteEventResponseModel>(response.data));
            }

            return new DeleteEventResponseModel
            {
                Succeeded = false,
                Message = "Event Not Found"
            };
        }
    }
}
