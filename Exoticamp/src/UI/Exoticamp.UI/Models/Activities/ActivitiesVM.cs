using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Exoticamp.UI.Models.Activities
{
    public class ActivitiesVM
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }

        [JsonProperty("name")]
        [Required(ErrorMessage = "Name is Required")]
        [StringLength(100, ErrorMessage = "Name length can't be more than 100 characters.")]
        public string Name { get; set; }

       // public ICollection<CampsiteDetails> CampsiteDetails { get; set; } = new List<CampsiteDetails>();
    }
}
