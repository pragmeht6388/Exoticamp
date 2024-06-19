using Exoticamp.UI.Helper;
using Exoticamp.UI.Models.Booking;
using Exoticamp.UI.Models.ResponseModels;
using Exoticamp.UI.Models.ResponseModels.Booking;
using Exoticamp.UI.Services.IRepositories;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

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


   
    }
}
