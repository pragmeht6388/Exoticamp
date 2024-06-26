﻿using Exoticamp.Application.Contracts.Persistence;
using Exoticamp.Domain.Entities;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exoticamp.Persistence.Repositories
{
    public class ReviewReplyRepository : BaseRepository<ReviewReply>, IReviewReplyRepository
    {
        private readonly ILogger _logger;
        // private readonly ApplicationDbContext _dbContext;
        public ReviewReplyRepository(ApplicationDbContext dbContext, ILogger<ReviewReply> logger) : base(dbContext, logger)
        {
            _logger = logger;
            // _dbContext = dbContext;
        }

        public Task<Reviews> AddReviews(Reviews reviews)
        {
            throw new NotImplementedException();
        }

        public Task<ReviewReply> AddReviewReply(ReviewReply reviews)
        {
            throw new NotImplementedException();
        }

        public Task<List<ReviewReply>> GetAllReply(bool includePassedEvents)
        {
            throw new NotImplementedException();
        }
    }
}
