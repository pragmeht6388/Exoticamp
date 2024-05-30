using Exoticamp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exoticamp.Application.Contracts.Persistence
{
    public interface IBannerRepository : IAsyncRepository<Banner>
    {
        Task<List<Banner>> GetAllBanners(bool includeInactive);
        Task<Banner> AddBanner(Banner banner);
        Task<Banner> UpdateBanner(Banner banner);
        Task<Banner> DeleteBanner(Banner banner);

        Task<Banner> GetBannerByLinkAsync(string link);
    }
}
