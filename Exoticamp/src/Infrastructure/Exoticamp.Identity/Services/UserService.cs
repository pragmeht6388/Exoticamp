using Exoticamp.Application.Contracts.Identity;
using Exoticamp.Application.Models.Authentication;
using Exoticamp.Identity.Models;
using Microsoft.AspNetCore.Identity;
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
    }
}
