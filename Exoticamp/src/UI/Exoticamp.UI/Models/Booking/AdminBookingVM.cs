namespace Exoticamp.UI.Models.Booking
{
    public class AdminBookingVM
    {
        public IEnumerable<BookingVM> Bookings { get; set; }
        public int TotalReviewsCount { get; set; }
    }
}
