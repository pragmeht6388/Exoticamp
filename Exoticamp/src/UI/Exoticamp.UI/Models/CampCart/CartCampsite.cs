using Exoticamp.UI.Models.CampsiteDetails;
using Exoticamp.UI.Models.Location;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace Exoticamp.UI.Models.CampCart
{
    public class CartCampsite
    {
        public Guid? CartId { get; set; }

        public string? UserId { get; set; }


        [Required(ErrorMessage = "Please enter name")]
        [StringLength(50, MinimumLength = 3)]
        public string CustomerName { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please select the date")]
        [DataType(DataType.Date)]
        [CustomValidation(typeof(CartCampsite), nameof(ValidateStartDate))]
        public DateOnly CheckIn { get; set; }

        [Required(ErrorMessage = "Please select the date")]
        [DataType(DataType.Date)]
        [CustomValidation(typeof(CartCampsite), nameof(ValidateEndDate))]
        public DateOnly CheckOut { get; set; }

        [Required(ErrorMessage = "Enter the number of adults")]
        public int NoOfAdults { get; set; }

        [Required(ErrorMessage = "Enter the number of children")]
        public int NoOfChildren { get; set; }

        [Required(ErrorMessage = "Enter the number of tents")]
        public int NoOfTents { get; set; }

        public decimal TotalPrice { get; set; }

        public string? GlampingType { get; set; }
        public decimal? PriceForAdults { get; set; }
        public decimal? PriceForChildren { get; set; }
        public decimal? PriceForTents { get; set; }

        public DateTime CreatedDate { get; set; }
        public string Status { get; set; }

        [Required(ErrorMessage = "Select campsite")]
        public Guid CampsiteId { get; set; }

        [Required(ErrorMessage = "Select location")]
        public Guid? LocationId { get; set; }

        public CampsiteDetailsVM? Campsite { get; set; }
        public LocationVM? Location { get; set; }

        public SelectList? LocationsList { get; set; }
        public SelectList? CampsitesList { get; set; }

        public static ValidationResult ValidateStartDate(DateOnly checkin, ValidationContext context)
        {
          
      
            return ValidationResult.Success;
        }

        public static ValidationResult ValidateEndDate(DateTime checkout, ValidationContext context)
        {
          
            return ValidationResult.Success;
        }

        public void CalculateTotalPrice()
        {
            decimal priceForAdults = PriceForAdults ?? 0;
            decimal priceForChildren = PriceForChildren ?? 0;

            TotalPrice = (NoOfAdults * priceForAdults) + (NoOfChildren * priceForChildren) + (NoOfTents * 100); // Assume $100 per tent
        }
    }
}
