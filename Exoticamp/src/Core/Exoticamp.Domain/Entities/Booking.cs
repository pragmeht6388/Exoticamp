using Exoticamp.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Exoticamp.Domain.Entities
{
    public  class Booking:AuditableEntity
    {
        public Guid BookingId { get; set; }
        public string CustomerName {  get; set; }
        public string Email { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public int NoOfAdults {  get; set; }
        public int NoOfChildrens {  get; set; }
        public int NoOfTents {  get; set; }
        public decimal TotalPrice { get; set; }
        public string? GlampingType {  get; set; }
        public string Status {  get; set; }
        public Guid CampsiteId { get; set; }
        public Guid LocationId { get; set; }
        //public Guid? PaymentId {  get; set; }
        //public Guid EventId { get; set; }
        //public virtual Event Event { get; set; }
        public Guid? GlampingId { get; set; }
        public int? NoOfGlamps { get; set; }
        public Guid? GuestDetailsId { get; set; }
        public GuestDetails? GuestDetails { get; set; }
        public virtual CampsiteDetails Campsite { get; set; }
        public virtual Location Location { get; set; }  
        

    }
}
