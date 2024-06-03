using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exoticamp.Application.Features.Events.Commands.UpdateEvent
{
    public class UpdateEventDto
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
