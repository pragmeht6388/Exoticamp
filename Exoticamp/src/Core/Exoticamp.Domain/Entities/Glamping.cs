using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exoticamp.Domain.Entities
{
    public class Glamping
    {
        public Guid GlampingId { get; set; }
        public Guid CampsiteId { get; set; }
        public CampsiteDetails Campsite { get; set; }
        public string Category { get; set; } // e.g., "2 Person", "4 Person"
        public int Capacity { get; set; }
        public decimal Cost { get; set; }
    }

}
