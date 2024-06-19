using Exoticamp.Application.Contracts.Persistence;
using Exoticamp.Application.Exceptions;
using Exoticamp.Application.Features.Events.Commands.DeleteEvent;
using Exoticamp.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.DataProtection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exoticamp.Application.Features.Bookings.Commands.DeleteBooking
{
    public class DeleteBookingCommandHandler : IRequestHandler<DeleteBookingCommand, Unit>
    {
        private readonly IBookingRepository _bookingRepository;
        private readonly IDataProtector _protector;

        public DeleteBookingCommandHandler(IBookingRepository bookingRepository, IDataProtectionProvider provider)
        {
            _bookingRepository = bookingRepository;
            _protector = provider.CreateProtector("");
        }

        public async Task<Unit> Handle(DeleteBookingCommand request, CancellationToken cancellationToken)
        {
            var bookingToDelete = await _bookingRepository.GetByIdAsync(request.BookingId);

            if (bookingToDelete == null)
            {
                throw new NotFoundException(nameof(Booking), request.BookingId);
            }

            await _bookingRepository.DeleteAsync(bookingToDelete);
            return Unit.Value;
        }
    }
}
