using AutoMapper;
using Exoticamp.Application.Contracts.Persistence;
using Exoticamp.Application.Features.UserQueries.Queries.GetUserQueryList;
using Exoticamp.Application.Responses;
using Exoticamp.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exoticamp.Application.Features.Locations.Queries
{
    public class GetLocationListQueryHandler : IRequestHandler<GetLocationListQuery, Response<IEnumerable<GetLocationListVM>>>
    {
        private readonly IAsyncRepository<Location> _asyncRepository;
        private readonly IMapper _mapper;

        public GetLocationListQueryHandler(IMapper mapper, IAsyncRepository<Location> asyncRepository)
        {
            _mapper = mapper;
            _asyncRepository = asyncRepository;
        }

        public async Task<Response<IEnumerable<GetLocationListVM>>> Handle(GetLocationListQuery request, CancellationToken cancellationToken)
        {
            var allQueries = (await _asyncRepository.ListAllAsync()).OrderBy(x => x.Name);
            var userQueryList = _mapper.Map<List<GetLocationListVM>>(allQueries);
            var response = new Response<IEnumerable<GetLocationListVM>>(userQueryList);
            return response;
        }


    }
}
