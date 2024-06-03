using AutoMapper;
using Exoticamp.Application.Contracts.Identity;
using Exoticamp.Application.Features.Categories.Queries.GetCategoriesList;
using Exoticamp.Application.Responses;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exoticamp.Application.Features.Users.Queries.GetUser
{
    public class GetUserQueryHandler : IRequestHandler<GetUserQuery, Response<GetUserDto>>
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        private readonly ILogger<GetUserQueryHandler> _logger;
        public GetUserQueryHandler(IMapper mapper, IUserService userService, ILogger<GetUserQueryHandler> logger)
        {
            _mapper = mapper;

            _logger = logger;
            _userService = userService;
        }
        public async Task<Response<GetUserDto>> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            var user = _userService.GetUserDetailsById(request.UserId);
            var result = _mapper.Map<GetUserDto>(user);
            return new Response<GetUserDto>(result, "success");
        }
    }
}
