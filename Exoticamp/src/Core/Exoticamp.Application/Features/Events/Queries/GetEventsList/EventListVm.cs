using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Exoticamp.Application.Features.Events.Queries.GetEventsList
{
    public class EventListVm
    {
        public string EventId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public int Capacity { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }
        [Required]

        public string Description { get; set; }
      
     

        public string? ImageUrl { get; set; }
        [Required]
        public string Highlights { get; set; }
        [Required]
        public string EventRules { get; set; }
    }
}
