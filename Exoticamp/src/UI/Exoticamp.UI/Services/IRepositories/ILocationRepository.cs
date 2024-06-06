
using Exoticamp.UI.Models.Location;

namespace Exoticamp.UI.Services.IRepositories
{
    public interface ILocationRepository
    {
        Task<IEnumerable<LocationVM>> GetAllLocations();
    }
}
