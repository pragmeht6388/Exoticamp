using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Exoticamp.UI.Models.Category
{
    public class CategoryVM
    {
        [Key]
        [JsonProperty("categoryId")]
        public Guid CategoryId { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("events")]
        public ICollection<Models.Events.EventVM> Events { get; set; }

        [JsonProperty("campsiteDetails")]
        public ICollection<Models.CampsiteDetails.CampsiteDetailsVM> CampsiteDetails { get; set; }
    }
}
