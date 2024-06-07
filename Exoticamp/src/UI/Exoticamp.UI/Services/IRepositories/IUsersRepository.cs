using Exoticamp.UI.Models.Events;
using Exoticamp.UI.Models.ResponseModels;
using Exoticamp.UI.Models.ResponseModels.Users;
using Exoticamp.UI.Models.Users;

namespace Exoticamp.UI.Services.IRepositories
{
    public interface IUsersRepository
    {

        public Task<IEnumerable<UsersVM>> GetAllUsersAsync();

        public Task<IEnumerable<UsersVM>> GetAllVendorsAsync();
        public Task<UsersVM> IsDeleteAsync(string Email);
        public Task<UsersVM> IsLockedUsersAsync(string Email);
        public Task<Response<UsersVM>> GetUserByIdAsync(string UserId);
        public Task<Response<string>> UpdateProfile(UsersVM model);


    }
}
