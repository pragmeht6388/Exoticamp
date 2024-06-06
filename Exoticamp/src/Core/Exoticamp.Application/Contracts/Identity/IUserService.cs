using Exoticamp.Application.Features.Users.Queries.GetUserList;
using Exoticamp.Application.Features.Vendors.Queries.GetVendorList;
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
        Task<List< GetUserListDto>> GetAllUserDetails();
        Task<List< GetVendorListDto>> GetAllVendorDetails();
        Task<RegistrationRequest> Delete(RegistrationRequest category);
        Task<RegistrationRequest> GetUserDetailsById(string Id);
    }
}
