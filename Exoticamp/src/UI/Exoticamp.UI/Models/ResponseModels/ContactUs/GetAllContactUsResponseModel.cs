using Exoticamp.UI.Models.ContactUs;
using Exoticamp.UI.Models.Events;
using Newtonsoft.Json;
using System.ComponentModel;

namespace Exoticamp.UI.Models.ResponseModels.ContactUs
{
    public class GetAllContactUsResponseModel
    {
        [JsonProperty("succeeded")]
        [DefaultValue(false)]
        public bool Succeeded { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("errors")]
        public List<string> Errors { get; set; }

        [JsonProperty("data")]
        public IEnumerable<ContactUsVM> Data { get; set; }
    }
}
