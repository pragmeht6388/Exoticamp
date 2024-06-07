using Exoticamp.Application.Contracts.Persistence;
using Exoticamp.Application.Helper;
using FluentValidation;

namespace Exoticamp.Application.Features.Banners.Commands.CreateBanner
{
    public class CreateBannerCommandValidator : AbstractValidator<CreateBannerCommand>
    {
        private readonly IMessageRepository _messageRepository;

        public CreateBannerCommandValidator(IMessageRepository messageRepository)
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
