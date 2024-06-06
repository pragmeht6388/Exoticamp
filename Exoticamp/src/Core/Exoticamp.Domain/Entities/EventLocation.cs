using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
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

        [ForeignKey("LocationId")]
        public  virtual Location Location { get; set; }

        [ForeignKey("EventId")]
        public virtual Event Event { get; set; }
    }
}
