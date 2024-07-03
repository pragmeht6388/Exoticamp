using Exoticamp.Domain.Entities;
using Exoticamp.UI.Models.Events;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Exoticamp.UI.Models.EventCart
{
    public class EventCartVM
    {
        [Key]
        [JsonProperty("cartId")]
        public Guid CartId { get; set; }

        [JsonProperty("userId")]
        public Guid? UserId { get; set; }

        [JsonProperty("customerName")]
        public string? CustomerName { get; set; }

        [JsonProperty("email")]
        public string? Email { get; set; }

        [JsonProperty("checkIn")]
        public DateOnly CheckIn { get; set; }

        [JsonProperty("checkOut")]
        public DateOnly CheckOut { get; set; }

        [JsonProperty("noOfAdults")]
        public int? NoOfAdults { get; set; }

        [JsonProperty("noOfChildrens")]
        public int? NoOfChildrens { get; set; }

        [JsonProperty("noOfTents")]
        public int? NoOfTents { get; set; }

        [JsonProperty("totalPrice")]
        public decimal TotalPrice { get; set; }

        [JsonProperty("status")]
        public string? Status { get; set; }

        [JsonProperty("locationId")]
        public Guid? LocationId { get; set; }

        [JsonProperty("eventId")]
        public Guid? EventId { get; set; }
        [JsonProperty("eventName")]
        public Guid? EventName { get; set; }

        [JsonProperty("event")]
        public virtual EventVM Event { get; set; }

        [JsonProperty("glampingId")]
        public Guid? GlampingId { get; set; }

        [JsonProperty("noOfGlamps")]
        public int? NoOfGlamps { get; set; }

        [JsonProperty("guestDetailsId")]
        public Guid? GuestDetailsId { get; set; }

        [JsonProperty("isActive")]
        public bool? IsActive { get; set; }

        // Additional properties with JsonProperty
        [JsonProperty("approvedBy")]
        public string? ApprovedBy { get; set; }

        [JsonProperty("approvededDate")]
        public DateTime? ApprovededDate { get; set; }

        [JsonProperty("createdBy")]
        public string? CreatedBy { get; set; }

        [JsonProperty("deletededBy")]
        public string? DeletededBy { get; set; }

        [JsonProperty("deletedDate")]
        public DateTime? DeletedDate { get; set; }



        // Navigation properties should not have JsonProperty unless needed for specific serialization purposes
        public virtual GuestDetails? GuestDetails { get; set; }
        public virtual Domain.Entities.Location Location { get; set; }

        public decimal? PriceForAdults { get; set; }
        public decimal? PriceForChildrens { get; set; }


        public void CalculateTotalPrice()
        {
            decimal priceForAdults = PriceForAdults ?? 0;
            decimal priceForChildren = PriceForChildrens ?? 0;

            TotalPrice = (NoOfAdults * priceForAdults) + (NoOfChildrens * priceForChildren) ?? 0; // Assume $100 per tent
        }
    }
}
