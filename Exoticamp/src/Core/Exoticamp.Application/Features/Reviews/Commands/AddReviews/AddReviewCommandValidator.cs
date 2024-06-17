using Exoticamp.Application.Contracts.Persistence;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exoticamp.Application.Features.Reviews.Commands.AddReviews
{

    public class AddReviewCommandValidator : AbstractValidator<AddReviewCommand>
    {
        private readonly IMessageRepository _messageRepository;
        public AddReviewCommandValidator(IMessageRepository messageRepository)
        {
            _messageRepository = messageRepository;
            RuleFor(r => r.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(100).WithMessage("{PropertyName} must not exceed 100 characters.");

            RuleFor(r => r.DateTime)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .Must(date => date <= DateTime.Now).WithMessage("{PropertyName} must be in the past.");

            RuleFor(r => r.Ratings)
                .InclusiveBetween(1, 5).WithMessage("{PropertyName} must be between 1 and 5.");

            RuleFor(r => r.Description)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(1000).WithMessage("{PropertyName} must not exceed 1000 characters.");

        }
    }
}


