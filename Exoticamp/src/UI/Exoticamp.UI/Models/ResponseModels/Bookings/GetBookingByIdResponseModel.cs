using Exoticamp.UI.Models.Booking;
using Newtonsoft.Json;

namespace Exoticamp.UI.Models.ResponseModels.Bookings
{
    public class GetBookingByIdResponseModel
    {

        [JsonProperty("Succeeded")]
        public bool Succeeded { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("token")]
        public string Token { get; set; }

        [JsonProperty("statusCode")]
        public string StatusCode { get; set; }

        [JsonProperty("data")]
        public BookingVM Data { get; set; }
    }
}
