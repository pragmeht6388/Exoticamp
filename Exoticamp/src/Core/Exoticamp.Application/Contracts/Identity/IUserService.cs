using Exoticamp.Application.Features.Users.Queries.GetUserList;
using Exoticamp.Application.Features.Vendors.Queries.GetVendorList;
using Exoticamp.Application.Features.Users.Queries.GetUser;
using Exoticamp.Application.Models.Authentication;
using Exoticamp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exoticamp.Application.Features.Vendors.Queries.GetVendor;
using Exoticamp.Application.Features.Vendors.Commands.UpdateVendor;

namespace Exoticamp.Application.Contracts.Identity
{
    public interface IUserService
    {
        Task<List< GetUserListDto>> GetAllUserDetails();
        Task<List< GetVendorListDto>> GetAllVendorDetails();
        Task<RegistrationRequest> Delete(RegistrationRequest category);
        Task<GetUserDto> GetUserDetailsById(string Id);
        Task<string> UpdateUser(GetUserDto model);
        Task<UpdatedVendorDto> UpdateVendor(UpdatedVendorDto model);
        Task<GetVendorDto> GetVendorDetailsById(string Id);


    }
}
