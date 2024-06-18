using Exoticamp.Application.Models.Authentication;
using Exoticamp.Application.Responses;
using System.Threading.Tasks;

namespace Exoticamp.Application.Contracts.Identity
{
    public interface IAuthenticationService
    {
        Task<AuthenticationResponse> AuthenticateAsync(AuthenticationRequest request);
        Task<ForgotPasswordResponse> ForgotPasswordAsync(ForgotPasswordRequest request);
        Task<Response<object>> MarkUserUnlockedAsync(string userId);
        Task<Response<RegistrationResponse>> RegisterAsync(RegistrationRequest request);
        Task<RefreshTokenResponse> RefreshTokenAsync(RefreshTokenRequest request);
        Task<RevokeTokenResponse> RevokeToken(RevokeTokenRequest request);
        Task<Response<object>> MarkUserAsDeletedAsync(string userId);
       // Task<Response<object>> ForgotPasswordAsync(string  Email);
        


    }
}
