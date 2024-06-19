using Exoticamp.UI.Models.Booking;
using Exoticamp.UI.Models.ResponseModels.Booking;

namespace Exoticamp.UI.Services.IRepositories
{
    public interface IBookingRepository
    {
        Task<IEnumerable<BookingVM>> GetAllBookings();
    }
}
