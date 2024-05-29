using AutoMapper;
using Exoticamp.Application.Contracts.Persistence;
using Exoticamp.Application.Exceptions;
using Exoticamp.Application.Responses;
using Exoticamp.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Exoticamp.Application.Features.Banners.Commands.UpdateBanner
{
    public class UpdateBannerCommandHandler : IRequestHandler<UpdateBannerCommand, Response<UpdateBannerDto>>
    {
        private readonly IBannerRepository _bannerRepository;
        private readonly IMapper _mapper;
        private readonly IMessageRepository _messageRepository;

        public UpdateBannerCommandHandler(IMapper mapper, IBannerRepository bannerRepository, IMessageRepository messageRepository)
        {
            _mapper = mapper;
            _bannerRepository = bannerRepository;
            _messageRepository = messageRepository;
        }

        public async Task<Response<UpdateBannerDto>> Handle(UpdateBannerCommand request, CancellationToken cancellationToken)
        {
            var bannerToUpdate = await _bannerRepository.GetByIdAsync(request.BannerId);

            if (bannerToUpdate == null)
            {
                throw new NotFoundException(nameof(Banner), request.BannerId);
            }

            var validator = new UpdateBannerCommandValidator(_messageRepository);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
            {
                throw new ValidationException(validationResult);
            }

            _mapper.Map(request, bannerToUpdate);

            await _bannerRepository.UpdateAsync(bannerToUpdate);

            var dto = _mapper.Map<UpdateBannerDto>(bannerToUpdate);

            return new Response<UpdateBannerDto>(dto, "Updated successfully");
        }
    }
}
