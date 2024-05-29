using Exoticamp.Application.Contracts.Persistence;
using Exoticamp.Domain.Entities;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exoticamp.Persistence.Repositories
{
    public class CampsiteDetailsRepository:BaseRepository<CampsiteDetails>, ICampsiteDetailsRepository
    {
        private readonly ILogger _logger;
        public CampsiteDetailsRepository(ApplicationDbContext dbContext, ILogger<CampsiteDetails> logger) : base(dbContext, logger)
        {
            _logger = logger;
        }

        public Task<CampsiteDetails> AddCampsite(CampsiteDetails campsite)
        {
            throw new NotImplementedException();
        }

        public Task<CampsiteDetails> Delete(CampsiteDetails campsite)
        {
            throw new NotImplementedException();
        }

        public Task<List<CampsiteDetails>> GetAllCampsite(bool includePassedEvents)
        {
            throw new NotImplementedException();
        }

        public Task<CampsiteDetails> Update(CampsiteDetails campsite)
        {
            throw new NotImplementedException();
        }

    }
}
