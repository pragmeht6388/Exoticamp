using Exoticamp.Application.Contracts.Persistence;
using Exoticamp.Application.Features.Bookings.Commands.AddBooking;
using Exoticamp.Application.Helper;
using FluentValidation;

namespace Exoticamp.Application.Features.Events.Commands.UpdateEvent
{
    public class UpdateEventCommandValidator : AbstractValidator<UpdateEventCommand>
    {
        private readonly IMessageRepository _messageRepository;
        public UpdateEventCommandValidator(IMessageRepository messageRepository)
        {
            _messageRepository = messageRepository;

            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("Name is required")
                .NotNull().WithMessage("Name can not be null")
                .MaximumLength(50).WithMessage("Name shold not exceed 50 characters");

            RuleFor(p => p.StartDate)
                .NotEmpty().WithMessage("Event Start date is required")
                .NotNull().WithMessage("Event Start date is required")
                .GreaterThan(DateTime.Now);
            RuleFor(p => p.EndDate)
              .NotEmpty().WithMessage("Event End date date is required")
              .NotNull()
              .GreaterThan((p => p.StartDate)).WithMessage("End date should be greater than start date");

        
            RuleFor(p => p.Price)
                .NotEmpty().WithMessage("Event price is required")
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


      
        private string GetMessage(string Code, string Lang)
        {
            return _messageRepository.GetMessage(Code, Lang).Result.MessageContent.ToString();
        }
    }
}
