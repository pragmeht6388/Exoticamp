using Exoticamp.UI.Models.Login;
using Exoticamp.UI.Models.ResponseModels.Users;

namespace Exoticamp.UI.Services.IRepositories
{
    public interface ILoginRepository
    {
        Task<UserLoginResponse> AuthenticateAsync(LoginVM request);

    }
}
