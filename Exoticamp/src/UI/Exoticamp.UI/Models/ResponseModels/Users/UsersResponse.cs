using Exoticamp.UI.Models.Events;
using Exoticamp.UI.Models.Users;
using Newtonsoft.Json;

namespace Exoticamp.UI.Models.ResponseModels.Users

{
    public class UsersResponse
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
        public IEnumerable<UsersVM> Data { get; set; }
    }
}
