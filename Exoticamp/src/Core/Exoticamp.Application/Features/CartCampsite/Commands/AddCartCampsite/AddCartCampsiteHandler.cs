using AutoMapper;
using Exoticamp.Application.Contracts;
using Exoticamp.Application.Contracts.Persistence;
using Exoticamp.Application.Exceptions;
using Exoticamp.Application.Features.CartCampsite.Commands.AddCartCampsite;
using Exoticamp.Application.Responses;
using Exoticamp.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Exoticamp.Application.Features.CartCampsite.Commands.AddCartCampsite
{
    public class AddCartCampsiteHandler : IRequestHandler<AddCartCampsite, Response<CartCampDto>>
    {
        private readonly IMapper _mapper;
        private readonly ICartCampRepository _cartCampRepository;
        private readonly IMessageRepository _messageRepository;
        private readonly ILoggedInUserService _loggedInUserService;

        public AddCartCampsiteHandler(IMapper mapper, ICartCampRepository cartCampRepository, IMessageRepository messageRepository,ILoggedInUserService loggedInUserService)
        {
            _mapper = mapper;
            _cartCampRepository = cartCampRepository;
            _messageRepository = messageRepository;
            _loggedInUserService=loggedInUserService;
        }

        public async Task<Response<CartCampDto>> Handle(AddCartCampsite request, CancellationToken cancellationToken)
        {
            Response<CartCampDto> addCartCampsiteCommandResponse = null;

            var validator = new AddCartCampsiteCommandValidator(_messageRepository);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
            {
                throw new ValidationException(validationResult);
            }
            else
            {
                var cartCamp = new CartCamp
                {
                    CartId = Guid.NewGuid(),
                    UserId = Guid.Parse(_loggedInUserService.UserId.ToString()),
                    CustomerName = request.CustomerName,
                    Email = request.Email,
                    CheckIn = request.CheckIn,
                    CheckOut = request.CheckOut,
                    NoOfAdults = request.NoOfAdults,
                    NoOfChildrens = request.NoOfChildren,
                    NoOfTents = request.NoOfTents,
                    TotalPrice = request.TotalPrice,
                    Status = request.Status,
                    CampsiteId = request.CampsiteId,
                    //LocationId = request.LocationId,
                    //GlampingId = request.GlampingId,
                    NoOfGlamps = request.NoOfGlamps,
                    IsActive = request.IsActive,
                    //GuestDetailsId = request.GuestDetailsId
                };

                cartCamp = await _cartCampRepository.Addcart(cartCamp);
                addCartCampsiteCommandResponse = new Response<CartCampDto>(_mapper.Map<CartCampDto>(cartCamp), "success");
            }

            return addCartCampsiteCommandResponse;
        }
    }
}
