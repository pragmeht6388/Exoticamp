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
                .NotEmpty().WithMessage(GetMessage("1", ApplicationConstants.LANG_ENG))
                .NotNull()
                .MaximumLength(2048).WithMessage(GetMessage("2", ApplicationConstants.LANG_ENG));

            RuleFor(p => p.PromoCode)
                .NotEmpty().WithMessage(GetMessage("1", ApplicationConstants.LANG_ENG))
                .NotNull()
                .MaximumLength(50).WithMessage(GetMessage("2", ApplicationConstants.LANG_ENG));

            RuleFor(p => p.Locations)
                .NotEmpty().WithMessage(GetMessage("1", ApplicationConstants.LANG_ENG))
                .NotNull();

            RuleFor(p => p.ImagePath)
                .NotEmpty().WithMessage(GetMessage("1", ApplicationConstants.LANG_ENG))
                .NotNull();
        }

        private string GetMessage(string code, string lang)
        {
            var messageTask = _messageRepository.GetMessage(code, lang);
            var message = messageTask?.Result;
            return message?.MessageContent?.ToString() ?? "Some Details are Invalid";
        }
    }
}
