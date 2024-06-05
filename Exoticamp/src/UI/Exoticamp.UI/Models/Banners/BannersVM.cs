using System.ComponentModel.DataAnnotations.Schema;

namespace Exoticamp.UI.Models.Banners
{
    public class BannerViewModel
    {
        public Guid BannerId { get; set; }
        public string Link { get; set; }
        public bool IsActive { get; set; }
        public string PromoCode { get; set; }
        public string Locations { get; set; }
        [NotMapped]
        public IFormFile ImageFile { get; set; }
        public string? ImagePath { get; set; }
    }
}
