using Exoticamp.UI.Models.Campsite;
using Newtonsoft.Json;
using System.ComponentModel;

namespace Exoticamp.UI.Models.ResponseModels.Campsite
{
    public class DeleteCampsiteResponseModel
    {
        [JsonProperty("succeeded")]
        [DefaultValue(false)]
        public bool Succeeded { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("errors")]
        public List<string> Errors { get; set; }

        [JsonProperty("data")]
        public CampsiteVM Data { get; set; }
    }
}
