using AutoMapper;
using Exoticamp.Application.Contracts.Persistence;
using Exoticamp.Application.Features.Events.Queries.GetEventsList;
using Exoticamp.Application.Responses;
using Exoticamp.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exoticamp.Application.Features.UserQueries.Queries.GetUserQueryList
{
    public class GetUserQueryListQueryHandler : IRequestHandler<GetUserQueryListQuery, Response<IEnumerable<GetUserQueryListVM>>>
    {
        private readonly IAsyncRepository<UserQuery> _asyncRepository;
        private readonly IMapper _mapper;

        public GetUserQueryListQueryHandler(IMapper mapper, IAsyncRepository<UserQuery> asyncRepository)
        {
            _mapper = mapper;
            _asyncRepository = asyncRepository;
        }

        public async Task<Response<IEnumerable<GetUserQueryListVM>>> Handle(GetUserQueryListQuery request, CancellationToken cancellationToken)
        {
            var allQueries = (await _asyncRepository.ListAllAsync()).Where(x => x.IsDeleted == false).OrderBy(x => x.Id);
            var userQueryList = _mapper.Map<List<GetUserQueryListVM>>(allQueries);
            var response = new Response<IEnumerable<GetUserQueryListVM>>(userQueryList);
            return response;
        }
    }
}
