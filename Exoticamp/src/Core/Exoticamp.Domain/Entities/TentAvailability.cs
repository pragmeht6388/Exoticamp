using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exoticamp.Domain.Entities
{
    public class TentAvailability
    {
        public Guid Id { get; set; }
        public Guid TentId { get; set; }
        public Guid CampsiteId { get; set; }
        public Guid? GlampingId { get; set; }
        public int AvailableTents { get; set; }
        public int BookedTents { get; set; }
        public Guid VendorId { get; set; } // To filter based on logged-in vendor
    }

}
