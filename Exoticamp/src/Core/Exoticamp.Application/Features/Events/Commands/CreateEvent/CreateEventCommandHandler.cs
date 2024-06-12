using AutoMapper;
using Exoticamp.Application.Models.Mail;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;
using Exoticamp.Application.Contracts.Infrastructure;
using Exoticamp.Application.Contracts.Persistence;
using Exoticamp.Application.Responses;
using Exoticamp.Domain.Entities;
using Exoticamp.Application.Exceptions;

namespace Exoticamp.Application.Features.Events.Commands.CreateEvent
{
    public class CreateEventCommandHandler : IRequestHandler<CreateEventCommand, Response<CreateEventCommandDto>>
    {
        private readonly IEventRepository _eventRepository;
        private readonly ICampsiteDetailsRepository _campsiteDetailsRepository;
        private readonly IMapper _mapper;
     
        private readonly ILogger<CreateEventCommandHandler> _logger;
        private readonly IMessageRepository _messageRepository;

        public CreateEventCommandHandler(IMapper mapper, IEventRepository eventRepository,ILogger<CreateEventCommandHandler> logger,
            IMessageRepository messageRepository, ICampsiteDetailsRepository campsiteDetailsRepository)
        {
            _mapper = mapper;
            _eventRepository = eventRepository;
            // _emailService = emailService;
            _logger = logger;
            _messageRepository = messageRepository;
            _campsiteDetailsRepository = campsiteDetailsRepository;
        }

        public async Task<Response<CreateEventCommandDto>> Handle(CreateEventCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Handle Initiated");

            var validator = new CreateEventCommandValidator(_eventRepository, _messageRepository);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
                throw new Exceptions.ValidationException(validationResult);
            //var @event = _mapper.Map<Event>(request);

            

            var eventObj = await _eventRepository.AddEvent(request);
            Response<CreateEventCommandDto> response = new Response<CreateEventCommandDto>();

            if (eventObj!=null)
            {

                 response = new Response<CreateEventCommandDto>(_mapper.Map<CreateEventCommandDto>(eventObj), "Inserted successfully");
                _logger.LogInformation("Handle Completed");
                return response;
            }
            else
            {

                response.Message="Event not added";
                _logger.LogInformation("Not Handled ");
            }
           

            return response ;
        }
    }
}


