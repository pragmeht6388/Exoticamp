using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exoticamp.Application.Features.Glamping.GetGlampingList
{
    public class GetGlampingListDto
    {
        public Guid GlampingId { get; set; }
        
        
        public string Category { get; set; } // e.g., "2 Person", "4 Person"
        public int Capacity { get; set; }
        public decimal Cost { get; set; }
    }
}
