using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exoticamp.Application.Features.Events.Commands.CreateEvent
{
    public class CreateEventCommandDto
    {
        public Guid EventId { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

         public int Capacity { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public string Description { get; set; }
        // public string? ImageUrl { get; set; }
        public List<string> ImageUrls { get; set; } = new List<string>();
        public string Highlights { get; set; }

         public string EventRules { get; set; }
        // public Guid CampsiteId { get; set; }
        public List<Guid> CampsiteIds { get; set; } = new List<Guid>();

        // public Guid ActivityId { get; set; }
        public List<Guid> ActivityIds { get; set; } = new List<Guid>();


        public Guid LocationId { get; set; }
        public bool Status { get; set; }
        public bool IsDeleted { get; set; }
    }
}
