using Exoticamp.UI.Models.Events;
using Newtonsoft.Json;

namespace Exoticamp.UI.Models.ResponseModels.Events
{
    public class GetAllEventResponseModel
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
            public IEnumerable<EventVM> Data { get; set; }
        
    }
}
