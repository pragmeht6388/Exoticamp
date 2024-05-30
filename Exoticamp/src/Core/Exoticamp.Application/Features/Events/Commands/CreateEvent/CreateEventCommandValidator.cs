using Exoticamp.Application.Contracts.Persistence;
using Exoticamp.Application.Helper;
using FluentValidation;
using System;
using System.ComponentModel.DataAnnotations;
using System.Threading;
using System.Threading.Tasks;

namespace Exoticamp.Application.Features.Events.Commands.CreateEvent
{
    public class CreateEventCommandValidator : AbstractValidator<CreateEventCommand>
    {
        private readonly IEventRepository _eventRepository;
        private readonly IMessageRepository _messageRepository;
        public CreateEventCommandValidator(IEventRepository eventRepository, IMessageRepository messageRepository)
        {
            _eventRepository = eventRepository;
            _messageRepository = messageRepository;

            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("Name is required")
                .NotNull().WithMessage("Name can not be null")
                .MaximumLength(50).WithMessage("Name shold not exceed 50 characters");

            RuleFor(p => p.StartDate)
                .NotEmpty().WithMessage(GetMessage("1", ApplicationConstants.LANG_ENG))
                .NotNull()
                .GreaterThan(DateTime.Now);
            RuleFor(p => p.EndDate)
              .NotEmpty().WithMessage(GetMessage("1", ApplicationConstants.LANG_ENG))
              .NotNull()
              .GreaterThan((p => p.StartDate)).WithMessage("End date should be greater than start date");

            RuleFor(e => e)
                .MustAsync(EventNameAndDateUnique)
                .WithMessage(GetMessage("3", ApplicationConstants.LANG_ENG));

            RuleFor(p => p.Price)
                .NotEmpty().WithMessage(GetMessage("1", ApplicationConstants.LANG_ENG))
                .GreaterThan(0).WithMessage("Event price shold be greater than Zero");

            RuleFor(p => p.Capacity)
               .NotEmpty().WithMessage("Capacity for event is required")
               .GreaterThan(0).WithMessage("Capacity for event shold be greater than Zero");
            RuleFor(p => p.Description)
               .NotEmpty().WithMessage("Description is required")
               .NotNull().WithMessage("Description can not be null")
               .MaximumLength(400).WithMessage("Description shold not exceed 400 characters");
            RuleFor(p => p.ImageUrl)
               .NotEmpty().WithMessage("Image Url is required")
               .NotNull().WithMessage("Image Url can not be null")
               .MaximumLength(400).WithMessage("Image Url shold not exceed 400 characters");
            RuleFor(p => p.Highlights)
              .NotEmpty().WithMessage("Highlights is required")
              .NotNull().WithMessage("Highlights can not be null")
              .MaximumLength(400).WithMessage("Highlights shold not exceed 400 characters");
            RuleFor(p => p.EventRules)
              .NotEmpty().WithMessage("Event Rules is required")
              .NotNull().WithMessage("Event Rules can not be null")
              .MaximumLength(400).WithMessage("Event Rules shold not exceed 400 characters");
        }

        private async Task<bool> EventNameAndDateUnique(CreateEventCommand e, CancellationToken token)
        {
            return !await _eventRepository.IsEventNameAndDateUnique(e.Name, e.StartDate);
        }

        private string GetMessage(string Code, string Lang)
        {
            return _messageRepository.GetMessage(Code, Lang).Result.MessageContent.ToString();
        }
    }
}
