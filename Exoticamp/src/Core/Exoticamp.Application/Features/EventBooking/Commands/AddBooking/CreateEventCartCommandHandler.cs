using AutoMapper;
using Exoticamp.Application.Contracts;
using Exoticamp.Application.Contracts.Persistence;
using Exoticamp.Application.Exceptions;
using Exoticamp.Application.Features.Bookings.Commands.AddBooking;
using Exoticamp.Application.Features.Campsite.Commands.AddCampsite;
using Exoticamp.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exoticamp.Application.Features.EventBooking.Commands.AddBooking
{
    public class CreateEventCartCommandHandler : IRequestHandler<CreateEventCartCommand, Response<CreateEventCartDto>>
    {
        private readonly IMapper _mapper;
        private readonly IEventBookingCartRepository _eventBookingCartRepository;
        private readonly IMessageRepository _messageRepository;
        private readonly ILoggedInUserService _loggedInUserService;

        public CreateEventCartCommandHandler(IMapper mapper, IEventBookingCartRepository eventBookingCartRepository, IMessageRepository messageRepository,ILoggedInUserService loggedInUserService)
        {
            _mapper = mapper;
            _eventBookingCartRepository = eventBookingCartRepository;
            _messageRepository = messageRepository;
            _loggedInUserService = loggedInUserService;
        }

        public async Task<Response<CreateEventCartDto>> Handle(CreateEventCartCommand request, CancellationToken cancellationToken)
        {
            Response<CreateEventCartDto> addEventCartCommandResponse = null;

            var validator = new CreateEventCartCommandValidator(_messageRepository);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
            {
                throw new ValidationException(validationResult);
            }
            else
            {
                var evntCart = new Domain.Entities.EventBookingCart
                {

                    CustomerName = request.CustomerName,
                    Email = request.Email,
                    CheckIn = request.CheckIn,
                    CheckOut = request.CheckOut,
                    NoOfAdults = request.NoOfAdults,
                    NoOfChildrens = request.NoOfChildrens,
                    NoOfTents = request.NoOfTents,
                    TotalPrice = request.TotalPrice,
                    Status = request.Status,
                   // LocationId = request.LocationId,
                    EventId = request.EventId,
                    //Event = request.Event,
                    //GlampingId = request.GlampingId,
                    //NoOfGlamps = request.NoOfGlamps,
                    //GuestDetailsId = request.GuestDetailsId,
                    IsActive = request.IsActive,
                    UserId = Guid.Parse(_loggedInUserService.UserId.ToString()),
                };
                evntCart = await _eventBookingCartRepository.AddAsync(evntCart);
                addEventCartCommandResponse = new Response<CreateEventCartDto>(_mapper.Map<CreateEventCartDto>(evntCart), "success");
            }

            return addEventCartCommandResponse;

        }

    }
}
