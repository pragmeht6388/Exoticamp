using Exoticamp.Domain.Entities;

namespace Exoticamp.Application.Contracts.Persistence
{
    public interface ICategoryRepository : IAsyncRepository<Category>
    {
        Task<List<Category>> GetCategoriesWithEvents(bool includePassedEvents);
        Task<Category> AddCategory(Category category);
        Task<Category> Update(Category category);
        Task<Category> Delete(Category category);


    }
}
