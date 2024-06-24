using Exoticamp.UI.Models.CampsiteDetails;

namespace Exoticamp.UI.Models.Booking
{
    public class VendorBookVM
    {
        public IEnumerable<BookingVM> Bookings { get; set; }
        public IEnumerable<CampsiteDetailsVM> Campsite { get; set; }
        public int TotalReviewsCount { get; set; }
        public decimal TotalRevenue { get; set; }
    }
}
