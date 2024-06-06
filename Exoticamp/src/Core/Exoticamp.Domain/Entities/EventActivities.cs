using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exoticamp.Domain.Entities
{
    public class EventActivities
    {
        public Guid Id { get; set; }
        public Guid ActivityId { get; set; }

        public Guid EventId { get; set; }
        public ICollection<Activities> Activities { get; set; }
        public ICollection<Event> Events { get; set; } 
    }
}
