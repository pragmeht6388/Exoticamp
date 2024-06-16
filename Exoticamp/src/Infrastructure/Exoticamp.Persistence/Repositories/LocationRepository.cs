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
    public class LocationRepository : BaseRepository<Location>, ILoactionRepository
    {
        private readonly ILogger _logger;

        public LocationRepository(ApplicationDbContext dbContext, ILogger<Location> logger) : base(dbContext, logger)
        {
            _logger = logger;
        }
        public async Task<Location> GetLocationById(string id)
        {
            return await _dbContext.Locations.FirstOrDefaultAsync(b => b.Id.ToString() == id);
        }
    }
}
