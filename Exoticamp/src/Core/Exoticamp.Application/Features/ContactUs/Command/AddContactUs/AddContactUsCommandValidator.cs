using Exoticamp.Application.Contracts.Persistence;
using Exoticamp.Application.Helper;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exoticamp.Application.Features.ContactUs.Command.AddContactUs
{
    internal class AddContactUsCommandValidator : AbstractValidator<AddContactUsCommand>
    {
        private readonly IMessageRepository _messageRepository;

        public AddContactUsCommandValidator(IMessageRepository messageRepository)
        {
            _messageRepository = messageRepository;

            RuleFor(p => p.Name)
              .NotEmpty().WithMessage("{PropertyName} is required.")
              .NotNull()
              .MaximumLength(100).WithMessage("{PropertyName} must not exceed 100 characters.")
              .Matches(@"^[^\d]*$").WithMessage("{PropertyName} should not contain numeric values."); // Custom validation

            RuleFor(p => p.Email)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(100).WithMessage("{PropertyName} must not exceed 100 characters.")
                .EmailAddress().WithMessage("Invalid {PropertyName} format."); // Added email format validation

            RuleFor(p => p.Message)
               .NotEmpty().WithMessage("{PropertyName} is required.")
               .NotNull()
               .MaximumLength(1000).WithMessage("{PropertyName} must not exceed 1000 characters.");
        }
         
    }
}
