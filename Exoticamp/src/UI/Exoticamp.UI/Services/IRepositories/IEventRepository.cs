using Exoticamp.UI.Models.Events;
using Exoticamp.UI.Models.ResponseModels.Events;

namespace Exoticamp.UI.Services.IRepositories
{
    public interface IEventRepository
    {
        Task<IEnumerable<EventVM>> GetAllEvents();
       
    }
}
