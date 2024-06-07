using Exoticamp.Application.Responses;
using MediatR;

namespace Exoticamp.Application.Features.Banners.Commands.UpdateBanner
{
    public class UpdateBannerCommand : IRequest<Response<UpdateBannerDto>>
    {
        public Guid BannerId { get; set; }
        public string Link { get; set; }
        public bool IsActive { get; set; }
        public string PromoCode { get; set; }
        //public string Locations { get; set; }
        public bool IsDeleted { get; set; }
        public Guid LocationId { get; set; }
        public string ImagePath { get; set; }
    }
}
