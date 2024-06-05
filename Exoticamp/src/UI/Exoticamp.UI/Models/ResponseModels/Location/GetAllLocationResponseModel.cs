
using Exoticamp.UI.Models.Location;
using Newtonsoft.Json;

namespace Exoticamp.UI.Models.ResponseModels.Location
{
    public class GetAllLocationResponseModel
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
        public IEnumerable<LocationVM> Data { get; set; }
    }
}
