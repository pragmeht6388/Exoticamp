using AutoMapper;
using Exoticamp.Application.Contracts.Persistence;
using Exoticamp.Application.Exceptions;

using Exoticamp.Application.Features.Banners.Commands.CreateBanner;
using Exoticamp.Application.Features.Categories.Commands.CreateCategory;
using Exoticamp.Application.Responses;
using Exoticamp.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Exoticamp.Application.Features.Banners.Commands.CreateBanner
{
    public class CreateBannerCommandHandler : IRequestHandler<CreateBannerCommand, Response<CreateBannerDto>>
    {
        private readonly IMapper _mapper;
        private readonly IBannerRepository _bannerRepository;
        private readonly IMessageRepository _messageRepository;

        public CreateBannerCommandHandler(IMapper mapper, IBannerRepository bannerRepository, IMessageRepository messageRepository)
        {
            _mapper = mapper;
            _bannerRepository = bannerRepository;
            _messageRepository = messageRepository;
        }

        public async Task<Response<CreateBannerDto>> Handle(CreateBannerCommand request, CancellationToken cancellationToken)
        {
            Response<CreateBannerDto> addBannerCommandResponse = new Response<CreateBannerDto>();

            var validator = new CreateBannerCommandValidator(_messageRepository);
            var validationResult = await validator.ValidateAsync(request);
           

            if (validationResult.Errors.Count > 0)
            {
                throw new ValidationException(validationResult);
            }
            var existingBanner = await _bannerRepository.GetBannerByLinkAsync(request.Link);
            if (existingBanner != null)
            {
                addBannerCommandResponse.Message = "Invalid Details";
                //throw new BannerLinkAlreadyExistsException(request.Link);
            }
            else
            {
                var banner = new Banner
                {
                    Link = request.Link,
                    IsActive = request.IsActive,
                    PromoCode = request.PromoCode,
                    LocationId = request.LocationId,
                    ImagePath = request.ImagePath,
                    IsDeleted =request.IsDeleted
                };
                banner = await _bannerRepository.AddAsync(banner);
                addBannerCommandResponse = new Response<CreateBannerDto>(_mapper.Map<CreateBannerDto>(banner), "success");
            }

            return addBannerCommandResponse;
        }
    }
}
