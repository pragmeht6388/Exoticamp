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
    public class TentRepository : BaseRepository<Tent>, ITentRepository
    {
        private readonly ILogger _logger;
        public TentRepository(ApplicationDbContext dbContext, ILogger<Tent> logger) : base(dbContext, logger)
        {
            _logger = logger;
        }
        public Task<List<Tent>> GetAllTents(bool includePassedEvents)
        {
            throw new NotImplementedException();
        }
    }
}
