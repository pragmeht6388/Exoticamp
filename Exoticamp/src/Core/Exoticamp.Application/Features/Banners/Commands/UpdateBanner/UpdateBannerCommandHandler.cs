using AutoMapper;
using Exoticamp.Application.Contracts.Persistence;
using Exoticamp.Application.Exceptions;
using Exoticamp.Application.Features.Banners.Commands.CreateBanner;
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
            Response<UpdateBannerDto> addBannerCommandResponse = new Response<UpdateBannerDto>();
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
            var existingBanner = await _bannerRepository.GetBannerByLinkAsync(request.Link);
            if (existingBanner != null)
            {
                // If a banner with the same link already exists, set the message accordingly
                addBannerCommandResponse.Message = $"Link Existed '{request.Link}'";
                // Optionally, you may choose to throw an exception here if needed
                // throw new BannerLinkAlreadyExistsException(request.Link);
            }
            else
            {
                // If no banner with the same link exists, set the message to "Successful"
                addBannerCommandResponse.Message = "Successful";
            }

            _mapper.Map(request, bannerToUpdate);

            await _bannerRepository.UpdateAsync(bannerToUpdate);

            var dto = _mapper.Map<UpdateBannerDto>(bannerToUpdate);

            return new Response<UpdateBannerDto>(dto, "Updated successfully");
        }
    }
}
