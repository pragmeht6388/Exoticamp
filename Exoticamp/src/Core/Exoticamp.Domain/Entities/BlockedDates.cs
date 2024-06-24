using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exoticamp.Domain.Entities
{
    public class BlockedDates
    {
        public Guid Id { get; set; }
        public Guid TentId { get; set; }
        public Guid CampsiteId { get; set; }
        public Guid? GlampingId { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public int NoOfPersons { get; set; }
        public string Reason { get; set; }
        public Guid VendorId { get; set; } // To filter based on logged-in vendor
    }

}
