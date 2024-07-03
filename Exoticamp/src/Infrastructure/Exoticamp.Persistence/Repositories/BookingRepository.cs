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
    public class BookingRepository:BaseRepository<Booking>,IBookingRepository
    {
        private readonly ILogger _logger;
        public BookingRepository(ApplicationDbContext dbContext, ILogger<Booking> logger) : base(dbContext, logger)
        {
            _logger = logger;
        }
        public Task<bool> IsCheckInDateUnique( DateTime checkInDate,Guid id)
        {
            _logger.LogInformation("GetCategoriesWithEvents Initiated");
            var matches = _dbContext.Bookings.Where(x=>x.CampsiteId==id).Any(e => e.CheckIn.Date.Equals(checkInDate.Date));
            _logger.LogInformation("GetCategoriesWithEvents Completed");
            return Task.FromResult(matches);
        }
    }
}
