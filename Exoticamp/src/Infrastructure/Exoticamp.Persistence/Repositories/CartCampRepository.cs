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
    public class CartCampRepository : BaseRepository<CartCamp>, ICartCampRepository
    {
        private readonly ILogger _logger;

        public CartCampRepository(ApplicationDbContext dbContext, ILogger<CartCamp> logger) : base(dbContext, logger)
        {
            _logger = logger;
        }

        public async Task<CartCamp> Addcart(CartCamp cartCamp)
        {
            return await AddAsync(cartCamp);
        }

        public Task<CartCamp> DeleteCart(CartCamp cartCamp)
        {
            throw new NotImplementedException();
        }

        public Task<List<Campsite>> GetAll(bool includePassedEvents)
        {
            throw new NotImplementedException();
        }
    }
}
