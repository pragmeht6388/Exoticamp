using Exoticamp.Application.Contracts.Persistence;
using Exoticamp.Application.Features.Bookings.Commands.AddBooking;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exoticamp.Application.Features.EventBooking.Commands.AddBooking
{
    public class CreateEventCartCommandValidator : AbstractValidator<CreateEventCartCommand>
    {
        private readonly IEventBookingCartRepository _bookingRepository;
        private readonly IMessageRepository _messageRepository;
        public CreateEventCartCommandValidator( IMessageRepository messageRepository)
        {
            _messageRepository = messageRepository;

            //RuleFor(p => p.CustomerName)
            //    .NotEmpty().WithMessage("Name is required")
            //    .NotNull().WithMessage("Name can not be null")
            //    .MaximumLength(50).WithMessage("Name shold not exceed 50 characters");
        }
    }
}
