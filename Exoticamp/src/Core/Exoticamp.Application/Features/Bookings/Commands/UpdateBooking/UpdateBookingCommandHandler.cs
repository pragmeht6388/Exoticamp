using AutoMapper;
using Exoticamp.Application.Contracts.Persistence;
using Exoticamp.Application.Exceptions;
using Exoticamp.Application.Features.Events.Commands.UpdateEvent;
using Exoticamp.Application.Responses;
using Exoticamp.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exoticamp.Application.Features.Bookings.Commands.UpdateBooking
{
    public class UpdateBookingCommandHandler : IRequestHandler<UpdateBookingCommand, Response<UpdateBookingDto>>
    {
        private readonly IBookingRepository _bookingRepository;
        private readonly IMapper _mapper;
        private readonly IMessageRepository _messageRepository;

        public UpdateBookingCommandHandler(IMapper mapper, IBookingRepository bookingRepository, IMessageRepository messageRepository)
        {
            _mapper = mapper;
            _bookingRepository= bookingRepository;
            _messageRepository = messageRepository;
        }

        public async Task<Response<UpdateBookingDto>> Handle(UpdateBookingCommand request, CancellationToken cancellationToken)
        {
            var response = new Response<UpdateBookingDto>();
            var bookingObj=await _bookingRepository.GetByIdAsync(request.BookingId);
            if (bookingObj == null) {

                response.Message = "Booking Not found";
            }
            var validator = new UpdateBookingCommandValidator(_messageRepository,_bookingRepository);
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (validationResult.Errors.Count > 0)
                throw new ValidationException(validationResult);

              _mapper.Map(request, bookingObj, typeof(UpdateBookingCommand), typeof(Booking));

             await _bookingRepository.UpdateAsync(bookingObj);

        
                response = new Response<UpdateBookingDto>(_mapper.Map<UpdateBookingDto>(bookingObj));
                response.Message = "Updated Successfully";
        
            return response;
        }
    }
}
