using Exoticamp.UI.Helper;
using Exoticamp.UI.Models.Booking;
using Exoticamp.UI.Models.ResponseModels;
using Exoticamp.UI.Models.ResponseModels.Booking;
using Exoticamp.UI.Models.ResponseModels.Bookings;
using Exoticamp.UI.Models.ResponseModels.Events;
using Exoticamp.UI.Services.IRepositories;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Text;

namespace Exoticamp.UI.Services.Repositories
{
    public class BookingRepository : IBookingRepository
    {

        private APIRepository _apiRepository;

        private Response<string> _oApiResponse;
        private string _sToken = string.Empty;
        private readonly IOptions<ApiBaseUrl> _apiBaseUrl;
        private readonly IConfiguration _configuration;
        public BookingRepository(IOptions<ApiBaseUrl> apiBaseUrl)
        {
            _apiBaseUrl = apiBaseUrl;

        }
        public async Task<IEnumerable<BookingVM>> GetAllBookings()
        {
            GetAllBookingsResponseModel response = new GetAllBookingsResponseModel();
            List<BookingVM> bookings = new List<BookingVM>();
            _apiRepository = new APIRepository(_configuration);

            _oApiResponse = new Response<string>();
            byte[] content = Array.Empty<byte>();
            var bytes = new ByteArrayContent(content);
            _oApiResponse = await _apiRepository.APICommunication(_apiBaseUrl.Value.ExoticampApiBaseUrl, URLHelper.GetAllBookings, HttpMethod.Get, bytes, _sToken);
            if (_oApiResponse.data != null)
            {
                bookings = (JsonConvert.DeserializeObject<GetAllBookingsResponseModel>(_oApiResponse.data)).Data.ToList();
            }

            return bookings;
        }

        public async Task<AddBookingResponseModel> AddBooking(BookingVM model)
        {
            AddBookingResponseModel res = new AddBookingResponseModel();

            _apiRepository = new APIRepository(_configuration);

            var response = new Response<string>();
            var json = JsonConvert.SerializeObject(model, Formatting.Indented);
            byte[] content = Encoding.ASCII.GetBytes(json);

            var bytes = new ByteArrayContent(content);
            response = await _apiRepository.APICommunication(_apiBaseUrl.Value.ExoticampApiBaseUrl, URLHelper.AddBooking, HttpMethod.Post, bytes, _sToken);
            if (response.Success == true)
            {
                res= (JsonConvert.DeserializeObject<AddBookingResponseModel>(response.data));
                res.Message=response.data;
                return res;
            }

            res.Succeeded = false;
            res.Message = response.Message;

           
            return res;
        }

        public async Task<GetBookingByIdResponseModel> GetBookingById(string id)
        {
            _apiRepository = new APIRepository(_configuration);

            var response = new Response<string>();
            var json = JsonConvert.SerializeObject(id, Formatting.Indented);
            byte[] content = Encoding.ASCII.GetBytes(json);

            var bytes = new ByteArrayContent(content);
            response = await _apiRepository.APICommunication(_apiBaseUrl.Value.ExoticampApiBaseUrl, URLHelper.GetBookingById.Replace("{0}", id), HttpMethod.Get, null, _sToken);
            if (response.data != null)
            {
                return  JsonConvert.DeserializeObject<GetBookingByIdResponseModel>(response.data);
            }

            return new GetBookingByIdResponseModel
            {
                Succeeded = false,
                Message = "Booking Not Found"
            };
        }

        public async Task<EditBookingResponseModel> UpdateBooking(BookingVM model)
        {
            _apiRepository = new APIRepository(_configuration);
            var result = new EditBookingResponseModel();
            var response = new Response<string>();
            var json = JsonConvert.SerializeObject(model, Formatting.Indented);
            byte[] content = Encoding.ASCII.GetBytes(json);

            var bytes = new ByteArrayContent(content);
            response = await _apiRepository.APICommunication(_apiBaseUrl.Value.ExoticampApiBaseUrl, URLHelper.EditBooking, HttpMethod.Put, bytes, _sToken);
            if (response.Success == true)
            {
                result= JsonConvert.DeserializeObject<EditBookingResponseModel>(response.data);
                result.Message = response.data;
                return result;
            }


            result.Succeeded = false;
            result.Message = response.Message;
            return result;

        }
    }
}
