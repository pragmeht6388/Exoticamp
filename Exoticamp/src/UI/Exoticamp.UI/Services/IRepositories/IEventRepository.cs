using Exoticamp.UI.Models.Events;
using Exoticamp.UI.Models.ResponseModels.Events;

namespace Exoticamp.UI.Services.IRepositories
{
    public interface IEventRepository
    {
        Task<IEnumerable<EventVM>> GetAllEvents();
        Task<AddEventResponseModel> AddEvent(EventVM model);
        Task<EditEventResponseModel> EditEvent(EventVM model);
        Task<GetEventByIdResponseModel> GetEventById(string id);
        Task<DeleteEventResponseModel> DeleteEvent(string modelid);
    }
}
