using Newtonsoft.Json;

namespace Exoticamp.UI.Models.CampCart
{
    public class AllCartResponseModel
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
        public IEnumerable<CartCampsite> Data { get; set; }
    }
}
