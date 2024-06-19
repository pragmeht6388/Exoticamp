using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exoticamp.Domain.Entities
{
    public class Payment
    {
        public Guid PaymentId { get; set; }
        public bool PaymentStatus { get; set; }
        public decimal AmountPaid { get; set; }
        public Guid BookingId {  get; set; }
        public virtual Booking Booking { get; set; }
    }
}
