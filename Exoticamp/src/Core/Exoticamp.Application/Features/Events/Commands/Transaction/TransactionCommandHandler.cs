﻿using AutoMapper;
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

namespace Exoticamp.Application.Features.Events.Commands.Transaction
{
    public class TransactionCommandHandler : IRequestHandler<TransactionCommand, Response<TransactionCommandDto>>
    {
        private readonly IEventRepository _eventRepository;
        private readonly IMapper _mapper;
        //private readonly IEmailService _emailService;
        private readonly ILogger<TransactionCommandHandler> _logger;
        private readonly IMessageRepository _messageRepository;

        public TransactionCommandHandler(IMapper mapper, IEventRepository eventRepository,  ILogger<TransactionCommandHandler> logger, IMessageRepository messageRepository)
        {
            _mapper = mapper;
            _eventRepository = eventRepository;
           // _emailService = emailService;
            _logger = logger;
            _messageRepository = messageRepository;
        }

        public async Task<Response<TransactionCommandDto>> Handle(TransactionCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Handle Initiated");

            var validator = new TransactionCommandValidator(_eventRepository, _messageRepository);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
                throw new Exceptions.ValidationException(validationResult);

            var @event = _mapper.Map<Event>(request);
           // @event.Category.Name = request.CategoryName;
            @event = await _eventRepository.AddEventWithCategory(@event);

            //Sending email notification to admin address
            //var email = new Email() { To = "gill@snowball.be", Body = $"A new event was created: {request}", Subject = "A new event was created" };

            //try
            //{
            //    await _emailService.SendEmail(email);
            //}
            //catch (Exception ex)
            //{
            //    //this shouldn't stop the API from doing else so this can be logged
            //    _logger.LogError($"Mailing about event {@event.EventId} failed due to an error with the mail service: {ex.Message}");
            //}

            var response = new Response<TransactionCommandDto>(_mapper.Map<TransactionCommandDto>(@event), "Inserted successfully ");

            _logger.LogInformation("Handle Completed");

            return response;
        }
    }
}
