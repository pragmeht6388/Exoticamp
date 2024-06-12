using Exoticamp.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Exoticamp.Domain.Entities
{
    public class Reviews:AuditableEntity
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime DateTime { get; set; }
        public int Ratings { get; set; }
        public string Description { get; set; }
        public bool Status { get; set; }

        public Guid BookingId { get; set; }
        public Guid UserId { get; set; }

        public virtual Booking Booking { get; set; }

    }
}
