using MediatR;
using Exoticamp.Application.Responses;

namespace Exoticamp.Application.Features.Banners.Commands.CreateBanner
{
    public class CreateBannerCommand : IRequest<Response<CreateBannerDto>>
    {
        public string Link { get; set; }
        public bool IsActive { get; set; } = true; // Default to active
        public string PromoCode { get; set; }

        public bool IsDeleted { get; set; } = false;
        public Guid LocationId {  get; set; }
        //public string Locations { get; set; }
        public string ImagePath { get; set; }

    }
}
