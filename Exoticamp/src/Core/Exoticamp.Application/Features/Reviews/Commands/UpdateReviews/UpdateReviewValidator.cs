using Exoticamp.Application.Contracts.Persistence;
using Exoticamp.Application.Features.CampsiteDetails.Commands.UpdateCampsite;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exoticamp.Application.Features.Reviews.Commands.UpdateReviews
{
    public class UpdateReviewValidator : AbstractValidator<UpdateReviewCommand>
    {
        private readonly IMessageRepository _messageRepository;

        public UpdateReviewValidator(IMessageRepository messageRepository)
        {
            _messageRepository = messageRepository;

            RuleFor(p => p.Name)
               .NotEmpty().WithMessage("{PropertyName} is required.")
               .NotNull()
               .MaximumLength(100).WithMessage("{PropertyName} must not exceed 100 characters.");

            RuleFor(p => p.Description)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .MaximumLength(100).WithMessage("{PropertyName} must not exceed 100 characters.");

            RuleFor(p => p.Ratings)
                .NotEmpty().WithMessage("{PropertyName} is required.");
        }
        }
    }
