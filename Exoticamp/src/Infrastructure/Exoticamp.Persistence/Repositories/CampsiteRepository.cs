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
    public class CampsiteRepository: BaseRepository<Campsite>, ICampsiteRepository
    {
        private readonly ILogger _logger;
        public CampsiteRepository(ApplicationDbContext dbContext, ILogger<Campsite> logger) : base(dbContext, logger)
        {
            _logger = logger;
        }

        public Task<Campsite> AddCampsite(Campsite campsite)
        {
            throw new NotImplementedException();
        }

        public Task<Campsite> Delete(Campsite campsite)
        {
            throw new NotImplementedException();
        }

        public Task<List<Campsite>> GetAllCampsite(bool includePassedEvents)
        {
            throw new NotImplementedException();
        }

        public Task<Campsite> Update(Campsite campsite)
        {
            throw new NotImplementedException();
        }


    }
}
