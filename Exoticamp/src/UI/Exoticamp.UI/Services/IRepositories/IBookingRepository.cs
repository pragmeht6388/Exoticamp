using Exoticamp.UI.Models.Booking;
using Exoticamp.UI.Models.ResponseModels.Booking;
using Exoticamp.UI.Models.ResponseModels.Bookings;

namespace Exoticamp.UI.Services.IRepositories
{
    public interface IBookingRepository
    {
        Task<IEnumerable<BookingVM>> GetAllBookings();

        Task<AddBookingResponseModel> AddBooking(BookingVM bookingVM);
    }
}
