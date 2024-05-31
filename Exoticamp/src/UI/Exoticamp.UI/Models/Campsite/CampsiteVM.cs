using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Exoticamp.UI.Models.Campsite
{
    public class CampsiteVM
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }

        [JsonProperty("name")]
        [Required(ErrorMessage = "Name is Required")]
        [StringLength(100, ErrorMessage = "Name length can't be more than 100 characters.")]
        public string Name { get; set; }

        [JsonProperty("location")]
        [Required(ErrorMessage = "Location is Required")]
        public string Location { get; set; }

        [JsonProperty("status")]
        public bool Status { get; set; }

        [JsonProperty("tentType")]
        public string TentType { get; set; }

        [JsonProperty("isActive")]
        public bool? isActive { get; set; } //whether it is deleted or not

        [JsonProperty("approvedBy")]
        public string? ApprovedBy { get; set; }

        [JsonProperty("approvededDate")]
        public DateTime? ApprovededDate { get; set; }

        [JsonProperty("deletededBy")]
        public string? DeletededBy { get; set; }

        [JsonProperty("deletedDate")]
        public DateTime? DeletedDate { get; set; }
    }
}
