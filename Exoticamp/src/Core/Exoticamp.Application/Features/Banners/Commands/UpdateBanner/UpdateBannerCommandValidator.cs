using FluentValidation;
using Exoticamp.Application.Contracts.Persistence;

namespace Exoticamp.Application.Features.Banners.Commands.UpdateBanner
{
    public class UpdateBannerCommandValidator : AbstractValidator<UpdateBannerCommand>
    {
        private readonly IMessageRepository _messageRepository;

        public UpdateBannerCommandValidator(IMessageRepository messageRepository)
        {
            _messageRepository = messageRepository;

            RuleFor(x => x.Link)
                .NotEmpty().WithMessage("Link is required.")
                .MaximumLength(2048).WithMessage("Link cannot exceed 2048 characters.");

            RuleFor(x => x.Locations)
                .NotEmpty().WithMessage("Locations are required.");

            RuleFor(x => x.ImagePath)
                .NotEmpty().WithMessage("ImagePath is required.");
        }
    }
}
