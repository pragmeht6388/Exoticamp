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
    public class BannerRepository : BaseRepository<Banner>, IBannerRepository
    {
        private readonly ILogger _logger;

        public BannerRepository(ApplicationDbContext dbContext, ILogger<Banner> logger) : base(dbContext, logger)
        {
            _logger = logger;
        }

        public async Task<Banner> AddBanner(Banner banner)
        {
            return await AddAsync(banner);
        }

        public async Task<Banner> DeleteBanner(Banner banner)
        {
            await DeleteAsync(banner);
            return banner;
        }

        public async Task<List<Banner>> GetAllBanners(bool includeInactive)
        {
            return await _dbContext.Banners
                .Where(b => includeInactive || b.IsActive)
                .ToListAsync();
        }

        public async Task<Banner> UpdateBanner(Banner banner)
        {
            await UpdateAsync(banner);
            return banner;
        }
    }
}
