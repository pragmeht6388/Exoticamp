using Exoticamp.UI.Models.ForgotPassword;
using Exoticamp.UI.Models.Login;
using Exoticamp.UI.Models.ResponseModels.ForgotPassword;
using Exoticamp.UI.Models.ResponseModels.Users;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;

namespace Exoticamp.UI.Services.IRepositories
{
    public interface ILoginRepository
    {
        Task<UserLoginResponse> AuthenticateAsync(LoginVM request);
  
        Task<ForgotPasswordResponseModel> ForgotPasswordAsync(ForgotPasswordVM request);
    }
}
