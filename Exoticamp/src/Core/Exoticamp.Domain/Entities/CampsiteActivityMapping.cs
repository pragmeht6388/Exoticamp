using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exoticamp.Domain.Entities
{
    public class CampsiteActivityMapping
    {
        public Guid Id { get; set; }
        public Guid CampsiteId { get; set; }
        public Campsite Campsite { get; set; }

        public Guid AcivityId { get; set; }
        public Activities Activities { get; set; }
    }
}
