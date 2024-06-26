﻿using Exoticamp.UI.Models.CampsiteDetails;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Exoticamp.UI.Models.Events
{
    public class AddEventVM
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

        [Required(ErrorMessage = "Please select the date")]
        [DataType(DataType.Date)]
        [CustomValidation(typeof(EventVM), nameof(ValidateEndDate))]
        public DateTime EndDate { get; set; }

        [Required(ErrorMessage = "“Enter description of the event”")]
        [StringLength(250)]
        public string Description { get; set; }

        [NotMapped]
        // public List<IFormFile> Image { get; set; }
        public IFormFile Image { get; set; }

        public string? ImageUrl { get; set; }
       // public List<string>? ImageUrl { get; set; }

        [Required(ErrorMessage = "enter highlights of the event")]
        [StringLength(100)]
        public string Highlights { get; set; }

        [Required(ErrorMessage = "enter rules of the event")]
        [StringLength(100)]
        public string EventRules { get; set; }
        [Required(ErrorMessage = "Please select the  campsite")]
        //public Guid? CampsiteId { get; set; }

        public List<Guid>? CampsiteIds { get; set; }

        [Required(ErrorMessage = "Please select activities")]
        //public Guid? ActivityId { get; set; }
        public List<Guid>? ActivityIds { get; set; }

        [Required(ErrorMessage = "Please select a location")]
        public Guid? LocationId { get; set; }
        public bool Status { get; set; }
        public bool IsDeleted { get; set; }
        public CampsiteDetailsVM? Campsite { get; set; }



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

        public SelectList? ActivitiesVMs { get; set; }
        public SelectList? Locations { get; set; }
        public SelectList? Campsites { get; set; }

        public EventLocationDto? EventLocationDto { get; set; }
        public EventActivityDto? EventActivityDto { get; set; }
    }
    //public class EventLocationDto
    //{
    //    public Guid? Id { get; set; }
    //    public Guid LocationId { get; set; }
    //    public LocationDetails LocationDetails { get; set; }


    //}
    //public class LocationDetails
    //{
    //    [JsonProperty("name")]
    //    public string Name { get; set; }

    //}
    //public class EventActivityDto
    //{
    //    public Guid? Id { get; set; }
    //    public Guid ActivityId { get; set; }
    //    public ActivityDetails ActivityDetails { get; set; }

    //}
    //public class ActivityDetails
    //{
    //    [JsonProperty("name")]
    //    public string Name { get; set; }

    //}
}
