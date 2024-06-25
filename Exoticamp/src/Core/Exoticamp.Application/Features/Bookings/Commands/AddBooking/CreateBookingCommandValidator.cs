using Exoticamp.Application.Contracts.Persistence;
using Exoticamp.Application.Features.Events.Commands.CreateEvent;
using FluentValidation;

namespace Exoticamp.Application.Features.Bookings.Commands.AddBooking
{
    public class CreateBookingCommandValidator : AbstractValidator<CreateBookingCommand>
    {
        private readonly IBookingRepository _bookingRepository;
        private readonly IMessageRepository _messageRepository;
        public CreateBookingCommandValidator(IBookingRepository bookingRepository, IMessageRepository messageRepository)
        {
            _bookingRepository = bookingRepository;
            _messageRepository = messageRepository;

            RuleFor(p => p.CustomerName)
                .NotEmpty().WithMessage("Name is required")
                .NotNull().WithMessage("Name can not be null")
                .MaximumLength(50).WithMessage("Name shold not exceed 50 characters");
        RuleFor(p => p.Email)
              .NotEmpty().WithMessage("Email is required")
              .NotNull().WithMessage("Email can not be Empty").MaximumLength(50).WithMessage("Name shold not exceed 50 characters");
            RuleFor(p => p.CheckIn)
                .NotEmpty().WithMessage("Check In date is required")
                .NotNull()
                .GreaterThan(DateTime.Now);
            RuleFor(p => p.CheckOut)
              .NotEmpty().WithMessage("End date is required")
              .NotNull()
              .GreaterThan((p => p.CheckIn)).WithMessage("Check Out date should be greater than Check In date");

            RuleFor(e => e)
                .MustAsync(CheckInDateUnique)
                .WithMessage("Event and start date name must be unique");


            //RuleFor(p => p.Capacity)
            //   .NotEmpty().WithMessage("Capacity for event is required")
            //   .GreaterThan(0).WithMessage("Capacity for event shold be greater than Zero");
            //RuleFor(p => p.Description)
            //   .NotEmpty().WithMessage("Description is required")
            //   .NotNull().WithMessage("Description can not be null")
            //   .MaximumLength(400).WithMessage("Description shold not exceed 400 characters");
            //RuleFor(p => p.ImageUrl)
            //   .NotEmpty().WithMessage("Image Url is required")
            //   .NotNull().WithMessage("Image Url can not be null")
            //   .MaximumLength(400).WithMessage("Image Url shold not exceed 400 characters");
            //RuleFor(p => p.Highlights)
            //  .NotEmpty().WithMessage("Highlights is required")
            //  .NotNull().WithMessage("Highlights can not be null")
            //  .MaximumLength(400).WithMessage("Highlights shold not exceed 400 characters");
            //RuleFor(p => p.EventRules)
            //  .NotEmpty().WithMessage("Event Rules is required")
            //  .NotNull().WithMessage("Event Rules can not be null")
            //  .MaximumLength(400).WithMessage("Event Rules shold not exceed 400 characters");
        }

        private async Task<bool> CheckInDateUnique(CreateBookingCommand e, CancellationToken token)
        {
            return !await _bookingRepository.IsCheckInDateUnique( e.CheckIn,e.CampsiteId);
        }

        private string GetMessage(string Code, string Lang)
        {
            return _messageRepository.GetMessage(Code, Lang).Result.MessageContent.ToString();
        }
    }
}
