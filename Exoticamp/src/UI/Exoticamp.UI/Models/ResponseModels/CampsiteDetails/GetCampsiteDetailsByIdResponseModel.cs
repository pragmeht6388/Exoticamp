using Exoticamp.UI.Models.CampsiteDetails;
using Newtonsoft.Json;
using System.ComponentModel;

namespace Exoticamp.UI.Models.ResponseModels.CampsiteDetails
{
    public class GetCampsiteDetailsByIdResponseModel
    {
        [JsonProperty("succeeded")]
        [DefaultValue(false)]
        public bool Succeeded { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("errors")]
        public List<string> Errors { get; set; }

        [JsonProperty("data")]
        public CampsiteDetailsVM Data { get; set; }
    }
}
