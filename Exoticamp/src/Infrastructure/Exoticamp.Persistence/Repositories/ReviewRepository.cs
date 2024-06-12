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
    public class ReviewRepository : BaseRepository<Reviews>, IReviewRepository
    {
        private readonly ILogger _logger;
        // private readonly ApplicationDbContext _dbContext;
        public ReviewRepository(ApplicationDbContext dbContext, ILogger<Reviews> logger) : base(dbContext, logger)
        {
            _logger = logger;
            // _dbContext = dbContext;
        }

        public Task<Reviews> AddReviews(Reviews reviews)
        {
            throw new NotImplementedException();
        }
        public Task<List<Reviews>> GetAllReviews(bool includePassedEvents)
        {
            throw new NotImplementedException();
        }
    }
}
