﻿using AutoMapper;
using Exoticamp.Application.Exceptions;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using Exoticamp.Application.Contracts.Persistence;
using Exoticamp.Application.Responses;
using Exoticamp.Domain.Entities;

namespace Exoticamp.Application.Features.Events.Commands.UpdateEvent
{
    public class UpdateEventCommandHandler : IRequestHandler<UpdateEventCommand, Response<UpdateEventDto>>
    {
        private readonly IEventRepository _eventRepository;
        private readonly IMapper _mapper;
        private readonly IMessageRepository _messageRepository;

        public UpdateEventCommandHandler(IMapper mapper, IEventRepository eventRepository, IMessageRepository messageRepository)
        {
            _mapper = mapper;
            _eventRepository = eventRepository;
            _messageRepository = messageRepository;
        }

        public async Task<Response<UpdateEventDto>> Handle(UpdateEventCommand request, CancellationToken cancellationToken)
        {
           // var eventToUpdate = await _eventRepository.GetByIdAsync(request.EventId);

            //if (eventToUpdate == null)
            //{
            //    throw new NotFoundException(nameof(Event), request.EventId);
            //}

            var validator = new UpdateEventCommandValidator(_messageRepository);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
                throw new ValidationException(validationResult);

          //  _mapper.Map(request, eventToUpdate, typeof(UpdateEventCommand), typeof(Event));

          var dto =await _eventRepository.UpdateEvent(request);

            return new Response<UpdateEventDto>(dto, "Updated successfully ");



        }
    }
}