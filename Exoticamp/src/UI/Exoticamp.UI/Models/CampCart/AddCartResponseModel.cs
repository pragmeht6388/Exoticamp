using Newtonsoft.Json;

namespace Exoticamp.UI.Models.CampCart
{
    public class AddCartResponseModel
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
        public CartCampsite Data { get; set; }
    }
}
