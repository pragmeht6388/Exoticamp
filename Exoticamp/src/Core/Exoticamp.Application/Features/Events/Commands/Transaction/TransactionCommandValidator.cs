using Exoticamp.Application.Contracts.Persistence;
using Exoticamp.Application.Helper;
using FluentValidation;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Exoticamp.Application.Features.Events.Commands.Transaction
{
    public class TransactionCommandValidator : AbstractValidator<TransactionCommand>
    {
        private readonly IEventRepository _eventRepository;
        private readonly IMessageRepository _messageRepository;
        public TransactionCommandValidator(IEventRepository eventRepository, IMessageRepository messageRepository)
        {
            _eventRepository = eventRepository;
            _messageRepository = messageRepository;

            RuleFor(p => p.Name)
                .NotEmpty().WithMessage(GetMessage("1", ApplicationConstants.LANG_ENG))
                .NotNull()
                .MaximumLength(50).WithMessage(GetMessage("2", ApplicationConstants.LANG_ENG));

            RuleFor(p => p.StartDate)
                .NotEmpty().WithMessage(GetMessage("1", ApplicationConstants.LANG_ENG))
                .NotNull()
                .GreaterThan(DateTime.Now);

            RuleFor(e => e)
                .MustAsync(EventNameAndDateUnique)
                .WithMessage(GetMessage("3", ApplicationConstants.LANG_ENG));

            RuleFor(p => p.Price)
                .NotEmpty().WithMessage(GetMessage("1", ApplicationConstants.LANG_ENG))
                .GreaterThan(0);
        }

        private async Task<bool> EventNameAndDateUnique(TransactionCommand e, CancellationToken token)
        {
            return !await _eventRepository.IsEventNameAndDateUnique(e.Name, e.StartDate);
        }

        private string GetMessage(string Code, string Lang)
        {
            return _messageRepository.GetMessage(Code, Lang).Result.MessageContent.ToString();
        }
    }
}
