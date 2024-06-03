using Exoticamp.Application.Contracts.Persistence;
using Exoticamp.Application.Exceptions;
using Exoticamp.Application.Features.Banners.Commands.DeleteBanner;
using Exoticamp.Domain.Entities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Exoticamp.Application.Features.Banners.Commands.DeleteBanner
{
    public class DeleteBannerCommandHandler : IRequestHandler<DeleteBannerCommand, Unit>
    {
        private readonly IBannerRepository _bannerRepository;

        public DeleteBannerCommandHandler(IBannerRepository bannerRepository)
        {
            _bannerRepository = bannerRepository;
        }

        public async Task<Unit> Handle(DeleteBannerCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var bannerToDelete = await _bannerRepository.GetByIdAsync(Guid.Parse(request.Id));

                if (bannerToDelete == null)
                {
                    throw new NotFoundException(nameof(Banner), request.Id);
                }

                // Perform the deletion logic here
                // For example, you can mark the banner as inactive or delete it from the database
                //bannerToDelete.IsDeleted = true;
                bannerToDelete.IsActive = false; // Marking the banner as inactive

                // Update the database
                await _bannerRepository.UpdateAsync(bannerToDelete);

                return Unit.Value;
            }
            catch (Exception ex)
            {
                // Log or handle the exception appropriately
                throw; // Rethrow the exception to maintain consistency in error handling
            }
        }
    }
}
