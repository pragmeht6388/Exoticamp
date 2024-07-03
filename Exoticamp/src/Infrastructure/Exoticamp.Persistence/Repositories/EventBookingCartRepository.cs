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
    public class EventBookingCartRepository : BaseRepository<EventBookingCart>, IEventBookingCartRepository
    {
        private readonly ILogger _logger;
        public EventBookingCartRepository(ApplicationDbContext dbContext, ILogger<EventBookingCart> logger) : base(dbContext, logger)
        {
            _logger = logger;
        }

        public Task<EventBookingCart> AddEventBookingCart(EventBookingCart eventBookingCart)
        {
            throw new NotImplementedException();
        }

        public Task<EventBookingCart> Delete(EventBookingCart eventBookingCart)
        {
            throw new NotImplementedException();
        }

        public Task<List<EventBookingCart>> GetAllEventBookingCart(bool includePassedEvents)
        {
            throw new NotImplementedException();
        }

        public Task<EventBookingCart> Update(EventBookingCart eventBookingCart)
        {
            throw new NotImplementedException();
        }

    }
}
