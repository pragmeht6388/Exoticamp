using Exoticamp.UI.Models.ResponseModels.Search;

namespace Exoticamp.UI.Services.IRepositories
{
    public interface ISearchRepository
    {
        Task<SearchResponseModel> SearchContent(string text);
    }
}
