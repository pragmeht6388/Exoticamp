using Exoticamp.UI.Models.ResponseModels;
using Exoticamp.UI.Models.UserQuery;

namespace Exoticamp.UI.Services.IRepositories
{
    public interface IUserQueryRepository
    {
        Task<IEnumerable<UserQueyVM>> GetAllUserQueries();
        Task<Response<UserQueyVM>> GetUserQueryById( string Id);
        Task<Response<string>> RespondToUserQuery(UserQueyVM userQuey);


    }
}
