using Exoticamp.Application.Models.Authentication;
using Exoticamp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exoticamp.Application.Contracts.Identity
{
    public interface IUserService
    {
        Task<List< RegistrationRequest>> GetAllUserDetails();
        Task<RegistrationRequest> Delete(RegistrationRequest category);
        Task<ApplicationUser> GetUserDetailsById(string Id);
    }
}
