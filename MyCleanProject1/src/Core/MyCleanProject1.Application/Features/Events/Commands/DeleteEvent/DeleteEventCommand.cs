using MediatR;
using System;

namespace MyCleanProject1.Application.Features.Events.Commands.DeleteEvent
{
    public class DeleteEventCommand: IRequest<Unit>
    {
        public string EventId { get; set; }
    }
}
