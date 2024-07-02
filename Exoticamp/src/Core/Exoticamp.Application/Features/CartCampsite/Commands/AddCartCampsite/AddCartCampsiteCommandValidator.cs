using Exoticamp.Application.Features.CartCampsite.Commands.AddCartCampsite;
using Exoticamp.Application.Contracts.Persistence;
using FluentValidation;

namespace Exoticamp.Application.Features.CartCampsite.Commands.AddCartCampsite
{
    public class AddCartCampsiteCommandValidator : AbstractValidator<AddCartCampsite>
    {
        private readonly IMessageRepository _messageRepository;

        public AddCartCampsiteCommandValidator(IMessageRepository messageRepository)
        {
            _messageRepository = messageRepository;

            RuleFor(x => x.UserId).NotEmpty().WithMessage("User ID is required.");
            RuleFor(x => x.CheckIn).NotEmpty().WithMessage("Check-in date is required.");
            RuleFor(x => x.CheckOut).NotEmpty().WithMessage("Check-out date is required.");
            RuleFor(x => x.TotalPrice).GreaterThan(0).WithMessage("Total price must be greater than zero.");
            // Add other validation rules as needed
        }
    }
}
