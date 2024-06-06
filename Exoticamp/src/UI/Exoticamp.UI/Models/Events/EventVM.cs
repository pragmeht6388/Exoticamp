

using Exoticamp.Domain.Entities;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Exoticamp.UI.Models.Events
{
    public class EventVM
    {
        public string? EventId { get; set; }

        [Required(ErrorMessage = "Please enter event name")]
        [StringLength(50, MinimumLength = 3)]
        public string Name { get; set; }

        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Price must be greater than zero.")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Select number of person capacity")]
        [Range(1, int.MaxValue, ErrorMessage = "Capacity must be at least 1.")]
        public int Capacity { get; set; }

        [Required(ErrorMessage = "Please select the date")]
        [DataType(DataType.Date)]
        [CustomValidation(typeof(EventVM), nameof(ValidateStartDate))]
        public DateTime StartDate { get; set; }

        [Required (ErrorMessage = "Please select the date")]
        [DataType(DataType.Date)]
        [CustomValidation(typeof(EventVM), nameof(ValidateEndDate))]
        public DateTime EndDate { get; set; }

        [Required (ErrorMessage = "“Enter description of the event”")]
        [StringLength(250)]
        public string Description { get; set; }
        [Required(ErrorMessage = "upload the images of the event")]
        [NotMapped]
        public IFormFile Image { get; set; }
       
        public string? ImageUrl { get; set; }

        [Required(ErrorMessage = "enter highlights of the event")]
        [StringLength(100)]
        public string Highlights { get; set; }

        [Required(ErrorMessage = "enter rules of the event")]
        [StringLength(100)]
        public string EventRules { get; set; }
        [Required(ErrorMessage = "Please select the  campsite")]
        public Guid CampsiteId { get; set; }
        public Domain.Entities. CampsiteDetails Campsite { get; set; }
        [Required(ErrorMessage = "Please select activities")]
        public Guid ActivityId { get; set; }
        public Domain.Entities.Activities activity { get; set; }
        [Required(ErrorMessage = "Please select a location")]
        public string location { get; set; }
        public bool Status { get; set; }



        public static ValidationResult ValidateStartDate(DateTime startDate, ValidationContext context)
        {
            if (startDate <= DateTime.Now)
            {
                return new ValidationResult("Start date must be greater than the current date.");
            }
            return ValidationResult.Success;
        }

        public static ValidationResult ValidateEndDate(DateTime endDate, ValidationContext context)
        {
            var instance = context.ObjectInstance as EventVM;
            if (instance != null && endDate <= instance.StartDate)
            {
                return new ValidationResult("End date must be greater than the start date.");
            }
            return ValidationResult.Success;
        }
    }
}
