using Exoticamp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exoticamp.Application.Features.Banners.Queries.GetBanner
{
    public class BannerVM
    {
        public string BannerId { get; set; }
        public string Link { get; set; }
        public bool IsActive { get; set; }
        public string PromoCode { get; set; }
        //public string Locations { get; set; }
        public bool IsDeleted { get; set; }

        public Guid LocationId {  get; set; }

        public Location Location {  get; set; }
        public string ImagePath { get; set; }
    }
}
