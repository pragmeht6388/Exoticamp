using FluentValidation;
using Exoticamp.Application.Contracts.Persistence;
using Exoticamp.Application.Features.Customer.Commands.CreateCustomer;

namespace Exoticamp.Application.Features.Customer.Commands.CreateCustomer
{
    public class CreateCustomerCommandValidator : AbstractValidator<CreateCustomerCommand>
    {
        private readonly IMessageRepository _messageRepository;

        public CreateCustomerCommandValidator(IMessageRepository messageRepository)
        {
            _messageRepository = messageRepository;

            RuleFor(p => p.MobileNumber)
                .NotEmpty().WithMessage("Mobile number is required.")
                .Matches(@"^\+?[1-9]\d{1,14}$").WithMessage("Invalid mobile number format."); // Example format validation

            RuleFor(p => p.CreatedDate)
                .NotEmpty().WithMessage("Created date is required.")
                .LessThanOrEqualTo(DateTime.Now).WithMessage("Created date cannot be in the future.");

            RuleFor(p => p.OTPNO)
                .GreaterThan(0).WithMessage("OTP number must be greater than zero.");

            RuleFor(p => p.CreatedBy)
                .NotEmpty().WithMessage("Created by is required.")
                .MaximumLength(100).WithMessage("Created by cannot exceed 100 characters."); // Adjust length as needed

            RuleFor(p => p.ICNumber)
                .NotEmpty().WithMessage("IC number is required.")
                .GreaterThan(0).WithMessage("IC number must be a positive integer.");
        }
    }
}
