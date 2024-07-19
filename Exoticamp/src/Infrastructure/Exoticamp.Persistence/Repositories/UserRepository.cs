using Exoticamp.Application.Contracts.Persistence;
using Exoticamp.Application.Models.Authentication;
using Exoticamp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exoticamp.Persistence.Repositories
{
    public class UserRepository : IUserRepository
    {
        public Task<RegistrationRequest> AddAsync(RegistrationRequest entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(RegistrationRequest entity)
        {
            throw new NotImplementedException();
        }
        public Task<RegistrationRequest> GetByIdbyintAsync(int id)
        {
            throw new NotImplementedException();
        }
        public Task<List<RegistrationRequest>> GetAllUsers(bool includePassedEvents)
        {
            throw new NotImplementedException();
        }

        public Task<RegistrationRequest> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }


		public Task<IReadOnlyList<RegistrationRequest>> GetPagedReponseAsync(int page, int size)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<RegistrationRequest>> ListAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(RegistrationRequest entity)
        {
            throw new NotImplementedException();
        }

    }
}
