using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Exoticamp.Application.Features.Events.Commands.CreateEvent;

namespace Exoticamp.Application.Features.Events.Queries.GetEventDetail
{
    public class EventDetailVm
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

        public EventLocationDto EventLocationDto {  get; set; }
        public EventActivityDto EventActivityDto {  get; set; } 
    }
    public class EventLocationDto
    {
        public Guid Id { get; set;}
        public Guid LocationId { get; set; }
        public LocationDetails LocationDetails {  get; set; }


    }
    public  class LocationDetails
    {
        public string Name { get; set; }

    }
    public class EventActivityDto
    {
        public Guid Id { get; set; }
        public Guid ActivityId { get; set; }
        public ActivityDetails ActivityDetails { get; set; }

    }
    public class ActivityDetails
    {
        public string Name { get; set; }

    }
}
