using FluentValidation;
using Exoticamp.Application.Contracts.Persistence;
using Exoticamp.Application.Helper;

namespace Exoticamp.Application.Features.Banners.Commands.UpdateBanner
{
    public class UpdateBannerCommandValidator : AbstractValidator<UpdateBannerCommand>
    {
        private readonly IMessageRepository _messageRepository;

        public UpdateBannerCommandValidator(IMessageRepository messageRepository)
        {
            _messageRepository = messageRepository;

            RuleFor(p => p.Link)
                            .NotEmpty().WithMessage("Link is required.")
                            .NotNull()
                            .MaximumLength(2048).WithMessage("Link cannot exceed 2048 characters.");

            RuleFor(p => p.PromoCode)
                .NotEmpty().WithMessage("PromoCode is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("PromoCode cannot exceed 50 characters.");

            RuleFor(p => p.ImagePath)
                .NotEmpty().WithMessage("ImagePath is required.")
                .NotNull();
        }
    }
}
