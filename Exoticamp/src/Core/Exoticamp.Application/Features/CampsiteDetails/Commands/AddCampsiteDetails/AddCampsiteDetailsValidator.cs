using Exoticamp.Application.Contracts.Persistence;
using Exoticamp.Application.Features.Campsite.Commands.AddCampsite;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exoticamp.Application.Features.CampsiteDetails.Commands.AddCampsiteDetails
{
    internal class AddCampsiteDetailsCommandValidator : AbstractValidator<AddCampsiteDetailsCommand>
    {
        private readonly IMessageRepository _messageRepository;

        public AddCampsiteDetailsCommandValidator(IMessageRepository messageRepository)
        {
            _messageRepository = messageRepository;

            RuleFor(p => p.Name)
               .NotEmpty().WithMessage("{PropertyName} is required.")
               .NotNull()
               .MaximumLength(100).WithMessage("{PropertyName} must not exceed 100 characters.")
               .Matches(@"^[^\d]*$").WithMessage("{PropertyName} should not contain numeric values."); // Custom validation
            ;

            RuleFor(p => p.Location)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(100).WithMessage("{PropertyName} must not exceed 100 characters.");
           
            //RuleFor(p => p.TentType)
            //    .NotEmpty().WithMessage("{PropertyName} is required.");

            RuleFor(p => p.Price)
              .NotEmpty().WithMessage("{PropertyName} is required.");

            RuleFor(p => p.Images)
                .NotEmpty().WithMessage("{PropertyName} is required.");

            RuleFor(p => p.DateTime)
                .NotEmpty().WithMessage("{PropertyName} is required.");

            RuleFor(p => p.Highlights)
                .NotEmpty().WithMessage("{PropertyName} is required.");

            RuleFor(p => p.Ratings)
                .NotEmpty().WithMessage("{PropertyName} is required.");

            RuleFor(p => p.AboutCampsite)
                .NotEmpty().WithMessage("{PropertyName} is required.");

            RuleFor(p => p.CampsiteRules)
                .NotEmpty().WithMessage("{PropertyName} is required.");

            RuleFor(p => p.BestTimeToVisit)
                .NotEmpty().WithMessage("{PropertyName} is required.");

            RuleFor(p => p.HowToGetHere)
                .NotEmpty().WithMessage("{PropertyName} is required.");

            RuleFor(p => p.QuickSummary)
                .NotEmpty().WithMessage("{PropertyName} is required.");

            RuleFor(p => p.MealPlans)
                .NotEmpty().WithMessage("{PropertyName} is required.");

            RuleFor(p => p.Itinerary)
                .NotEmpty().WithMessage("{PropertyName} is required.");

            RuleFor(p => p.Inclusions)
                .NotEmpty().WithMessage("{PropertyName} is required.");

            RuleFor(p => p.Exclusion)
                .NotEmpty().WithMessage("{PropertyName} is required.");

            RuleFor(p => p.Amenities)
                .NotEmpty().WithMessage("{PropertyName} is required.");

            RuleFor(p => p.Accommodation)
                .NotEmpty().WithMessage("{PropertyName} is required.");

            RuleFor(p => p.Safety)
                .NotEmpty().WithMessage("{PropertyName} is required.");

            RuleFor(p => p.DistanceWithMap)
                .NotEmpty().WithMessage("{PropertyName} is required.");

            RuleFor(p => p.WhyExoticamp)
                .NotEmpty().WithMessage("{PropertyName} is required.");

            RuleFor(p => p.FAQs)
                .NotEmpty().WithMessage("{PropertyName} is required.");

            RuleFor(p => p.HouseRules)
                .NotEmpty().WithMessage("{PropertyName} is required.");

            RuleFor(p => p.CancellationPolicy)
                .NotEmpty().WithMessage("{PropertyName} is required.");

            // Add custom validation rule for isActive
            //RuleFor(p => p.isActive)
            //    .NotNull().WithMessage("{PropertyName} is required.");

            // Add custom validation rule for ApprovedBy
            //RuleFor(p => p.ApprovedBy)
            //    .NotEmpty().WithMessage("{PropertyName} is required.")
            //    .When(p => p.isActive == true);

            //// Add custom validation rule for ApprovededDate
            //RuleFor(p => p.ApprovededDate)
            //    .NotEmpty().WithMessage("{PropertyName} is required.")
            //    .When(p => p.isActive == true);

            //// Add custom validation rule for DeletededBy
            //RuleFor(p => p.DeletededBy)
            //    .NotEmpty().WithMessage("{PropertyName} is required.")
            //    .When(p => p.isActive == false);

            //// Add custom validation rule for DeletedDate
            //RuleFor(p => p.DeletedDate)
            //    .NotEmpty().WithMessage("{PropertyName} is required.")
            //    .When(p => p.isActive == false);
        }



    }
}
