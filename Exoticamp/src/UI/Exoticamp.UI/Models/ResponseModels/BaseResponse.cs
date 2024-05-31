using Newtonsoft.Json;
using System.Net;

namespace Exoticamp.UI.Models.ResponseModels
{
    public class Response<T>
    {
        public HttpStatusCode statusCode { get; set; }
        public T data { get; set; }
        public String Message { get; set; }
        public Boolean Success { get; set; }
        public string NotificationType { get; set; }
        public string ReturnToUrl { get; set; }
        private List<ErrorMessage> ErrorMessages { get; set; }
        private string Token { get; set; }

    }

    public class ErrorMessage
    {
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Code { get; }

        public string Message { get; }

        public ErrorMessage(string code, string message)
        {
            Code = code != string.Empty ? code : null;
            Message = message;
        }
    }
}
