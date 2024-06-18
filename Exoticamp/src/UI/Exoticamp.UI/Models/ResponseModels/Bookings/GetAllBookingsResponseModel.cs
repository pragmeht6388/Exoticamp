using Exoticamp.UI.Models.Banners;
using Exoticamp.UI.Models.Booking;
using Newtonsoft.Json;

namespace Exoticamp.UI.Models.ResponseModels.Booking
{
    public class GetAllBookingsResponseModel
    {
        [JsonProperty("isSuccess")]
        public bool IsSuccess { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("token")]
        public string Token { get; set; }

        [JsonProperty("statusCode")]
        public string StatusCode { get; set; }

        [JsonProperty("data")]
        public IEnumerable<BookingVM> Data { get; set; }
    }
}
