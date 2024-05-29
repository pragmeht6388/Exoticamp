using Exoticamp.Application.Models.Authentication;
using Exoticamp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exoticamp.Application.Contracts.Persistence
{
    
    public interface IUserRepository : IAsyncRepository<RegistrationRequest>
    {
        Task<List<RegistrationRequest>> GetAllUsers(bool includePassedEvents);
        //Task<RegistrationRequest> AddProduct(Product product);
        //Task<RegistrationRequest> Update(Product product);
        //Task<Product> Delete(Product product);
    }
}
