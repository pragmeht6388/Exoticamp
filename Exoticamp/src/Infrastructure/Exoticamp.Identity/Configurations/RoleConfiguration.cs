using Exoticamp.Application.Models.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Diagnostics.CodeAnalysis;

namespace Exoticamp.Identity.Configurations
{
    [ExcludeFromCodeCoverage]
    public class RoleConfiguration  
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        public RoleConfiguration(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }
        public async Task<bool> RoleExistsAsync(string roleName)
        {
            return await _roleManager.RoleExistsAsync(roleName);
        }


         
        public async Task<IdentityResult> AddRoleAsync(CreateRoleRequest createRole)
        {
            if (createRole.CreateBy != "SuperAdmin")
            {
                return IdentityResult.Failed(new IdentityError { Description = "Only Admin can create roles." });
            }
            if (await RoleExistsAsync(createRole.RoleName))
            {
                return IdentityResult.Failed(new IdentityError { Description = $"Role {createRole.RoleName} already exists." });
            }

            IdentityRole role = new IdentityRole
            {
                Name = createRole.RoleName,
                NormalizedName = createRole.RoleName.ToUpper()
            };

            return await _roleManager.CreateAsync(role);
        }
    }
}
