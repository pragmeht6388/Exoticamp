using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Authentication;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Exoticamp.Application.Models.Authentication;
using Exoticamp.Application.Contracts.Identity;
using Exoticamp.Identity.Models;
using Exoticamp.Application.Responses;

namespace Exoticamp.Identity.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly JwtSettings _jwtSettings;

        public AuthenticationService(UserManager<ApplicationUser> userManager,
            IOptions<JwtSettings> jwtSettings,
            SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _jwtSettings = jwtSettings.Value;
            _signInManager = signInManager;
        }

        public async Task<AuthenticationResponse> AuthenticateAsync(AuthenticationRequest request)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);

            var role = await _userManager.GetRolesAsync(user);
            AuthenticationResponse response = new AuthenticationResponse();

            if (user == null)
            {
                response.IsAuthenticated = false;
                response.Message = $"No Accounts Registered with {request.Email}.";
                return response;
            }

            var result = await _signInManager.PasswordSignInAsync(user.UserName, request.Password, false, lockoutOnFailure: false);
            if (user.IsLocked)
            {
                response.IsAuthenticated = false;
                response.Message = $"Account for '{request.Email}' is locked. Please contact the administrator.";
                return response;
            }

            if (!result.Succeeded)
            {
                user.LoginAttemptCount += 1;

                if (user.LoginAttemptCount >= 3)
                {
                    user.IsLocked = true;
                    response.IsAuthenticated = false;
                    response.Message = $"Account for '{request.Email}' is locked due to multiple failed login attempts. Please contact the administrator.";

                }
                else
                {
                    response.IsAuthenticated = false;
                    response.Message = $"Invalid password for '{request.Email}'. You have {3 - user.LoginAttemptCount} more attempts before your account is locked.";
                }

                await _userManager.UpdateAsync(user);
                return response;
                //throw new AuthenticationException($"Credentials for '{request.Email}' aren't valid'.");
            }
            user.LoginAttemptCount = 0;
            await _userManager.UpdateAsync(user);
            JwtSecurityToken jwtSecurityToken = await GenerateToken(user);

            if (user.RefreshTokens.Any(a => a.IsActive))
            {
                var activeRefreshToken = user.RefreshTokens.FirstOrDefault(a => a.IsActive);
                response.RefreshToken = activeRefreshToken.Token;
                response.RefreshTokenExpiration = activeRefreshToken.Expires;
            }
            else
            {
                var refreshToken = GenerateRefreshToken();
                response.RefreshToken = refreshToken.Token;
                response.RefreshTokenExpiration = refreshToken.Expires;
                user.RefreshTokens.Add(refreshToken);
                await _userManager.UpdateAsync(user);
            }

            response.IsAuthenticated = true;
            response.Id = user.Id;
            response.Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
            response.Email = user.Email;
            response.UserName = user.UserName;
            response.Name = user.Name;
            response.LocationId = user.LocationId;
            if (role.Count > 0)
            {
                response.Role = role[0];
            }


            return response;
        }


        public async Task<ForgotPasswordResponse> ForgotPasswordAsync(ForgotPasswordRequest request)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);


            ForgotPasswordResponse response = new ForgotPasswordResponse();

            if (user == null)
            {
                response.userExists = false;
                //response.Message = $"No Accounts Registered with {request.Email}.";
                return response;
            }
            response.userExists = true;
            return response;
        }

        public async Task<Response<RegistrationResponse>> RegisterAsync(RegistrationRequest request)
        {
            var registrationresponse = new Response<RegistrationResponse>();

            var existingUser = await _userManager.FindByNameAsync(request.Email);


            if (existingUser != null)
            {
                registrationresponse.Message = $"Username '{request.Email}' already exists.";
                registrationresponse.Succeeded = false;
                return registrationresponse;
            }

            var user = new ApplicationUser
            {
                UserName = request.Email,
                Email = request.Email,
                Name = request.Name,
                PhoneNumber = request.PhoneNumber,
                TermsandCondition = true,
                EmailConfirmed = true,
                LocationId = request.LocationId,

            };

            var existingEmail = await _userManager.FindByEmailAsync(request.Email);

            if (existingEmail == null)
            {
                var result = await _userManager.CreateAsync(user, request.Password);

                if (result.Succeeded)
                {
                    if (string.IsNullOrEmpty(request.Role))
                    {
                        await _userManager.AddToRoleAsync(user, "User");
                    }
                    else if (request.Role == "SuperAdmin")
                    {
                        await _userManager.AddToRoleAsync(user, "Vendor");
                    }

                    return new Response<RegistrationResponse>()
                    {
                        Succeeded = true,
                        Data = new RegistrationResponse { UserId = user.Id }
                    };
                }
                else
                {
                    throw new Exception($"{result.Errors}");
                }
            }
            else
            {
                throw new ArgumentException($"Email '{request.Email}' already exists.");
            }
        }

        private async Task<JwtSecurityToken> GenerateToken(ApplicationUser user)
        {
            var userClaims = await _userManager.GetClaimsAsync(user);
            var roles = await _userManager.GetRolesAsync(user);

            var roleClaims = new List<Claim>();

            for (int i = 0; i < roles.Count; i++)
            {
                roleClaims.Add(new Claim("roles", roles[i]));
            }

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim("uid", user.Id)
            }
            .Union(userClaims)
            .Union(roleClaims);

            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key));
            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

            var jwtSecurityToken = new JwtSecurityToken(
                issuer: _jwtSettings.Issuer,
                audience: _jwtSettings.Audience,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(_jwtSettings.DurationInMinutes),
                signingCredentials: signingCredentials);
            return jwtSecurityToken;
        }

        private RefreshToken GenerateRefreshToken()
        {
            var randomNumber = new byte[32];
            using (var generator = new RNGCryptoServiceProvider())
            {
                generator.GetBytes(randomNumber);
                return new RefreshToken
                {
                    Token = Convert.ToBase64String(randomNumber),
                    Expires = DateTime.UtcNow.AddDays(10),
                    Created = DateTime.UtcNow
                };
            }
        }

        public async Task<RefreshTokenResponse> RefreshTokenAsync(RefreshTokenRequest request)
        {
            var response = new RefreshTokenResponse();
            var user = _userManager.Users.SingleOrDefault(u => u.RefreshTokens.Any(t => t.Token == request.Token));
            if (user == null)
            {
                response.IsAuthenticated = false;
                response.Message = $"Token did not match any users.";
                return response;
            }

            var refreshToken = user.RefreshTokens.Single(x => x.Token == request.Token);

            if (!refreshToken.IsActive)
            {
                response.IsAuthenticated = false;
                response.Message = $"Token Not Active.";
                return response;
            }

            //Revoke Current Refresh Token
            refreshToken.Revoked = DateTime.UtcNow;

            //Generate new Refresh Token and save to Database
            var newRefreshToken = GenerateRefreshToken();
            user.RefreshTokens.Add(newRefreshToken);
            await _userManager.UpdateAsync(user);

            //Generates new jwt
            response.IsAuthenticated = true;
            JwtSecurityToken jwtSecurityToken = await GenerateToken(user);
            response.Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
            response.Email = user.Email;
            response.UserName = user.UserName;
            response.RefreshToken = newRefreshToken.Token;
            response.RefreshTokenExpiration = newRefreshToken.Expires;
            return response;
        }

        //public async Task<Response<object>> ForgotPasswordAsync(string email)
        //{
        //    var response = new Response<object>();

        //    var user = await _userManager.FindByEmailAsync(email);
        //    if (user == null)
        //    {
        //        response.Succeeded = false;
        //        response.Message = "User not found";
        //        return response;
        //    }

        //    // Add logic to handle password reset (e.g., generate reset token, send email, etc.)
        //    // For now, we assume the operation is successful if the user is found.
        //    response.Succeeded = true;
        //    response.Message = "Password reset instructions have been sent to your email";
        //    return response;
        //}


        public async Task<RevokeTokenResponse> RevokeToken(RevokeTokenRequest request)
        {
            var response = new RevokeTokenResponse();
            if (string.IsNullOrEmpty(request.Token))
            {
                response.IsRevoked = false;
                response.Message = "Token is required";
                return response;
            }

            var user = _userManager.Users.SingleOrDefault(u => u.RefreshTokens.Any(t => t.Token == request.Token));

            if (user == null)
            {
                response.IsRevoked = false;
                response.Message = "Token did not match any users";
                return response;
            }

            var refreshToken = user.RefreshTokens.Single(x => x.Token == request.Token);
            if (!refreshToken.IsActive)
            {
                response.IsRevoked = false;
                response.Message = "Token is not active";
                return response;
            }
            // revoke token and save
            refreshToken.Revoked = DateTime.UtcNow;
            await _userManager.UpdateAsync(user);
            response.IsRevoked = true;
            response.Message = "Token revoked";
            return response;
        }

        public async Task<Response<object>> MarkUserAsDeletedAsync(string userId)
        {
            var response = new Response<object>();

            var user = await _userManager.FindByEmailAsync(userId);
            if (user == null)
            {
                response.Succeeded = false;
                response.Message = "User not found";
                return response;
            }

            user.IsDeleted = true; // Assuming `IsDeleted` is a property in ApplicationUser
            var result = await _userManager.UpdateAsync(user);

            if (!result.Succeeded)
            {
                response.Succeeded = false;
                response.Message = "Error marking user as deleted";
                return response;
            }

            response.Succeeded = true;
            response.Message = "User marked as deleted successfully";
            return response;
        }

        public async Task<Response<object>> MarkUserUnlockedAsync(string userId)
        {
            var response = new Response<object>();

            var user = await _userManager.FindByEmailAsync(userId);
            if (user == null)
            {
                response.Succeeded = false;
                response.Message = "User not found";
                return response;
            }

            user.IsLocked = false;
            user.LoginAttemptCount = 0;

            var result = await _userManager.UpdateAsync(user);
            if (!result.Succeeded)
            {
                response.Succeeded = false;
                response.Message = "Error unlocking user account";
                return response;
            }

            response.Succeeded = true;
            response.Message = "User account unlocked successfully";
            return response;
        }
    }
}
