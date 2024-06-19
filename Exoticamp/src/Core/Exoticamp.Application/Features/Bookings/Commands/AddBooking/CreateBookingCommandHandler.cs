using AutoMapper;
using Exoticamp.Application.Contracts.Persistence;
using Exoticamp.Application.Features.Events.Commands.CreateEvent;
using Exoticamp.Application.Responses;
using Exoticamp.Domain.Entities;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exoticamp.Application.Features.Bookings.Commands.AddBooking
{
    public class CreateBookingCommandHandler:IRequestHandler<CreateBookingCommand, Response<CreateBookingDto>>
    {
        private readonly IMapper _mapper;
        private readonly IBookingRepository _bookingRepository;
        private readonly IMessageRepository _messageRepository;
        private readonly ILogger<CreateBookingCommandHandler> _logger;
        public readonly ICampsiteDetailsRepository _campsiteDetailsRepository;
        public readonly ILoactionRepository _locationRepository;

        public CreateBookingCommandHandler(IMapper mapper, IBookingRepository bookingRepository, IMessageRepository messageRepository,ILogger<CreateBookingCommandHandler>logger
            ,ICampsiteDetailsRepository campsiteDetailsRepository,ILoactionRepository loactionRepository)
        {
            _mapper = mapper;
            _bookingRepository = bookingRepository;
            _messageRepository = messageRepository;
            _logger = logger;
            _campsiteDetailsRepository = campsiteDetailsRepository;
            _locationRepository = loactionRepository;
        }

        public async Task<Response<CreateBookingDto>> Handle(CreateBookingCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Handle Initiated");
            Response<CreateBookingDto> response = new Response<CreateBookingDto>();
            var campsite= await _campsiteDetailsRepository.GetByIdAsync(request.CampsiteId);
            var  location =await _locationRepository.GetByIdAsync(request.LocationId);
            if (campsite==null)
            {
                response.Message = "Campsite Not found";
                return response;
            }
            if (location == null)
            {
                response.Message = "Location Not found";
                return response;
            }

            request.
            var validator = new CreateBookingCommandValidator(_bookingRepository, _messageRepository);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
                throw new Exceptions.ValidationException(validationResult);
            //var @event = _mapper.Map<Event>(request);

           var booking= _mapper.Map<Booking>(request);

            var bookingObj = await _bookingRepository.AddAsync(booking);
          

            if (bookingObj != null)
            {

                response = new Response<CreateBookingDto>(_mapper.Map<CreateBookingDto>(bookingObj), "Inserted successfully");
                _logger.LogInformation("Handle Completed");
                return response;
            }
            else
            {

                response.Message = "Event not added";
                _logger.LogInformation("Not Handled ");
            }


            return response;
        }
    }
}
