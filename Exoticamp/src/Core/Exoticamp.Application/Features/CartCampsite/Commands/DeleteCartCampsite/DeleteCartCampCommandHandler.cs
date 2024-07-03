using AutoMapper;
using Exoticamp.Application.Contracts.Persistence;
using Exoticamp.Application.Exceptions;
using Exoticamp.Application.Features.CartCampsite.Commands.DeleteCartCamp;
using Exoticamp.Application.Responses;
using Exoticamp.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Exoticamp.Application.Features.CartCampsite.Commands.DeleteCartCamp
{
    public class DeleteCartCampCommandHandler : IRequestHandler<DeleteCartCampCommand, Response<bool>>
    {
        private readonly IAsyncRepository<CartCamp> _cartRepository;
        private readonly IMapper _mapper;

        public DeleteCartCampCommandHandler(IMapper mapper, IAsyncRepository<CartCamp> cartRepository)
        {
            _mapper = mapper;
            _cartRepository = cartRepository;
        }

        public async Task<Response<bool>> Handle(DeleteCartCampCommand request, CancellationToken cancellationToken)
        {
            var cartCamp = await _cartRepository.GetByIdAsync(request.CartId);

            if (cartCamp == null)
            {
                throw new NotFoundException(nameof(CartCamp), request.CartId);
            }

            await _cartRepository.DeleteAsync(cartCamp);

            return new Response<bool>(true);
        }
    }
}
