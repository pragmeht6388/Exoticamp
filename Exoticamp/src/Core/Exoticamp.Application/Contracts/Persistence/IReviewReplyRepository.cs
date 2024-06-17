using Exoticamp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exoticamp.Application.Contracts.Persistence
{
    public interface IReviewReplyRepository : IAsyncRepository<ReviewReply>
    {
        Task<ReviewReply> AddReviewReply(ReviewReply reviews);
    }
}
