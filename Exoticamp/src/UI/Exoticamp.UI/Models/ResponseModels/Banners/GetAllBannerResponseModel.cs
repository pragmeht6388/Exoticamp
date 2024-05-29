using Exoticamp.UI.Models.Banners;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Exoticamp.UI.Models.ResponseModels.Banners
{
    public class GetAllBannerResponseModel
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
        public IEnumerable<BannerViewModel> Data { get; set; }
    }
}
