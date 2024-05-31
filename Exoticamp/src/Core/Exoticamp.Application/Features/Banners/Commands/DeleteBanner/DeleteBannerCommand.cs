using MediatR;
using System;

namespace Exoticamp.Application.Features.Banners.Commands.DeleteBanner
{
    public class DeleteBannerCommand : IRequest<Unit>
    {
        public string Id { get; set; }
    }
}
