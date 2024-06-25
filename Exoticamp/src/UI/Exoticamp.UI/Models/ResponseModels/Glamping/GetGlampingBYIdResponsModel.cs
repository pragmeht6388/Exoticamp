using Exoticamp.UI.Models.Glamping;
using Newtonsoft.Json;

namespace Exoticamp.UI.Models.ResponseModels.Glamping
{
    public class GetGlampingBYIdResponsModel
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
        public GlampingVM Data { get; set; } // Changed to a single GlampingVM
    }
}
