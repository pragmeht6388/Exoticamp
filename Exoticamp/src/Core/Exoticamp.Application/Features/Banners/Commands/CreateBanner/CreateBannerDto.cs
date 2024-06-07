using Exoticamp.Domain.Entities;
using System;

namespace Exoticamp.Application.Features.Banners.Commands.CreateBanner
{
    public class CreateBannerDto
    {
        public Guid BannerId { get; set; }
        public string Link { get; set; }
        public bool IsActive { get; set; }
        public string PromoCode { get; set; }
        //public string Locations { get; set; }
   
        public Guid LocationId { get; set; }
        public string ImagePath { get; set; }

        public Location Location { get; set; }
        public bool IsDeleted { get; set; }
    }
}
