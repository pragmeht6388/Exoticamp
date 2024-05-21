using MediatR;
using System;

namespace Exoticamp.Application.Features.Events.Commands.DeleteEvent
{
    public class DeleteEventCommand : IRequest<Unit>
    {
        public string EventId { get; set; }
    }
}
