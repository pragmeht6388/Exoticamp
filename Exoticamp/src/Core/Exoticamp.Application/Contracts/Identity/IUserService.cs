using Exoticamp.Application.Models.Authentication;
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
    }
}
