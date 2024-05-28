namespace Exoticamp.Application.Features.Banners.Queries
{
    public class BannerDto
    {
        public Guid BannerId { get; set; }
        public string Link { get; set; }
        public bool IsActive { get; set; }
        public string PromoCode { get; set; }
        public string Locations { get; set; }
        public string ImagePath { get; set; }
    }
}
