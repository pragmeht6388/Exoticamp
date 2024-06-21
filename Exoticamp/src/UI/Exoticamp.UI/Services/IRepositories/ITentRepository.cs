using Exoticamp.UI.Models.TentType;

namespace Exoticamp.UI.Services.IRepositories
{
    public interface ITentRepository
    {
        Task<IEnumerable<TentTypeVM>> GetAllTents();

    }
}
