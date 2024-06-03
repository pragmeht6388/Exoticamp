using AutoMapper;
using Exoticamp.Application.Exceptions;

using MediatR;
using Microsoft.AspNetCore.DataProtection;
using System;
using System.Threading;
using System.Threading.Tasks;
using Exoticamp.Application.Contracts.Persistence;
using Exoticamp.Domain.Entities;

namespace Exoticamp.Application.Features.Events.Commands.DeleteEvent
{
    public class DeleteEventCommandHandler : IRequestHandler<DeleteEventCommand, Unit>
    {
        private readonly IEventRepository _eventRepository;
        private readonly IDataProtector _protector;

        public DeleteEventCommandHandler(IEventRepository eventRepository, IDataProtectionProvider provider)
        {
            _eventRepository = eventRepository;
            _protector = provider.CreateProtector("");
        }

        public async Task<Unit> Handle(DeleteEventCommand request, CancellationToken cancellationToken)
        {
            var eventToDelete = await _eventRepository.GetByIdAsync(Guid.Parse(request.EventId));

            if (eventToDelete == null)
            {
                throw new NotFoundException(nameof(Event), Guid.Parse(request.EventId));
            }

            await _eventRepository.DeleteAsync(eventToDelete);
            return Unit.Value;
        }
    }
}
