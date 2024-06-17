using Exoticamp.Application.Contracts.Identity;
using Exoticamp.Application.Features.Users.Queries.GetUserList;
using Exoticamp.Application.Features.Vendors.Queries.GetVendorList;
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
using Exoticamp.Application.Features.Vendors.Queries.GetVendor;

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

        public async Task<List<GetUserListDto>> GetAllUserDetails()
        {

            //var data = await (from user in identityDbContext.Users
            //                  join userRole in identityDbContext.UserRoles on user.Id equals userRole.UserId
            //                  join role in identityDbContext.Roles on userRole.RoleId equals role.Id
            //                  select new RegistrationRequest()
            //                  {
            //                      Email= user.Email,
            //                      Name=user.Name,
            //                       PhoneNumber= user.PhoneNumber,
            //                       Role= role.Name,
            //                       TermsandCondition= user.TermsandCondition
            //                  }).ToListAsync();

            //return data;
             
                var data = await (from user in identityDbContext.Users
                                  join userRole in identityDbContext.UserRoles on user.Id equals userRole.UserId
                                  join role in identityDbContext.Roles on userRole.RoleId equals role.Id
                                  where role.Name == "User" && user.IsDeleted == false
                                  select new GetUserListDto()
                                  {
                                      Id = user.Id,
                                      Email = user.Email,
                                      Name = user.Name,
                                      PhoneNumber = user.PhoneNumber,
                                      Role = role.Name,
                                      TermsandCondition = user.TermsandCondition,
                                      IsLocked = user.IsLocked,
                                      LoginAttemptCount = user.LoginAttemptCount,

                                  }).ToListAsync();

               return data;
            

        }

        public async Task<List<GetVendorListDto>> GetAllVendorDetails()
        {

            var data = await (from user in identityDbContext.Users
                              join userRole in identityDbContext.UserRoles on user.Id equals userRole.UserId
                              join role in identityDbContext.Roles on userRole.RoleId equals role.Id
                              where role.Name == "Vendor" && user.IsDeleted ==  false
                              select new GetVendorListDto()
                              {    Id=user.Id,
                                  Email = user.Email,
                                  Name = user.Name,
                                  PhoneNumber = user.PhoneNumber,
                                  Role = role.Name,
                                  TermsandCondition = user.TermsandCondition,
                                  IsLocked = user.IsLocked,
                                  LoginAttemptCount = user.LoginAttemptCount,
                                  
                                  
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
                IsLocked= user.IsLocked,
                 LoginAttemptCount= user.LoginAttemptCount,
            };
        }
        public async Task<GetVendorDto> GetVendorDetailsById(string Id)
        {
            var user = await _userManager.FindByIdAsync(Id);
            return new GetVendorDto()
            {
                  Id=user.Id,
                Email = user.Email,
                Name = user.Name,
                PhoneNumber = user.PhoneNumber,
                AltAddress = user.AltAddress,
                LocationId = user.LocationId,
                AltEmail = user.AltEmail,
                AltPhoneNumber = user.AltPhoneNumber,
                Address = user.Address,
                IsLocked=user.IsLocked,
                LoginAttemptCount=user.LoginAttemptCount,
                

            };
        }

        public async Task<string> UpdateUser(GetUserDto model)
        {
            var user = await _userManager.FindByIdAsync(model.Id);
            user.PhoneNumber = model.PhoneNumber;
            user.Name = model.Name;
            user.Email = model.Email;
            user.ActivityId = model.PreferenceId;
            user.LocationId = model.LocationId;

            await _userManager.UpdateAsync(user);

            return user.Id;


        }
        public async Task<string> UpdateVendor(GetVendorDto model)
        {
            var vendor = await _userManager.FindByIdAsync(model.Id);

            if (vendor == null)
            {
                // Handle case where vendor is not found
                throw new Exception("Vendor not found");
            }

            // Update vendor properties
            vendor.Name = model.Name;
            vendor.PhoneNumber = model.PhoneNumber;
            vendor.Email = model.Email;
            vendor.Address = model.Address;
            vendor.AltPhoneNumber = model.AltPhoneNumber;
            vendor.AltEmail = model.AltEmail;
            vendor.AltAddress = model.AltAddress;
            vendor.LocationId = model.LocationId;

            // Save changes
            await _userManager.UpdateAsync(vendor);

            return vendor.Id;
        }
    }
}
