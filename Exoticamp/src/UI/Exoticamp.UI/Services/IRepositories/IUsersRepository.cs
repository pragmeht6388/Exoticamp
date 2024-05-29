using Exoticamp.UI.Models.Events;
using Exoticamp.UI.Models.ResponseModels.Users;
using Exoticamp.UI.Models.Users;

namespace Exoticamp.UI.Services.IRepositories
{
    public interface IUsersRepository
    {

        public  Task<IEnumerable<UsersVM>> GetAllUsersAsync();
        
        }
}
