using Exoticamp.Application.Features.Banners.Queries.GetBanner;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exoticamp.Domain.Entities;

namespace Exoticamp.Application.Features.Glamping.GetGlamping
{
    public class GlampingDto 
    {
        public Guid GlampingId { get; set; }
        public Guid CampsiteId { get; set; }
        public Exoticamp.Domain.Entities.CampsiteDetails Campsite { get; set; }
        public string Category { get; set; } // e.g., "2 Person", "4 Person"
        public int Capacity { get; set; }
        public decimal Cost { get; set; }
    }
}
