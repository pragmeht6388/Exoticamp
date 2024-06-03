

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Exoticamp.UI.Models.Events
{
    public class EventVM
    {
        public string? EventId { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 3)]
        public string Name { get; set; }

        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Price must be greater than zero.")]
        public decimal Price { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Capacity must be at least 1.")]
        public int Capacity { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [CustomValidation(typeof(EventVM), nameof(ValidateStartDate))]
        public DateTime StartDate { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [CustomValidation(typeof(EventVM), nameof(ValidateEndDate))]
        public DateTime EndDate { get; set; }

        [Required]
        [StringLength(500)]
        public string Description { get; set; }
        [NotMapped]
        public IFormFile Image { get; set; }
       
        public string? ImageUrl { get; set; }

        [Required]
        [StringLength(500)]
        public string Highlights { get; set; }

        [Required]
        [StringLength(500)]
        public string EventRules { get; set; }
        //public Guid CampsiteId { get; set; }
        //public Category Campsite { get; set; }
        //public Guid ActivityId { get; set; }
        //public Activity activity { get; set; }
        // public Guid LocationId { get; set; }
        //public Location location { get; set; }



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
