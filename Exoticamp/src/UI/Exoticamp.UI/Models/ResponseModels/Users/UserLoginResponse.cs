using Exoticamp.UI.Models.Login;
using Exoticamp.UI.Models.Registration;
using Newtonsoft.Json;
using System.ComponentModel;

namespace Exoticamp.UI.Models.ResponseModels.Users
{
    public class UserLoginResponse
    {
        public bool IsAuthenticated { get; set; }

        public string Role { get; set; }
        public string UserId { get; set; }


        [JsonProperty("isSuccess")]
        public bool IsSuccess { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("token")]
        public string Token { get; set; }

        [JsonProperty("statusCode")]
        public string StatusCode { get; set; }

        [JsonProperty("data")]
        public  LoginVM Data { get; set; }
        [JsonProperty("succeeded")]
        [DefaultValue(false)]
        public bool Succeeded { get; set; }
    }
}
