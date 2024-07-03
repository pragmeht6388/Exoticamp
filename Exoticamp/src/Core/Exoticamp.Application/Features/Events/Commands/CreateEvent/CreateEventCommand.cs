using MediatR;
using System;
using Exoticamp.Application.Responses;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Exoticamp.Application.Features.Events.Commands.CreateEvent
{
    public class CreateEventCommand : IRequest<Response<CreateEventCommandDto>>
    {



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
        [CustomValidation(typeof(CreateEventCommand), nameof(ValidateStartDate))]
        public DateTime StartDate { get; set; }

        [Required(ErrorMessage = "Please select the date")]
        [DataType(DataType.Date)]
        [CustomValidation(typeof(CreateEventCommand), nameof(ValidateEndDate))]
        public DateTime EndDate { get; set; }

        [Required(ErrorMessage = "“Enter description of the event”")]
        [StringLength(250)]
        public string Description { get; set; }
        [Required(ErrorMessage = "upload the images of the event")]



        public string? ImageUrl { get; set; } 

        [Required(ErrorMessage = "enter highlights of the event")]
        [StringLength(100)]
        public string Highlights { get; set; }

        [Required(ErrorMessage = "enter rules of the event")]
        [StringLength(100)]
        public string EventRules { get; set; }
        [Required(ErrorMessage = "Please select the  campsite")]
        public List<Guid> CampsiteIds { get; set; } = new List<Guid>();

        [Required(ErrorMessage = "Please select activities")]
        public List<Guid> ActivityIds { get; set; } = new List<Guid>();

        [Required(ErrorMessage = "Please select a location")]
        public Guid LocationId { get; set; }
        public bool Status { get; set; }
        public bool IsDeleted { get; set; }
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
            var instance = context.ObjectInstance as CreateEventCommand;
            if (instance != null && endDate <= instance.StartDate)
            {
                return new ValidationResult("End date must be greater than the start date.");
            }
            return ValidationResult.Success;
        }

    }
}
