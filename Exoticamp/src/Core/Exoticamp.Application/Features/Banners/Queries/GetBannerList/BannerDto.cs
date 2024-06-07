using Exoticamp.Domain.Entities;

namespace Exoticamp.Application.Features.Banners.Queries
{
    public class BannerDto
    {
        public Guid BannerId { get; set; }
        public string Link { get; set; }
        public bool IsActive { get; set; }
        public string PromoCode { get; set; }

        public bool IsDeleted { get; set; }

        public Guid LocationId { get; set; }

        public string LocationName { get; set; }
        public Location Location { get; set; }
        public string ImagePath { get; set; }
    }
}
