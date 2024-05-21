using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;
using Exoticamp.Application.Contracts.Persistence;
using Exoticamp.Domain.Entities;
using Exoticamp.Persistence;

namespace Exoticamp.Persistence.Repositories
{
    [ExcludeFromCodeCoverage]
    public class OrderRepository : BaseRepository<Order>, IOrderRepository
    {
        private readonly ILogger _logger;
        public OrderRepository(ApplicationDbContext dbContext, ILogger<Order> logger) : base(dbContext, logger)
        {
            _logger = logger;
        }

        public async Task<List<Order>> GetPagedOrdersForMonth(DateTime date, int page, int size)
        {
            _logger.LogInformation("GetPagedOrdersForMonth Initiated");
            return await _dbContext.Orders.Where(x => x.OrderPlaced.Month == date.Month && x.OrderPlaced.Year == date.Year)
                .Skip((page - 1) * size).Take(size).AsNoTracking().ToListAsync();
        }

        public async Task<int> GetTotalCountOfOrdersForMonth(DateTime date)
        {
            _logger.LogInformation("GetPagedOrdersForMonth Initiated");
            return await _dbContext.Orders.CountAsync(x => x.OrderPlaced.Month == date.Month && x.OrderPlaced.Year == date.Year);
        }
    }
}
