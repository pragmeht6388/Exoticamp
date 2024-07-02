using AutoMapper;
using Exoticamp.Application.Contracts.Persistence;
using Exoticamp.Application.Responses;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Exoticamp.Application.Features.CartCampsite.Query.GetCartCampList
{
    public class GetCartCampListQueryHandler : IRequestHandler<GetCartCampListQuery, Response<IEnumerable<CartCampVM>>>
    {
        private readonly ICartCampRepository _cartCampRepository;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public GetCartCampListQueryHandler(IMapper mapper, ICartCampRepository cartCampRepository, ILogger<GetCartCampListQueryHandler> logger)
        {
            _mapper = mapper;
            _cartCampRepository = cartCampRepository;
            _logger = logger;
        }

        public async Task<Response<IEnumerable<CartCampVM>>> Handle(GetCartCampListQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Handle Initiated");

            // Retrieve all cart camps
            var allCartCamps = await _cartCampRepository.ListAllAsync();

            // Map the retrieved cart camps to view models
            var cartCampVMs = _mapper.Map<IEnumerable<CartCampVM>>(allCartCamps);

            _logger.LogInformation("Handle Completed");

            return new Response<IEnumerable<CartCampVM>>(cartCampVMs, "success");
        }
    }
}
