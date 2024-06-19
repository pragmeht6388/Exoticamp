using Exoticamp.UI.Models.Location;
using Exoticamp.UI.Models.Search;
using Newtonsoft.Json;

namespace Exoticamp.UI.Models.ResponseModels.Search
{
    public class SearchResponseModel
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
        public SearchDto Data { get; set; }
    }
}
