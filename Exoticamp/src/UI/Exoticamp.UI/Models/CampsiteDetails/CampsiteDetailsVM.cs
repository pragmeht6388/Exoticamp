using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using Exoticamp.UI.Models.Activities;

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
        [RegularExpression(@"^[a-zA-Z\s]*$", ErrorMessage = "Name should contain only alphabets and space")]
        public string Name { get; set; }

        [JsonProperty("location")]
        [Required(ErrorMessage = "Location is Required")]
        public string Location { get; set; }

        [JsonProperty("locationId")]
        public Guid LocationId { get; set; }

        [JsonProperty("status")]
        public bool Status { get; set; }

        [JsonProperty("tentName")]

        public string TentName { get; set; }
        [JsonProperty("tentId")]
        public Guid TentId { get; set; }

        [JsonProperty("noOfTents")]
        public int NoOfTents { get; set; }

        [JsonProperty("price")]
        public decimal Price { get; set; }

        [NotMapped]
        public IFormFile? ImageFile { get; set; }

        [JsonProperty("images")]
        public string? Images { get; set; }

        [JsonProperty("dateTime")]
        [FutureDate(ErrorMessage = "Please select a future date")]
        public DateTime DateTime { get; set; }

        [JsonProperty("highlights")]
        public string Highlights { get; set; }

        [JsonProperty("ratings")]
        [Range(0, 5, ErrorMessage = "Rating should be a number between 0 and 5")]

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
        [JsonProperty("CategoryName")]
        public string CategoryName { get; set; }

        [ForeignKey(nameof(CategoryId))]

        [JsonProperty("activitiesId")]
        public Guid ActivitiesId { get; set; }

        [JsonProperty("activitiesName")]
        public string ActivityName { get; set; }

        [ForeignKey(nameof(ActivitiesId))]


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
        [JsonProperty("CreatedBy")]
        public string CreatedBy {  get; set; }

        [JsonProperty("deletededBy")]
        public string? DeletededBy { get; set; }

        [JsonProperty("deletedDate")]
        public DateTime? DeletedDate { get; set; }

        [JsonProperty("activities")]
        public List<ActivitiesVM> Activities { get; set; }


        public class FutureDateAttribute : ValidationAttribute
        {
            public override bool IsValid(object value)
            {
                DateTime dateTime = Convert.ToDateTime(value);
                return dateTime >= DateTime.Now;
            }
        }
    }
}
