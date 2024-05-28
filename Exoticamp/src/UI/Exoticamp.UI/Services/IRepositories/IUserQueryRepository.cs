using Exoticamp.UI.Models.UserQuery;

namespace Exoticamp.UI.Services.IRepositories
{
    public interface IUserQueryRepository
    {
        Task<IEnumerable<UserQueyVM>> GetAllUserQueries();
        Task<UserQueyVM> GetUserQueryById( Guid Id);
        Task<Guid> RespondToUserQuery(UserQueyVM userQuey);


    }
}
