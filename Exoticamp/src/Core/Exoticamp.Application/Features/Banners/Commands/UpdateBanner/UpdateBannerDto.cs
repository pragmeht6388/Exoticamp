using Exoticamp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exoticamp.Application.Features.Banners.Commands.UpdateBanner
{
    public class UpdateBannerDto
    {
        public Guid BannerId { get; set; }
        public string Link { get; set; }
        public bool IsActive { get; set; }
        public string PromoCode { get; set; }
        //public string Locations { get; set; }
        public bool IsDeleted { get; set; }
        public Guid LocationId { get; set; }
        public string ImagePath { get; set; }

        public Location Location { get; set; }
    }
}
