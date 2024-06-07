using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exoticamp.Domain.Entities
{
    public class CampsiteActivities
    {
        [Key]
        public Guid Id { get; set; }
        public Guid CampsiteId { get; set; }
        public CampsiteDetails CampsiteDetails { get; set; }

        public Guid ActivityId { get; set; }
        public Activities Activities { get; set; }
    }
}
