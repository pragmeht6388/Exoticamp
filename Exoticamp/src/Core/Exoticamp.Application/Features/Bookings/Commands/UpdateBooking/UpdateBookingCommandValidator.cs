using Exoticamp.Application.Contracts.Persistence;
using Exoticamp.Application.Features.Bookings.Commands.AddBooking;
using Exoticamp.Application.Features.Events.Commands.UpdateEvent;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exoticamp.Application.Features.Bookings.Commands.UpdateBooking
{
    public class UpdateBookingCommandValidator : AbstractValidator<UpdateBookingCommand>
    {
        private readonly IMessageRepository _messageRepository;
        private readonly IBookingRepository _bookingRepository;
        public UpdateBookingCommandValidator(IMessageRepository messageRepository, IBookingRepository bookingRepository)
        {
            _messageRepository = messageRepository;
            _bookingRepository = bookingRepository;

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
                .WithMessage(" check in date name must be unique");
           
        }

        private async Task<bool> CheckInDateUnique(UpdateBookingCommand e, CancellationToken token)
        {
            return !await _bookingRepository.IsCheckInDateUnique(e.CheckIn);
        }
        private string GetMessage(string Code, string Lang)
        {
            return _messageRepository.GetMessage(Code, Lang).Result.MessageContent.ToString();
        }
    }
}
