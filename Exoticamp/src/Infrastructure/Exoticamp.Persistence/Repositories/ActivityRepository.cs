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
    public class ActivityRepository : BaseRepository<Activities>, IActivitiesRepository
    {
        private readonly ILogger _logger;
        public ActivityRepository(ApplicationDbContext dbContext, ILogger<Activities> logger) : base(dbContext, logger)
        {
            _logger = logger;
        }

        public Task<Activities> Add(Activities activities)
        {
            throw new NotImplementedException();
        }

        public Task<Activities> Delete(Activities activities)
        {
            throw new NotImplementedException();
        }

        public Task<List<Activities>> GetAll(bool includePassedEvents)
        {
            throw new NotImplementedException();
        }

        public Task<Activities> Update(Activities activities)
        {
            throw new NotImplementedException();
        }

    }
}
