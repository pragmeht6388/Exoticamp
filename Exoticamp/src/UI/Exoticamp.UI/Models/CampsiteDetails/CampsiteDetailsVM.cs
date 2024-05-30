using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace Exoticamp.UI.Models.CampsiteDetails
{
    public class CampsiteDetailsVM
    {
        [Key]
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

        [JsonProperty("images")]
        public string Images { get; set; }

        [JsonProperty("dateTime")]
        public DateTime DateTime { get; set; }

        [JsonProperty("highlights")]
        public string Highlights { get; set; }

        [JsonProperty("ratings")]
        public string Ratings { get; set; }

        [JsonProperty("aboutCampsite")]
        public string AboutCampsite { get; set; }

        [JsonProperty("campsiteRules")]
        public string CampsiteRules { get; set; }

        [JsonProperty("bestTimeToVisit")]
        public string BestTimeToVisit { get; set; }

        [JsonProperty("howToGetHere")]
        public string HowToGetHere { get; set; }

        [JsonProperty("quickSummary")]
        public string QuickSummary { get; set; }

        [JsonProperty("categoryId")]
        public Guid CategoryId { get; set; }

        [ForeignKey(nameof(CategoryId))]
        //[JsonProperty("categories")]
        //public ICollection<Category> Categories { get; set; }

        [JsonProperty("activitiesId")]
        public Guid ActivitiesId { get; set; }

        [ForeignKey(nameof(ActivitiesId))]
        //[JsonProperty("activities")]
        //public ICollection<Activities> Activities { get; set; }

        [JsonProperty("mealPlans")]
        public string MealPlans { get; set; }

        [JsonProperty("itinerary")]
        public string Itinerary { get; set; }

        [JsonProperty("inclusions")]
        public string Inclusions { get; set; }

        [JsonProperty("exclusion")]
        public string Exclusion { get; set; }

        [JsonProperty("amenities")]
        public string Amenities { get; set; }

        [JsonProperty("accommodation")]
        public string Accommodation { get; set; }

        [JsonProperty("safety")]
        public string Safety { get; set; }

        [JsonProperty("distanceWithMap")]
        public string DistanceWithMap { get; set; }

        [JsonProperty("whyExoticamp")]
        public string WhyExoticamp { get; set; }

        [JsonProperty("faqs")]
        public string FAQs { get; set; }

        [JsonProperty("houseRules")]
        public string HouseRules { get; set; }

        [JsonProperty("cancellationPolicy")]
        public string CancellationPolicy { get; set; }

        [JsonProperty("isActive")]
        public bool? IsActive { get; set; }

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
