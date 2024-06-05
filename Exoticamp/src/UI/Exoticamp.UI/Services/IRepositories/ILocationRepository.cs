
namespace Exoticamp.UI.Services.IRepositories
{
    public interface ILocationRepository
    {
        Task<IEnumerable<LocationVM>> GetAllEvents();
    }
}
