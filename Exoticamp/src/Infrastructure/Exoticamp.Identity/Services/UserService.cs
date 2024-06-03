using Exoticamp.Application.Contracts.Identity;
using Exoticamp.Application.Features.Users.Queries.GetUser;
using Exoticamp.Application.Models.Authentication;
using Exoticamp.Identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exoticamp.Identity.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<ApplicationUser> _userManager;

        private readonly IdentityDbContext identityDbContext;
        public UserService(UserManager<ApplicationUser> userManager, IdentityDbContext _identityDbContext)
        {
            identityDbContext = _identityDbContext;
            _userManager = userManager;  
        }

        public async Task<RegistrationRequest> Delete(RegistrationRequest registrationRequest)
        {
           var user = await _userManager.FindByEmailAsync(registrationRequest.Email);
            // Or use FindByIdAsync if using UserId
            // var user = await _userManager.FindByIdAsync(registrationRequest.Id);

            if (user == null)
            {
                return null; // User not found
            }

            // Begin transaction if necessary
            using var transaction = await identityDbContext.Database.BeginTransactionAsync();

            try
            {
                // Remove any related data if necessary
                var userRoles = await identityDbContext.UserRoles
                    .Where(ur => ur.UserId == user.Id)
                .ToListAsync();

                identityDbContext.UserRoles.RemoveRange(userRoles);

                // Remove user
                var result = await _userManager.DeleteAsync(user);

                if (result.Succeeded)
                {
                    await identityDbContext.SaveChangesAsync();
                    await transaction.CommitAsync();
                }
                else
                {
                    await transaction.RollbackAsync();
                    throw new Exception("Error occurred while deleting user");
                }

                return registrationRequest;
            }
            catch
            {
                await transaction.RollbackAsync();
                throw;
            }
        
    
}

        public async Task<List<RegistrationRequest>> GetAllUserDetails()
        {

            var data = await (from user in identityDbContext.Users
                              join userRole in identityDbContext.UserRoles on user.Id equals userRole.UserId
                              join role in identityDbContext.Roles on userRole.RoleId equals role.Id
                              select new RegistrationRequest()
                              {
                                  Email= user.Email,
                                  Name=user.Name,
                                   PhoneNumber= user.PhoneNumber,
                                   Role= role.Name,
                                   TermsandCondition= user.TermsandCondition
                              }).ToListAsync();

            return data;
        }

        public async Task<GetUserDto> GetUserDetailsById(string Id)
        {
            var user = await _userManager.FindByIdAsync(Id);
            return new GetUserDto()
            {
                Email = user.Email,
                Name = user.Name,
                PhoneNumber = user.PhoneNumber,
                TermsandCondition = user.TermsandCondition,
                LocationId = user.LocationId,
                PreferenceId = user.ActivityId,
                
            };
        }
    }
}
