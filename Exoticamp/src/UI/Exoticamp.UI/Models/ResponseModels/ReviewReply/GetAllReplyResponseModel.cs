using Exoticamp.UI.Models.ReviewReply;
using Newtonsoft.Json;
using System.ComponentModel;

namespace Exoticamp.UI.Models.ResponseModels.ReviewReply
{
    public class GetAllReplyResponseModel
    {
        [JsonProperty("succeeded")]
        [DefaultValue(false)]
        public bool Succeeded { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("errors")]
        public List<string> Errors { get; set; }

        [JsonProperty("data")]
        public IEnumerable<ReviewReplyVM> Data { get; set; }
    }
}
