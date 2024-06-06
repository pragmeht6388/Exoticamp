using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
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


        [ForeignKey("EventId")]
        public virtual Event Event { get; set; }

        [ForeignKey("ActivityId")]
        public virtual Activities Activity { get; set; }
    }
}
