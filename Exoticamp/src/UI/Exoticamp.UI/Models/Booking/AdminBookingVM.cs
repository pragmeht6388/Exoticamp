using Exoticamp.UI.Models.CampsiteDetails;

namespace Exoticamp.UI.Models.Booking
{
    public class AdminBookingVM
    {
        public IEnumerable<BookingVM> Bookings { get; set; }
        public IEnumerable<CampsiteDetailsVM> Campsite { get; set; }
        public int TotalReviewsCount { get; set; }
        public decimal TotalRevenue => Bookings.Sum(b => b.TotalPrice);
    }
}
