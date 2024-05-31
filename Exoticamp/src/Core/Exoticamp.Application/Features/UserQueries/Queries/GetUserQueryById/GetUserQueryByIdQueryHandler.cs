using AutoMapper;
using Exoticamp.Application.Contracts.Persistence;
using Exoticamp.Application.Exceptions;
using Exoticamp.Application.Features.UserQueries.Queries.GetUserQueryList;
using Exoticamp.Application.Responses;
using Exoticamp.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Exoticamp.Application.Features.UserQueries.Queries.GetUserQueryById
{
    public class GetUserQueryByIdQueryHandler : IRequestHandler<GetUserQueryByIdQuery, Response<GetUserQueryListVM>>
    {
        private readonly IAsyncRepository<UserQuery> _asyncRepository;
        private readonly IMapper _mapper;

        public GetUserQueryByIdQueryHandler(IMapper mapper, IAsyncRepository<UserQuery> asyncRepository)
        {
            _mapper = mapper;
            _asyncRepository = asyncRepository;
        }


        public async Task<Response<GetUserQueryListVM>> Handle(GetUserQueryByIdQuery request, CancellationToken cancellationToken)
        {
            var userQuery = (await _asyncRepository.GetByIdAsync(new Guid(request.UserQueryId)));
            if (userQuery == null || userQuery.IsDeleted == true)
            {
                throw new NotFoundException(nameof(UserQuery), request.UserQueryId);
            }
            var query = _mapper.Map<GetUserQueryListVM>(userQuery);
            var response = new Response<GetUserQueryListVM>(query);
            return response;
        }
    }
}
