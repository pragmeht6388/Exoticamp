using Exoticamp.UI.Models.Activities;

namespace Exoticamp.UI.Services.IRepositories
{
    public interface IActivitiesRepository
    {
        Task<IEnumerable<ActivitiesVM>> GetAllActivities();

    }
}
