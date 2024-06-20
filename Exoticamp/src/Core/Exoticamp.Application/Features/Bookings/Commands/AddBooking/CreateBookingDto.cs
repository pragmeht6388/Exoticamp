using Exoticamp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exoticamp.Application.Features.Bookings.Commands.AddBooking
{
    public class CreateBookingDto
    {
        public Guid BookingId { get; set; }
        public string CustomerName { get; set; }
        public string Email { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public int NoOfAdults { get; set; }
        public int NoOfChildrens { get; set; }
        public int NoOfTents { get; set; }
        public decimal TotalPrice { get; set; }
        public string? GlampingType { get; set; }
        public string Status { get; set; }
        public Guid CampsiteId { get; set; }
        public Guid LocationId { get; set; }
        //public Guid? PaymentId { get; set; }
        public  Domain.Entities.CampsiteDetails? Campsite { get; set; }
        public  Location? Location { get; set; }
        
    }
}
