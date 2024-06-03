using MediatR;
using System;
using Exoticamp.Application.Responses;

namespace Exoticamp.Application.Features.Events.Commands.UpdateEvent
{
    public class UpdateEventCommand : IRequest<Response<UpdateEventDto>>
    {
        public Guid EventId { get; set; }
        public string Name { get; set; }

        public decimal Price { get; set; }

        public int Capacity { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }
        public string Description { get; set; }

        public string ImageUrl { get; set; }

        public string Highlights { get; set; }

        public string EventRules { get; set; }
    }
}
