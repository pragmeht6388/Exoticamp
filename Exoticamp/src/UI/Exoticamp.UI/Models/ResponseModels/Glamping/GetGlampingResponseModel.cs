using Exoticamp.UI.Models.Glamping;
using Exoticamp.UI.Services.Repositories;
using Newtonsoft.Json;

namespace Exoticamp.UI.Models.ResponseModels.Glamping
{
    public class GetGlampingResponseModel
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
        public IEnumerable< GlampingVM> Data { get; set; }
         
    }
}
