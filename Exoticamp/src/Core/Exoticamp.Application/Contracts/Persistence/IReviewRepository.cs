using Exoticamp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exoticamp.Application.Contracts.Persistence
{
    public interface IReviewRepository : IAsyncRepository<Reviews>
    {
        Task<List<Reviews>> GetAllReviews(bool includePassedEvents);
        Task<Reviews> AddReviews(Reviews reviews);
    }
}
