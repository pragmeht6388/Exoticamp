using MediatR;
using System;
using Exoticamp.Application.Responses;
using Exoticamp.Application.Features.Events.Commands.CreateEvent;
using System.ComponentModel.DataAnnotations;

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
       

        public string? ImageUrl { get; set; }

        public string Highlights { get; set; }

        public string EventRules { get; set; }
        public Guid CampsiteId { get; set; }

        public Guid ActivityId { get; set; }

        public Guid LocationId { get; set; }
        public bool Status { get; set; }
        public bool IsDeleted { get; set; }
        public EventLocationDTO EventLocationDTO {  get; set; }
        public EventActivityDTO EventActivityDTO {  get; set; }
    }
    public class EventLocationDTO
    {
        public Guid EventLocationId { get; set; }
        public Guid LocationId { get; set; }
    }
    public class EventActivityDTO
    {
        public Guid ActivityId { get; set; }
        public Guid EventActivityId {  get; set; }
    }
}
