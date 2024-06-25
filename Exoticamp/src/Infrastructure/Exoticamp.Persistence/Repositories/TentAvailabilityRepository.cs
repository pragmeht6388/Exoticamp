using Exoticamp.Application.Contracts.Persistence;
using Exoticamp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exoticamp.Persistence.Repositories
{
    public class TentAvailabilityRepository : BaseRepository<TentAvailability>, ITentAvailabilityRepository
    {
        private readonly ILogger _logger;
        public TentAvailabilityRepository(ApplicationDbContext dbContext, ILogger<TentAvailability> logger) : base(dbContext, logger)
        {
            _logger = logger;
        }

        public async Task<IEnumerable<TentAvailability>> GetAll()
        {
            return null;// await _dbContext.ListAllAsync();
        }
    }
}
