using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exoticamp.Domain.Entities
{
    public class EventLocation
    {
        public Guid Id { get; set; }
        public Guid EventId { get; set; }
        public Guid LocationId {get;set; }
        public ICollection<Location> Locations { get; set; }
        public ICollection<Event> Events { get; set; }
    }
}
