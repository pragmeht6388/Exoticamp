using Exoticamp.UI.Models.Events;
using Exoticamp.UI.Models.ResponseModels;
using Exoticamp.UI.Models.ResponseModels.Users;
using Exoticamp.UI.Models.Users;
using Exoticamp.UI.Models.Vendors;

namespace Exoticamp.UI.Services.IRepositories
{
    public interface IUsersRepository
    {

        public Task<IEnumerable<UsersVM>> GetAllUsersAsync();

        public Task<IEnumerable<UsersVM>> GetAllVendorsAsync();
        public Task<string> IsDeleteAsync(string Email);
        public Task<string> IsLockedUsersAsync(string Email);
        public Task<Response<UsersVM>> GetUserByIdAsync(string UserId);
        public Task<Response<VendorVM>> GetVendorByIdAsync(string UserId);
        public Task<Response<string>> UpdateProfile(UsersVM model);


    }
}
