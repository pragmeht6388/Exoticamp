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
                .NotEmpty().WithMessage(GetMessage("1", ApplicationConstants.LANG_ENG))
                .NotNull()
                .MaximumLength(2048).WithMessage(GetMessage("2", ApplicationConstants.LANG_ENG));

            RuleFor(p => p.PromoCode)
                .MaximumLength(50).WithMessage(GetMessage("3", ApplicationConstants.LANG_ENG));

            RuleFor(p => p.Locations)
                .NotEmpty().WithMessage(GetMessage("4", ApplicationConstants.LANG_ENG))
                .NotNull();

            RuleFor(p => p.ImagePath)
                .NotEmpty().WithMessage(GetMessage("5", ApplicationConstants.LANG_ENG))
                .NotNull();
        }

        private string GetMessage(string code, string lang)
        {
            var messageTask = _messageRepository.GetMessage(code, lang);
            var message = messageTask?.Result;
            return message?.MessageContent?.ToString() ?? "Default error message.";
        }
    }
}
