using Exoticamp.UI.Models.CampsiteDetails;
using Exoticamp.UI.Models.Category;

namespace Exoticamp.UI.Services.IRepositories
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<CategoryVM>> GetAllCategory();

    }
}
