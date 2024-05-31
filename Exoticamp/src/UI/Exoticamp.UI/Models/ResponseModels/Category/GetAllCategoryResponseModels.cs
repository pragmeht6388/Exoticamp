using Exoticamp.UI.Models.CampsiteDetails;
using Exoticamp.UI.Models.Category;
using Newtonsoft.Json;
using System.ComponentModel;

namespace Exoticamp.UI.Models.ResponseModels.Category
{
    public class GetAllCategoryResponseModels
    {
        [JsonProperty("succeeded")]
        [DefaultValue(false)]
        public bool Succeeded { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("errors")]
        public List<string> Errors { get; set; }

        [JsonProperty("data")]
        public IEnumerable<CategoryVM> Data { get; set; }
    }
}
