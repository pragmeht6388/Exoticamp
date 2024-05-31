using Exoticamp.UI.Models.Events;
using Exoticamp.UI.Models.Registration;
using Newtonsoft.Json;
using System.ComponentModel;

namespace Exoticamp.UI.Models.ResponseModels.Events
{
    public class CreateRegistrationUsResponse
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
        public  RegistrationVM Data { get; set; }
        [JsonProperty("succeeded")]
        [DefaultValue(false)]
        public bool Succeeded { get; set; }
    }
}
