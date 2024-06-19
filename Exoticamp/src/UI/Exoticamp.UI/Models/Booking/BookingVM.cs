namespace Exoticamp.UI.Models.Booking
{
    public class BookingVM
    {
        public Guid BookingId { get; set; }
        public string Campsite { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public int NoOfPersons { get; set; }
        public string Status { get; set; }
        public string Action { get; set; }
        public string GuestNames { get; set; }
        public int NoOfTents { get; set; }
        public string GlampingType { get; set; }
        public string VegNonVegPax { get; set; }
        public string PaymentStatus { get; set; }
        public decimal AmountPaid { get; set; }
        public string CustomizedItinerary { get; set; }
    }
}
